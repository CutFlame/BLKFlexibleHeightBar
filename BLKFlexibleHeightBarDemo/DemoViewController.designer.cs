// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace BLKFlexibleHeightBarDemo
{
	[Register ("DemoViewController")]
	partial class DemoViewController
	{
		[Outlet]
		UIKit.UIButton facebookButton { get; set; }

		[Outlet]
		UIKit.UIButton squareCashButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (squareCashButton != null) {
				squareCashButton.Dispose ();
				squareCashButton = null;
			}

			if (facebookButton != null) {
				facebookButton.Dispose ();
				facebookButton = null;
			}
		}
	}
}
