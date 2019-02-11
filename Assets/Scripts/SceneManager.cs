using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    
    public void LoadHome()
    {
        SceneCache.WriteCache(0);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void LoadTest()
    {
        SceneCache.WriteCache(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        SceneCache.WriteCache(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
