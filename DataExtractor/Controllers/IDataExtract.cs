using System;
namespace DataExtractor.Controllers
{
    public interface IDataExtract
    {
        DataExtractor.Model.MasterEntity GetData();
    }
}
