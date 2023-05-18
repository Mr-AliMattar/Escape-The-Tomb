using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject[] obstaclePrefabs;           //obstacle prefabs
    [SerializeField] GameObject[] environmentPrefabs;       //environment prefabs
    [SerializeField] int obstaclePoolSize;                  //number of prefabs that will spawn
    [SerializeField] int enviroenmentPoolSize;                  //number of prefabs that will spawn

    [Space]
    [SerializeField] int minPrefRange = 0;                      //minimum Obstacle Prefabs Range
    [SerializeField] int maxPrefRange = 0;                      //maximum Obstacle Prefabs Range

    List<GameObject> obstaclePool = new List<GameObject>();
    List<GameObject> enivronmentPool = new List<GameObject>();
    #endregion

    #region Properties
    public int MinPrefRange { get { return minPrefRange; } set { minPrefRange = value; } }
    public int MaxPrefRange { get { return maxPrefRange; } set { maxPrefRange = value; } }
    #endregion

    #region UnityMethods
    void Start()
    {
        //Instantiate each obstacle prefab
        for (int ii = 0; ii < maxPrefRange; ii++)
        {
            for (int i = 0; i < obstaclePoolSize; i++)
            {
                GameObject obstacle = Instantiate(obstaclePrefabs[ii], transform);
                obstacle.SetActive(false);
                obstaclePool.Add(obstacle);
            }
        }
        //Instantiate each environment prefab
        foreach (var environmentObject in environmentPrefabs)
        {
            for (int i = 0; i < enviroenmentPoolSize; i++)
            {
                GameObject environment = Instantiate(environmentObject, transform);
                environment.SetActive(false);
                enivronmentPool.Add(environment);
            }
        }
    }
    #endregion

    #region Obstacle Methods
    public GameObject GetObstacle()
    {
        // Find all inactive obstacle in the pool
        List<GameObject> inactiveObstacles = new List<GameObject>();

        foreach (GameObject obstacle in obstaclePool)
        {
            if (!obstacle.activeInHierarchy)
            {
                inactiveObstacles.Add(obstacle);
            }
        }

        // If all obstacles are active, create a new one and add it to the pool
        if (inactiveObstacles.Count <= 0)
        {
            GameObject newObstacle = Instantiate(obstaclePrefabs[Random.Range(0, maxPrefRange)], transform);
            newObstacle.SetActive(true);
            obstaclePool.Add(newObstacle);
            return newObstacle;
        }

        // Return a random inactive obstacle from the pool
        int randomIndex = Random.Range(0, inactiveObstacles.Count);
        GameObject randomObstacle = inactiveObstacles[randomIndex];
        randomObstacle.SetActive(true);
        return randomObstacle;
    }

    public void ReturnObstacle(GameObject obstacle)
    {
        // Deactivate the obstacle
        obstacle.SetActive(false);
    }
    #endregion

    #region Environment
    public GameObject GetEnvironment()
    {
        // Find all inactive environment in the pool
        List<GameObject> inactiveenvironments = new List<GameObject>();

        foreach (GameObject environment in enivronmentPool)
        {
            if (!environment.activeInHierarchy)
            {
                inactiveenvironments.Add(environment);
            }
        }

        // If all environments are active, create a new one and add it to the pool
        if (inactiveenvironments.Count <= 0)
        {
            GameObject newEnvironment = Instantiate(environmentPrefabs[Random.Range(0, environmentPrefabs.Length)], transform);
            newEnvironment.SetActive(true);
            enivronmentPool.Add(newEnvironment);
            return newEnvironment;
        }

        // Return a random inactive environment from the pool
        int randomIndex = Random.Range(0, inactiveenvironments.Count);
        GameObject randomEnvironment = inactiveenvironments[randomIndex];
        randomEnvironment.SetActive(true);
        return randomEnvironment;
    }
    public void ReturnEnvironment(GameObject environment)
    {
        // Deactivate the environment
        environment.SetActive(false);
    }
    #endregion
}
