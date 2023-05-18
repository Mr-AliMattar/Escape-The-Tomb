using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    #region Fields
    [SerializeField] int lastLevel;                                  //Last level in the scene
    [SerializeField] int nextSceneNum;                              //Next scene that will load after finshing the game
    [SerializeField] int[] lvlsGoalPoints;                          //How many point does the player need to win in each level

    int points;
    int lvl;
    #endregion

    #region Events
    public static event Action PlayerWon;
    #endregion

    #region Properties
    public bool Won { get; set; }
    public int Lvl { get { return lvl; } set { lvl = value; } }
    public int LastLevel { get { return lastLevel; } set { lastLevel = value; } }
    public int GoalPoints { get { return lvlsGoalPoints[lvl]; } }
    public bool SpawnFinish                                           //Check points to Spawn The Flag
    {
        get
        {
            int finishSpawnNumber;
            finishSpawnNumber = lvlsGoalPoints[lvl] -3;
            if (points == finishSpawnNumber)
            {
                return true;
            }
            return false;
        }
    }
    #endregion

    #region Public Methods
    public void PointsHandler()
    {
        if (lvlsGoalPoints[lvl] == points)
        {
            lvl++;
            Won= true;
            PlayerWon?.Invoke();
        }
        else
        {
            points++;
        }
    }
    #endregion
}
