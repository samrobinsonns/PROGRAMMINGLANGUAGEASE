using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class CircleCommand : GraphicsCommand
    {
        public override void Execute(Graphics graphics, string[] args, Canvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (args.Length == 1 && int.TryParse(args[0], out int radius))
            {
                int x = currentPosition.X - radius;
                int y = currentPosition.Y - radius;

                if (canvas.IsFilling)
                {
                    SolidBrush brush = new SolidBrush(canvas.FillColor);
                    graphics.FillEllipse(brush, x, y, 2 * radius, 2 * radius);
                }
                else
                {
                    graphics.DrawEllipse(drawingPen, x, y, 2 * radius, 2 * radius);
                }

                // Use Invoke to update the commandTextBox on the UI thread
                commandTextBox.Invoke((MethodInvoker)delegate
                {
                    commandTextBox.Clear();
                });
            }
            else
            {
                MessageBox.Show("Invalid arguments for 'circle' command. Please provide a valid radius.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
