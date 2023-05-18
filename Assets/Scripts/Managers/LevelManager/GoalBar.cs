using UnityEngine;
using UnityEngine.UI;

public class GoalBar : MonoBehaviour
{
    #region Fields
    [SerializeField] Text currentLvlText;           //Current Text UI from goal bar
    [SerializeField] Text nextLvlText;              //Next Text UI from goal bar
    [SerializeField] Slider progressBar;            //Slider UI/Progress bar from goal bar

    [Space]
    [SerializeField] Image currentLvlImage;         //Current Image UI from goal bar
    [SerializeField] Image nextLvlImage;            //Current Image UI from goal bar
    [SerializeField] Image progressBarImage;            //Image fill from slider/Progress bar from goal bar
    [SerializeField] Sprite winImage;

    Color newColor;
    #endregion

    #region Properties
    public int CurrentLevel { get; set; }
    public int GoalPoints { get; set; }
    public int LastLevel { get; set; }
    public float Progress { get { return progressBar.value; } set { progressBar.value = value; } }
    #endregion

    #region Methods
    void Start() 
    {
        //Color the Current level image and the slider
        newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        currentLvlImage.color = newColor;
        progressBarImage.color = newColor;

        int currentLevel = CurrentLevel + 1;
        currentLvlText.text = currentLevel.ToString();
        if(currentLevel >= LastLevel)
        {
            nextLvlText.text = string.Empty;
            nextLvlImage.sprite = winImage;
        } else
        {
            int nextLevel = currentLevel + 1;
            nextLvlText.text = nextLevel.ToString();
        }
        progressBar.maxValue = GoalPoints;
    }

    public void ColorNexLvlImage()
    {
        nextLvlImage.color = newColor;
    }
    #endregion
}
