using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;

namespace UnitTests
{
    /// <summary>
    /// Represents a test class for testing the MoveToCommand class.
    /// </summary>
    [TestClass]
    public class MoveToCommandTests
    {
        /// <summary>
        /// Test method to verify that Execute method changes the current position with valid dimensions.
        /// </summary>
        [TestMethod]
        public void Execute_MoveTo_WithValidDimensions()
        {
            // Arrange
            var canvas = new Canvas();
            var moveToCommand = new PositionCommand();
            string[] args = { "100", "50" }; // Test dimensions

            // Act
            moveToCommand.Execute(canvas, args);

            // Assert
            Assert.AreEqual(new Point(100, 50), canvas.CurrentPosition);
        }

        /// <summary>
        /// Test method to verify that Execute method shows an error message for invalid arguments.
        /// </summary>
        [TestMethod]
        public void Execute_InvalidArguments_ShowsErrorMessage()
        {
            // Arrange
            var canvas = new Canvas();
            var moveToCommand = new PositionCommand();
            string[] args = { "invalid", "50" };

            // Act
            moveToCommand.Execute(canvas, args);
        }
    }
}
