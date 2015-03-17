using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace BLKFlexibleHeightBarDemo
{

	public partial class SquareCashStyleViewController : UIViewController
	{
		SquareCashStyleBar _myCustomBar;
		//BLKDelegateSplitter _delegateSplitter;

		public SquareCashStyleViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			tableView.DataSource = new SquareTableViewDataSource ();

			SetNeedsStatusBarAppearanceUpdate ();

			// Setup the bar
			_myCustomBar = new SquareCashStyleBar (new CGRect (0f, 0f, View.Frame.Width, 100f));

			var behaviorDefiner = new SquareCashStyleBehaviorDefiner ();
			behaviorDefiner.AddSnappingPositionProgress (0f, 0f, .5f);
			behaviorDefiner.AddSnappingPositionProgress (1f, .5f, 1f);
			behaviorDefiner.IsSnappingEnabled = true;
			behaviorDefiner.IsElasticMaximumHeightAtTop = true;
			tableView.Delegate = behaviorDefiner;
			_myCustomBar.BehaviorDefiner = behaviorDefiner;

			// Configure a separate UITableViewDelegate and UIScrollViewDelegate (optional)
			//_delegateSplitter = new BLKDelegateSplitter(behaviorDefiner, this);

			View.AddSubview (_myCustomBar);

			// Setup the table view
			tableView.RegisterClassForCellReuse (typeof(UITableViewCell), @"Cell");
			tableView.ContentInset = new UIEdgeInsets (_myCustomBar.MaximumBarHeight, 0f, 0f, 0f);


			// Add close button - it's pinned to the top right corner, so it doesn't need to respond to bar height changes
			var closeButton = new BLKFlexibleHeightBarSubviewUIButton ();
			closeButton.Frame = new CGRect (_myCustomBar.Frame.Width - 40f, 25f, 30f, 30f);
			closeButton.TintColor = UIColor.White;
			closeButton.SetImage (UIImage.FromFile (@"Close.png"), UIControlState.Normal);
			closeButton.AddTarget (CloseViewController, UIControlEvent.TouchUpInside);
			_myCustomBar.AddSubview (closeButton);

		}

		public override UIStatusBarStyle PreferredStatusBarStyle ()
		{
			return UIStatusBarStyle.LightContent;
		}

		void CloseViewController(object sender, EventArgs e)
		{
			DismissViewController (true, null);
		}


		class SquareTableViewDataSource : UITableViewDataSource
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
