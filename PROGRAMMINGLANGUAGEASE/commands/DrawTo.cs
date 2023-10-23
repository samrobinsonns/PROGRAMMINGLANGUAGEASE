using System;
using System.Windows.Forms;
using System.Drawing;
using PROGRAMMINGLANGUAGEASE.Commands;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class DrawToCommand : BasicCommand
    {
        public override void Execute(Canvas canvas, string[] args)
        {
            if (args.Length >= 2 && int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
            {
                // Get the destination point
                Point destination = new Point(x, y);

                // Draw a line from the current position to the destination with the current pen color
                using (Graphics graphics = canvas.DrawingPictureBox.CreateGraphics())
                {
                    graphics.DrawLine(canvas.DrawingPen, canvas.CurrentPosition, destination);
                }

                // Update the current position to the destination
                canvas.CurrentPosition = destination;
                canvas.CommandTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Invalid arguments for 'drawto' command. Please provide valid coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
