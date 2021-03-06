﻿using AngleSharp.Css;
using AngleSharp.DOM;
using AngleSharp.DOM.Collections;
using AngleSharp.DOM.Css;
using AngleSharp.DOM.Html;
using AngleSharp.Events;
using AngleSharp.Html;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace AngleSharp
{
    /// <summary>
    /// A handy helper to construct various kinds of documents
    /// from a given source code, URL or stream.
    /// </summary>
    public sealed class DocumentBuilder
    {
        #region Members

        IParser parser;

        #endregion

        #region ctor

        /// <summary>
        /// Creates a new builder with the specified source.
        /// </summary>
        /// <param name="source">The code manager.</param>
        /// <param name="document">The document to fill.</param>
        /// <param name="options">Options to use for the document generation.</param>
        DocumentBuilder(SourceManager source, HTMLDocument document, DocumentOptions options)
        {
            document.Options = options;
            parser = new HtmlParser(document, source);
			parser.ErrorOccurred += ParseErrorOccurred;

			if (options.OnError != null)
				parser.ErrorOccurred += options.OnError;
        }

        /// <summary>
        /// Creates a new builder with the specified source.
        /// </summary>
        /// <param name="source">The code manager.</param>
        /// <param name="sheet">The document to fill.</param>
        /// <param name="options">Options to use for the document generation.</param>
        DocumentBuilder(SourceManager source, CSSStyleSheet sheet, DocumentOptions options)
        {
            sheet.Options = options;
            parser = new CssParser(sheet, source);
			parser.ErrorOccurred += ParseErrorOccurred;

			if (options.OnError != null)
				parser.ErrorOccurred += options.OnError;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the result of an HTML parsing.
        /// </summary>
        public HTMLDocument HtmlResult
        {
            get { return ((HtmlParser)parser).Result; }
        }

        /// <summary>
        /// Gets the result of a CSS parsing.
        /// </summary>
        public CSSStyleSheet CssResult
        {
            get { return ((CssParser)parser).Result; }
        }

        #endregion

        #region HTML Construction

        /// <summary>
        /// Builds a new HTMLDocument with the given source code string.
        /// </summary>
        /// <param name="sourceCode">The string to use as source code.</param>
        /// <param name="options">[Optional] Options to use for the document generation.</param>
        /// <returns>The constructed HTML document.</returns>
        public static HTMLDocument Html(String sourceCode, DocumentOptions options = null)
        {
            var source = new SourceManager(sourceCode);
            var db = new DocumentBuilder(source, new HTMLDocument(), options ?? DocumentOptions.Default);
            return db.HtmlResult;
        }

        /// <summary>
        /// Builds a new HTMLDocument with the given URL.
        /// </summary>
        /// <param name="url">The URL which points to the address containing the source code.</param>
        /// <param name="options">[Optional] Options to use for the document generation.</param>
        /// <returns>The constructed HTML document.</returns>
        public static HTMLDocument Html(Uri url, DocumentOptions options = null)
        {
            return HtmlAsync(url, options).Result;
        }

        /// <summary>
        /// Builds a new HTMLDocument by asynchronously requesting the given URL.
        /// </summary>
        /// <param name="url">The URL which points to the address containing the source code.</param>
        /// <param name="options">[Optional] Options to use for the document generation.</param>
        /// <returns>The task that constructs the HTML document.</returns>
        public static async Task<HTMLDocument> HtmlAsync(Uri url, DocumentOptions options = null)
        {
            var stream = await Builder.GetFromUrl(url);
            var source = new SourceManager(stream);
			var db = new DocumentBuilder(source, new HTMLDocument { DocumentURI = url.OriginalString }, options ?? DocumentOptions.Default);
			await db.parser.ParseAsync();
            return db.HtmlResult;
        }

        /// <summary>
        /// Builds a new HTMLDocument with the given (network) stream.
        /// </summary>
        /// <param name="stream">The stream of chars to use as source code.</param>
        /// <param name="options">[Optional] Options to use for the document generation.</param>
        /// <returns>The constructed HTML document.</returns>
        public static HTMLDocument Html(Stream stream, DocumentOptions options = null)
        {
            var source = new SourceManager(stream);
			var db = new DocumentBuilder(source, new HTMLDocument(), options ?? DocumentOptions.Default);
            return db.HtmlResult;
        }

        /// <summary>
        /// Builds a list of nodes according with 8.4 Parsing HTML fragments.
        /// </summary>
        /// <param name="sourceCode">The string to use as source code.</param>
        /// <param name="context">[Optional] The context node to use.</param>
        /// <param name="options">[Optional] Options to use for the document generation.</param>
        /// <returns>A list of parsed nodes.</returns>
        public static NodeList HtmlFragment(String sourceCode, Node context = null, DocumentOptions options = null)
        {
            var source = new SourceManager(sourceCode);
            var doc = new HTMLDocument();

            //Disable scripting for HTML fragments (security reasons)
            options = options ?? new DocumentOptions(scripting: false);

            var db = new DocumentBuilder(source, doc, options);

            if (context != null)
            {
                if (context.OwnerDocument != null && context.OwnerDocument.QuirksMode != QuirksMode.Off)
                    doc.QuirksMode = context.OwnerDocument.QuirksMode;

                var parser = (HtmlParser)db.parser;
                parser.SwitchToFragment(context);
                return parser.Result.DocumentElement.ChildNodes;
            }

            return db.HtmlResult.ChildNodes;
        }

        #endregion

        #region CSS Construction

        /// <summary>
        /// Builds a new CSSStyleSheet with the given source code string.
        /// </summary>
        /// <param name="sourceCode">The string to use as source code.</param>
        /// <param name="options">[Optional] Options to use for the document generation.</param>
        /// <returns>The constructed CSS stylesheet.</returns>
        public static CSSStyleSheet Css(String sourceCode, DocumentOptions options = null)
        {
            var source = new SourceManager(sourceCode);
			var db = new DocumentBuilder(source, new CSSStyleSheet(), options ?? DocumentOptions.Default);
            return db.CssResult;
        }

        /// <summary>
        /// Builds a new CSSStyleSheet with the given URL.
        /// </summary>
        /// <param name="url">The URL which points to the address containing the source code.</param>
        /// <param name="options">[Optional] Options to use for the document generation.</param>
        /// <returns>The constructed CSS stylesheet.</returns>
        public static CSSStyleSheet Css(Uri url, DocumentOptions options = null)
        {
            return CssAsync(url, options).Result;
        }

        /// <summary>
        /// Builds a new CSSStyleSheet asynchronously by requesting the given URL.
        /// </summary>
        /// <param name="url">The URL which points to the address containing the source code.</param>
        /// <param name="options">[Optional] Options to use for the document generation.</param>
        /// <returns>The task which constructs the CSS stylesheet.</returns>
        public static async Task<CSSStyleSheet> CssAsync(Uri url, DocumentOptions options = null)
        {
            var stream = await Builder.GetFromUrl(url);
            var source = new SourceManager(stream);
			var db = new DocumentBuilder(source, new CSSStyleSheet { Href = url.OriginalString }, options ?? DocumentOptions.Default);
			await db.parser.ParseAsync();
            return db.CssResult;
        }

        /// <summary>
        /// Builds a new CSSStyleSheet with the given network stream.
        /// </summary>
        /// <param name="stream">The stream of chars to use as source code.</param>
        /// <param name="options">[Optional] Options to use for the document generation.</param>
        /// <returns>The constructed CSS stylesheet.</returns>
        public static CSSStyleSheet Css(Stream stream, DocumentOptions options = null)
        {
            var source = new SourceManager(stream);
			var db = new DocumentBuilder(source, new CSSStyleSheet(), options ?? DocumentOptions.Default);
            return db.CssResult;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Called once a helper class finds a parse error.
        /// </summary>
        /// <param name="sender">The helper that encountered the error.</param>
        /// <param name="e">The arguments passed from the helper instance.</param>
        void ParseErrorOccurred(object sender, ParseErrorEventArgs e)
        {
            Debug.WriteLine(e);
        }

        #endregion
    }
}
