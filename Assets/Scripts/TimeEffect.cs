using UnityEngine;

public class TimeEffect : MonoBehaviour
{
    [SerializeField] float timeEffect;                  //the more the faster game will be, the fewer the slower. Normal Time is (1)
    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == ("Player"))
        {
            Time.timeScale = timeEffect;
        }
    }
}
