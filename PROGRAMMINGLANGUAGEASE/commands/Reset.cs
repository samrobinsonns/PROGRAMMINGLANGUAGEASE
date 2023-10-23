using PROGRAMMINGLANGUAGEASE.Commands;
using System;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public  class ResetCommand : BasicCommand
    {
        public override void Execute(Canvas canvas, string[] args)
        {
            // Reset the drawing settings to their default values
            canvas.CurrentPosition = new Point(40, 40);
        }
    }
}
