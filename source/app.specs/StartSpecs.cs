using Machine.Specifications;
using app.tasks.startup;
using app.utility.containers;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Start))]
  public class StartSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_run : concern
    {
		Establish e = () =>
		              	{
							configuringTheContainer = fake.an<IRunAStartupStep>();

		              	};

      Because b = () =>
        Start.by<IRunAStartupStep>();

	  It configuring_the_container_ran = () =>
		  configuringTheContainer.received(x => x.run());
        
		static IRunAStartupStep configuringTheContainer;
    }
  }
}
