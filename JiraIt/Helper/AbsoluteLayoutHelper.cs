using System;

using Xamarin.Forms;

namespace JiraIt
{
	public class AbsoluteLayoutHelper
	{
		public AbsoluteLayoutHelper ()
		{
		}

		public static void SetControlToFull(Element element)
		{
			AbsoluteLayout.SetLayoutFlags (element, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(element, new Rectangle(0, 0, 1, 1));
		}
	}
}

