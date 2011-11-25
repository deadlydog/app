﻿using System.Web;

namespace app.web.core.aspnet
{
  public class PageFactory : ICreateAResponse
  {
    IFindPathsToViews page_path_registry;
    TemplateFactory template_factory;

    public PageFactory(IFindPathsToViews page_path_registry, TemplateFactory template_factory)
    {
      this.page_path_registry = page_path_registry;
      this.template_factory = template_factory;
    }

    public IHttpHandler create_using<ReportModel>(ReportModel model)
    {
      var path = this.page_path_registry.find_path_for<ReportModel>();
      var handler = template_factory(path, typeof(IDisplayA<ReportModel>)) as IDisplayA<ReportModel>;
      handler.model = model;
      return handler;
    }
  }
}