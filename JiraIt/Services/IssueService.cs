using System;
using System.Collections.Generic;

namespace JiraIt
{
	public class IssueService
	{
		public IssueService ()
		{
		}

		public IEnumerable<Issue> GetIssues(Project project)
		{
			return App.Database.GetIssues(project.Id);
		}
	}
}