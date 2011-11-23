using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
	[Subject(typeof(Command))]
	public class CommandSpecs
	{
		public abstract class concern : Observes<IProcessOneRequest,
										  Command>
		{ }

		public class when_testing_to_see_if_command_can_handle_request : concern
		{
			public class and_the_command_can_handle_the_request
			{
				Establish e = () =>
								{
									goodRequest = fake.an<IContainRequestInformation>();
									//goodRequest.setup(x => x.criteria = true);
								};

				Because b = () =>
					result = sut.can_handle(goodRequest);

				It should_be_able_to_handle_request = () =>
					result.ShouldEqual(true);

				static bool result;
				static IContainRequestInformation goodRequest;
			}

			public class and_the_command_can_not_handle_the_request
			{
				Establish e = () =>
				{
					badRequest = fake.an<IContainRequestInformation>();
					//badRequest.setup(x => x.criteria = false);
				};

				Because b = () =>
					result = sut.can_handle(badRequest);

				It should_not_be_able_to_handle_request = () =>
					result.ShouldEqual(false);

				static bool result;
				static IContainRequestInformation badRequest;
			}
		}
	}
}