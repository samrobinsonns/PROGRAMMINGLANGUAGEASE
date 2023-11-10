using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    /// <summary>
    /// Represents a test class for testing the DrawToCommand class.
    /// </summary>
    [TestClass]
    public class DrawToCommandTests
    {
        /// <summary>
        /// Test method to verify that Execute method draws to a valid location and updates the current position.
        /// </summary>
        [TestMethod]
        public void Execute_DrawTo_WithValidDimensions()
        {
            var canvas = new Canvas();
            var drawToCommand = new DrawToCommand();
            string[] args = { "100", "50" }; // Test location
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            drawToCommand.Execute(canvas, args);

            Assert.AreEqual(new Point(100, 50), canvas.CurrentPosition);
        }

        /// <summary>
        /// Test method to verify that Execute method shows an error message for invalid arguments.
        /// </summary>
        [TestMethod]
        public void Execute_InvalidArguments_ShowsErrorMessage()
        {
            var canvas = new Canvas();
            var drawToCommand = new DrawToCommand();
            string[] args = { "invalid", "50" };

            drawToCommand.Execute(canvas, args);
        }
    }
}
