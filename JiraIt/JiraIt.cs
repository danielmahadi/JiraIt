using System;
using Xamarin.Forms;

namespace JiraIt
{
	public class App : Application
	{
		private static InMemoryDb _db = new InMemoryDb();

		public App ()
		{
			// The root page of your application
			var navigation = new NavigationPage(new ProjectListPage());
			navigation.BarBackgroundColor = Color.FromRgb (10, 65, 110);
			navigation.BarTextColor = Color.White;

			MainPage = navigation;

			var projectA = new Project { Name = "Death Star", Key = "DS" };
			var projectB = new Project { Name = "Light Saber", Key = "LS" };
			var projectC = new Project { Name = "Millenium Falcon", Key = "MF" };

			_db.SaveProject (projectA);
			_db.SaveProject (projectB);
			_db.SaveProject (projectC);

			_db.SaveIssue (new Issue{ Summary = "Relocate expose vent far away from core reactor", Project = projectA });
			_db.SaveIssue (new Issue{ Summary = "Light saber is too large for Yoda", Project = projectB });
			_db.SaveIssue (new Issue{ Summary = "Add more secret compartments for more smuggling", Project = projectC });
		}

		public static InMemoryDb Database
		{
			get { return _db; }
		}

		public static ContentPage CurrentPage { get; set; }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
