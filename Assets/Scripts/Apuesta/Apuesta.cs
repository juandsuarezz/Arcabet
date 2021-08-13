using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Apuesta : MonoBehaviour
{
    public int valorApuesta, totalApuesta, monedasTotales, precioHabilidades,
    valorRestante, highscore;
    public Text apuestaText, valortotalText, tusmonedasText, restantesText, continuarText, retirarText;
    public InputField inputApuesta;
    public GameObject noMonedasCanvas, feid, panel, continuarCanvas, needCanvas, retirarCanvas, ayudaCanvas;
    public ApuestaButtons apuestaButtons1, apuestaButtons2, apuestaButtons3;
    public Button90 button90;
    public Animator feidAnim, musicAnim;

    // Start is called before the first frame update
    void Start()
    {
        ayudaCanvas.SetActive(false);
        retirarCanvas.SetActive(false);
        highscore = PlayerPrefs.GetInt("highscore");
        needCanvas.SetActive(false);
        continuarCanvas.SetActive(false);
        feid.SetActive(true);
        StartCoroutine("quitFeid");
        noMonedasCanvas.SetActive(false);
        monedasTotales = PlayerPrefs.GetInt("monedas");
    }

    // Update is called once per frame
    void Update()
    {
        if(valorApuesta == 0)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
        valorRestante = monedasTotales - totalApuesta;
        totalApuesta = valorApuesta + precioHabilidades;
        retirarText.text = "Estas seguro?\n\n\nte retiras con\n\n$ " + monedasTotales.ToString() + " monedas";
        continuarText.text = "Quieres continuar?\n\nTu apuesta actual es\n $ " + valorApuesta.ToString() + " \n\ntotal + habilidades\n$ " + totalApuesta.ToString();
        restantesText.text = "monedas restantes $ " + valorRestante.ToString();
        tusmonedasText.text = "Tus monedas $ " + monedasTotales.ToString();
        valortotalText.text = "$ " + totalApuesta.ToString();
        apuestaText.text = "$ " + valorApuesta.ToString();
    }

    public void cambiarApuestaButton()
    {
        if((int.Parse(inputApuesta.text) <= (monedasTotales - precioHabilidades)))
        {
            valorApuesta = int.Parse(inputApuesta.text);
            inputApuesta.text = "";
            apuestaButtons1.SetValor();
            apuestaButtons2.SetValor();
            apuestaButtons3.SetValor();
            button90.SetValor();
            apuestaButtons1.cantidad = 0;
            apuestaButtons2.cantidad = 0;
            apuestaButtons3.cantidad = 0;
            button90.cantidad = 0;
            precioHabilidades = 0;
        }
        else
        {
            noMonedasCanvas.SetActive(true);
            inputApuesta.text = "";
        }
    }
    public void cerrarButton(GameObject canvas)
    {
        canvas.SetActive(false);
    }

    IEnumerator quitFeid()
    {
        yield return new WaitForSeconds(1.3f);
        feid.SetActive(false);
    }

    public void BorrarTodo()
    {
        valorApuesta = 0;
        precioHabilidades = 0;
        apuestaButtons1.SetValor();
        apuestaButtons2.SetValor();
        apuestaButtons3.SetValor();
        button90.SetValor();
        apuestaButtons1.cantidad = 0;
        apuestaButtons2.cantidad = 0;
        apuestaButtons3.cantidad = 0;
        button90.cantidad = 0;
        precioHabilidades = 0;
    }

    public void ContinuarButton()
    {
        monedasTotales = monedasTotales - precioHabilidades;
        feid.SetActive(true);
        feidAnim.SetTrigger("go");
        musicAnim.SetTrigger("go");
        StartCoroutine("goFortune");
        PlayerPrefs.SetInt("monedas", monedasTotales);
        PlayerPrefs.SetInt("apuesta", valorApuesta);
        PlayerPrefs.SetInt("ch1", apuestaButtons1.cantidad);
        PlayerPrefs.SetInt("ch2", apuestaButtons2.cantidad);
        PlayerPrefs.SetInt("ch3", apuestaButtons3.cantidad);
        PlayerPrefs.SetInt("ch4", button90.cantidad);
        PlayerPrefs.Save();
    }

    public void NextButton()
    {
        if(valorApuesta != 0)
        {
            continuarCanvas.SetActive(true);
        }
        else
        {
            needCanvas.SetActive(true);
        }
    }

    IEnumerator goFortune()
    {
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene("WheelsOfFortune");
    }

    public void CancelarButton(GameObject canvas)
    {
        canvas.SetActive(false);
    }

    public void RetirarmeButton()
    {
        retirarCanvas.SetActive(true);
    }

    public void SalirButton()
    {
        feid.SetActive(true);
        feidAnim.SetTrigger("go");
        musicAnim.SetTrigger("go");
        StartCoroutine("goMenu");
        if(monedasTotales > highscore)
        {
            PlayerPrefs.SetInt("highscore", monedasTotales);
        }
    }

    IEnumerator goMenu()
    {
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene("MainMenu");
    }

    public void AyudaButton()
    {
        ayudaCanvas.SetActive(true);
    }

    public void TemporalButton()
    {
        int valor90 = PlayerPrefs.GetInt("valor90");
        PlayerPrefs.SetInt("valor90", valor90 * 2);
    }
}
