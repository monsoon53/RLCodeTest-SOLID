using RLCodeTest.Models;
using RLCodeTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Linq;

namespace RLCodeTest.Services.Services
{
    public class XmlFileService : IXmlFileService
    {
        public bool GenerateXMLFileFromMaturityData(IEnumerable<MaturityDataModel> maturityData)
        {
            // Use Linq to XML to create XML file containing Policy Number and Maturity Value
            XDocument doc = new XDocument();

            // Create the root element for the document - MaturityDataResults
            XElement maturityDataResultsElement = new XElement("MaturityDataResults");

            // Iterate through Maturity Data items 
            foreach (var item in maturityData)
            {
                // Create Maturity Data element for each policy
                XElement maturityDataElement =
                    new XElement("MaturityData",
                        new XElement("PolicyNumber", item.PolicyNumber),
                        new XElement("MaturityValue", item.MaturityValue));

                // Add element to the root element
                maturityDataResultsElement.Add(maturityDataElement);
            }

            // Add root element to XML Document
            doc.Add(maturityDataResultsElement);

            string xmlFilename = ConfigurationManager.AppSettings["XMLFileName"];
            string xmlFolder = ConfigurationManager.AppSettings["XMLFolder"];

            // Define file save path
            string saveFilePath = AppDomain.CurrentDomain.BaseDirectory + Path.Combine(xmlFolder, xmlFilename);

            // Call save method to generate XML file and save to file system
            doc.Save(saveFilePath);

            return true;
        }
    }
}
