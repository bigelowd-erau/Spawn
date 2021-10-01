using UnityEngine;

public class Client : MonoBehaviour
{
    private PlayerController m_PlayerReciever;
    public PlayerMovement pm;

    public delegate void PlayerCommandInput(Command command);
    public static event PlayerCommandInput OnPlayerCommandInput;

    public delegate void ApplyPlayerCommand();
    public static event ApplyPlayerCommand ExecutePlayerCommand;

    private void OnEnable()
    {
        m_PlayerReciever = new PlayerReciever(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>());
        //Debug.Log(GameObject.FindGameObjectsWithTag("Player").Length);
        //m_PlayerReciever = new PlayerReciever(pm);
        PlayerCollision.OnHitObstacle += Disable;
    }

    private void Update()
    {
        if (Input.GetKey("a"))
        {
            Command playerCommand = new MoveLeftCommand(m_PlayerReciever);
            //Invoker invoker = new Invoker();

            OnPlayerCommandInput(playerCommand);

            //invoker.SetCommand(playerCommand);
            //invoker.ExecuteCommand();
        }
        if (Input.GetKey("d"))
        {
            Command playerCommand = new MoveRightCommand(m_PlayerReciever);
            //Invoker invoker = new Invoker();
            OnPlayerCommandInput(playerCommand);

            //invoker.SetCommand(playerCommand);
            //invoker.ExecuteCommand();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ExecutePlayerCommand();
    }

    public void Disable()
    {
        //this.enabled = false;
        Destroy(this);
    }

    private void OnDisable()
    {
        PlayerCollision.OnHitObstacle -= Disable;
    }
}
