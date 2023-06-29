using System;
using System.Collections;
using System.Collections.Generic;
using RPG.UI;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseAllWindows();
        }
    }

    public void CloseAllWindows()
    {
        foreach (GameObject panel in panels)
        {
            panel.GetComponent<ICloseableUIElement>().Close();
        }    
    }
    
}
