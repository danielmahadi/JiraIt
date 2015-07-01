using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;

[assembly: ExportRenderer (typeof (Editor), typeof (JiraIt.iOS.CustomEditorRenderer))]
namespace JiraIt.iOS
{	
	public class CustomEditorRenderer : EditorRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null)
			{   // perform initial setup
				// lets get a reference to the native control
				var nativeTextView = (UITextView)Control;
				// do whatever you want to the UITextField here!
				nativeTextView.Font = UIFont.SystemFontOfSize(UIFont.SystemFontSize);
			}
		}
	}
}