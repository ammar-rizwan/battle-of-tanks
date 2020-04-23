using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public Slider slider ;
    public GameObject Loading;
    public GameObject mainMenu;   
    public GameObject Level;
    public Button[] levelButton;
    private int lastLevel;
    public void Awake(){
        
        if(PlayerPrefs.HasKey("lastLevel"))
        {
            lastLevel = PlayerPrefs.GetInt("lastLevel");
            Debug.Log(lastLevel);
            for (int i = 0; i < lastLevel; i++)
            {
                levelButton[i].interactable = true;
            }
        }
        else
        {
            lastLevel = 1;
           PlayerPrefs.SetInt("lastLevel", 1);
        }

    }
    public void playGame(Button btn){
        switch (btn.name)
        {
            case "PlayButton":
                Debug.Log("PlayButton");
                PlayerPrefs.SetInt("CurrentLevel",lastLevel);

                break;
            case "Level1":
                Debug.Log("Level1");
                PlayerPrefs.SetInt("CurrentLevel", 1);
                //  PlayerPrefs.SetInt("lastLevel", 1
                break;

            case "Level2":
                PlayerPrefs.SetInt("CurrentLevel",2);
                Debug.Log("Level2");
                break;
            case "Level3":
                PlayerPrefs.SetInt("CurrentLevel",3);
                Debug.Log("Level1");   
                break;
            case "Level4":
                PlayerPrefs.SetInt("CurrentLevel",4);
                Debug.Log("Level4");                
                break;
            case "Level5":
                PlayerPrefs.SetInt("CurrentLevel",5);
                Debug.Log("Level5");                
                break;
                 

            default:
                break;

        }
     
        mainMenu.SetActive(false);
        Level.SetActive(false);

        StartCoroutine(loadAsyncLevel(SceneManager.GetActiveScene().buildIndex +1));
    }
    public void quitGame(){
        Application.Quit();
    }
    
    IEnumerator loadAsyncLevel(int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        Loading.SetActive(true);
        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value  = progress;
            yield return null;
        }
    }
   
}
