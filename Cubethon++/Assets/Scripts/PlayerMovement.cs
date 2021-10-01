using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //the player object's rigid body
    private Rigidbody rb;
    public float forwardForce;
    public float sidewaysforce;
    //a sudo player rotation that is set when a new floor is touched
    public float playerRotation = 0; //io 0, 60, 120, 180
    //the calculated radial rotation
    float playerRadRot;

    public delegate void GravityChange(float playerRotation);
    public static event GravityChange ChangeGravity;

    void OnEnable()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        playerRotation = 0;
        PlayerCollision.OnHitObstacle += Disable;
        PlayerCollision.OnFloorCollision += CalcNewGravity;
    }
    public void Disable()
    {
        //this.enabled = false;
        Destroy(this);
    }
    private void OnDisable()
    {
        PlayerCollision.OnHitObstacle -= Disable;
        PlayerCollision.OnFloorCollision -= CalcNewGravity;
    }

    // Fixedupdate is called at a fixed time interval
    void FixedUpdate()
    {
        //adds a consistent forward force to the player object
        rb.AddForce(0,0,forwardForce * Time.deltaTime);
        //get current
        playerRadRot = Mathf.Deg2Rad * playerRotation;
        
    }

    public void MoveLeft()
    {
        rb.AddForce(-sidewaysforce * Time.deltaTime * Mathf.Cos(playerRadRot), -sidewaysforce * Time.deltaTime * Mathf.Sin(playerRadRot), 0, ForceMode.VelocityChange);
    }

    public void MoveRight()
    {
        rb.AddForce(sidewaysforce * Time.deltaTime * Mathf.Cos(playerRadRot), sidewaysforce * Time.deltaTime * Mathf.Sin(playerRadRot), 0, ForceMode.VelocityChange);
    }

    public void CalcNewGravity(Collision collision)
    {
        //set player rotation to the floor's rotation
        playerRotation = collision.collider.transform.rotation.eulerAngles.z;
        //change the gravity towards the direction of the players new rotation.
        ChangeGravity(playerRotation);
    }
}
