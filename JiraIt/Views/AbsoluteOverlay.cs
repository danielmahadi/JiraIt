using System;

using Xamarin.Forms;

namespace JiraIt
{
	public class AbsoluteOverlay
	{
		private readonly StackLayout _overlay;
		private readonly ActivityIndicator _indicator;
		private readonly Label _label;

		public StackLayout Overlay 
		{
			get { return _overlay; }
		}

		public void Show()
		{
			SetVisibleState (true);
		}

		public void SetMessage(string message)
		{
			_label.Text = message;
		}

		public void Hide()
		{
			SetVisibleState (false);
		}

		private void SetVisibleState(bool isVisible)
		{
			_indicator.IsRunning = isVisible;
			_indicator.IsVisible = isVisible;

			_label.IsVisible = isVisible;
			_overlay.IsVisible = isVisible;
		}

		public AbsoluteOverlay() 
		{
			_indicator = new ActivityIndicator {
				Color = Color.White,
			};

			_label = new Label {
				TextColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label))
			};

			_overlay = new StackLayout {
				BackgroundColor = Color.Black,
				Opacity = .5f,
				Children = {
					new StackLayout {
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						Children = {
							_indicator, _label
						}
					}

				}
			};

			Hide ();
		}
	}
}

