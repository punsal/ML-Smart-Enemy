using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public LoadingBarController controller;
    private void Update()
    {
        if(controller.loading.fillAmount >= .9f)
        {
            StartCoroutine(LoadRequestedScene());
        }
    }

    private IEnumerator LoadRequestedScene()
    {
        yield return null;
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneCache.ReadCache(), LoadSceneMode.Single);
    }
}
