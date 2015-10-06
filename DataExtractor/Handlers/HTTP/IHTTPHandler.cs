using System;
namespace DataExtractor.Handlers
{
    public interface IHTTPHandler
    {
        void PostMasterEntity(string uri, string json);
    }
}
