using System;
namespace DataExtractor.Handlers
{
    public interface IIisHandler
    {
        DataExtractor.Model.IISData CreateIisDataObject(Version IisVersion);
        Version GetIisVersion();
        DataExtractor.Model.IIS.IISStringContainer StoreIIS(DataExtractor.Model.IISData iis);
    }
}
