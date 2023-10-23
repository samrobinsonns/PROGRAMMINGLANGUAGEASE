﻿using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class RectangleCommand : GraphicsCommand
    {
        public override void Execute(Graphics graphics, string[] args, Canvas canvas)
        {
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            if (args.Length >= 2)
            {
                if (int.TryParse(args[0], out int width) && int.TryParse(args[1], out int height))
                {
                    int x = currentPosition.X;
                    int y = currentPosition.Y;

                    // Check if a new pen color has been set
                    if (drawingPen != null)
                    {
                        graphics.DrawRectangle(drawingPen, x, y, width, height);
                    }
                    else
                    {
                        graphics.DrawRectangle(Pens.Black, x, y, width, height); // Default to black if no pen color is set
                    }
                    commandTextBox.Clear();
                }
                else
                {
                    Error.ShowError("Invalid arguments for 'rectangle' command. Please provide valid width and height.");
                }
            }
        }
    }
}
