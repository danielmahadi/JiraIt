using System;
using Xamarin.Forms;

namespace JiraIt
{
	public class IssuePage : ContentPage
	{
		public IssuePage (string title)
		{
			const string DAILOG_TITLE = "Warning";

			NavigationPage.SetHasNavigationBar (this, true);

			Title = title;

			ToolbarItems.Add (new ToolbarItem ("Save", "", () => {

				var issue = (Issue) BindingContext;
				var hasError = false;

				if (string.IsNullOrEmpty(issue.Summary)) 
				{
					hasError = true;
					DisplayAlert (DAILOG_TITLE, "Please enter summary for issue", "OK");
				}

				if (!hasError) {
					App.Database.SaveIssue(issue);

					Navigation.PopAsync ();
				}
			}));

			var table = new TableView {
				Intent = TableIntent.Form,
				HasUnevenRows = true
			};

			AddSummarySection (table);

			AddDescriptionSection (table);

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					table
				}
			}; 
		}

		private void AddSummarySection(TableView table)
		{
			var summarySection = new TableSection ("Summary");

			var summaryGrid = new Grid {
				Padding = new Thickness(10, 0, 0, 0),
				VerticalOptions = LayoutOptions.FillAndExpand,
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) }
				}
			};

			var summaryEntry = new Entry { 
				Placeholder = "Hyperdrive damanged",
			};
			summaryEntry.SetBinding (Entry.TextProperty, "Summary");


			summaryGrid.Children.Add (summaryEntry, 0, 0);

			summarySection.Add (new ViewCell {
				View = summaryGrid
			});

			table.Root.Add (summarySection);
		}

		private void AddDescriptionSection(TableView table)
		{
			const int HEIGHT = 150;

			var descriptionSection = new TableSection ("Description");

			var descriptionGrid = new Grid {
				Padding = new Thickness(10),
				HeightRequest = HEIGHT,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) }
				}
			};

			var descriptionEntry = new Editor {
				HeightRequest = HEIGHT
			};

			descriptionEntry.SetBinding (Editor.TextProperty, "Description");

			descriptionGrid.Children.Add (descriptionEntry, 0, 0);

			descriptionSection.Add (new ViewCell {
				View = descriptionGrid,
				Height = HEIGHT
			});

			table.Root.Add (descriptionSection);
		}
	}
}