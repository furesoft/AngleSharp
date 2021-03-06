﻿using System;

namespace AngleSharp.DOM.Html
{
    /// <summary>
    /// Represents an HTML basefont element.
    /// </summary>
    [DOM("HTMLBaseFontElement")]
    public sealed class HTMLBaseFontElement : HTMLElement
    {
        internal HTMLBaseFontElement()
        {
            _name = Tags.BASEFONT;
        }

        /// <summary>
        /// Gets if the node is in the special category.
        /// </summary>
        protected internal override Boolean IsSpecial
        {
            get { return true; }
        }
    }
}
