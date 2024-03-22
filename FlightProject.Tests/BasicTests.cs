using NUnit.Framework.Internal;

using FlightProject;

    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestFlightStatus_FlightNotExists_ReturnsInvalidFlightNumber()
        {
            // Arrange
            string flightNumber = "XYZ123";

            // Act
            string result = Flight.flightStatus(flightNumber);

            // Assert
            Assert.AreEqual("Invalid Flight Number", result);
        }

        [Test]
        public void TestFlightStatus_FlightFuture_ReturnsTimeToFlight()
        {
            // Arrange
            string flightNumber = "ZW346";
            Flight.flightSchedule[flightNumber] = DateTime.UtcNow.AddHours(1);

            // Act
            string result = Flight.flightStatus(flightNumber);

            // Assert
            Assert.IsTrue(result.StartsWith("Time to flight"));
        }

        [Test]
        public void TestFlightStatus_FlightPast_ReturnsFlightAlreadyLeft()
        {
            // Arrange
            string flightNumber = "ZW346";
            Flight.flightSchedule[flightNumber] = DateTime.UtcNow.AddHours(-1);

            // Act
            string result = Flight.flightStatus(flightNumber);

            // Assert
            Assert.AreEqual("Flight Already Left", result);
        }
    }


