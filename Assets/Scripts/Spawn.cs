using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    #region Fields
    [SerializeField] ObjectPool pool;              //object pool
    
    [Space]
    [Header("Obstcale Spawn Settings")]
    [SerializeField] int obstcaleSpawnCounts;               //the obstcale spawn's count
    [SerializeField] float obstcaleMinz, obstcaleMaxz;              //obstcale will spawn within this range
    [Header("Environment Spawn Settings")]
    [SerializeField] int environmentSpawnCounts;               //the obstcale spawn's count
    [SerializeField] float environmentMinz, environmentMaxz;              //obstcale will spawn within this range

    List<GameObject> obstcaleSpawnList= new List<GameObject>();
    List<GameObject> environmentspawnList= new List<GameObject>();
    #endregion

    #region Properties
    public int ObstcaleSpawnCounts { get { return obstcaleSpawnCounts; } set { obstcaleSpawnCounts = value; } }
    public float ObstcaleMinz { get { return obstcaleMinz; } set { obstcaleMinz = value; } }
    public float ObstcaleMaxz { get { return obstcaleMaxz; } set { obstcaleMaxz = value; } }
    #endregion

    #region UnityMethods
    void OnEnable() 
    {
        //Obstacle Spawn
        for (int i = 0; i < obstcaleSpawnCounts; i++)
        {
            GameObject spawnObject = pool.GetObstacle();

            //Calculate a random pos range according to fields
            float zAxis = Random.Range(transform.position.z - obstcaleMinz, transform.position.z + obstcaleMaxz);

            //Spawn and add the object to list
            spawnObject.transform.position = new Vector3(0f, 0f, zAxis);

            //Check if the spawnd object isn't in list
            if (!obstcaleSpawnList.Contains(spawnObject))
            {
                obstcaleSpawnList.Add(spawnObject);
            }
        }

        //Environment Spawn
        for (int i = 0; i < environmentSpawnCounts; i++)
        {
            GameObject spawnObject = pool.GetEnvironment();

            //Calculate a random pos range according to fields
            float zAxis = Random.Range(transform.position.z - environmentMinz, transform.position.z + environmentMaxz);

            //Spawn and add the object to list
            spawnObject.transform.position = new Vector3(0f, 0f, zAxis);

            //Check if the spawnd object isn't in list
            if (!environmentspawnList.Contains(spawnObject))
            {
                environmentspawnList.Add(spawnObject);
            }
        }
    }
    void OnDisable()
    {
        // Return all spawned obstacles to the object pool
            foreach (GameObject obstacle in obstcaleSpawnList)
            {
            if (obstacle != null)
                  pool.ReturnObstacle(obstacle);
            }
        obstcaleSpawnList.Clear();

        //Return all spawned environment to the object pool
        foreach (GameObject environment in environmentspawnList)
        {
            if (environment != null)
                pool.ReturnEnvironment(environment);
        }
        environmentspawnList.Clear();
    }
    #endregion
}
