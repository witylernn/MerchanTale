using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public SaveLoad SaveLoad;
    string lastLoaded;
    public void SceneSwitch(string sceneName)
    {
        switch (sceneName)
        {
            case "farm":
                if (lastLoaded == "farm")
                {
                    print("already farming");
                    return;
                }
                break;

            case "beach":
                if (lastLoaded == "beach")
                {
                    print("already beaching");
                }
                break;
            case "town":
                if (lastLoaded == "town")
                {
                    print("already towning");
                }
                break;
        }
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        lastLoaded = scene.name;
        SaveLoad.Save();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }
}
