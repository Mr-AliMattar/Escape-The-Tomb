using UnityEngine;

namespace Obstacle
{
    public class Swing : MonoBehaviour
    {
        #region Fields
        [SerializeField] float swingSpeed;
        [SerializeField] float swingAngle;
        [SerializeField] SwingType swingType;

        float currentAngle = 0f;
        Vector3 swingRotation;
        int direction = 1;
        #endregion

        #region UnityMethods
        private void Update()
        {
            //Calculate the amount to swing
            float swingAmount = swingSpeed * Time.deltaTime * direction;

            //Check if angle amount is bigger than the swingAnle (target angle)
            if (currentAngle + swingAmount > swingAngle)
            {
                swingAmount = swingAngle - currentAngle;
                direction = -1;
            }
            else if (currentAngle + swingAmount < -swingAngle)
            {
                swingAmount = -swingAngle - currentAngle;
                direction = 1;
            }

            //Update the current swing angle and apply the rotation to the object
            currentAngle += swingAmount;

            //Swing the abostcale around X axis if IsXAxis true/ swing the obstcale around Y axis if IsXAxis false
            switch (swingType)
            {
                case SwingType.xAxis:
                    swingRotation = new Vector3(currentAngle, 0f, 0f);
                    break;
                case SwingType.yAxis:
                    swingRotation = new Vector3(0f, currentAngle, 0f);
                    break;
                case SwingType.zAxis:
                    swingRotation = new Vector3(0f, 0f, currentAngle);
                    break;
            }
                    transform.localRotation = Quaternion.Euler(swingRotation);
        }
        #endregion
    }
}
