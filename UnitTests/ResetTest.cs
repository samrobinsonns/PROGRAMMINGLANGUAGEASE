using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class ResetCommandTests
    {
        [TestMethod]
        public void Execute_Reset()
        {
            var canvas = new Canvas();
            var resetCommand = new ResetCommand();

            resetCommand.Execute(canvas, null);

            Assert.AreEqual(new Point(40, 40), canvas.CurrentPosition);
        }
    }
}
