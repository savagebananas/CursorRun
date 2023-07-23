using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Game,
        GameOver
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Game.ToString());
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene(Scene.GameOver.ToString());
    }
}
