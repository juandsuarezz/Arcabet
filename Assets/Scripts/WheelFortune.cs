using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelFortune : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;
    private bool coroutineAllowed;
    private int finalAngle;
    private int enemies;

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
                enemies = 10;
                text.text = "Enemigos: 10";
                break;
            case 45:
                enemies = 20;
                text.text = "Enemigos: 20";
                break;
            case 90:
                enemies = 30;
                text.text = "Enemigos: 30";
                break;
            case 135:
                enemies = 40;
                text.text = "Enemigos: 40";
                break;
            case 180:
                enemies = 50;
                text.text = "Enemigos: 50";
                break;
            case 225:
                enemies = 60;
                text.text = "Enemigos: 60";
                break;
            case 270:
                enemies = 80;
                text.text = "Enemigos: 80";
                break;
            case 315:
                enemies = 100;
                text.text = "Enemigos: 100";
                break;
        }
        coroutineAllowed = true;
    }
}
