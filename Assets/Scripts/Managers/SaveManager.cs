using UnityEngine;

public class SaveManager
{
    #region Fields
    private SettingsData settings = new SettingsData();
    #endregion

    #region Properties
    public float SoundVolume
    {
        get { return settings.soundVolume; }
        set { settings.soundVolume = value; }
    }
    public int Jewellery
    {
        get { return settings.jewellery; }
        set { settings.jewellery= value; }
    }
    public int Level
    {
        get { return settings.level; }
        set { settings.level = value; }
    }
    #endregion

    #region Methods
    // Save Settings to Object as JSON
    public void SaveData()
    {
        string saveJson = JsonUtility.ToJson(settings);
        PlayerPrefs.SetString("Data", saveJson);
        PlayerPrefs.Save();
    }
    // Load Settings from Object as JSON
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Data"))
        {
            string saveJson = PlayerPrefs.GetString("Data");
            settings = JsonUtility.FromJson<SettingsData>(saveJson);
        }
        else { SaveData(); }
    }
    #endregion
}
