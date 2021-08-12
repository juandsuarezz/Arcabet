using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button90 : MonoBehaviour
{
    public int porcentaje, cantidad, valor90;
    public Apuesta apuestaScript;
    public float cost;
    public Text precioText, cantidadText;
    public GameObject unavezCanvas;
    // Start is called before the first frame update
    void Start()
    {
        unavezCanvas.SetActive(false);
        cantidad = 0;
        StartCoroutine("setValue");
    }

    // Update is called once per frame
    void Update()
    {
        cost = Mathf.Round((float)apuestaScript.valorApuesta * ((float)porcentaje / 100) * valor90);
        valor90 = PlayerPrefs.GetInt("valor90");
        cost = Mathf.Round(cost);
        precioText.text = "precio: $ " + cost.ToString();
        cantidadText.text = cantidad.ToString();
    }

    public void ClickButton()
    { 
        if(apuestaScript.valorRestante >= (int)cost)
        {   
            if(cantidad == 0)
            {
                apuestaScript.precioHabilidades = apuestaScript.precioHabilidades + (int)cost;
                cantidad = cantidad + 1;
            }
            else
            {
                unavezCanvas.SetActive(true);
            }
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
        cost = Mathf.Round((float)apuestaScript.valorApuesta * ((float)porcentaje / 100) * valor90);
    }
}
