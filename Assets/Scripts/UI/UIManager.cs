using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentLevel;
    public Text currentLevelLabel;
    public TextMeshProUGUI Countdown;
    public bool flag ;
    public static int RemainingEnemies = 1;
    public Button retryButton;

    public float currentTime=0f; 
    private float startTime =3f;
    public  Text KillText;
    public static int KillCounter = 0;


    void Start()
    {
             flag = false;
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            currentLevelLabel.text = "Level " +currentLevel.ToString();
            currentTime = startTime;
     }
    
    // Update is called once per frame
    void Update()
    {
       KillText.text = "Kills: " + KillCounter.ToString();
        currentTime -= 1 *Time.deltaTime;
        Countdown.text = currentTime.ToString("0");
        if(currentTime<=0){
            currentTime = 0;

            Countdown.gameObject.SetActive(false);
        }
       if(RemainingEnemies == 0)
        {
            if (currentLevel != 5) {


                PlayerPrefs.SetInt("CurrentLevel", currentLevel + 1);
                PlayerPrefs.SetInt("lastLevel", currentLevel+1);
                //Debug.Log("Current "+currentLevel.ToString());
                KillCounter = 0;
                KillText.text = "Kills: " + KillCounter.ToString();

                retryButton.gameObject.SetActive(true);
                Countdown.gameObject.SetActive(true);
                Countdown.text = "Win";

                //retryButton.gameObject.SetActive(z
                retryButton.GetComponentInChildren<Text>().text = "Continue";
            }
            else
            {
                Countdown.enabled = true;
                Countdown.text = "Over";
            }

        }
    }
    public void onRetry()
    {
        KillCounter = 0;
        SceneManager.LoadScene(1);

    }
}
