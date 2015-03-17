using Foundation;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace BLKFlexibleHeightBarDemo
{
	public class FacebookStyleBar : BLKFlexibleHeightBar
	{
		public FacebookStyleBar (CGRect frame) : base(frame)
		{
			ConfigureBar ();
		}

		public FacebookStyleBar()
		{
			ConfigureBar ();
		}

		void ConfigureBar()
		{
			// Configure bar appearence
			_maximumBarHeight = 105.0f;
			_minimumBarHeight = 20.0f;
			BackgroundColor = UIColor.FromRGBA (0.31f, 0.42f, 0.64f, 1.0f);
			ClipsToBounds = true;

			// Add blue bar view
			var blueBarView = new BLKFlexibleHeightBarSubviewUIView ();
			blueBarView.BackgroundColor = BackgroundColor;

			var initialBlueBarLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes ();
			initialBlueBarLayoutAttributes.Frame = new CGRect (0f, 25f, Frame.Size.Width, 40f);
			initialBlueBarLayoutAttributes.ZIndex = 1023;
			blueBarView.AddLayoutAttributes (initialBlueBarLayoutAttributes, 0f);
			blueBarView.AddLayoutAttributes (initialBlueBarLayoutAttributes, 40f / (105f - 20));

			var finalBlueBarLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialBlueBarLayoutAttributes);
			finalBlueBarLayoutAttributes.Transform = CGAffineTransform.MakeTranslation (0f, -40f);
			blueBarView.AddLayoutAttributes (finalBlueBarLayoutAttributes, 1f);

			AddSubview (blueBarView);

			// Add search field and close button
			var searchField = new BLKFlexibleHeightBarSubviewUITextField ();
			searchField.Layer.CornerRadius = 5f;
			searchField.AttributedPlaceholder = new NSAttributedString ("Search", foregroundColor: UIColor.FromRGBA (.55f, .6f, .75f, 1f));
			searchField.BackgroundColor = UIColor.FromRGBA (.22f, .27f, .46f, 1f);
			searchField.Layer.SublayerTransform = CATransform3D.MakeTranslation (5f, 0f, 0f);

			var initialSearchFieldLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes ();
			initialSearchFieldLayoutAttributes.Frame = new CGRect (8f, 25f, initialBlueBarLayoutAttributes.Size.Width * .85f, initialBlueBarLayoutAttributes.Size.Height - 8f);
			initialSearchFieldLayoutAttributes.ZIndex = 1024;
			searchField.AddLayoutAttributes (initialSearchFieldLayoutAttributes, 0f);
			searchField.AddLayoutAttributes (initialSearchFieldLayoutAttributes, 40f / (105f - 20f));

			var finalSearchFieldLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialSearchFieldLayoutAttributes);
			finalSearchFieldLayoutAttributes.Transform = CGAffineTransform.MakeTranslation (0f, -.3f * (105f - 20f));
			finalSearchFieldLayoutAttributes.Alpha = 0f;

			searchField.AddLayoutAttributes (finalSearchFieldLayoutAttributes, 0.8f);
			searchField.AddLayoutAttributes (finalSearchFieldLayoutAttributes, 1.0f);

			AddSubview (searchField);

			// Add white bar view
			var whiteBarView = new BLKFlexibleHeightBarSubviewUIView ();
			whiteBarView.BackgroundColor = UIColor.White;

			var initialWhiteBarLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes ();
			initialWhiteBarLayoutAttributes.Frame = new CGRect (0f, 65f, Frame.Size.Width, 40f);
			whiteBarView.AddLayoutAttributes (initialWhiteBarLayoutAttributes, 0f);

			var finalWhiteBarLayoutAttributes = new BLKFlexibleHeightBarSubviewLayoutAttributes (initialWhiteBarLayoutAttributes);
			finalWhiteBarLayoutAttributes.Transform = CGAffineTransform.MakeTranslation (0f, -40f);
			whiteBarView.AddLayoutAttributes (finalWhiteBarLayoutAttributes, 40f / (105f - 20f));

			AddSubview (whiteBarView);

			// Configure white bar view subviews
			var bottomBorderView = new UIView (new CGRect (0f, initialWhiteBarLayoutAttributes.Size.Height - .5f, initialWhiteBarLayoutAttributes.Size.Width, .5f));
			bottomBorderView.BackgroundColor = UIColor.FromRGBA (.75f, .76f, .78f, 1f);
			whiteBarView.AddSubview (bottomBorderView);

			var leftVerticalDividerView = new UIView (new CGRect (initialWhiteBarLayoutAttributes.Size.Width * 0.334f, initialWhiteBarLayoutAttributes.Size.Height * .1f, .5f, initialWhiteBarLayoutAttributes.Size.Height * .8f));
			leftVerticalDividerView.BackgroundColor = UIColor.FromRGBA (.85f, .86f, .88f, 1f);
			whiteBarView.AddSubview (leftVerticalDividerView);

			var rightVerticalDividerView = new UIView (new CGRect (initialWhiteBarLayoutAttributes.Size.Width * .667f, initialWhiteBarLayoutAttributes.Size.Height * .1f, .5f, initialWhiteBarLayoutAttributes.Size.Height * .8f));
			rightVerticalDividerView.BackgroundColor = UIColor.FromRGBA (.85f, .86f, .88f, 1f);
			whiteBarView.AddSubview (rightVerticalDividerView);
		}
	}
}
