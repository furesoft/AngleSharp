﻿using System;

namespace AngleSharp.DOM.Css
{
    /// <summary>
    /// Represents a CSS value.
	/// </summary>
	[DOM("CSSValue")]
    public class CSSValue : ICssObject
    {
        #region Members

        /// <summary>
        /// The type of value.
        /// </summary>
        protected CssValueType _type;

        /// <summary>
        /// The CSS text representation of the value.
        /// </summary>
        protected String _text;

        static CSSValue _inherited;
        static CSSValue _lmarker;
        static CSSValue _pmarker;

        #endregion

        #region ctor

        /// <summary>
        /// Creates a new CSS value.
        /// </summary>
        internal CSSValue()
        {
            _type = CssValueType.Custom;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance for an inherited value.
        /// </summary>
        public static CSSValue Inherit
        {
            get { return _inherited ?? (_inherited = new CSSValue { _text = "inherit", _type = CssValueType.Inherit }); }
        }

        /// <summary>
        /// Gets the list marker.
        /// </summary>
        internal static CSSValue ListMarker
        {
            get { return _lmarker ?? (_lmarker = new CSSValue()); }
        }

        /// <summary>
        /// Gets the pool marker.
        /// </summary>
        internal static CSSValue PoolMarker
        {
            get { return _pmarker ?? (_pmarker = new CSSValue()); }
        }

        /// <summary>
        /// Gets a code defining the type of the value as defined above.
		/// </summary>
		[DOM("cssValueType")]
        public CssValueType CssValueType
        {
            get { return _type; }
        }

        /// <summary>
        /// Gets or sets a string representation of the current value.
        /// </summary>
		[DOM("cssText")]
        public String CssText
        {
            get { return ToCss(); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a CSS code representation of the stylesheet.
        /// </summary>
        /// <returns>A string that contains the code.</returns>
        public virtual String ToCss()
        {
            return _text;
        }

        #endregion

        //UNITLESS in QUIRKSMODE:
        //  border-top-width
        //  border-right-width
        //  border-bottom-width
        //  border-left-width
        //  border-width
        //  bottom
        //  font-size
        //  height
        //  left
        //  letter-spacing
        //  margin
        //  margin-right
        //  margin-left
        //  margin-top
        //  margin-bottom
        //  padding
        //  padding-top
        //  padding-bottom
        //  padding-left
        //  padding-right
        //  right
        //  top
        //  width
        //  word-spacing

        //HASHLESS in QUIRKSMODE:
        //  background-color
        //  border-color
        //  border-top-color
        //  border-right-color
        //  border-bottom-color
        //  border-left-color
        //  color
    }
}
