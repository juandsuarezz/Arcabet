using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject feid, winCanvas, loseCanvas, player;
    public Animator feidAnim, musicAnim;
    public Text h1, h2, h3, h4, apuestaTitle, perdidaText, perdidaMonedas, gananciaText, gananciaMonedas, monedasPausa;
    public int monedas, apuesta, ch1, ch2, ch3, ch4, apuesta2, ready;
    public PlayerSkillsHolder playerSkills;

    // Start is called before the first frame update
    void Start()
    {
        ready = 1;
        PlayerPrefs.SetInt("ready", ready);
        PlayerPrefs.Save();
        Time.timeScale = 1;
        StartCoroutine("quitFeid");
        feid.SetActive(true);
        SetVars();
        apuestaTitle.text = "apuesta: $ " + apuesta.ToString();
        monedasPausa.text = "tus monedas: $ " + monedas.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        apuesta2 = apuesta * 2;
        h1.text = playerSkills.ability.amount.ToString();
        h2.text = ch2.ToString();
        h3.text = ch3.ToString();
        h4.text = ch4.ToString();

        ch1 = PlayerPrefs.GetInt("ch1");
        ch2 = PlayerPrefs.GetInt("ch2");
        ch3 = PlayerPrefs.GetInt("ch3");
        ch4 = PlayerPrefs.GetInt("ch4");
    }

    public void SetVars()
    {
        monedas = PlayerPrefs.GetInt("monedas");
        apuesta = PlayerPrefs.GetInt("apuesta");
        ch1 = PlayerPrefs.GetInt("ch1");
        ch2 = PlayerPrefs.GetInt("ch2");
        ch3 = PlayerPrefs.GetInt("ch3");
        ch4 = PlayerPrefs.GetInt("ch4");
    }

    public void YouWin()
    {
        player.SetActive(false);
        monedas = monedas + apuesta;
        PlayerPrefs.SetInt("monedas", monedas);
        PlayerPrefs.Save();
        gananciaText.text = "+ $ " + apuesta2.ToString();
        gananciaMonedas.text = "monedas totales: $ " + monedas.ToString();
        winCanvas.SetActive(true);
    }

    public void YouLose()
    {
        player.SetActive(false);
        monedas = monedas - apuesta;
        PlayerPrefs.SetInt("monedas", monedas);
        PlayerPrefs.Save();
        perdidaText.text = "- $ " + apuesta.ToString();
        perdidaMonedas.text = "monedas restantes: $ " + monedas.ToString();
        loseCanvas.SetActive(true);
    }
    public void SalirButton()
    {
        feid.SetActive(true);
        feidAnim.SetTrigger("go");
        musicAnim.SetTrigger("go");
        StartCoroutine("goScene");
    }

    IEnumerator quitFeid()
    {
        yield return new WaitForSeconds(1.3f);
        feid.SetActive(false);
    }

    IEnumerator goScene()
    {
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene("Apuesta");
    }

    public void EnterButton()
    {
        Time.timeScale = 0;
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
    }

    public void abandonar()
    {
        monedas = monedas - apuesta;
        PlayerPrefs.SetInt("monedas", monedas);
        PlayerPrefs.Save();
    }
}
