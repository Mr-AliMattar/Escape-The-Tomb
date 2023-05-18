using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WindowPop : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject restartMenu;             //Menu will pop up for user to choose to play again or not
    [SerializeField] GameObject WinMenu;             //Menu will pop up for user to choose to play again or not
    [SerializeField] Text message;                       //UI Text to show messages like you win/lose etc...

    bool used;                                    //used the stop watch before or not
    #endregion

    #region PublicMethods
    //Active the (restartMenu) Object
    public void PopRestartOut()
    {
        restartMenu.SetActive(true);
    }
    public void PopWinOut()
    {
        WinMenu.SetActive(true);
    }
    public void PopLostMessage()
    {
        if (message.text == string.Empty)
        {
            message.text = "Try Again!";
        }
    }
    public void PopWinMessage()
    {
        if (message.text == string.Empty)
        {
            message.text = "You Won!";
        }
    }
    public void PopMessage(string message)
    {
        this.message.text = message;
    }
    public IEnumerator PopMessage(float timer)
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            int timeInt = (int)timer;

            this.message.text = timeInt.ToString();
            yield return null;
        }
        if (!used)
        {
            this.message.text = "Tap The Screen To Dash";
            used = true;
        }
        else
        {
            this.message.text = "";
        }
    }
    #endregion
}
