using UnityEngine;

public abstract class PlayerGravitySubscriber : MonoBehaviour, ISubscriber
{
    public void Subscribe()
    {
        //subscribe to different events
        PlayerMovement.ChangeGravity += ChangeGravity;
    }
    public void Unsubscribe()
    {
        //Unsubscribe to different events
        PlayerMovement.ChangeGravity += ChangeGravity;
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
    public virtual void ChangeGravity(float rotation) { }
}
