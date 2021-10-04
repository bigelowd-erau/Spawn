using UnityEngine;

public class GameManagerSubscriber : MonoBehaviour, ISubscriber
{
    public void Subscribe()
    {
        //subscribe to different events
        PlayerCollision.OnHitObstacle += EndGame;
    }
    public void Unsubscribe()
    {
        //Unsubscribe to different events
        PlayerCollision.OnHitObstacle -= EndGame;
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
    public virtual void EndGame() { }
}
