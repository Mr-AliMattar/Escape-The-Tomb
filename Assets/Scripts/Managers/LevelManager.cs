using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Fields
    [SerializeField] Player player;
    [SerializeField] WindowPop windowPop;
    [SerializeField] Goal goal;
    [SerializeField] GoalBar goalBar;
    [SerializeField] StopWatch stopWatch;
    [SerializeField] SpawnControl spawnControl;
    [SerializeField] GameManager gameManager;
    #endregion

    #region Unity Methods
    void Awake()
    {
        //Stop the game and start countdown
        StartCountdown();
    }
    void OnEnable()
    {
        LostTrigger.Lost += PlayerLost;
        Player.SuccussDash += PlayerEarnPoint;
        Player.DashEvent += DisableMessages;
    }
    void OnDisable()
    {
        LostTrigger.Lost -= PlayerLost;
        Player.SuccussDash -= PlayerEarnPoint;
        Player.DashEvent -= DisableMessages;
    }
    #endregion

    #region Methods
    void PlayerLost()
    {
        windowPop.PopRestartOut();
        windowPop.PopLostMessage();
        stopWatch.StopGame();
    }
    void PlayerEarnPoint()
    {
        //Cheack to Spawn the flag or not
        foreach (var trigger in spawnControl.Triggers)
        {
            trigger.SpawnFlag = goal.SpawnFinish;
        }
        //Add points
        goal.PointsHandler();
        //Increase progress bar value
        goalBar.Progress++;

        //Add Jewellery
        gameManager.AddJewellery(1);

        //Player Won the Game
        if (goal.Won) { windowPop.PopWinMessage(); windowPop.PopWinOut(); stopWatch.StopGame(true); 
            goal.Won = false; goalBar.ColorNexLvlImage(); gameManager.AddLevel(1); player.Animator.SetTrigger("Won"); }
    }
    public void StartCountdown()
    {
        stopWatch.PauseTimer = 4;
        stopWatch.StopGame(true);
        StartCoroutine(stopWatch.Countdown());
        StartCoroutine(windowPop.PopMessage(stopWatch.PauseTimer));
    }
    public void PauseGame()
    {
        if (stopWatch.IsStopped)
        {
            if (stopWatch.PauseTimer > 0)
            {
                StopAllCoroutines();
                stopWatch.PauseTimer = 0;
                return;
            }
            stopWatch.PauseTimer = 4;
            StartCountdown();
            return;
        }
        stopWatch.StopGame();
    }
    void DisableMessages()
    {
        //display the message
        windowPop.PopMessage(string.Empty);
    }
    #endregion
}
