using System;
using System.Collections.Generic;

namespace JiraIt
{
	public class ProjectService
	{
		public ProjectService ()
		{
		}

		public IList<Project> GetProjects() 
		{
			return App.Database.GetProjects ();
		}
	}
}

