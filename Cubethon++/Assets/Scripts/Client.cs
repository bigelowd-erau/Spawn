using UnityEngine;

public class Client : ClientSubscriber
{
    private PlayerController m_PlayerReciever;

    public delegate void PlayerCommandInput(Command command);
    public static event PlayerCommandInput OnPlayerCommandInput;

    public override void OnEnable()
    {
        base.OnEnable();
        m_PlayerReciever = new PlayerReciever(/*GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>()*/);
    }

    public void Update()
    {
        if (Input.GetKey("a"))
        {
            Command playerCommand = new MoveLeftCommand(m_PlayerReciever);
            OnPlayerCommandInput?.Invoke(playerCommand);
        }
        if (Input.GetKey("d"))
        {
            Command playerCommand = new MoveRightCommand(m_PlayerReciever);
            OnPlayerCommandInput?.Invoke(playerCommand);
        }
    }

    public override void Disable()
    {
        Destroy(this);
    }
}
