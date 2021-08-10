using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apuesta : MonoBehaviour
{
    public int valorApuesta, totalApuesta, monedasTotales, precioHabilidades,
    valorRestante, valorHabilidad;
    public Text apuestaText, valortotalText, tusmonedasText, restantesText;
    public InputField inputApuesta;
    public GameObject noMonedasCanvas, feid, panel;
    public ApuestaButtons apuestaButtons1, apuestaButtons2, apuestaButtons3, apuestaButtons4;

    // Start is called before the first frame update
    void Start()
    {
        feid.SetActive(true);
        StartCoroutine("quitFeid");
        noMonedasCanvas.SetActive(false);
        monedasTotales = 1000;
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
            apuestaButtons4.SetValor();
            apuestaButtons1.cantidad = 0;
            apuestaButtons2.cantidad = 0;
            apuestaButtons3.cantidad = 0;
            apuestaButtons4.cantidad = 0;
            precioHabilidades = 0;
        }
        else
        {
            noMonedasCanvas.SetActive(true);
            inputApuesta.text = "";
        }
    }
    public void cerrarButton()
    {
        noMonedasCanvas.SetActive(false);
    }

    public void botontemporal()
    {
        apuestaButtons4.cost = apuestaButtons4.cost * 1.3f;
    }

    IEnumerator quitFeid()
    {
        yield return new WaitForSeconds(2f);
        feid.SetActive(false);
    }

    public void BorrarTodo()
    {
        valorApuesta = 0;
        precioHabilidades = 0;
        apuestaButtons1.SetValor();
        apuestaButtons2.SetValor();
        apuestaButtons3.SetValor();
        apuestaButtons4.SetValor();
        apuestaButtons1.cantidad = 0;
        apuestaButtons2.cantidad = 0;
        apuestaButtons3.cantidad = 0;
        apuestaButtons4.cantidad = 0;
        precioHabilidades = 0;
    }
}
