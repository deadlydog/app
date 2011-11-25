using app.web.core.stubs;

namespace app.tasks.startup
{
  public class ConfigureQueries
  {
    IProvideContainerRegistrationServices registration;

    public ConfigureQueries(IProvideContainerRegistrationServices registration)
    {
      this.registration = registration;
    }

    public void run()
    {
      registration.register<GetTheMainDepartments>();
      registration.register<GetDepartmentsInDepartment>();
      registration.register<GetProductsInADepartment>();
    }
  }
}