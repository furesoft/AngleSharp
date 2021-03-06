﻿using AngleSharp.DOM;
using AngleSharp.DOM.Collections;
using AngleSharp.DOM.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class DOM
    {
        [TestMethod]
        public void DOMTokenListWritesBack()
        {
            var testClass = "myclass";
            var div = new HTMLDivElement();
            div.ClassName = "";
            div.ClassList.Add(testClass);
            Assert.AreEqual(testClass, div.ClassName);
        }

        [TestMethod]
        public void DOMTokenListCorrectlyInitializedFindsClass()
        {
            var testClass = "myclass";
            var div = new HTMLDivElement();
            div.ClassName = testClass + " whatever anotherclass";
            Assert.IsTrue(div.ClassList.Contains(testClass));
        }

        [TestMethod]
        public void DOMTokenListCorrectlyInitializedNoClass()
        {
            var testClass = "myclass1";
            var div = new HTMLDivElement();
            div.ClassName = "myclass2 whatever anotherclass";
            Assert.IsFalse(div.ClassList.Contains(testClass));
        }

        [TestMethod]
        public void DOMTokenListToggleWorksTurnOff()
        {
            var testClass = "myclass";
            var otherClasses = "otherClass someOther more";
            var div = new HTMLDivElement();
            div.ClassName = testClass + " " + otherClasses;
            div.ClassList.Toggle(testClass);
            Assert.AreEqual(div.ClassName, otherClasses);
        }

        [TestMethod]
        public void DOMTokenListToggleWorksTurnOn()
        {
            var testClass = "myclass";
            var otherClasses = "otherClass someOther more";
            var div = new HTMLDivElement();
            div.ClassName = otherClasses;
            div.ClassList.Toggle(testClass);
            Assert.AreEqual(div.ClassName, otherClasses + " " + testClass);
        }

        [TestMethod]
        public void DOMStringMapBindingGet()
        {
            var value = "SomeUser";
            var div = new HTMLDivElement();
            div.SetAttribute("data-user", value);
            Assert.AreEqual(div.Dataset["user"], value);
        }

        [TestMethod]
        public void DOMStringMapBindingSet()
        {
            var value = "SomeUser";
            var div = new HTMLDivElement();
            div.Dataset["user"] = value;
            Assert.AreEqual(div.GetAttribute("data-user"), value);
        }

        [TestMethod]
        public void DOMStringMapHasNoAttribute()
        {
            var div = new HTMLDivElement();
            Assert.IsFalse(div.Dataset.HasDataAttr("user"));
        }

        [TestMethod]
        public void DOMStringMapHasAttributesButRequestedMissing()
        {
            var div = new HTMLDivElement();
            div.SetAttribute("data-some", "test");
            div.SetAttribute("data-another", "");
            div.SetAttribute("data-test", "third attribute");
            Assert.IsFalse(div.Dataset.HasDataAttr("user"));
        }

        [TestMethod]
        public void DOMStringMapIEnumerableWorking()
        {
            var div = new HTMLDivElement();
            div.SetAttribute("data-some", "test");
            div.SetAttribute("data-another", "");
            div.SetAttribute("data-test", "third attribute");
            Assert.AreEqual(3, div.Dataset.Count());
            Assert.AreEqual("some", div.Dataset.First().Key);
            Assert.AreEqual("test", div.Dataset.First().Value);
            Assert.AreEqual("test", div.Dataset.Last().Key);
            Assert.AreEqual("third attribute", div.Dataset.Last().Value);
        }

        [TestMethod]
        public void HtmlCustomTitleGeneration()
        {
            var doc = new HTMLDocument();
            var title = "My Title";
            doc.Title = title;
            Assert.AreEqual(title, doc.Title);
        }

        [TestMethod]
        public void HtmlHasRightHeadElement()
        {
            var doc = new HTMLDocument();
            var root = new HTMLHtmlElement();
            doc.AppendChild(root);
            var head = new HTMLHeadElement();
            root.AppendChild(head);
            Assert.AreEqual(head, doc.Head);
        }

        [TestMethod]
        public void HtmlHasRightBodyElement()
        {
            var doc = new HTMLDocument();
            var root = new HTMLHtmlElement();
            doc.AppendChild(root);
            var body = new HTMLBodyElement();
            root.AppendChild(body);
            Assert.AreEqual(body, doc.Body);
        }

        [TestMethod]
        public void NormalizeRemovesEmptyTextNodes()
        {
            var div = new HTMLDivElement();
            div.AppendChild(new HTMLAnchorElement());
            div.AppendChild(new TextNode());
            div.AppendChild(new HTMLDivElement());
            div.AppendChild(new TextNode("Hi there!"));
            div.AppendChild(new HTMLImageElement());
            div.Normalize();
            Assert.AreEqual(div.ChildNodes.Length, 4);
        }

        [TestMethod]
        public void NormalizeRemovesEmptyTextNodesNested()
        {
            var div = new HTMLDivElement();
            var a = new HTMLAnchorElement();
            a.AppendChild(new TextNode());
            a.AppendChild(new TextNode("Not empty."));
            div.AppendChild(a);
            div.AppendChild(new TextNode());
            div.AppendChild(new HTMLDivElement());
            div.AppendChild(new TextNode("Certainly not empty!"));
            div.AppendChild(new HTMLImageElement());
            div.Normalize();
            Assert.AreEqual(a.ChildNodes.Length, 1);
        }

        [TestMethod]
        public void NormalizeMergeTextNodes()
        {
            var div = new HTMLDivElement();
            var a = new HTMLAnchorElement();
            a.AppendChild(new TextNode());
            a.AppendChild(new TextNode("Not empty."));
            div.AppendChild(a);
            div.AppendChild(new TextNode());
            div.AppendChild(new HTMLDivElement());
            div.AppendChild(new TextNode("Certainly not empty!"));
            div.AppendChild(new TextNode("Certainly not empty!"));
            div.AppendChild(new TextNode("Certainly not empty!"));
            div.AppendChild(new TextNode("Certainly not empty!"));
            div.AppendChild(new HTMLImageElement());
            div.Normalize();
            Assert.AreEqual(div.ChildNodes.Length, 4);
        }

        [TestMethod]
        public void LocationCorrectAddressWithoutPort()
        {
            var hostname = "www.w3.org";
            var protocol = "http:";
            var path = "/some/path";
            var address = protocol + "//" + hostname + path;
            var location = new Location(address);
            Assert.AreEqual(string.Empty, location.Hash);
            Assert.AreEqual(hostname, location.Host);
            Assert.AreEqual(hostname, location.HostName);
            Assert.AreEqual(address, location.Href);
            Assert.AreEqual(path, location.PathName);
            Assert.AreEqual(string.Empty, location.Port);
            Assert.AreEqual(protocol, location.Protocol);
        }

        [TestMethod]
        public void LocationCorrectAddressWithoutPortButWithHash()
        {
            var hostname = "www.w3.org";
            var protocol = "http:";
            var path = "/some/path";
            var hash = "#myhash";
            var address = protocol + "//" + hostname + path + hash;
            var location = new Location(address);
            Assert.AreEqual(hash, location.Hash);
            Assert.AreEqual(hostname, location.Host);
            Assert.AreEqual(hostname, location.HostName);
            Assert.AreEqual(address, location.Href);
            Assert.AreEqual(path, location.PathName);
            Assert.AreEqual(string.Empty, location.Port);
            Assert.AreEqual(protocol, location.Protocol);
        }

        [TestMethod]
        public void LocationCorrectAddressWithPort()
        {
            var hostname = "www.w3.org";
            var protocol = "http:";
            var port = "8080";
            var path = "/some/path";
            var host = hostname + ":" + port;
            var address = protocol + "//" + host + path;
            var location = new Location(address);
            Assert.AreEqual(string.Empty, location.Hash);
            Assert.AreEqual(host, location.Host);
            Assert.AreEqual(hostname, location.HostName);
            Assert.AreEqual(address, location.Href);
            Assert.AreEqual(path, location.PathName);
            Assert.AreEqual(port, location.Port);
            Assert.AreEqual(protocol, location.Protocol);
        }

        [TestMethod]
        public void LocationCorrectAddressWithPortAndHash()
        {
            var hostname = "www.w3.org";
            var protocol = "http:";
            var port = "8080";
            var path = "/some/path";
            var hash = "#myhash";
            var host = hostname + ":" + port;
            var address = protocol + "//" + host + path + hash;
            var location = new Location(address);
            Assert.AreEqual(hash, location.Hash);
            Assert.AreEqual(host, location.Host);
            Assert.AreEqual(hostname, location.HostName);
            Assert.AreEqual(address, location.Href);
            Assert.AreEqual(path, location.PathName);
            Assert.AreEqual(port, location.Port);
            Assert.AreEqual(protocol, location.Protocol);
        }

        [TestMethod]
        public void LocationCorrectAddressWithHashChange()
        {
            var hostname = "www.w3.org";
            var protocol = "http:";
            var path = "/some/path";
            var hash = "#myhash";
            var address = protocol + "//" + hostname + path;
            var location = new Location(address);
            Assert.AreEqual(string.Empty, location.Hash);
            location.Hash = hash;
            address = protocol + "//" + hostname + path + hash;
            Assert.AreEqual(hash, location.Hash);
            Assert.AreEqual(hostname, location.Host);
            Assert.AreEqual(hostname, location.HostName);
            Assert.AreEqual(address, location.Href);
            Assert.AreEqual(path, location.PathName);
            Assert.AreEqual(string.Empty, location.Port);
            Assert.AreEqual(protocol, location.Protocol);
            Assert.AreEqual(address, location.Href);
        }

        [TestMethod]
        public void LocationCorrectAddressWithProtocolChange()
        {
            var hostname = "www.w3.org";
            var protocol = "http:";
            var path = "/some/path";
            var address = protocol + "//" + hostname + path;
            var location = new Location(address);
            Assert.AreEqual(protocol, location.Protocol);
            protocol = "https:";
            location.Protocol = protocol;
            address = protocol + "//" + hostname + path;
            Assert.AreEqual(protocol, location.Protocol);
            Assert.AreEqual(string.Empty, location.Hash);
            Assert.AreEqual(hostname, location.Host);
            Assert.AreEqual(hostname, location.HostName);
            Assert.AreEqual(address, location.Href);
            Assert.AreEqual(path, location.PathName);
            Assert.AreEqual(string.Empty, location.Port);
            Assert.AreEqual(protocol, location.Protocol);
            Assert.AreEqual(address, location.Href);
        }

        [TestMethod]
        public void LocationCorrectAddressWithPathChange()
        {
            var hostname = "www.w3.org";
            var protocol = "http:";
            var path = "/some/path";
            var address = protocol + "//" + hostname + path;
            var location = new Location(address);
            Assert.AreEqual(path, location.PathName);
            path = "/";
            location.PathName = "";
            address = protocol + "//" + hostname + path;
            Assert.AreEqual(protocol, location.Protocol);
            Assert.AreEqual(string.Empty, location.Hash);
            Assert.AreEqual(hostname, location.Host);
            Assert.AreEqual(hostname, location.HostName);
            Assert.AreEqual(address, location.Href);
            Assert.AreEqual(path, location.PathName);
            Assert.AreEqual(string.Empty, location.Port);
            Assert.AreEqual(protocol, location.Protocol);
            Assert.AreEqual(address, location.Href);
        }

        [TestMethod]
        public void CSSStyleDeclarationEmpty()
        {
            var css = new CSSStyleDeclaration();
            Assert.AreEqual("", css.CssText);
            Assert.AreEqual(0, css.Length);
        }

        [TestMethod]
        public void CSSStyleDeclarationUnbound()
        {
            var css = new CSSStyleDeclaration();
            var text = "background: red; color: black";
            css.CssText = text;
            Assert.AreEqual(text, css.CssText);
            Assert.AreEqual(2, css.Length);
        }

        [TestMethod]
        public void CSSStyleDeclarationBoundOutboundDirectionIndirect()
        {
            var element = new HTMLElement();
            var text = "background: red; color: black";
            element.SetAttribute("style", text);
            Assert.AreEqual(text, element.Style.CssText);
            Assert.AreEqual(2, element.Style.Length);
        }

        [TestMethod]
        public void CSSStyleDeclarationBoundOutboundDirectionDirect()
        {
            var element = new HTMLElement();
            var text = "background: red; color: black";
            element.SetAttribute("style", String.Empty);
            Assert.AreEqual(String.Empty, element.Style.CssText);
            element.Attributes["style"].Value = text;
            Assert.AreEqual(text, element.Style.CssText);
            Assert.AreEqual(2, element.Style.Length);
        }

        [TestMethod]
        public void CSSStyleDeclarationBoundInboundDirection()
        {
            var element = new HTMLElement();
            var text = "background: red; color: black";
            element.Style.CssText = text;
            Assert.AreEqual(text, element.Attributes["style"].Value);
            Assert.AreEqual(2, element.Style.Length);
        }
    }
}
