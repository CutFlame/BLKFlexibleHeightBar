using System;
using UIKit;

namespace BLKFlexibleHeightBarDemo
{
	public partial class DemoViewController : UIViewController
	{
		public DemoViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SetNeedsStatusBarAppearanceUpdate ();

			squareCashButton.Layer.BorderWidth = 2f;
			squareCashButton.Layer.BorderColor = UIColor.FromWhiteAlpha (0f, .5f).CGColor;

			facebookButton.Layer.BorderWidth = 2f;
			facebookButton.Layer.BorderColor = UIColor.FromWhiteAlpha (0f, .5f).CGColor;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override UIStatusBarStyle PreferredStatusBarStyle ()
		{
			return UIStatusBarStyle.Default;
		}
	}
}
