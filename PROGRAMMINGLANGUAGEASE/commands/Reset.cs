using System;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public static class ResetCommand
    {
        public static void Execute(Canvas canvas)
        {
            // Reset the drawing settings to their default values
            canvas.CurrentPosition = new Point(40, 40);
        }
    }
}
