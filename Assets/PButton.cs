using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PButton : MonoBehaviour
{
    public Sprite PauseSprite;
    public Sprite PlaySprite;
    public void PToggle()
    {
        if (Time.timeScale != 0)
        {
            GetComponent<Image>().sprite = PlaySprite;
            Time.timeScale = 0;
            return;
        }
        else
        {
            GetComponent<Image>().sprite = PauseSprite;
            Time.timeScale = 1;
        }
    }

}
