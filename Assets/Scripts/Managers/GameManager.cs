using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Fields
    [SerializeField] AudioManager audioManager;
    [SerializeField] Slider soundSlider;
    [SerializeField] Goal goal;
    [SerializeField] SpawnControl spawnControl;
    [SerializeField] GoalBar goalBar;

    SaveManager saveManager;
    #endregion

    #region Events
    public static event Action OnButton;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        Time.timeScale = 1;
        //Intialize Save manager
        saveManager = new SaveManager();
        //Load Save
        saveManager.LoadData();

        //Load Game Settings and Set it to every class need it
        audioManager.Volume = saveManager.SoundVolume;
        soundSlider.value = saveManager.SoundVolume;

        //In case you are not in main menu
        if (goal != null)
        {
            //go to main menu
            if (saveManager.Level > goal.LastLevel) { saveManager.Level = goal.LastLevel; saveManager.SaveData(); LoadScene(0); return; }
            goal.Lvl = saveManager.Level;
            spawnControl.Level = saveManager.Level;
            goalBar.CurrentLevel = goal.Lvl;
            goalBar.LastLevel = goal.LastLevel;
            goalBar.GoalPoints = goal.GoalPoints;
        }
    }
    #endregion

    #region Methods
    // Load a scene using sceneNum
    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
    // Quit the App
    public void Quit()
    {
        Application.Quit();
    }
    // To simply active and deactive UI-s
    public void SwitchGameObjects(GameObject UI)
    {
        UI.SetActive(!UI.activeSelf);
    }
    public void ButtonSFX()
    {
        OnButton?.Invoke();
    }
    public void ResetLevel()
    {
        saveManager.Level = 0;
        saveManager.SaveData();
    }
    // Change SoundVolume value to get called by GameManager
    public void ChangeSound(float value)
    {
        saveManager.SoundVolume = value;
        saveManager.SaveData();
        audioManager.Volume = value;
    }
    public void AddJewellery(int jewellery)
    {
        saveManager.Jewellery += jewellery;
        saveManager.SaveData();
    }
    public void AddLevel(int level)
    {
        saveManager.Level += level;
        saveManager.SaveData();
    }
    #endregion
}
