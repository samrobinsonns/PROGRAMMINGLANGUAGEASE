using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    /// <summary>
    /// Represents a test class for testing the CircleCommand class.
    /// </summary>
    [TestClass]
    public class CircleCommandTests
    {
        /// <summary>
        /// Test method to verify that Execute method draws a circle with a valid radius.
        /// </summary>
        [TestMethod]
        public void Execute_WithValidRadius_DrawsCircle()
        {
            // Arrange
            var canvas = new Canvas();
            var circleCommand = new CircleCommand();
            string[] args = new string[] { "50" }; // Test radius for circle
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            // Act
            circleCommand.Execute(graphics, args, canvas);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandTextBox.Text));
        }

        /// <summary>
        /// Test method to verify that Execute method shows an error message with an invalid radius.
        /// </summary>
        [TestMethod]
        public void Execute_WithInvalidRadius_ShowsErrorMessage()
        {
            // Arrange
            var canvas = new Canvas();
            var circleCommand = new CircleCommand();
            string[] args = new string[] { "invalidRadius" };
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            // Act and Assert
            circleCommand.Execute(graphics, args, canvas);
        }
    }
}
