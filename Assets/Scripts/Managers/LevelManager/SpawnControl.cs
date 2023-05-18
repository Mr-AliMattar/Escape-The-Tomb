using System.Linq;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    //Warning!!! {elments number should be the same as levels number}

    #region Fields
    [SerializeField] ObjectPool pool;
    [SerializeField] Spawn[] spawns;
    [SerializeField] SpawnTrigger[] triggers;
    
    [Space]
    [SerializeField] int[] minPrefRange;                    //minimum Obstacle Prefabs Range each level
    [SerializeField] int[] maxPrefRange;                    //maximum Obstacle Prefabs Range each level
    [SerializeField] int[] obstaclesCount;                  //Obstacles count each level
    [SerializeField] float[] obstcaleMinz, obstcaleMaxz;                  //Obstacles position range each level

    int level;
    #endregion

    #region Properties
    public int Level { get { return level; } set { level = value; } }
    public SpawnTrigger[] Triggers { get { return triggers; } }
    #endregion

    #region UnityMethods
    void OnEnable()
    {
        if (BadSettings)
        {
            level = SaftyNumber -1;
        }
        pool.MinPrefRange = minPrefRange[level];
        pool.MaxPrefRange = maxPrefRange[level];
        foreach (var spawn in spawns)
        {
            spawn.ObstcaleSpawnCounts = obstaclesCount[level];
            spawn.ObstcaleMinz = obstcaleMinz[level];
            spawn.ObstcaleMaxz = obstcaleMaxz[level];
        }
    }
    void Start()
    {
        foreach (var spawn in spawns)
        {
            spawn.gameObject.SetActive(true);
        }
    }
    #endregion

    #region PrivateMethod
    //If bad settings are true. choose the most approprite way for settings
    int SaftyNumber
    {
        get
        {
            int lowestLength = new[] { minPrefRange.Length, maxPrefRange.Length, obstaclesCount.Length, obstcaleMinz.Length, obstcaleMaxz.Length }.Min();
            return lowestLength;
        }
    }
    //Check if Levels number are bigger than elments number
    bool BadSettings
    {
        get
        {
            if (minPrefRange.Length > level && maxPrefRange.Length > level &&
                obstaclesCount.Length > level && obstcaleMinz.Length > level && obstcaleMaxz.Length > level)
            {
                return false;
            }
            return true;
        }
    }
    #endregion
}
