using System;
using UnityEngine;

public class LostTrigger : MonoBehaviour
{
    #region Fields
    [SerializeField]
    Vector3 forceDirections;                //The amount of force in every direction (X,Y,Z)
    #endregion

    #region Events
    public delegate void Message(string message);

    public static event Action Lost;
    #endregion

    #region Methods
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            ThrowPlayer(collision.rigidbody);
            Lost?.Invoke();
        }
    }

    // Push/Throw player to make it funny
    void ThrowPlayer(Rigidbody playerBody)
    {
        playerBody.AddForce(forceDirections, ForceMode.Impulse);
    }
    #endregion
}
