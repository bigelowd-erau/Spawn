using System;
using UnityEngine;
using System.Collections.Generic;

public class Invoker: MonoBehaviour
{
    private Command m_Command;
    //public Queue<Command> commandQueue;
    //public CommandDisplay commandDisplay;

    public delegate void OnCommandExecution(Command m_Command);
    public static event OnCommandExecution CommandExecuted;

    public void OnEnable()
    {
        //commandQueue = new Queue<Command>();
        Client.OnPlayerCommandInput += SetCommand;
        //Client.ExecutePlayerCommand += ExecuteCommand;
    }

    public void SetCommand(Command command)
    {
        m_Command = command;
        //commandDisplay.AddCommandToDisplay(m_Command); ;
    }

    public void FixedUpdate()
    {
        ExecuteCommand();
    }

    public void ExecuteCommand()
    {
        if (m_Command != null)
        { 
            m_Command.Execute();
            //CommandExecuted(m_Command);
            CommandLog.commands.Enqueue(m_Command);
            m_Command = null;
        }
    }

    public void OnDisable()
    {
        //commandQueue = new Queue<Command>();
        Client.OnPlayerCommandInput -= SetCommand;
        //Client.ExecutePlayerCommand -= ExecuteCommand;
    }
}
