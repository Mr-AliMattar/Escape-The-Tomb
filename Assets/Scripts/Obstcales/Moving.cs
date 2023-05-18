using UnityEngine;

namespace Obstacle {
    public class Moving : MonoBehaviour
    {
        #region Fields
        [SerializeField] float speed;
        [SerializeField] Transform startPoint;
        [SerializeField] Transform endPoint;

        Vector3 targetPos;
        bool reset;                     //reset target position
        #endregion

        #region UnityMethods
        void OnEnable()
        {
            targetPos = startPoint.position;
        }
        void OnDisable()
        {
            reset= false;
        }
        void Update()
        {
            if (!reset)
            {
                targetPos = startPoint.position;
                reset = true;
            }
            //Move obstacle to target position
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            //Check if the obstacle reached the targe pos
            if (transform.position != targetPos) return;

            //Switch position back and fourth
            if (targetPos == startPoint.position)
            {
                targetPos = endPoint.position;
            }
            else
            if (targetPos == endPoint.position)
            {
                targetPos = startPoint.position;
            }
        }
        #endregion
    }
}
