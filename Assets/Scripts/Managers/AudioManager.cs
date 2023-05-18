using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Fields
    [SerializeField]
    AudioClip dashAudio;
    [SerializeField]
    AudioClip lostAudio;
    [SerializeField]
    AudioClip wonAudio;
    [SerializeField]
    AudioClip buttonAudio;

    AudioSource audioSource;
    #endregion

    #region Properties
    public float Volume
    {
        set
        {
            audioSource.volume = value;
        }
    }
    #endregion

    #region UnityMethods
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnEnable()
    {
        Player.DashEvent += PlayDashAudio;
        LostTrigger.Lost += PlayLostAudio;
        Goal.PlayerWon += PlayWonAudio;
        GameManager.OnButton += PlayButtonAudio;
    }
    void OnDisable()
    {
        Player.DashEvent -= PlayDashAudio;
        LostTrigger.Lost -= PlayLostAudio;
        Goal.PlayerWon -= PlayWonAudio;
        GameManager.OnButton -= PlayButtonAudio;
    }
    #endregion

    #region PrivateMethods
    void PlayDashAudio()
    {
        audioSource.clip = dashAudio;
        audioSource.Play();
    }
    void PlayLostAudio()
    {
        audioSource.clip = lostAudio;
        audioSource.Play();
    }
    void PlayWonAudio()
    {
        audioSource.clip = wonAudio;
        audioSource.Play();
    }
    void PlayButtonAudio()
    {
        audioSource.clip = buttonAudio;
        audioSource.Play();
    }
    #endregion
}
