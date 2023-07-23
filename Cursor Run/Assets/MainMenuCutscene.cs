using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCutscene : MonoBehaviour
{
    public Animator spiderAnimator;
    public AnimationClip spiderAnimation;
    public GameObject screenExplosion;
    public AnimationClip screenExplosionAnimation;
    public GameObject flashPanel;
    public AnimationClip whiteFadeOut;

    public void StartGame()
    {
        StartCoroutine(SpiderAnimation());
        //ScenesManager.Instance.LoadNewGame();
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
