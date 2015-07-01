using System;
using System.Collections.Generic;
using System.Linq;

namespace JiraIt
{
	public class InMemoryDb
	{
		private IList<Project> _projects;
		private IList<Issue> _issues;

		public InMemoryDb ()
		{
			_projects = new List<Project> ();
			_issues = new List<Issue> ();
		}

		public void SaveProject(Project project)
		{
			project.Id = _projects.Any() ? 
				_projects.Max (x => x.Id) + 1
				: 1;
			
			_projects.Add (project);
		}

		public IList<Project> GetProjects()
		{
			var result = new List<Project> ();

			foreach (var project in _projects) 
			{
				result.Add (new Project{
					Id = project.Id,
					Key = project.Key,
					Name = project.Name
				});
			}

			return result;
		}

		public void SaveIssue(Issue issue)
		{
			if (issue.Id == 0) {
				issue.Id = _issues.Any () ? 
					_issues.Max (x => x.Id) + 1
					: 1;

				issue.Key = string.Format ("{0}-{1}", issue.Project.Key, issue.Id);

				_issues.Add (issue);
			} else {
				var dbIssue = _issues.First (x => x.Id == issue.Id);
				dbIssue.Summary = issue.Summary;
				dbIssue.Description = issue.Description;
			}
		}

		public void DeleteIssue(Issue issue)
		{
			var toDelete = _issues.First (x => x.Id == issue.Id);
			_issues.Remove (toDelete);
		}

		public IEnumerable<Issue> GetIssues(int projectId)
		{
			var result = new List<Issue> ();;

			foreach (var issue in _issues.Where (x => x.Project.Id == projectId)) 
			{
				result.Add (new Issue{
					Id = issue.Id,
					Key = issue.Key,
					Description = issue.Description,
					Project = issue.Project,
					Summary = issue.Summary,
				});
			}

			return result;
		}
	}
}