using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCutscene : MonoBehaviour
{
    public GameObject titleUI;
    public GameObject buttonUI;

    public Animator spiderAnimator;
    public AnimationClip spiderAnimation;
    public GameObject screenExplosion;
    public AnimationClip screenExplosionAnimation;
    public GameObject flashPanel;
    public AnimationClip whiteFadeOut;

    public void StartGame()
    {
        AudioManager.instance.PlaySound("Button Click");
        FadeOutUI();
        StartCoroutine(SpiderAnimation());
    }

    private void FadeOutUI()
    {
        titleUI.GetComponent<Animator>().SetTrigger("FadeOut");
        buttonUI.GetComponent<Animator>().SetTrigger("FadeOut");
        StartCoroutine(DisableUIElements());
    }

    private IEnumerator DisableUIElements()
    {
        yield return new WaitForSeconds(1f);
        titleUI.SetActive(false);
        buttonUI.SetActive(false);
    }

    private IEnumerator SpiderAnimation()
    {
        spiderAnimator.SetTrigger("introAnimation");
        yield return new WaitForSeconds(spiderAnimation.length);
        StartCoroutine(ScreenExplosion());
    }
    private IEnumerator ScreenExplosion()
    {
        var i = Instantiate(screenExplosion, new Vector3(0, 0, 0), Quaternion.identity);
        AudioManager.instance.PlaySound("Screen Explosion");
        yield return new WaitForSeconds(screenExplosionAnimation.length);
        ScenesManager.Instance.LoadNewGame();
        StartCoroutine(WhiteFadeOut(i));
    }

    private IEnumerator WhiteFadeOut(GameObject i)
    {
        flashPanel.SetActive(true);
        flashPanel.GetComponent<Animator>().SetTrigger("whiteFadeOut");
        GameObject.Destroy(i);
        yield return new WaitForSeconds(whiteFadeOut.length);
        flashPanel.SetActive(false);
        
    }
}
