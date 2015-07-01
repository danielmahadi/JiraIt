using System;
using Xamarin.Forms;

namespace JiraIt
{
	public class ProjectItemCell : ViewCell
	{
		public ProjectItemCell ()
		{

			var label = new Label {
				YAlign = TextAlignment.Center
			};

			label.SetBinding (Label.TextProperty, "Name");

			View = new StackLayout { 
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { label }
			};
		}
	}
}

