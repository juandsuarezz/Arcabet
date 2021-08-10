using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelSeconds : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;
    private bool coroutineAllowed;
    private int finalAngle;
    private float seconds;

    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && coroutineAllowed)
        {
            StartCoroutine(Spin());
        }
    }

    private IEnumerator Spin()
    {
        coroutineAllowed = false;
        randomValue = Random.Range(20, 30);
        timeInterval = 0.1f;

        for (int i = 0; i < randomValue; i++)
        {
            transform.Rotate(0, 0, 22.5f);
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.2f;
            if (i > Mathf.RoundToInt(randomValue * 0.85f))
                timeInterval = 0.4f;
            yield return new WaitForSeconds(timeInterval);
        }

        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
            transform.Rotate(0, 0, 22.5f);

        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        switch (finalAngle)
        {
            case 0:
                seconds = 30;
                text.text = "Segundos: 30";
                break;
            case 45:
                seconds = 40;
                text.text = "Segundos: 40";
                break;
            case 90:
                seconds = 50;
                text.text = "Segundos: 50";
                break;
            case 135:
                seconds = 60;
                text.text = "Segundos: 60";
                break;
            case 180:
                seconds = 70;
                text.text = "Segundos: 70";
                break;
            case 225:
                seconds = 80;
                text.text = "Segundos: 80";
                break;
            case 270:
                seconds = 90;
                text.text = "Segundos: 90";
                break;
            case 315:
                seconds = 100;
                text.text = "Segundos: 100";
                break;
        }
        coroutineAllowed = true;
    }
}
