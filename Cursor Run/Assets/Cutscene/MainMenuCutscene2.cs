using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCutscene2 : MonoBehaviour
{
    public GameObject panel;
    public GameObject windowsScreen;

    void Start()
    {
        StartCoroutine(WhiteFadeIn());
        StartCoroutine(ScreenShatter());
    }

    private IEnumerator WhiteFadeIn()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(1f);
        panel.SetActive(false);
    }

    private IEnumerator ScreenShatter()
    {
        var w = Instantiate(windowsScreen);
        yield return new WaitForSeconds(1f);
        w.GetComponent<Animator>().SetTrigger("screenShatter");
        StartCoroutine(StartMusic());
        
    }

    private IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.instance.PlaySound("Battle Theme");
    }
}
