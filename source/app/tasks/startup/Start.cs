using System.Collections.Generic;
using app.utility.containers.basic;

namespace app.tasks.startup
{
	public static class Start : IProvideContainerRegistrationServices
	{
		static List<IRunAStartupStep> thingsToRun = new List<IRunAStartupStep>();

		public static IRunAStartupStep by<T>()
		{
			thingsToRun.Clear();
			T instance;
			thingsToRun.Add(instance);
			
		}

		public static IRunAStartupStep followed_by<T>()
		{
			
		}

		public static IRunAStartupStep finish_by<T>()
		{
			thingsToRun.Add();
			foreach (IRunAStartupStep step in thingsToRun)
			{
				step.run();
			}
		}

		static void register<Implementation>()
		{
			register<Implementation, Implementation>();
		}
		static void register<Contract, Implementation>() where Implementation : Contract
		{
			dependencies.Add(typeof(Contract), new AutomaticDependencyFactory(container, new GreedyConstructorSelectionStrategy(), typeof(Implementation)));
		}
		static void register_instance<RegisteredType>(RegisteredType item)
		{
			dependencies.Add(typeof(RegisteredType), new SimpleFactory(() => item));
		}
	}
}