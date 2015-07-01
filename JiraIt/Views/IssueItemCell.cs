using System;
using Xamarin.Forms;

namespace JiraIt
{
	public class IssueItemCell : ViewCell
	{
		public IssueItemCell ()
		{
			var key = new Label {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				YAlign = TextAlignment.Center
			};

			key.SetBinding (Label.TextProperty, "Key");

			var summary = new Label {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				YAlign = TextAlignment.Center
			};

			summary.SetBinding (Label.TextProperty, "Summary");

			var editAction = new MenuItem { Text = "Edit" };
			editAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			editAction.Clicked += (sender, e) => {
				var mi = (MenuItem) sender;
				var issue = (Issue) mi.CommandParameter;

				var issuePage = new IssuePage(issue.Key);
				issuePage.BindingContext = issue;

				ParentView.Navigation.PushAsync(issuePage);
			};

			var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true };
			deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			deleteAction.Clicked += async (sender, e) => {
				var mi = (MenuItem) sender;
				var issue = (Issue) mi.CommandParameter;

				var answer = await App.CurrentPage.DisplayAlert("Delete?", "Would you like to remove this issue?", "Yes", "No");

				if (answer)
				{
					App.Database.DeleteIssue(issue);

					if (App.CurrentPage is IssueListPage)
					{
						((IssueListPage)App.CurrentPage).UpdateList();
					}
				}
			};

			ContextActions.Add (editAction);
			ContextActions.Add (deleteAction);

			View = new StackLayout { 
				Padding = new Thickness(20, 5, 0, 0),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { key, summary }
			};
		}
	}
}