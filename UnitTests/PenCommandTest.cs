using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;

namespace UnitTests
{
    /// <summary>
    /// Represents a test class for testing the PenCommand class.
    /// </summary>
    [TestClass]
    public class PenCommandTests
    {
        /// <summary>
        /// Test method to verify that executing the PenCommand changes the pen color to red.
        /// </summary>
        [TestMethod]
        public void Execute_ChangesPenColorToRed()
        {
            // Arrange
            var canvas = new Canvas();
            var penCommand = new PenCommand();
            string[] args = new string[] { "red" };

            // Act
            penCommand.Execute(canvas, args);

            // Assert
            Assert.AreEqual(Color.Red, canvas.DrawingPen.Color);
        }
    }
}
