﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using AngleSharp;
using AngleSharp.DOM;

namespace UnitTests
{
    /// <summary>
    /// Tests from https://github.com/html5lib/html5lib-tests (*)
    /// to be more specific: (*)/blob/master/tree-construction/comments01.dat
    /// </summary>
    [TestClass]
    public class HtmlComments
    {
        [TestMethod]
        public void ValidCommentInText()
        {
            var doc = DocumentBuilder.Html(@"FOO<!-- BAR -->BAZ");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Length);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(3, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Length);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO", dochtml0body1Text0.TextContent);

            var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment1.NodeType);
            Assert.AreEqual(@" BAR ", dochtml0body1Comment1.TextContent);

            var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text2.NodeType);
            Assert.AreEqual("BAZ", dochtml0body1Text2.TextContent);
        }

        [TestMethod]
        public void ToleratedComment()
        {
            var doc = DocumentBuilder.Html(@"FOO<!-- BAR --!>BAZ");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Length);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(3, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Length);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO", dochtml0body1Text0.TextContent);

            var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment1.NodeType);
            Assert.AreEqual(@" BAR ", dochtml0body1Comment1.TextContent);

            var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text2.NodeType);
            Assert.AreEqual("BAZ", dochtml0body1Text2.TextContent);
        }

        [TestMethod]
        public void InvalidComment()
        {
            var doc = DocumentBuilder.Html(@"FOO<!-- BAR --   >BAZ");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Length);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(2, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Length);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO", dochtml0body1Text0.TextContent);

            var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment1.NodeType);
            Assert.AreEqual(@" BAR --   >BAZ", dochtml0body1Comment1.TextContent);
        }

        [TestMethod]
        public void ValidCommentWithTagInside()
        {
            var doc = DocumentBuilder.Html(@"FOO<!-- BAR -- <QUX> -- MUX -->BAZ");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Length);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(3, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Length);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO", dochtml0body1Text0.TextContent);

            var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment1.NodeType);
            Assert.AreEqual(@" BAR -- <QUX> -- MUX ", dochtml0body1Comment1.TextContent);

            var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text2.NodeType);
            Assert.AreEqual("BAZ", dochtml0body1Text2.TextContent);

        }

        [TestMethod]
        public void ToleratedCommentWithTagInside()
        {
            var doc = DocumentBuilder.Html(@"FOO<!-- BAR -- <QUX> -- MUX --!>BAZ");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Length);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(3, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Length);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO", dochtml0body1Text0.TextContent);

            var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment1.NodeType);
            Assert.AreEqual(@" BAR -- <QUX> -- MUX ", dochtml0body1Comment1.TextContent);

            var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text2.NodeType);
            Assert.AreEqual("BAZ", dochtml0body1Text2.TextContent);
        }

        [TestMethod]
        public void InvalidCommentWithTagInside()
        {
            var doc = DocumentBuilder.Html(@"FOO<!-- BAR -- <QUX> -- MUX -- >BAZ");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Length);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(2, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Length);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO", dochtml0body1Text0.TextContent);

            var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment1.NodeType);
            Assert.AreEqual(@" BAR -- <QUX> -- MUX -- >BAZ", dochtml0body1Comment1.TextContent);
        }

        [TestMethod]
        public void ToleratedInvalidEmptyComment4Dashes()
        {
            var doc = DocumentBuilder.Html(@"FOO<!---->BAZ");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Length);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(3, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Length);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO", dochtml0body1Text0.TextContent);

            var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment1.NodeType);
            Assert.AreEqual(@"", dochtml0body1Comment1.TextContent);

            var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text2.NodeType);
            Assert.AreEqual("BAZ", dochtml0body1Text2.TextContent);
        }

        [TestMethod]
        public void ToleratedInvalidEmptyComment3Dashes()
        {
            var doc = DocumentBuilder.Html(@"FOO<!--->BAZ");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Length);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(3, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Length);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO", dochtml0body1Text0.TextContent);

            var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment1.NodeType);
            Assert.AreEqual(@"", dochtml0body1Comment1.TextContent);

            var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text2.NodeType);
            Assert.AreEqual("BAZ", dochtml0body1Text2.TextContent);

        }

        [TestMethod]
        public void ToleratedInvalidEmptyComment2Dashes()
        {
            var doc = DocumentBuilder.Html(@"FOO<!-->BAZ");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Length);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(3, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Length);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO", dochtml0body1Text0.TextContent);

            var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment1.NodeType);
            Assert.AreEqual(@"", dochtml0body1Comment1.TextContent);

            var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text2.NodeType);
            Assert.AreEqual("BAZ", dochtml0body1Text2.TextContent);


        }

        [TestMethod]
        public void XmlPreambleAsBogusCommentFollowedByText()
        {
            var doc = DocumentBuilder.Html(@"<?xml version=""1.0"">Hi");

            var docComment0 = doc.ChildNodes[0];
            Assert.AreEqual(NodeType.Comment, docComment0.NodeType);
            Assert.AreEqual(@"?xml version=""1.0""", docComment0.TextContent);

            var dochtml1 = doc.ChildNodes[1];
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Length);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0];
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Length);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1];
            Assert.AreEqual(1, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Length);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

            var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml1body1Text0.NodeType);
            Assert.AreEqual("Hi", dochtml1body1Text0.TextContent);
        }

        [TestMethod]
        public void XmlPreambleAsBogusCommentStandalone()
        {
            var doc = DocumentBuilder.Html(@"<?xml version=""1.0"">");

            var docComment0 = doc.ChildNodes[0];
            Assert.AreEqual(NodeType.Comment, docComment0.NodeType);
            Assert.AreEqual(@"?xml version=""1.0""", docComment0.TextContent);

            var dochtml1 = doc.ChildNodes[1];
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Length);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0];
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Length);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1];
            Assert.AreEqual(0, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Length);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);

        }

        [TestMethod]
        public void XmlPreambleFragmentWithEOF()
        {
            var doc = DocumentBuilder.Html(@"<?xml version");

            var docComment0 = doc.ChildNodes[0];
            Assert.AreEqual(NodeType.Comment, docComment0.NodeType);
            Assert.AreEqual(@"?xml version", docComment0.TextContent);

            var dochtml1 = doc.ChildNodes[1];
            Assert.AreEqual(2, dochtml1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1.Attributes.Length);
            Assert.AreEqual("html", dochtml1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1.NodeType);

            var dochtml1head0 = dochtml1.ChildNodes[0];
            Assert.AreEqual(0, dochtml1head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1head0.Attributes.Length);
            Assert.AreEqual("head", dochtml1head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1head0.NodeType);

            var dochtml1body1 = dochtml1.ChildNodes[1];
            Assert.AreEqual(0, dochtml1body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml1body1.Attributes.Length);
            Assert.AreEqual("body", dochtml1body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml1body1.NodeType);
        }

        [TestMethod]
        public void ToleratedInvalidEmptyComment5Dashes()
        {
            var doc = DocumentBuilder.Html(@"FOO<!----->BAZ");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head0.Attributes.Length);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(3, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body1.Attributes.Length);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text0.NodeType);
            Assert.AreEqual("FOO", dochtml0body1Text0.TextContent);

            var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
            Assert.AreEqual(NodeType.Comment, dochtml0body1Comment1.NodeType);
            Assert.AreEqual(@"-", dochtml0body1Comment1.TextContent);

            var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
            Assert.AreEqual(NodeType.Text, dochtml0body1Text2.NodeType);
            Assert.AreEqual("BAZ", dochtml0body1Text2.TextContent);

        }

        [TestMethod]
        public void ValidCommentInRoot()
        {
            var doc = DocumentBuilder.Html(@"<html><!-- comment --><title>Comment before head</title>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(3, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0.Attributes.Length);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0Comment0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(NodeType.Comment, dochtml0Comment0.NodeType);
            Assert.AreEqual(@" comment ", dochtml0Comment0.TextContent);

            var dochtml0head1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0head1.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head1.Attributes.Length);
            Assert.AreEqual("head", dochtml0head1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head1.NodeType);

            var dochtml0head1title0 = dochtml0head1.ChildNodes[0];
            Assert.AreEqual(1, dochtml0head1title0.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0head1title0.Attributes.Length);
            Assert.AreEqual("title", dochtml0head1title0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head1title0.NodeType);

            var dochtml0head1title0Text0 = dochtml0head1title0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0head1title0Text0.NodeType);
            Assert.AreEqual("Comment before head", dochtml0head1title0Text0.TextContent);

            var dochtml0body2 = dochtml0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body2.ChildNodes.Length);
            Assert.AreEqual(0, dochtml0body2.Attributes.Length);
            Assert.AreEqual("body", dochtml0body2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body2.NodeType);

        }
    }
}
