using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseInv : MonoBehaviour
{
    private bool inv = false;

    private void Start()
    {
        
        gameObject.SetActive(inv);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inv = !inv;
            gameObject.SetActive(inv);
        }
    }
}
