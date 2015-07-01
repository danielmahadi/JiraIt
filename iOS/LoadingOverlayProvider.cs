using System;
using UIKit;
using CoreGraphics;

namespace JiraIt.iOS
{
	public class LoadingOverlayProvider : ILoadingOverlayProvider
	{
		public LoadingOverlay GetLoadingOverlay()
		{
			// Determine the correct size to start the overlay (depending on device orientation)
			var bounds = UIScreen.MainScreen.Bounds; // portrait bounds
			if (UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeLeft || UIApplication.SharedApplication.StatusBarOrientation == UIInterfaceOrientation.LandscapeRight) {
				bounds.Size = new CGSize(bounds.Size.Height, bounds.Size.Width);
			}

			return new LoadingOverlay (bounds);
		}
	}
}