using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApuestaButtons : MonoBehaviour
{
    public int porcentaje, cantidad;
    public Apuesta apuestaScript;
    public float cost;
    public Text precioText, cantidadText;
    // Start is called before the first frame update
    void Start()
    {
        cantidad = 0;
        StartCoroutine("setValue");
    }

    // Update is called once per frame
    void Update()
    {
        cost = Mathf.Round(cost);
        precioText.text = "precio: $ " + cost.ToString();
        cantidadText.text = cantidad.ToString();
    }

    public void ClickButton()
    { 
        if(apuestaScript.valorRestante >= (int)cost)
        {   
            apuestaScript.precioHabilidades = apuestaScript.precioHabilidades + (int)cost;
            cantidad = cantidad + 1;
        }
        else
        {
            apuestaScript.noMonedasCanvas.SetActive(true);
        }
    }

    IEnumerator setValue()
    {
        yield return new WaitForSeconds(0.2f);
        SetValor();
    }

    public void SetValor()
    {
        cost = Mathf.Round((float)apuestaScript.valorApuesta * ((float)porcentaje / 100));
    }
}
