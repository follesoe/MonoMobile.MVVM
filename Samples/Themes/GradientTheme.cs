//
// GradientTheme.cs:
//
// Author:
//   Robert Kozak (rkozak@gmail.com) Twitter:@robertkozak
//
// Copyright 2011, Nowcom Corporation
//
// Code licensed under the MIT X11 license
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
namespace MonoMobile.MVVM
{
	using System;
	using System.Drawing;
	using MonoTouch.CoreGraphics;
	using MonoTouch.UIKit;

	public class GradientTheme: Theme
	{
		private CGGradient gradient { get; set; }

		public GradientTheme()
		{
			//BackgroundColor = UIColor.Clear;
			TextColor = UIColor.Black;
			TextShadowColor = UIColor.LightGray;
			TextShadowOffset = new SizeF(1, 0);
			
			gradient = new CGGradient(CGColorSpace.CreateDeviceRGB(), new float[] { 0.95f, 0.95f, 0.95f, 1, 0.85f, 0.85f, 0.85f, 1 }, new float[] { 0, 1 });
			
			DrawContentViewAction = (rect, context, cell) => { DrawContentView(rect, context, cell); };
		}

		public void DrawContentView(RectangleF rect, CGContext context, UITableViewElementCell cell)
		{
			context.DrawLinearGradient(gradient, new PointF(rect.Left, rect.Top), new PointF(rect.Left, rect.Bottom), CGGradientDrawingOptions.DrawsBeforeStartLocation);
			cell.ShouldDrawBorder = true;
		}
	}

}

