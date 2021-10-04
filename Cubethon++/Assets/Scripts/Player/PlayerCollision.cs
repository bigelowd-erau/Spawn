
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //public PlayerMovement movement;
    //public PlayerGravity playerGravity;
    //public Client client;

    public delegate void HitObstacle();
    public static event HitObstacle OnHitObstacle;

    public delegate void CollidedFloor(Collision collision);
    public static event CollidedFloor OnFloorCollision;

    //when the player collides with another object
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            OnFloorCollision?.Invoke(collision);
        }
        else if (collision.collider.tag == "Obstacle")
        {
            collision.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            //Call hit Obstacle event
            OnHitObstacle?.Invoke();
            Destroy(this);
        }
    }
}
