using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields
    [SerializeField] Animator anim;
    [SerializeField] float speed;
    [SerializeField] Transform[] targets;

    int targetNum;
    bool isMoving;
    #endregion

    #region Events
    public static event Action SuccussDash;
    public static event Action DashEvent;
    #endregion

    #region Properties
    public bool Stop { get; set; }
    public Animator Animator { get { return anim; } }
    #endregion

    #region UnityMethods
    void Update() 
    {
        //Check if player is not stopped (Lost/Win/Settings)
        if(Stop) return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isMoving)
        {
            isMoving = true;
            DashEvent?.Invoke();
        }

        //Check if player should move
        if(!isMoving) return;

        Dash();
    }
    #endregion

    #region PrivateMethods
    void Dash()
    {
        //Handle animator
        if(anim!= null) { anim.SetBool("Dash", true); }

        //Move the player to target point
        transform.position = Vector3.MoveTowards(transform.position, targets[targetNum].position, speed * Time.deltaTime);

        //Check if the player has reached the target point
        if (transform.position == targets[targetNum].position)
        {
            isMoving = false;
            targetNum = (targetNum + 1) % targets.Length;
            SuccussDash?.Invoke();

            //Handle Animator
            if (anim != null) { anim.SetBool("Dash", false); }
        }
    }
    #endregion
}
