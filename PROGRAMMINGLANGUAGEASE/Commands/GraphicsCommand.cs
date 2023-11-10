using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    /// <summary>
    /// Represents the base class for graphics commands that can be executed on a canvas.
    /// </summary>
    abstract public class GraphicsCommand
    {
        /// <summary>
        /// Executes a graphics command on the given canvas using specified graphics and arguments.
        /// </summary>
        /// <param name="graphics">The graphics object to be used for drawing.</param>
        /// <param name="args">The arguments for the command.</param>
        /// <param name="canvas">The canvas on which to execute the graphics command.</param>
        abstract public void Execute(Graphics graphics, string[] args, Canvas canvas);
    }
}