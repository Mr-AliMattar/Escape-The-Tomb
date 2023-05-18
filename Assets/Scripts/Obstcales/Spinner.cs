using UnityEngine;

namespace Obstacle
{
    public class Spinner : MonoBehaviour
    {
        #region Fields
        [SerializeField] float spinSpeed;
        #endregion

        #region UnityMethods
        void Update()
        {
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
        #endregion
    }
}
