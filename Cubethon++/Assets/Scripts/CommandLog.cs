using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommandLog
{
    public static Queue<Command> commands = new Queue<Command>();

    static CommandLog()
    {
        //Invoker.CommandExecuted += AddCommandToQueue;
    }

    static void AddCommandToQueue(Command command)
    {
        commands.Enqueue(command);
    }
}
