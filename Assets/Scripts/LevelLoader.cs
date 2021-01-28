using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int delay_start_scene = 3;
    int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(LoadStart());
        }
    }

    private IEnumerator LoadStart()
    {
        yield return new WaitForSeconds(delay_start_scene);
        LoadNextScene();
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
