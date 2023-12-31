﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    /// <summary>
    /// Represents a test class for testing the ClearCommand class.
    /// </summary>
    [TestClass]
    public class ClearCommandTests
    {
        /// <summary>
        /// Test method to verify that Execute method clears the canvas after drawing.
        /// </summary>
        [TestMethod]
        public void Execute_ClearsCanvas_AfterDrawing()
        {
            // Arrange
            var canvas = new Canvas();
            var circleCommand = new CircleCommand();
            var clearCommand = new ClearCommand();
            string[] circleArgs = new string[] { "50" };
            var bitmap = new Bitmap(100, 100);
            var graphics = Graphics.FromImage(bitmap);

            // Act
            circleCommand.Execute(graphics, circleArgs, canvas);
            clearCommand.Execute(canvas, null);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandTextBox.Text));
        }
    }
}
