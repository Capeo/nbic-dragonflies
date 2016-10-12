using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;

namespace NbicDragonflies.Helpers
{
    class TaxonHelper
    {
        // Get characteristic of specific "type"
        public string GetCharacteristic(string json, string type)
        {
            int typeLength = type.Length;

            if (type == "scientificName")
            {
                int charactersticIndex = json.IndexOf(type + "'"); // Change this to """ for real json
                int nextCommaIndex = json.Substring(charactersticIndex).IndexOf(",");

                return json.Substring(charactersticIndex + typeLength + 2, nextCommaIndex - (typeLength + 2));
            }
            else
            {
                int charactersticIndex = json.IndexOf(type);
                int nextCommaIndex = json.Substring(charactersticIndex, 100).IndexOf(",");

                return json.Substring(charactersticIndex + typeLength + 2, nextCommaIndex - (typeLength + 2));
            }
        }

        // Create TaxonItem based on Json
        public TaxonItem createTaxon(string json)
        {
            TaxonItem taxon;

            string scientificNameIdString = this.GetCharacteristic(json, "scientificNameID");
            string taxonIdString = this.GetCharacteristic(json, "taxonID");
            System.Diagnostics.Debug.WriteLine(taxonIdString);
            string scientificName = this.GetCharacteristic(json, "scientificName");

            int scientificNameId;
            int taxonId;

            try
            {
                scientificNameId = Int32.Parse(scientificNameIdString);
                taxonId = Int32.Parse(taxonIdString);

                taxon = new TaxonItem(scientificNameId, taxonId, scientificName);

                return taxon;
            }
            catch (FormatException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return new TaxonItem(0, 0, "Error");
        }
        
    }
}
