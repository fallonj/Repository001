using GeneralPractice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GeneralPractice.Tests
{
    
    
    /// <summary>
    ///This is a test class for BikeTest and is intended
    ///to contain all BikeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BikeTest
    {

        [TestMethod]
        public void Test_Milage_Increased()
        { 
            //Arrange
            Bike johnsBike = new Bike("Red", 2) { HasALight = false };
            int originalMilesOnBike = johnsBike.MilesOnTheClock;
            int journeyMiles = 40;

            //Act
            johnsBike.GoForARide(journeyMiles);

            //Assert
            Assert.AreEqual(originalMilesOnBike + journeyMiles, johnsBike.MilesOnTheClock);
        }

    }
}
