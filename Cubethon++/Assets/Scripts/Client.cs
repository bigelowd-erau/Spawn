using UnityEngine;

public class Client : MonoBehaviour
{
    private PlayerController m_PlayerReciever;
    public PlayerMovement pm;

    public delegate void PlayerCommandInput(Command command);
    public static event PlayerCommandInput OnPlayerCommandInput;

    private void OnEnable()
    {
        m_PlayerReciever = new PlayerReciever(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>());
        PlayerCollision.OnHitObstacle += Disable;
    }

    private void Update()
    {
        if (Input.GetKey("a"))
        {
            Command playerCommand = new MoveLeftCommand(m_PlayerReciever);
            OnPlayerCommandInput(playerCommand);
        }
        if (Input.GetKey("d"))
        {
            Command playerCommand = new MoveRightCommand(m_PlayerReciever);
            OnPlayerCommandInput(playerCommand);
        }
    }

    public void Disable()
    {
        Destroy(this);
    }

    private void OnDisable()
    {
        PlayerCollision.OnHitObstacle -= Disable;
    }
}
