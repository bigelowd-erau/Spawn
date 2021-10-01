using System;
using UnityEngine;
using System.Collections.Generic;

public class Invoker: MonoBehaviour
{
    private Command m_Command;

    public void OnEnable()
    {
        Client.OnPlayerCommandInput += SetCommand;
    }

    public void SetCommand(Command command)
    {
        m_Command = command;
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
            CommandLog.commands.Enqueue(m_Command);
            m_Command = null;
        }
    }

    public void OnDisable()
    {
        Client.OnPlayerCommandInput -= SetCommand;
    }
}
