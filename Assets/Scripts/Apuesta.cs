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
    public GameObject noMonedasCanvas, feid;
    public ApuestaButtons apuestaButtons;

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
        valorRestante = monedasTotales - totalApuesta;
        totalApuesta = valorApuesta + precioHabilidades;
        restantesText.text = "monedas restantes $ " + valorRestante.ToString();
        tusmonedasText.text = "Tus monedas $ " + monedasTotales.ToString();
        valortotalText.text = "$ " + totalApuesta.ToString();
        apuestaText.text = "$ " + valorApuesta.ToString();
    }

    public void cambiarApuestaButton()
    {
        if(int.Parse(inputApuesta.text) <= valorRestante)
        {
            valorApuesta = int.Parse(inputApuesta.text);
            inputApuesta.text = "";
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
        apuestaButtons.cost = apuestaButtons.cost * 1.3f;
    }

    IEnumerator quitFeid()
    {
        yield return new WaitForSeconds(2f);
        feid.SetActive(false);
    }
}
