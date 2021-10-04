using UnityEngine;

public class PlayerReciever : PlayerController
{
    //public PlayerMovement pm;

    public PlayerReciever(/*PlayerMovement pm*/)
    {
        //this.pm = pm;
    }
    public override void MoveLeft()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MoveLeft();
        //Debug.Log("Move Left");
    }

    public override void MoveRight()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MoveRight();
        //Debug.Log("Move Right");
    }
}
