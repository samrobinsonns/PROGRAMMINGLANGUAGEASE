using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;

namespace UnitTests
{
    /// <summary>
    /// Represents a test class for testing the ResetCommand class.
    /// </summary>
    [TestClass]
    public class ResetCommandTests
    {
        /// <summary>
        /// Test method to verify that executing the ResetCommand resets the canvas to the initial position.
        /// </summary>
        [TestMethod]
        public void Execute_Reset()
        {
            var canvas = new Canvas();
            var resetCommand = new ResetCommand();

            // Act
            resetCommand.Execute(canvas, null);

            // Assert
            Assert.AreEqual(new Point(40, 40), canvas.CurrentPosition);
        }
    }
}
