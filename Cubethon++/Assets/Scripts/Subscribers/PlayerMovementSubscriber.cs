using UnityEngine;

public abstract class PlayerMovementSubscriber : MonoBehaviour, ISubscriber
{
    public void Subscribe()
    {
        //subscribe to different events
        //event.eventhandler += SetCommand;
        PlayerCollision.OnHitObstacle += Disable;
        PlayerCollision.OnFloorCollision += CalcNewGravity;
    }
    public void Unsubscribe()
    {
        //Unsubscribe to different events
        PlayerCollision.OnHitObstacle -= Disable;
        PlayerCollision.OnFloorCollision -= CalcNewGravity;
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
    public virtual void Disable() { }
    public virtual void CalcNewGravity(Collision collision) { }
}
