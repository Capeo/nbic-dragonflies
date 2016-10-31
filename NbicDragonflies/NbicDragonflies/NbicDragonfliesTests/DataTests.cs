using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NbicDragonflies;
using NbicDragonflies.Data;

namespace NbicDragonfliesTests
{
    [TestClass]
    public class DataTests
    {
        // Test if gets json from RESTservice
        [TestMethod]
        public async Task GetTaxonJsonFromApi_ValidJson_TaxonJsonRetrieved()
        {
            // Arrange
            RestService rest = new RestService();
            int taxonId = 107;

            // Act
            String taxonJson = await rest.FetchDataAsync(NbicDragonflies.Utility.Constants.TaxonRestUrl + $"{taxonId}");

            // Assert
            Assert.IsTrue(taxonJson.Length > 0);
        }

        [TestMethod]
        public async Task GetTaxonFromApi_ValidTaxon_TaxonRetrieved()
        {
            // Arrange
            int taxonId = 107;

            // Act
            var taxon = await NbicDragonflies.Data.ApplicationDataManager.GetTaxon(taxonId);

            // Assert
            Assert.AreEqual(taxon.GetScientificName(), "Odonata");
        }
    }
}