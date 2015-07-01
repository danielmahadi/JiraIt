using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;

[assembly: ExportRenderer (typeof (Entry), typeof (JiraIt.iOS.CustomEntryRenderer))]
namespace JiraIt.iOS
{
	public class CustomEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				Control.BorderStyle = UITextBorderStyle.None;
			}
		}
	
	}
}

