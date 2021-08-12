using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WheelFortune : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;
    private int finalAngle;
    public int enemies;
    public int SpinCount;
    public GameObject girarButton, playButton, feid;
    public AudioSource audioSource;
    public AudioClip sound, cash;

    [SerializeField]
    private Text text;
    public Text ApuestaText;
    public int apuesta;
    public Animator feidAnim, musicAnim;

    // Start is called before the first frame update
    void Start()
    {
        apuesta = PlayerPrefs.GetInt("apuesta");
        enemies = PlayerPrefs.GetInt("enemigos");
        feid.SetActive(true);
        StartCoroutine("quitFeid");
        SpinCount = 0;
        girarButton.SetActive(true);
        playButton.SetActive(false);
        ApuestaText.text = "Tu apuesta actual es: $ " + apuesta.ToString();
    }

    void Update()
    {
        if(SpinCount == 2)
        {
            playButton.SetActive(true);
            audioSource.PlayOneShot(cash, 0.9f);
            SpinCount = 3;
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
                enemies = 10;
                text.text = "10";
                break;
            case 45:
                enemies = 20;
                text.text = "20";
                break;
            case 90:
                enemies = 30;
                text.text = "30";
                break;
            case 135:
                enemies = 40;
                text.text = "40";
                break;
            case 180:
                enemies = 50;
                text.text = "50";
                break;
            case 225:
                enemies = 60;
                text.text = "60";
                break;
            case 270:
                enemies = 80;
                text.text = "80";
                break;
            case 315:
                enemies = 100;
                text.text = "100";
                break;
        }
        SpinCount = SpinCount + 1;
        PlayerPrefs.SetInt("enemigos", enemies);
        PlayerPrefs.Save();
    }

    public void SpinButton()
    {
        girarButton.SetActive(false);
        StartCoroutine(Spin());
    }

    IEnumerator quitFeid()
    {
        yield return new WaitForSeconds(1.3f);
        feid.SetActive(false);
    }

    public void jugarButton()
    {
        feid.SetActive(true);
        feidAnim.SetTrigger("go");
        musicAnim.SetTrigger("go");
        StartCoroutine("goScene");
    }

    IEnumerator goScene()
    {
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene("PlayingScene");
    }
}
