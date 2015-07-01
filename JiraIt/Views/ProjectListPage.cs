using System;
using Xamarin.Forms;

namespace JiraIt
{
	public class ProjectListPage : ContentPage
	{
		ListView _listview;

		public ProjectListPage ()
		{
			NavigationPage.SetHasNavigationBar (this, true);

			Title = "Jira It";

			_listview = new ListView {
				RowHeight = 40,
				ItemTemplate = new DataTemplate (typeof(ProjectItemCell))
			};

			_listview.ItemsSource = new ProjectService ()
				.GetProjects ();

			_listview.ItemSelected += (sender, e) => {
				var project = (Project) e.SelectedItem;
				var issueListPage = new IssueListPage(project);

				App.CurrentPage = issueListPage;

				Navigation.PushAsync (issueListPage);
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { _listview }
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			_listview.ItemsSource = new ProjectService ()
				.GetProjects ();
		}
	}
}