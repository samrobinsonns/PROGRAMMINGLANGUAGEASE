using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    /// <summary>
    /// Represents the base class for basic commands that can be executed on a canvas.
    /// </summary>
    abstract public class BasicCommand
    {
        /// <summary>
        /// Executes the command on the given canvas with the specified arguments.
        /// </summary>
        /// <param name="canvas">The canvas on which to execute the command.</param>
        /// <param name="args">The arguments for the command.</param>
        abstract public void Execute(Canvas canvas, string[] args);
    }
}
