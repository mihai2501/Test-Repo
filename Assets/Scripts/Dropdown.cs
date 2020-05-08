using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dropdown : MonoBehaviour
{
    public Vector3 spawnLocation;
    public GameObject shapeHandler;
    public GameObject hexagon;
    public GameObject square;
    public GameObject circle;
    public GameObject triangle;

    
    public void HandleInputData(int val)
    {
        if (val == 0 )
        {
            Clear();
            Instantiate(hexagon, shapeHandler.transform);
        }
        if (val==1)
        {
            Clear();
            Instantiate(square, shapeHandler.transform);
        }
        if (val == 2)
        {
            Clear();
            Instantiate(circle, shapeHandler.transform);
        }
        if (val == 3)
        {
            Clear();
            Instantiate(triangle, shapeHandler.transform); 
        }
    }
    public void Clear()
    {
        foreach (Transform child in shapeHandler.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
