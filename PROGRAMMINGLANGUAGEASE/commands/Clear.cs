using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class ClearCommand : BasicCommand
    {
        public override void Execute(Canvas canvas, string[] args)
        {
            TextBox commandTextBox = canvas.CommandTextBox;
            // Clear the drawing canvas
            canvas.DrawingPictureBox.Invalidate();
            // Use Invoke to update the commandTextBox on the UI thread
            commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });

        }
    }
}
