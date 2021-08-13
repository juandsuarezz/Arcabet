using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTime : MonoBehaviour
{
    public float time;
    public Text timeText;
    public GameManager gameManager;

    private bool finish;


    // Start is called before the first frame update
    void Start()
    {
        time = PlayerPrefs.GetFloat("tiempo");
        //time = 5f;
        finish = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(finish)
        {
            time -= Time.deltaTime;
            timeText.text = "Tiempo: " + Mathf.Round(time).ToString();

            if (time <= 0 && finish)
            {
                //gameManager.YouWin();
                gameManager.YouLose();
                finish = false;
            }

            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && finish)
            {
                gameManager.YouWin();
                finish = false;
            }
        }
    }
}
