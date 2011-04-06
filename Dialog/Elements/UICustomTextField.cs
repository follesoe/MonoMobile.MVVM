// 
//  UICustomTextField.cs
// 
//  Author:
//    Robert Kozak (rkozak@gmail.com / Twitter:@robertkozak)
// 
//  Copyright 2011, Nowcom Corporation.
// 
//  Code licensed under the MIT X11 license
// 
//  Permission is hereby granted, free of charge, to any person obtaining
//  a copy of this software and associated documentation files (the
//  "Software"), to deal in the Software without restriction, including
//  without limitation the rights to use, copy, modify, merge, publish,
//  distribute, sublicense, and/or sell copies of the Software, and to
//  permit persons to whom the Software is furnished to do so, subject to
//  the following conditions:
// 
//  The above copyright notice and this permission notice shall be
//  included in all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//  EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//  MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//  NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
//  LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
//  OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//  WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
namespace MonoMobile.MVVM
{
	using System;
	using System.Drawing;
	using MonoTouch.CoreGraphics;
	using MonoTouch.Foundation;
	using MonoTouch.UIKit;

	public class UICustomTextField : UITextField
	{
		public UIColor PlaceholderColor { get; set; }
		public UITextAlignment PlaceholderAlignment { get; set; }

		public UICustomTextField(): base() {}
		public UICustomTextField(NSCoder coder): base(coder) {}
		public UICustomTextField(NSObjectFlag t): base(t) {}
		public UICustomTextField(IntPtr handle): base (handle) {}
		public UICustomTextField(RectangleF frame): base(frame) {}

		public override void DrawPlaceholder(RectangleF rect)
		{
			if (PlaceholderColor == null)
				PlaceholderColor = UIColor.FromWhiteAlpha(0.7f, 1.0f);

			PlaceholderColor.SetColor();

			DrawString(Placeholder, rect, UIFont.SystemFontOfSize(UIFont.LabelFontSize), UILineBreakMode.Clip, PlaceholderAlignment);
		}
	}
}
