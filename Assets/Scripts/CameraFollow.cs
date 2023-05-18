using UnityEngine;
using UnityEngine.LowLevel;

public class CameraFollow : MonoBehaviour
{
    #region Fields
    [SerializeField] Transform target;                  //Target to follow
    [SerializeField] Animator anim;                     //Camera Animator

    Vector3 offset;                                     //Calculate the camera position
    #endregion

    #region Methods
    void OnEnable()
    {
        Player.DashEvent += DashAnimation;
        Goal.PlayerWon += WinAnimation;
    }
    void OnDisable()
    {
        Player.DashEvent -= DashAnimation;
        Goal.PlayerWon -= WinAnimation;
    }
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
    void DashAnimation()
    {
        anim.SetTrigger("Zoom");
    }
    void WinAnimation()
    {
        anim.SetTrigger("Win");
    }
    #endregion
}
