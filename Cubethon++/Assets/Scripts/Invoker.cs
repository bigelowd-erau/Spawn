using System;
using UnityEngine;
using System.Collections.Generic;

public class Invoker: InvokerSubscriber
{
    private CommandArgs _commandArgs;

    public override void SetCommand(Command command)
    {
        _commandArgs.command = command;
    }
    public override void SetCommand(CommandArgs commandArg)
    {
        _commandArgs = commandArg;
    }

    public void FixedUpdate()
    {
        if (_commandArgs.command != null)
        {
            //execution time not set (therefore in not in replay)
            if (_commandArgs.executionTime == 0.0f)
            {
                _commandArgs.executionTime = Time.timeSinceLevelLoad;
                CommandLog.commands.Enqueue(_commandArgs);
                ExecuteCommand();
            }
            else if(_commandArgs.executionTime <= Time.timeSinceLevelLoad)
            {
                ExecuteCommand();
                if (CommandLog.commands.Count > 0)
                {
                    _commandArgs = CommandLog.commands.Dequeue();
                    //Debug.Log(CommandLog.commands.Count);
                }
                else
                {
                    _commandArgs.command = null;
                    CommandLog.commands = null;
                }
            }
            
        }
    }

    public void ExecuteCommand()
    {
        _commandArgs.command.Execute();
        _commandArgs.command = null;
        _commandArgs.executionTime = 0.0f;
    }
}
