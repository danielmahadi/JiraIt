using System;
using Xamarin.Forms;

namespace JiraIt
{
	public class IssueListPage : ContentPage
	{
		ListView _listview;
		Project _project;

		public IssueListPage (Project project)
		{
			NavigationPage.SetHasNavigationBar (this, true);

			_project = project;

			Title = _project.Name;

			_listview = new ListView{ 
				RowHeight = 80,
				ItemTemplate = new DataTemplate (typeof(IssueItemCell))
			};

			UpdateList ();

			_listview.ItemSelected += (sender, e) => {
				var issue = (Issue) e.SelectedItem;

				var issuePage = new IssuePage(issue.Key);
				issuePage.BindingContext = issue;

				Navigation.PushAsync (issuePage);
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { _listview }
			};

			if (Device.OS == TargetPlatform.iOS) {
				var addMenu = new ToolbarItem("+", null, () => {
					var issue = new Issue();
					issue.Project = project;

					var issuePage = new IssuePage("New Issue");
					issuePage.BindingContext = issue;

					Navigation.PushAsync (issuePage);
				}, 0, 0);

				ToolbarItems.Add(addMenu);
			}
		}

		public void UpdateList()
		{
			_listview.ItemsSource = new IssueService ().GetIssues (_project);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			UpdateList ();
		}
	}
}