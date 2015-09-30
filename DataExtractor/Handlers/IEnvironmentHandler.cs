using System;
namespace DataExtractor.Handlers
{
    public interface IEnvironmentHandler
    {
        DataExtractor.Model.EnvironmentData GetEnvironmentData();
    }
}
