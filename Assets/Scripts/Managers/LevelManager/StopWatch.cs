using System.Collections;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    #region Fields
    [SerializeField] Player player;
    [SerializeField] float pauseTimer;                   //Countdown pauseTimer then start the game


    #endregion

    #region Properties
    public float PauseTimer { get { return pauseTimer; } set { pauseTimer = value; } }
    public bool IsStopped { get; set; }
    #endregion

    #region PublicMethods
    public void StopGame(bool stop)
    {
        player.Stop = stop;
        IsStopped= stop;
    }
    public void StopGame()
    {
        player.Stop = true;
        IsStopped= true;
    }
    public void StopPlayer()
    {
        player.Stop = true;
    }
    public IEnumerator Countdown()
    {
        while (pauseTimer > 0)
        {
            pauseTimer -= Time.deltaTime;

            yield return null;
        }
        StopGame(false);
    }
    #endregion
}
