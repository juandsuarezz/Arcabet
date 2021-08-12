using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelSeconds : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;
    private int finalAngle;
    private float seconds;
    public WheelFortune wheelFortune;
    public Text frase;
    public AudioSource audioSource;
    public AudioClip sound;

    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(wheelFortune.SpinCount == 2)
        {
            frase.text = "Debes matar a " + wheelFortune.enemies.ToString() + 
            " enemigos en menos de " + seconds.ToString() + " segundos";
        }
    }

    private IEnumerator Spin()
    {
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
            audioSource.PlayOneShot(sound, 0.9f);
        }

        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
            transform.Rotate(0, 0, 22.5f);

        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        switch (finalAngle)
        {
            case 0:
                seconds = 30f;
                text.text = "30";
                break;
            case 45:
                seconds = 40f;
                text.text = "40";
                break;
            case 90:
                seconds = 50f;
                text.text = "50";
                break;
            case 135:
                seconds = 60f;
                text.text = "60";
                break;
            case 180:
                seconds = 70f;
                text.text = "70";
                break;
            case 225:
                seconds = 80f;
                text.text = "80";
                break;
            case 270:
                seconds = 90f;
                text.text = "90";
                break;
            case 315:
                seconds = 100f;
                text.text = "100";
                break;
        }

        PlayerPrefs.SetFloat("tiempo", seconds);
        wheelFortune.SpinCount = wheelFortune.SpinCount + 1;
    }

    public void SpinButton()
    {
        StartCoroutine(Spin());
    }
}
