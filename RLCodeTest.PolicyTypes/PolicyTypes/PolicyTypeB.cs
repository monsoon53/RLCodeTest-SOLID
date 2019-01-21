using RLCodeTest.Models;
using System;

namespace RLCodeTest.PolicyTypes.PolicyTypes
{
    // Complete IPolicyType implementation with policy type specific code by inheriting from BasePolicyType and overriding abstract methods 
    public class PolicyTypeB : BasePolicyType
    {
        public override bool IsPolicyType(MaturityDataModel model)
        {
            return model.PolicyNumber.StartsWith("B");
        }

        public override decimal GetManagementFeePercentage(MaturityDataModel model)
        {
            return 5;
        }

        public override bool GetDiscretionaryBonusEligibility(MaturityDataModel model)
        {
            if (model.Membership == true)
                return true;

            return false;
        }
    }
}
