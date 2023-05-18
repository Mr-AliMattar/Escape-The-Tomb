using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Fields
    [SerializeField] Transform target;                  //Target to follow

    Vector3 offset;                                     //Calculate the camera position
    #endregion

    #region UnityMethods
    private void Start()
    {
        offset = transform.position - target.position;
    }
    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(0f, 0f, target.position.z) + offset;
        }
    }
    #endregion
}
