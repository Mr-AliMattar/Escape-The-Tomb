using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject spawnObject;            //The spawn or despawn object
    [SerializeField] GameObject flagObject;             //The finish line object
    
    [Header("Settings")]
    [SerializeField] Transform spawnTransform;          //Where the Object will be spawnd
    [SerializeField] Transform flagTransform;          //Where the flag will be spawnd
    [SerializeField] bool isDespawn;                    //if this is checked it will deActive the spawn Object and move it to the pool
    #endregion

    #region Properties
    public bool SpawnFlag { get; set; }
    #endregion

    #region UnityMethods
    void OnTriggerEnter(Collider collider) 
    {
        if (collider.tag == ("Player"))
        {
            if (isDespawn)
            {
                spawnObject.SetActive(false);
            }
            else
            {
                spawnObject.transform.position= spawnTransform.position;
                spawnObject.SetActive(true);
                if (SpawnFlag)
                {
                    flagObject.transform.position = flagTransform.position;
                    flagObject.SetActive(true);
                }
            }
        }
    }
    #endregion
}
