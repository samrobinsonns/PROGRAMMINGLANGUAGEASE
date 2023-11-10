using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    /// <summary>
    /// Represents a test class for testing the TriangleCommand class.
    /// </summary>
    [TestClass]
    public class TriangleCommandTests
    {
        /// <summary>
        /// Test method to verify that executing the TriangleCommand with a valid radius draws a triangle on the canvas.
        /// </summary>
        [TestMethod]
        public void Execute_WithValidRadius_DrawsCircle()
        {
            var canvas = new Canvas();
            var triangleCommand = new TriangleCommand();
            string[] args = new string[] { "50" }; // Test size for triangle
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            triangleCommand.Execute(graphics, args, canvas);

            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandTextBox.Text));
        }
        /// <summary>
        /// Test method to verify that executing the TriangleCommand with an invalid radius shows an error message.
        /// </summary>
        [TestMethod]
        public void Execute_WithInvalidRadius_ShowsErrorMessage()
        {
            var canvas = new Canvas();
            var triangleCommand = new TriangleCommand();
            string[] args = new string[] { "invalidSize" };
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            triangleCommand.Execute(graphics, args, canvas);

        }
    }
}
