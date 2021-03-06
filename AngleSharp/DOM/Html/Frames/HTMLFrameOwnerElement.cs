﻿using System;

namespace AngleSharp.DOM.Html
{
    /// <summary>
    /// Represents the base class for frame owned elements.
    /// </summary>
    public abstract class HTMLFrameOwnerElement : HTMLElement
    {
        #region ctor

        internal HTMLFrameOwnerElement()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the status if the element can contain a range endpoint.
        /// </summary>
        public Boolean CanContainRangeEndpoint
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the width of the frame.
        /// </summary>
        [DOM("width")]
        public Int32 Width
        {
            get { return ToInteger(GetAttribute(AttributeNames.WIDTH), 0); }
            set { SetAttribute(AttributeNames.WIDTH, value.ToString()); }
        }

        /// <summary>
        /// Gets the height of the frame.
        /// </summary>
        [DOM("height")]
        public Int32 Height
        {
            get { return ToInteger(GetAttribute(AttributeNames.HEIGHT), 0); }
            set { SetAttribute(AttributeNames.HEIGHT, value.ToString()); }
        }

        /// <summary>
        /// Gets or sets the frame margin width, in pixels.
        /// </summary>
        [DOM("marginWidth")]
        public Int32 MarginWidth
        {
            get { return ToInteger(GetAttribute(AttributeNames.MARGINWIDTH), 0); }
            set { SetAttribute(AttributeNames.MARGINWIDTH, value.ToString()); }
        }

        /// <summary>
        /// Gets or sets the frame margin height, in pixels.
        /// </summary>
        [DOM("marginHeight")]
        public Int32 MarginHeight
        {
            get { return ToInteger(GetAttribute(AttributeNames.MARGINHEIGHT), 0); }
            set { SetAttribute(AttributeNames.MARGINHEIGHT, value.ToString()); }
        }

        #endregion
    }
}
