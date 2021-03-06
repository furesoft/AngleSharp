﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using AngleSharp;
using AngleSharp.DOM;
using AngleSharp.DOM.Html;

namespace UnitTests
{
    /// <summary>
    /// Tests from https://github.com/html5lib/html5lib-tests (*)
    /// to be more specific: (*)/blob/master/tree-construction/tests_innerHTML_1.dat
    /// and
    /// to be more specific: (*)/blob/master/tree-construction/tests4.dat
    /// </summary>
    [TestClass]
    public class HtmlFragments
    {
        [TestMethod]
        public void FragmentBodyContextDoubleBodyAndSpanElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<body><span>", HTMLElement.Create("body"));

            var docspan0 = doc[0];
            Assert.AreEqual(0, docspan0.ChildNodes.Length);
            Assert.AreEqual(0, docspan0.Attributes.Length);
            Assert.AreEqual("span", docspan0.NodeName);
            Assert.AreEqual(NodeType.Element, docspan0.NodeType);
        }

        [TestMethod]
        public void FragmentBodyContextSpanAndDoubleBodyElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<span><body>", HTMLElement.Create("body"));

            var docspan0 = doc[0];
            Assert.AreEqual(0, docspan0.ChildNodes.Length);
            Assert.AreEqual(0, docspan0.Attributes.Length);
            Assert.AreEqual("span", docspan0.NodeName);
            Assert.AreEqual(NodeType.Element, docspan0.NodeType);
        }

        [TestMethod]
        public void FragmentDivContextSpanAndDoubleBodyElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<span><body>", HTMLElement.Create("div"));

            var docspan0 = doc[0];
            Assert.AreEqual(0, docspan0.ChildNodes.Length);
            Assert.AreEqual(0, docspan0.Attributes.Length);
            Assert.AreEqual("span", docspan0.NodeName);
            Assert.AreEqual(NodeType.Element, docspan0.NodeType);
        }

        [TestMethod]
        public void FragmentHtmlContextBodyAndSpanElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<body><span>", HTMLElement.Create("html"));

            var dochead0 = doc[0];
            Assert.AreEqual(0, dochead0.ChildNodes.Length);
            Assert.AreEqual(0, dochead0.Attributes.Length);
            Assert.AreEqual("head", dochead0.NodeName);
            Assert.AreEqual(NodeType.Element, dochead0.NodeType);

            var docbody1 = doc[1];
            Assert.AreEqual(1, docbody1.ChildNodes.Length);
            Assert.AreEqual(0, docbody1.Attributes.Length);
            Assert.AreEqual("body", docbody1.NodeName);
            Assert.AreEqual(NodeType.Element, docbody1.NodeType);

            var docbody1span0 = docbody1.ChildNodes[0];
            Assert.AreEqual(0, docbody1span0.ChildNodes.Length);
            Assert.AreEqual(0, docbody1span0.Attributes.Length);
            Assert.AreEqual("span", docbody1span0.NodeName);
            Assert.AreEqual(NodeType.Element, docbody1span0.NodeType);
        }

        [TestMethod]
        public void FragmentBodyContextFramesetAndSpanElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<frameset><span>", HTMLElement.Create("body"));

            var docspan0 = doc[0];
            Assert.AreEqual(0, docspan0.ChildNodes.Length);
            Assert.AreEqual(0, docspan0.Attributes.Length);
            Assert.AreEqual("span", docspan0.NodeName);
            Assert.AreEqual(NodeType.Element, docspan0.NodeType);

        }

        [TestMethod]
        public void FragmentBodyContextSpanAndFramesetElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<span><frameset>", HTMLElement.Create("body"));

            var docspan0 = doc[0];
            Assert.AreEqual(0, docspan0.ChildNodes.Length);
            Assert.AreEqual(0, docspan0.Attributes.Length);
            Assert.AreEqual("span", docspan0.NodeName);
            Assert.AreEqual(NodeType.Element, docspan0.NodeType);
        }

        [TestMethod]
        public void FragmentDivContextSpanAndFramesetElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<span><frameset>", HTMLElement.Create("div"));

            var docspan0 = doc[0];
            Assert.AreEqual(0, docspan0.ChildNodes.Length);
            Assert.AreEqual(0, docspan0.Attributes.Length);
            Assert.AreEqual("span", docspan0.NodeName);
            Assert.AreEqual(NodeType.Element, docspan0.NodeType);
        }

        [TestMethod]
        public void FragmentHtmlContextEmpty()
        {
            var doc = DocumentBuilder.HtmlFragment(@"", HTMLElement.Create("html"));
            var dochead0 = doc[0];
            Assert.AreEqual(0, dochead0.ChildNodes.Length);
            Assert.AreEqual(0, dochead0.Attributes.Length);
            Assert.AreEqual("head", dochead0.NodeName);
            Assert.AreEqual(NodeType.Element, dochead0.NodeType);

            var docbody1 = doc[1];
            Assert.AreEqual(0, docbody1.ChildNodes.Length);
            Assert.AreEqual(0, docbody1.Attributes.Length);
            Assert.AreEqual("body", docbody1.NodeName);
            Assert.AreEqual(NodeType.Element, docbody1.NodeType);
        }

        [TestMethod]
        public void FragmentHtmlContextFramesetAndSpanElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<frameset><span>", HTMLElement.Create("html"));

            var dochead0 = doc[0];
            Assert.AreEqual(0, dochead0.ChildNodes.Length);
            Assert.AreEqual(0, dochead0.Attributes.Length);
            Assert.AreEqual("head", dochead0.NodeName);
            Assert.AreEqual(NodeType.Element, dochead0.NodeType);

            var docframeset1 = doc[1];
            Assert.AreEqual(0, docframeset1.ChildNodes.Length);
            Assert.AreEqual(0, docframeset1.Attributes.Length);
            Assert.AreEqual("frameset", docframeset1.NodeName);
            Assert.AreEqual(NodeType.Element, docframeset1.NodeType);
        }

        [TestMethod]
        public void FragmentTableContextOpeningTableAndTrElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<table><tr>", HTMLElement.Create("table"));

            var doctbody0 = doc[0];
            Assert.AreEqual(1, doctbody0.ChildNodes.Length);
            Assert.AreEqual(0, doctbody0.Attributes.Length);
            Assert.AreEqual("tbody", doctbody0.NodeName);
            Assert.AreEqual(NodeType.Element, doctbody0.NodeType);

            var doctbody0tr0 = doctbody0.ChildNodes[0];
            Assert.AreEqual(0, doctbody0tr0.ChildNodes.Length);
            Assert.AreEqual(0, doctbody0tr0.Attributes.Length);
            Assert.AreEqual("tr", doctbody0tr0.NodeName);
            Assert.AreEqual(NodeType.Element, doctbody0tr0.NodeType);
        }

        [TestMethod]
        public void FragmentTableContextClosingTableAndTrElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"</table><tr>", HTMLElement.Create("table"));

            var doctbody0 = doc[0];
            Assert.AreEqual(1, doctbody0.ChildNodes.Length);
            Assert.AreEqual(0, doctbody0.Attributes.Length);
            Assert.AreEqual("tbody", doctbody0.NodeName);
            Assert.AreEqual(NodeType.Element, doctbody0.NodeType);

            var doctbody0tr0 = doctbody0.ChildNodes[0];
            Assert.AreEqual(0, doctbody0tr0.ChildNodes.Length);
            Assert.AreEqual(0, doctbody0tr0.Attributes.Length);
            Assert.AreEqual("tr", doctbody0tr0.NodeName);
            Assert.AreEqual(NodeType.Element, doctbody0tr0.NodeType);
        }

        [TestMethod]
        public void FragmentFramesetContextClosingFramesetAndFrameElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"</frameset><frame>", HTMLElement.Create("frameset"));

            var docframe0 = doc[0];
            Assert.AreEqual(0, docframe0.ChildNodes.Length);
            Assert.AreEqual(0, docframe0.Attributes.Length);
            Assert.AreEqual("frame", docframe0.NodeName);
            Assert.AreEqual(NodeType.Element, docframe0.NodeType);
        }

        [TestMethod]
        public void FragmentSelectContextClosingSelectAndOptionElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"</select><option>", AngleSharp.DOM.Html.HTMLElement.Create("select"));
            var docoption0 = doc[0];
            Assert.AreEqual(0, docoption0.ChildNodes.Length);
            Assert.AreEqual(0, docoption0.Attributes.Length);
            Assert.AreEqual("option", docoption0.NodeName);
            Assert.AreEqual(NodeType.Element, docoption0.NodeType);
        }

        [TestMethod]
        public void FragmentSelectContextInputAndOptionElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<input><option>", AngleSharp.DOM.Html.HTMLElement.Create("select"));

            var docoption0 = doc[0];
            Assert.AreEqual(0, docoption0.ChildNodes.Length);
            Assert.AreEqual(0, docoption0.Attributes.Length);
            Assert.AreEqual("option", docoption0.NodeName);
            Assert.AreEqual(NodeType.Element, docoption0.NodeType);
        }

        [TestMethod]
        public void FragmentTdContextTableAndDoubleTdElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<table><td><td>", AngleSharp.DOM.Html.HTMLElement.Create("td"));

            var doctable0 = doc[0];
            Assert.AreEqual(1, doctable0.ChildNodes.Length);
            Assert.AreEqual(0, doctable0.Attributes.Length);
            Assert.AreEqual("table", doctable0.NodeName);
            Assert.AreEqual(NodeType.Element, doctable0.NodeType);

            var doctable0tbody0 = doctable0.ChildNodes[0];
            Assert.AreEqual(1, doctable0tbody0.ChildNodes.Length);
            Assert.AreEqual(0, doctable0tbody0.Attributes.Length);
            Assert.AreEqual("tbody", doctable0tbody0.NodeName);
            Assert.AreEqual(NodeType.Element, doctable0tbody0.NodeType);

            var doctable0tbody0tr0 = doctable0tbody0.ChildNodes[0];
            Assert.AreEqual(2, doctable0tbody0tr0.ChildNodes.Length);
            Assert.AreEqual(0, doctable0tbody0tr0.Attributes.Length);
            Assert.AreEqual("tr", doctable0tbody0tr0.NodeName);
            Assert.AreEqual(NodeType.Element, doctable0tbody0tr0.NodeType);

            var doctable0tbody0tr0td0 = doctable0tbody0tr0.ChildNodes[0];
            Assert.AreEqual(0, doctable0tbody0tr0td0.ChildNodes.Length);
            Assert.AreEqual(0, doctable0tbody0tr0td0.Attributes.Length);
            Assert.AreEqual("td", doctable0tbody0tr0td0.NodeName);
            Assert.AreEqual(NodeType.Element, doctable0tbody0tr0td0.NodeType);

            var doctable0tbody0tr0td1 = doctable0tbody0tr0.ChildNodes[1];
            Assert.AreEqual(0, doctable0tbody0tr0td1.ChildNodes.Length);
            Assert.AreEqual(0, doctable0tbody0tr0td1.Attributes.Length);
            Assert.AreEqual("td", doctable0tbody0tr0td1.NodeName);
            Assert.AreEqual(NodeType.Element, doctable0tbody0tr0td1.NodeType);

        }

        [TestMethod]
        public void FragmentTdContextTfootAndAnchorElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<tfoot><a>", AngleSharp.DOM.Html.HTMLElement.Create("td"));

            var doca0 = doc[0];
            Assert.AreEqual(0, doca0.ChildNodes.Length);
            Assert.AreEqual(0, doca0.Attributes.Length);
            Assert.AreEqual("a", doca0.NodeName);
            Assert.AreEqual(NodeType.Element, doca0.NodeType);
        }

        [TestMethod]
        public void FragmentTrContextTdAndFinishedTableAndTdElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<td><table></table><td>", AngleSharp.DOM.Html.HTMLElement.Create("tr"));

            var doctd0 = doc[0];
            Assert.AreEqual(1, doctd0.ChildNodes.Length);
            Assert.AreEqual(0, doctd0.Attributes.Length);
            Assert.AreEqual("td", doctd0.NodeName);
            Assert.AreEqual(NodeType.Element, doctd0.NodeType);

            var doctd0table0 = doctd0.ChildNodes[0];
            Assert.AreEqual(0, doctd0table0.ChildNodes.Length);
            Assert.AreEqual(0, doctd0table0.Attributes.Length);
            Assert.AreEqual("table", doctd0table0.NodeName);
            Assert.AreEqual(NodeType.Element, doctd0table0.NodeType);


            var doctd1 = doc[1];
            Assert.AreEqual(0, doctd1.ChildNodes.Length);
            Assert.AreEqual(0, doctd1.Attributes.Length);
            Assert.AreEqual("td", doctd1.NodeName);
            Assert.AreEqual(NodeType.Element, doctd1.NodeType);
        }

        [TestMethod]
        public void FragmentTbodyContextTdAndTableAndTbodyAndMisplacedAnchorAndTrElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<td><table><tbody><a><tr>", AngleSharp.DOM.Html.HTMLElement.Create("tbody"));

            var doctr0 = doc[0];
            Assert.AreEqual(1, doctr0.ChildNodes.Length);
            Assert.AreEqual(0, doctr0.Attributes.Length);
            Assert.AreEqual("tr", doctr0.NodeName);
            Assert.AreEqual(NodeType.Element, doctr0.NodeType);

            var doctr0td0 = doctr0.ChildNodes[0];
            Assert.AreEqual(2, doctr0td0.ChildNodes.Length);
            Assert.AreEqual(0, doctr0td0.Attributes.Length);
            Assert.AreEqual("td", doctr0td0.NodeName);
            Assert.AreEqual(NodeType.Element, doctr0td0.NodeType);

            var doctr0td0a0 = doctr0td0.ChildNodes[0];
            Assert.AreEqual(0, doctr0td0a0.ChildNodes.Length);
            Assert.AreEqual(0, doctr0td0a0.Attributes.Length);
            Assert.AreEqual("a", doctr0td0a0.NodeName);
            Assert.AreEqual(NodeType.Element, doctr0td0a0.NodeType);

            var doctr0td0table1 = doctr0td0.ChildNodes[1];
            Assert.AreEqual(1, doctr0td0table1.ChildNodes.Length);
            Assert.AreEqual(0, doctr0td0table1.Attributes.Length);
            Assert.AreEqual("table", doctr0td0table1.NodeName);
            Assert.AreEqual(NodeType.Element, doctr0td0table1.NodeType);

            var doctr0td0table1tbody0 = doctr0td0table1.ChildNodes[0];
            Assert.AreEqual(1, doctr0td0table1tbody0.ChildNodes.Length);
            Assert.AreEqual(0, doctr0td0table1tbody0.Attributes.Length);
            Assert.AreEqual("tbody", doctr0td0table1tbody0.NodeName);
            Assert.AreEqual(NodeType.Element, doctr0td0table1tbody0.NodeType);

            var doctr0td0table1tbody0tr0 = doctr0td0table1tbody0.ChildNodes[0];
            Assert.AreEqual(0, doctr0td0table1tbody0tr0.ChildNodes.Length);
            Assert.AreEqual(0, doctr0td0table1tbody0tr0.Attributes.Length);
            Assert.AreEqual("tr", doctr0td0table1tbody0tr0.NodeName);
            Assert.AreEqual(NodeType.Element, doctr0td0table1tbody0tr0.NodeType);

        }

        [TestMethod]
        public void FragmentTbodyContextMisplacedTheadAndAnchorElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<thead><a>",HTMLElement.Create("tbody"));

            var doca0 = doc[0];
            Assert.AreEqual(0, doca0.ChildNodes.Length);
            Assert.AreEqual(0, doca0.Attributes.Length);
            Assert.AreEqual("a", doca0.NodeName);
            Assert.AreEqual(NodeType.Element, doca0.NodeType);
        }

        [TestMethod]
        public void FragmentColgroupContextClosingColgroupAndColElement()
        {
            var doc = DocumentBuilder.HtmlFragment(@"</colgroup><col>", HTMLElement.Create("colgroup"));

            var doccol0 = doc[0];
            Assert.AreEqual(0, doccol0.ChildNodes.Length);
            Assert.AreEqual(0, doccol0.Attributes.Length);
            Assert.AreEqual("col", doccol0.NodeName);
            Assert.AreEqual(NodeType.Element, doccol0.NodeType);
        }

        [TestMethod]
        public void FragmentDivContextWithText()
        {
            var doc = DocumentBuilder.HtmlFragment(@"direct div content", HTMLElement.Create("div"));

            var docText0 = doc[0];
            Assert.AreEqual(NodeType.Text, docText0.NodeType);
            Assert.AreEqual("direct div content", docText0.TextContent);
        }

        [TestMethod]
        public void FragmentTextareaContextWithText()
        {
            var doc = DocumentBuilder.HtmlFragment(@"direct textarea content", HTMLElement.Create("textarea"));
            var docText0 = doc[0];
            Assert.AreEqual(NodeType.Text, docText0.NodeType);
            Assert.AreEqual("direct textarea content", docText0.TextContent);
        }

        [TestMethod]
        public void FragmentTextAreaContextWithTextAndMarkup()
        {
            var doc = DocumentBuilder.HtmlFragment(@"textarea content with <em>pseudo</em> <foo>markup", HTMLElement.Create("textarea"));
            var docText0 = doc[0];
            Assert.AreEqual(NodeType.Text, docText0.NodeType);
            Assert.AreEqual("textarea content with <em>pseudo</em> <foo>markup", docText0.TextContent);
        }

        [TestMethod]
        public void FragmentStyleContextWithText()
        {
            var doc = DocumentBuilder.HtmlFragment(@"this is &#x0043;DATA inside a <style> element", HTMLElement.Create("style"));

            var docText0 = doc[0];
            Assert.AreEqual(NodeType.Text, docText0.NodeType);
            Assert.AreEqual("this is &#x0043;DATA inside a <style> element", docText0.TextContent);
        }

        [TestMethod]
        public void FragmentPlaintextContext()
        {
            var doc = DocumentBuilder.HtmlFragment(@"</plaintext>", HTMLElement.Create("plaintext"));

            var docText0 = doc[0];
            Assert.AreEqual(NodeType.Text, docText0.NodeType);
            Assert.AreEqual("</plaintext>", docText0.TextContent);
        }

        [TestMethod]
        public void FragmentHtmlContextWithText()
        {
            var doc = DocumentBuilder.HtmlFragment(@"setting html's innerHTML", HTMLElement.Create("html"));

            var dochead0 = doc[0];
            Assert.AreEqual(0, dochead0.ChildNodes.Length);
            Assert.AreEqual(0, dochead0.Attributes.Length);
            Assert.AreEqual("head", dochead0.NodeName);
            Assert.AreEqual(NodeType.Element, dochead0.NodeType);

            var docbody1 = doc[1];
            Assert.AreEqual(1, docbody1.ChildNodes.Length);
            Assert.AreEqual(0, docbody1.Attributes.Length);
            Assert.AreEqual("body", docbody1.NodeName);
            Assert.AreEqual(NodeType.Element, docbody1.NodeType);

            var docbody1Text0 = docbody1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, docbody1Text0.NodeType);
            Assert.AreEqual("setting html's innerHTML", docbody1Text0.TextContent);
        }

        [TestMethod]
        public void FragmentHeadContextWithTextInTitle()
        {
            var doc = DocumentBuilder.HtmlFragment(@"<title>setting head's innerHTML</title>", HTMLElement.Create("head"));

            var doctitle0 = doc[0];
            Assert.AreEqual(1, doctitle0.ChildNodes.Length);
            Assert.AreEqual(0, doctitle0.Attributes.Length);
            Assert.AreEqual("title", doctitle0.NodeName);
            Assert.AreEqual(NodeType.Element, doctitle0.NodeType);

            var doctitle0Text0 = doctitle0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, doctitle0Text0.NodeType);
            Assert.AreEqual("setting head's innerHTML", doctitle0Text0.TextContent);
        }
    }
}
