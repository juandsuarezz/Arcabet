using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject feid;
    public Animator feidAnim, musicAnim;
    public int monedas, highscore, apuesta, ch1, ch2, ch3, ch4, enemigos, segundos, valor90, ready;
    public float tiempo;
    public Text highscoreText;

    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine("quitFeid");
        feid.SetActive(true);
        monedas = 1000;
        highscore = PlayerPrefs.GetInt("highscore");
        apuesta = 0;
        ch1 = 0;
        ch2 = 0;
        ch3 = 0;
        ch4 = 0;
        enemigos = 0;
        tiempo = 0;
        segundos = 0;
        valor90 = 1;
        ready = 0;
        SetPrefs();
        highscoreText.text = "$ " + highscore.ToString();
    }

    void Update()
    {
        
    }

    public void showCanvas(GameObject canvasname)
    {
        canvasname.SetActive(true);
    }

    public void backButton(GameObject canvasname)
    {
        canvasname.SetActive(false);
    }

    public void playButton()
    {
        feid.SetActive(true);
        feidAnim.SetTrigger("go");
        musicAnim.SetTrigger("go");
        StartCoroutine("goScene");
    }

    IEnumerator goScene()
    {
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene("Apuesta");
    }

    IEnumerator quitFeid()
    {
        yield return new WaitForSeconds(1.3f);
        feid.SetActive(false);
    }

    public void SetPrefs()
    {
        PlayerPrefs.SetInt("ready", ready);
        PlayerPrefs.SetInt("monedas", monedas);
        PlayerPrefs.SetInt("highscore", highscore);
        PlayerPrefs.SetInt("apuesta", apuesta);
        PlayerPrefs.SetInt("ch1", ch1);
        PlayerPrefs.SetInt("ch2", ch2);
        PlayerPrefs.SetInt("ch3", ch3);
        PlayerPrefs.SetInt("ch4", ch4);
        PlayerPrefs.SetInt("enemigos", enemigos);
        PlayerPrefs.SetInt("segundos", segundos);
        PlayerPrefs.SetInt("valor90", valor90);
        PlayerPrefs.SetFloat("tiempo", tiempo);
        PlayerPrefs.Save();
    }

    public void goEnlaces(string enlace)
    {
        Application.OpenURL(enlace);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
