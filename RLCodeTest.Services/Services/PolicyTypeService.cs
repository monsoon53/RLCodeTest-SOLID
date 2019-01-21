using RLCodeTest.Models;
using RLCodeTest.PolicyTypes.Interfaces;
using RLCodeTest.PolicyTypes.PolicyTypes;
using RLCodeTest.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RLCodeTest.Services.Services
{
    public class PolicyTypeService : IPolicyTypeService
    {
        private readonly List<IPolicyType> _policyTypes;
        public PolicyTypeService()
        {
            _policyTypes = new List<IPolicyType>();

            _policyTypes.Add(new PolicyTypeA());
            _policyTypes.Add(new PolicyTypeB());
            _policyTypes.Add(new PolicyTypeC());
        }

        public void PopulateValues(MaturityDataModel model)
        {
            _policyTypes.FirstOrDefault(x => x.IsPolicyType(model)).PopulateValues(model);
        }
    }
}
