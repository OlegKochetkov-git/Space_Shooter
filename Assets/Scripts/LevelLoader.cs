using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transition;

    int transitionTime = 1;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadHomeScreen()
    {
        SceneManager.LoadScene("Home Screen");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadGame()
    {
        StartCoroutine(LoadSceneWithTransition());
    }

    IEnumerator LoadSceneWithTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level");
    }
}
