using RLCodeTest.Models;

namespace RLCodeTest.PolicyTypes.Interfaces
{
    public interface IPolicyType
    {
        bool IsPolicyType(MaturityDataModel model);
        void PopulateValues(MaturityDataModel model);
        string GetPolicyType(MaturityDataModel model);
        decimal GetManagementFeePercentage(MaturityDataModel model);
        bool GetDiscretionaryBonusEligibility(MaturityDataModel model);
    }
}
