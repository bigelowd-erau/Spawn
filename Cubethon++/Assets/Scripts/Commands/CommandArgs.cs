using UnityEngine;

public struct CommandArgs
{
    public Command command { get; set; }
    public float executionTime { get; set; }
    public CommandArgs(Command command, float executionTime)
    {
        this.command = command;
        this.executionTime = executionTime;
    }
}
