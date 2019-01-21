namespace RLCodeTest.Models
{
    // Inherit from base model and add additional fields to use for Maturity Value calculation
    public class MaturityDataModel : MaturityDataBaseModel
    {
        public MaturityDataModel()
        {

        }

        // Constructor used to map from MaturityDataBaseModel
        public MaturityDataModel(MaturityDataBaseModel maturityDataBaseModel) : base()
        {
            PolicyNumber = maturityDataBaseModel.PolicyNumber;
            PolicyStartDate = maturityDataBaseModel.PolicyStartDate;
            Premiums = maturityDataBaseModel.Premiums;
            Membership = maturityDataBaseModel.Membership;
            DiscretionaryBonus = maturityDataBaseModel.DiscretionaryBonus;
            UpliftPercentage = maturityDataBaseModel.UpliftPercentage;
        }

        public string PolicyType { get; set; }
        public decimal ManagementFeePercentage { get; set; }
        public bool DiscretionaryBonusEligibility{ get; set; }
        public decimal MaturityValue { get; set; }
    }
}
