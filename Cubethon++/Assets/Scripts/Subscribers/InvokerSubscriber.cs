using UnityEngine;

public abstract class InvokerSubscriber : MonoBehaviour, ISubscriber
{
    public void Subscribe()
    {
        //subscribe to different events
        //event.eventhandler += SetCommand;
        if (CommandLog.commands != null)
            GameManager.SendSetCommand += SetCommand;
        else
            Client.OnPlayerCommandInput += SetCommand;
    }
    public void Unsubscribe()
    {
        //Unsubscribe to different events
        Client.OnPlayerCommandInput -= SetCommand;
        GameManager.SendSetCommand -= SetCommand;
    }
    public virtual void OnEnable()
    {
        Subscribe();
    }
    //allows for overiding incase more is needed OnEnable in child
    public virtual void OnDisable()
    {
        Unsubscribe();
    }
    //function will be ovveridden by child
    public virtual void SetCommand(Command command) { }
    public virtual void SetCommand(CommandArgs commandArg) { }
}
