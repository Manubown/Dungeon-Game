using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSceneSwitcher : MonoBehaviour
{
    public List<string> Scenes;

    public void OnTriggerEnter()
    {
        int x = Random.Range(0, Scenes.Count - 1);
        SceneManager.LoadScene(Scenes[x]);
    }
}
