using System;
namespace DataExtractor.Handlers
{
    public interface IServiceHandler
    {
        System.Collections.Generic.List<DataExtractor.Model.ApplicationData> ListServices();
    }
}
