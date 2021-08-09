using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject feid;
    public Animator feidAnim;

    void Start()
    {
        StartCoroutine("quitFeid");
        feid.SetActive(true);
    }

    // Update is called once per frame
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
        StartCoroutine("goScene");
    }

    IEnumerator goScene()
    {
        yield return new WaitForSeconds(2.2f);
        SceneManager.LoadScene("Apuesta");
    }

    IEnumerator quitFeid()
    {
        yield return new WaitForSeconds(2f);
        feid.SetActive(false);
    }
}
