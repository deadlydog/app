using System.Collections.Generic;

namespace app.tasks.startup
{
	public static class StartupExtensionMethods
	{
		public static IList<IRunAStartupStep> followed_by<T>(this IList<IRunAStartupStep> list)
		{

			list.Add(item);
			return list;
		}

		public static void finish_by<IRunAStartupStep>(this IList<IRunAStartupStep> list, IRunAStartupStep item )
		{
			list.Add(item);
			foreach (IRunAStartupStep step in list)
			{
				step.run();
			}
		}
	}
}