using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyTank;
    public int level;
    public int xpos;
    public int zpos;
    public int counter;
    public int n = 1;
    private int l;
    private float speedf;
    void Awake()
    {
        level = PlayerPrefs.GetInt("CurrentLevel");
        
    }

    void Start()
    {
        if (level < 4)
        {
            n = 1;
            if (level == 1) { l = 1;speedf = 4; }
            else if (level == 2) { l = 2; speedf = 4; }
            else { l = 3; speedf = 2; }
        }
        else
        {
            n = 3;
            if (level == 4) { l = 2; speedf = 4; }
            else
            {
                l = 3;
                speedf = 1.34f;
            }

            }
        
        n = n + 1;
        l = l - 1;
        UIManager.RemainingEnemies = n;
        //StartCoroutine(EnemyDrop());
        StartCoroutine(EnemyDrop1());

    }
    IEnumerator EnemyDrop1()
    {
        while (counter < n)
        {
            GameObject obj = (GameObject)Instantiate(enemyTank, new Vector3(-30, 0, 8), Quaternion.identity);

            EnemyHealth mything = obj.GetComponent<EnemyHealth>();
            EnemyFire mything1 = obj.GetComponent<EnemyFire>();

            //set a member variable (must be PUBLIC)
            mything.liv = l;
            mything1.speedF = speedf;
           // Debug.Log("Hello world 00000"+" "+level);

            //obj.liv = l;
            yield return new WaitForSeconds(3);
            counter += 1;
        }

    }


}
