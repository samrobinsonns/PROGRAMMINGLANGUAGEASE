using System.Collections.Generic;

public class ControlFlowHandler
{
    private Stack<ControlBlock> controlBlocks = new Stack<ControlBlock>();
    private bool isExecuting = true;
    private DrawingHandler drawingHandler;

    public ControlFlowHandler(DrawingHandler drawingHandler)
    {
        this.drawingHandler = drawingHandler;
    }

    public void ExecuteCommand(string command, string[] args)
    {
        switch (command.ToLower())
        {
            case "if":
                HandleIfCommand(args);
                break;
            case "endif":
                HandleEndIfCommand();
                break;
            default:
                if (isExecuting)
                {
                    drawingHandler.ExecuteDrawing(command, args);
                }
                break;
        }
    }

    private void HandleIfCommand(string[] args)
    {
        bool condition = EvaluateCondition(args);
        controlBlocks.Push(new ControlBlock { Type = "If", Condition = condition });
        isExecuting = condition;
    }

    private void HandleEndIfCommand()
    {
        if (controlBlocks.Count > 0 && controlBlocks.Peek().Type == "If")
        {
            controlBlocks.Pop();
        }
        isExecuting = controlBlocks.Count == 0 || (controlBlocks.Count > 0 && controlBlocks.Peek().Condition);
    }

    private bool EvaluateCondition(string[] args)
    {
        return args.Length > 0 && bool.TryParse(args[0], out bool result) && result;
    }
}

class ControlBlock
{
    public string Type; // "If" or other types like "While"
    public bool Condition; // The result of evaluating the condition
}
