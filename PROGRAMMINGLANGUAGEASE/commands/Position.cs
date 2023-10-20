using System;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public static class PositionCommand
    {
        public static void Execute(Canvas canvas, string[] args)
        {
            if (args.Length >= 2 && int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
            {
                // Set the current position to the specified coordinates
                canvas.CurrentPosition = new Point(x, y);
                canvas.CommandTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Invalid arguments for 'position' command. Please provide valid coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
