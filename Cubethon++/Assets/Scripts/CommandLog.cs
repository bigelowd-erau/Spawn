using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommandLog
{
    public static Queue<CommandArgs> commands;

    static CommandLog()
    {
        //Invoker.CommandExecuted += AddCommandToQueue;
    }

    static void AddCommandToQueue(Command command)
    {
        commands.Enqueue(new CommandArgs(command, Time.time));
    }
}
