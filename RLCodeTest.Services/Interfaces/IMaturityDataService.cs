using System.Collections.Generic;
using RLCodeTest.Models;

namespace RLCodeTest.Services.Interfaces
{
    public interface IMaturityDataService
    {
        IEnumerable<MaturityDataModel> GetMaturityDataAndCalculateValues();
        IEnumerable<MaturityDataModel> ConvertBaseDataAndCalculateValues(IEnumerable<MaturityDataBaseModel> maturityDataBase);
        List<MaturityDataModel> CalculateMaturityDataValuesFromList(List<MaturityDataModel> maturityData);
        MaturityDataModel CreateModelFromBaseAndPopulateValues(MaturityDataBaseModel item);
        void CalculateMaturityValue(MaturityDataModel model);
    }
}