using RLCodeTest.Models;
using RLCodeTest.PolicyTypes.Interfaces;

namespace RLCodeTest.PolicyTypes.PolicyTypes
{
    // Abstract class used to achieve a partial implementation of IPolicyType with common code implemented
    public abstract class BasePolicyType : IPolicyType
    {
        // Implemented Methods
        public void PopulateValues(MaturityDataModel model)
        {
            model.PolicyType = GetPolicyType(model);
            model.ManagementFeePercentage = GetManagementFeePercentage(model);
            model.DiscretionaryBonusEligibility = GetDiscretionaryBonusEligibility(model);
        }
        public string GetPolicyType(MaturityDataModel model)
        {
            if (model.PolicyNumber != null)
                return model.PolicyNumber.Substring(0, 1);

            return null;
        }

        // Abstract Methods
        public abstract bool IsPolicyType(MaturityDataModel model);
        public abstract decimal GetManagementFeePercentage(MaturityDataModel model);
        public abstract bool GetDiscretionaryBonusEligibility(MaturityDataModel model);
    }
}
