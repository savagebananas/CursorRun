using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCutscene : MonoBehaviour
{
    public GameObject panel;
    public GameObject rebootText;
    public GameObject cube;
    public Transform cubeLocation1;
    public Transform cubeLocation2;
    public Transform cubeLocation3;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        panel.SetActive(true);
        panel.GetComponent<Animator>().SetTrigger("blackFadeOut");
        yield return new WaitForSeconds(1f);
        panel.SetActive(false);
        StartCoroutine(RebootText());
    }

    IEnumerator RebootText()
    {
        rebootText.SetActive(true);
        StartCoroutine(SpawnCube1());
        yield return new WaitForSeconds(1.8f);
  
    }

    IEnumerator SpawnCube1()
    {
        var c = Instantiate(cube, cubeLocation1.position, Quaternion.identity);
        c.transform.parent = cubeLocation1;
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnCube2());
    }

    IEnumerator SpawnCube2()
    {
        var c = Instantiate(cube, cubeLocation2.position, Quaternion.identity);
        c.transform.parent = cubeLocation2;
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnCube3());
    }

    IEnumerator SpawnCube3()
    {
        var c = Instantiate(cube, cubeLocation3.position, Quaternion.identity);
        c.transform.parent = cubeLocation3;
        yield return new WaitForSeconds(1f);
        ScenesManager.Instance.ReturnToMenu();
    }


}
