using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panel;

    public void GameOver()
    {
        StartCoroutine(GameOverAnimation());
    }

    IEnumerator GameOverAnimation()
    {
        panel.GetComponent<Animator>().SetTrigger("blackFadeOut");
        yield return new WaitForSeconds(1f);
        ScenesManager.Instance.LoadGameOverScreen();
    }
}
