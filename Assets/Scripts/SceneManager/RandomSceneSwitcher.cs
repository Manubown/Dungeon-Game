using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class RandomSceneSwitcher : MonoBehaviour
{
    public List<string> Scenes;
    public KeyCode activationKey = KeyCode.F;
    private bool playerTriggered = false;

    private void Update()
    {
        if (Input.GetKeyDown(activationKey) && playerTriggered)
        {
            int x = Random.Range(0, Scenes.Count);

            SceneManager.LoadScene(Scenes[0]);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTriggered = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTriggered = false;
        }
    }
}
