using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbicDragonfliesTests
{
    [TestClass]
    public class DataTests
    {
        // Test if gets json from RESTservice
        [TestMethod]
        public async void GetTaxonJsonFromApi_ValidJson_TaxonJsonRetrieved()
        {
            // Arrange
            int taxonId = 107;

            // Act
            String taxonJson = await NbicDragonflies.Data.IRestService.FetchDataAsync(NbicDragonflies.Constants.TaxonRestUrl + $"{taxonId}");

            // Assert
            Assert.IsTrue(taxonJson.Length > 0);
        }

        [TestMethod]
        public async void GetTaxonFromApi_ValidTaxon_TaxonRetrieved()
        {
            // Arrange
            int taxonId = 107;

            // Act
            var taxon = await NbicDragonflies.Data.ApplicationDataManager.GetTaxon(taxonId);

            // Assert
            Assert.AreEqual(taxon.scientificName, "Odonata");
        }
    }
}