using RLCodeTest.DAL.Interfaces;
using RLCodeTest.Models;
using RLCodeTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RLCodeTest.Services.Services
{
    // Implement IMaturityDataService interface
    public class MaturityDataService : IMaturityDataService
    {
        // Using dependency injection to inject IMaturityDataRepository - this provides the flexibility to either -
        // Swap to a different type of data repository, or
        // Use a Mock repository for unit testing
        IMaturityDataRepository _repo;
        IPolicyTypeService _policyTypeServ;
        public MaturityDataService(IMaturityDataRepository repo, IPolicyTypeService policyTypeServ)
        {
            _repo = repo;
            _policyTypeServ = policyTypeServ;
        }

        public IEnumerable<MaturityDataModel> GetMaturityDataAndCalculateValues()
        {
            // Get base data from the Data Repository
            IEnumerable<MaturityDataBaseModel> maturityDataBase = _repo.GetMaturityData();

            // Convert data and calculate the values
            IEnumerable<MaturityDataModel> maturityData = ConvertBaseDataAndCalculateValues(maturityDataBase);

            return maturityData;
        }

        public IEnumerable<MaturityDataModel> ConvertBaseDataAndCalculateValues(IEnumerable<MaturityDataBaseModel> maturityDataBase)
        {
            IEnumerable<MaturityDataModel> maturityData = Enumerable.Empty<MaturityDataModel>();
            if (maturityDataBase != null && maturityDataBase.Any())
            {
                // Convert all objects in collection from MaturityDataBaseModel to MaturityDataModel and populate values for the additional properties
                maturityData = maturityDataBase.Select(item => CreateModelFromBaseAndPopulateValues(item));

                // Calculate Maturity Value for each MaturityDataModel object
                maturityData = CalculateMaturityDataValuesFromList(maturityData.ToList());
            }

            return maturityData;
        }


        public MaturityDataModel CreateModelFromBaseAndPopulateValues(MaturityDataBaseModel baseModel)
        {
            // Logic for mapping fields has been moved form here into the MaturityDataModel constructor
            MaturityDataModel model = new MaturityDataModel(baseModel);

            // PolicyTypeService is used populate values in accordance with rules that relate to the relevant policy type.
            _policyTypeServ.PopulateValues(model);

            return model;
        }

        public List<MaturityDataModel> CalculateMaturityDataValuesFromList(List<MaturityDataModel> maturityData)
        {
            // Iterate over the list and carry out the final Maturity Value calculation
            if (maturityData != null && maturityData.Any())
                for (int i = 0; i < maturityData.Count(); i++)
                    CalculateMaturityValue(maturityData[i]);

            return maturityData;
        }

        public void CalculateMaturityValue(MaturityDataModel model)
        {
            // Calculate Management Fee Value by using the number of Premiums and the Management Fee Percentage
            decimal managementFeeValue = model.Premiums * (model.ManagementFeePercentage / 100);

            // Calculate the Uplift Value by adding the Uplift Percentage to 1 - e.g. Uplift Percentage of 25% will equal an uplift value of 1.25
            decimal upliftValue = 1 + (model.UpliftPercentage / 100);

            // Calculate Discretionary Bonus Value using the Discretionary Bonus Eligibility
            decimal discretionaryBonusValue = model.DiscretionaryBonusEligibility == true ? model.DiscretionaryBonus : 0;

            // Carry out final Maturity Value calculation
            decimal maturityValue = ((model.Premiums - managementFeeValue) + discretionaryBonusValue) * upliftValue;

            // Round to 2 decimal places
            model.MaturityValue = Math.Round(maturityValue, 2);
        }
    }
}