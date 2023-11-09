using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class TriangleCommand : GraphicsCommand
    {
        public override void Execute(Graphics graphics, string[] args, Canvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (args.Length >= 1)
            {
                if (int.TryParse(args[0], out int sideLength))
                {
                    // Calculate the vertices of the triangle
                    int x1 = currentPosition.X;
                    int y1 = currentPosition.Y;
                    int x2 = x1 + sideLength;
                    int y2 = y1;
                    int x3 = x1 + sideLength / 2;
                    int y3 = y1 - (int)(System.Math.Sqrt(3) * sideLength / 2);

                    Point[] points = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };

                    // Check if filling is enabled and fill the triangle if needed
                    if (canvas.IsFilling)
                    {
                        using (SolidBrush brush = new SolidBrush(canvas.FillColor))
                        {
                            graphics.FillPolygon(brush, points);
                        }
                    }

                    // Draw the outline of the triangle
                    graphics.DrawPolygon(drawingPen, points);
                    commandTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Invalid arguments for 'triangle' command. Please provide a valid side length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Not enough arguments for 'triangle' command. Please provide a side length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
