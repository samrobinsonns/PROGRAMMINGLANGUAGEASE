using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;

namespace UnitTests
{
    /// <summary>
    /// Represents a test class for testing the FillCommand class.
    /// </summary>
    [TestClass]
    public class FillCommandTests
    {
        /// <summary>
        /// Test method to verify that Execute method toggles the fill mode on.
        /// </summary>
        [TestMethod]
        public void Execute_ToggleFillModeOn()
        {
            // Arrange
            var canvas = new Canvas();
            var fillCommand = new FillCommand();
            string[] args = { "on" };

            // Act
            fillCommand.Execute(canvas, args);

            // Assert
            Assert.IsTrue(canvas.IsFilling);
        }

        /// <summary>
        /// Test method to verify that Execute method toggles the fill mode off.
        /// </summary>
        [TestMethod]
        public void Execute_ToggleFillModeOff()
        {
            // Arrange
            var canvas = new Canvas();
            var fillCommand = new FillCommand();
            string[] args = { "off" };

            // Act
            fillCommand.Execute(canvas, args);

            // Assert
            Assert.IsFalse(canvas.IsFilling);
        }
    }
}
