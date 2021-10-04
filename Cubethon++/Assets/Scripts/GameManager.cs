
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GameManagerSubscriber
{
    bool gameHasEnded = false;
    //the time in seconds delay before causing the scene to reset
    public float restartDelay = 1f;
    //the complete level panel
    public GameObject completeLevelScreen;
    public delegate void SetCommand(CommandArgs commandArgs);
    public static event SetCommand SendSetCommand;

    private delegate void RunGame();
    RunGame GameRun;

    public override void OnEnable()
    {
        base.OnEnable();
        if (CommandLog.commands != null)
        {
            GameRun = ReplayRun;
        }
        else
        {
            CommandLog.commands = new Queue<CommandArgs>();
            GameRun = NormalRun;
        }
    }

    private void Start()
    {
        SendSetCommand?.Invoke(CommandLog.commands.Dequeue());
    }

    //called when the end object is triggered
    public void CompleteLevel()
    {
        //enables the level complete panel
        //causing the panel to overlay the game
        completeLevelScreen.SetActive(true);
    }

    public void FixedUpdate()
    {
        GameRun();
    }

    //Called when the player loses the level
    //hits obstacle or falls off map
    public override void EndGame()
    {
        //checks game has not previously quit    
        if (gameHasEnded == false)
        {
            //set game as ended
            gameHasEnded = true;
            //call the restart function after the defined restart delay
            Invoke("Restart", restartDelay);
        }
        
    }

    private void NormalRun()
    {

    }

    private void ReplayRun()
    {
        
    }

    //reloads the current level
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
