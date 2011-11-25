using app.utility;

namespace app.tasks.startup
{
  public interface IRunAStartupStep : IEncapsulateFunctionality
  {
	  IRunAStartupStep by<T>();
	  IRunAStartupStep followed_by<T>();
	  IRunAStartupStep finish_by<T>();
  }
}