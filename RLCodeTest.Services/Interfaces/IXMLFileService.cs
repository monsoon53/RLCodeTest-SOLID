using System.Collections.Generic;
using RLCodeTest.Models;

namespace RLCodeTest.Services.Interfaces
{
    public interface IXmlFileService
    {
        bool GenerateXMLFileFromMaturityData(IEnumerable<MaturityDataModel> maturityData);
    }
}