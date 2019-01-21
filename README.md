# RLCodeTest-SOLID
# SOLID Enhancements and Modifications #

The original technical project that I submitted met the requirements fairly well as it was requested that the solution that was not to be over engineered. 

However, I felt that the project could be improved in some areas. Should the requirements be changed so the application was to be more extendable and as compliant as possible with the SOLID Principles these are the changes that I would make.

## XML File generation ##
* The presence of this code in MaturityDataService is a Single Responsibility Principle violation 
* New Service/Interface added for XmlFileService/IXmlFileService
* IXmlFileService will be injected into the MaturityDataController class and called from there
* All XML file responsibility has now been removed from the MaturityDataService
* Additionally, the GenerateXMLFile() method has been renamed to GenerateXMLFileFromMaturityData() as it now resides in a more generic location in XmlFileService

## Maturity Data Calculations ##
* Should we need to accommodate more policy types then we have an Open/Closed Principle violation in MaturityDataService:
  * The rules are different in each policy type for calculating Management Fee Percentage and Discretionary Bonus Eligibility – we need a way to be able to add additional policy types without changing the code in MaturityDataService
  * Additional project/class library Layer added - RLCodeTest.PolicyTypes
    * Interface – IPolicyType
    * Abstract class – BasePolicyType 
      * Partial implementation of IPolicyType with common policy type code.
    * PolicyType classes – PolicyTypeA, PolicyTypeB, PolicyTypeC 
      * Inherit from BasePolicyType and then complete the implementation of IPolicyType by overriding abstract methods with policy type specific code.
  * Additional Service/Interface added for PolicyTypeService/IPolicyTypeService
    * Constructor populates a list of policy types of type IPolicyType
    * PopulateValues() takes a parameter of MaturityDataModel
      * This checks the policy type and uses this information to call PopulateValues() for the relevant policy type.
  * At this point, should a new policy type be required a class of PolicyTypeX would be added, implementing IPolicyType. Additionally an instance of PolicyTypeX would need to be added to the list in the constructor of PolicyTypeService.
* An additional potential OCP violation was the code in the MaturityDataService that maps the MaturityDataBaseModel model to the MaturityDataModel – this has been moved to a constructor in the MaturityDataModel class.
* Now we have fixed the Open/Closed Principle violations we have also made the MaturityDataService compliant with the Single Responsibility Principle; the only reason for the class to change now would be to accommodate a change to the final maturity value calculation.
* Additionally some of the code has been refactored slightly.
* Additional test case has been added to cover calculating a list of policies.

## Examples of SOLID compliance ##

* Single Responsibility Principle – each area of the solution has been written minimise its responsibilities.

* Open/Closed Principle – the solution is extendable for new policy types without touching the code in MaturityDataService

* Liskhov Substitution Policy – using the IPolicyType interface, the BasePolicyType abstract class, and the PolicyTypeX classes; all the PolicyTypeX classes are substitutable against their base type of IPolicyType.

* Interface Segregation Principle – solution is using interfaces with only the required fields; there are no fat interfaces that require unused implementations.

* Dependency Inversion Principle – using dependency injection to decouple all areas of the solution.
