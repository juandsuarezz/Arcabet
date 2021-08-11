using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTime : MonoBehaviour
{
    public float time;
    public Text timeText;


    // Start is called before the first frame update
    void Start()
    {
        time = PlayerPrefs.GetFloat("tiempo");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "Tiempo: " + Mathf.Round(time).ToString();

        if (time <= 0)
            // YouLose();
            time = 0;

        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            // YouWin();
        }
    }
}
