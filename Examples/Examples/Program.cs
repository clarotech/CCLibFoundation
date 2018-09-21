using System;
using System.IO;
using ClaroTech.FHIRSTU3.CCProfilesFoundation;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleCCOrganization();
        }

        static void ExampleCCOrganization()
        {
            Organization ex = new Organization();
            ex.CCInit();   // Initialise the metadata
            ex.Name = "Acme Example Organisation";

            ex.CCAddOdsOrganisationCode("ABC123");  // Add an id with appropriate system id
            ex.CCAddOdsSiteCode("XYZ999");   // Add an id with appropriate system id

            ResourceReference dummy = new ResourceReference("http://acme.org/Location/dummy");
            ex.CCSetMainLocation(dummy);   // Add CareConnect Extension

            Period dummyPeriod = new Period(new FhirDateTime(2011,3,12), new FhirDateTime(2017,10,2));
            ex.CCSetPeriod(dummyPeriod);  // Add CareConnect Extension

            WriteFhirXml("organization.xml", ex);


        }


        static void WriteFhirXml(string filename, Resource res)
        {
            if (!Directory.Exists("ExampleFiles"))
                Directory.CreateDirectory("ExampleFiles");

            FhirXmlSerializer op = new FhirXmlSerializer();
            string outxml = op.SerializeToString(res);
            File.WriteAllText($"ExampleFiles\\{filename}", outxml);
        }
    }
}
