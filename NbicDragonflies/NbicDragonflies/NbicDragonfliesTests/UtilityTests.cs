using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbicDragonfliesTests
{
    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void CapitalFirstLetter_ValidString_FirstLetterCapitalized()
        {
            // Arrange
            string originalString = "odonata";
            string expectedModifiedString = "Odonata";

            // Act
            string actualModifiedString = NbicDragonflies.Utility.Utilities.CapitalizeFirstLetter(originalString);

            // Assert
            Assert.AreEqual(expectedModifiedString, actualModifiedString);
        }
    }
}
