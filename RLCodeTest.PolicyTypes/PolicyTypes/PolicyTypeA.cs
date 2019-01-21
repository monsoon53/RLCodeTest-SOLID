using RLCodeTest.Models;
using System;

namespace RLCodeTest.PolicyTypes.PolicyTypes
{
    // Complete IPolicyType implementation with policy type specific code by inheriting from BasePolicyType and overriding abstract methods 
    public class PolicyTypeA : BasePolicyType
    {
        public override bool IsPolicyType(MaturityDataModel model)
        {
            return model.PolicyNumber.StartsWith("A");
        }

        public override decimal GetManagementFeePercentage(MaturityDataModel model)
        {
            return 3;
        }

        public override bool GetDiscretionaryBonusEligibility(MaturityDataModel model)
        {
            if (model.PolicyStartDate < DateTime.Parse("1990-01-01"))
                return true;

            return false;
        }
    }
}
