﻿using System.Web;
using app.utility.containers;

namespace app.web.core
{
  public class BasicHandler : IHttpHandler
  {
    IProcessRequests front_controller;
    ICreateRequests request_factory;

    public BasicHandler()
      : this(
        Container.fetch.an<IProcessRequests>(), Container.fetch.an<ICreateRequests>())
      )
    {
    }

    public BasicHandler(IProcessRequests front_controller, ICreateRequests request_factory)
    {
      this.front_controller = front_controller;
      this.request_factory = request_factory;
    }

    public void ProcessRequest(HttpContext context)
    {
      front_controller.process(request_factory.create_from(context));
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}