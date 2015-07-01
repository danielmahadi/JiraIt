using System;

namespace JiraIt
{
	public class Issue
	{
		public Issue ()
		{
		}

		public string Summary { get; set; }
		public string Description { get; set; }
		public string Key { get; set; }
		public Project Project { get; set; }
		public int Id { get;set; }
	}
}