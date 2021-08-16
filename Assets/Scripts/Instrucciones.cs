using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instrucciones : MonoBehaviour
{
    public GameObject feid;
    public Animator feidAnim, musicAnim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("quitFeid");
        feid.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SceneManager.LoadScene("PlayingScene");
    }

    IEnumerator quitFeid()
    {
        yield return new WaitForSeconds(1.3f);
        feid.SetActive(false);
    }
}
