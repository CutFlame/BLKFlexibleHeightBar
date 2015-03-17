using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace BLKFlexibleHeightBarDemo
{
	public partial class FacebookStyleViewController : UIViewController
	{
		FacebookStyleBar _myCustomBar;

		public FacebookStyleViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			tableView.DataSource = new FacebookTableViewDataSource ();

			SetNeedsStatusBarAppearanceUpdate ();

			_myCustomBar = new FacebookStyleBar (new CGRect (0f, 0f, View.Frame.Width, 100f));

			var behaviorDefiner = new FacebookStyleBarBehaviorDefiner ();
			behaviorDefiner.AddSnappingPositionProgress (0f, 0f, 40f/(105f-20f));
			behaviorDefiner.AddSnappingPositionProgress (1f, 40f/(105f-20f), 1f);
			behaviorDefiner.IsSnappingEnabled = true;
			behaviorDefiner.ThresholdNegativeDirection = 140f;
			tableView.Delegate = behaviorDefiner;
			_myCustomBar.BehaviorDefiner = behaviorDefiner;

			View.AddSubview (_myCustomBar);


			// Setup the table view
			tableView.RegisterClassForCellReuse (typeof(UITableViewCell), @"Cell");
			tableView.ContentInset = new UIEdgeInsets(_myCustomBar.MaximumBarHeight, 0f, 0f, 0f);


			// Add a close button to the bar
			var closeButton = new BLKFlexibleHeightBarSubviewUIButton();
			closeButton.UserInteractionEnabled = true;
			closeButton.TintColor = UIColor.White;
			closeButton.SetImage (UIImage.FromFile (@"Close.png"), UIControlState.Normal);
			closeButton.AddTarget (CloseViewController, UIControlEvent.TouchUpInside);

			var initialCloseButtonLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes ();
			initialCloseButtonLayoutAttributes.Frame = new CGRect(_myCustomBar.Frame.Width-35f, 26.5f, 30f, 30f);
			initialCloseButtonLayoutAttributes.ZIndex = 1024;

			closeButton.AddLayoutAttributes (initialCloseButtonLayoutAttributes, 0f);
			closeButton.AddLayoutAttributes (initialCloseButtonLayoutAttributes, 40f/(105f-20f));

			var finalCloseButtonLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialCloseButtonLayoutAttributes);
			finalCloseButtonLayoutAttributes.Transform = CGAffineTransform.MakeTranslation (0f, -.3f * (105f - 20f));
			finalCloseButtonLayoutAttributes.Alpha = 0f;

			closeButton.AddLayoutAttributes (finalCloseButtonLayoutAttributes, .8f);
			closeButton.AddLayoutAttributes (finalCloseButtonLayoutAttributes, 1f);

			_myCustomBar.AddSubview (closeButton);
		}

		void CloseViewController(object sender, EventArgs e)
		{
			DismissViewController (true, null);
		}

		public override UIStatusBarStyle PreferredStatusBarStyle ()
		{
			return UIStatusBarStyle.LightContent;
		}

		class FacebookTableViewDataSource : UITableViewDataSource
		{
			public override nint RowsInSection (UITableView tableView, nint section)
			{
				return 20;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (@"Cell", indexPath);
				cell.BackgroundColor = UIColor.FromRGBA (.95f, .95f, .95f, 1f);
				return cell;
			}
		}
	}
}
