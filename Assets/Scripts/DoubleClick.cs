using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    
    private SpriteRenderer rend;
    
  
    private float firstClickTime, timeBetweenClicks;
    private bool coroutineAllowed;
    private int clickcounter;

    private Color randomColor;
    private void Awake()
    {
        
        rend = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        
        firstClickTime = 0f;
        timeBetweenClicks = 0.2f;
        clickcounter = 0;
        coroutineAllowed = true;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && ClickShape())
        {
            clickcounter += 1;
            if (clickcounter==1 && coroutineAllowed)
            {
                firstClickTime = Time.time;

                StartCoroutine(DoubleClickDetection());
            }
        }
    }

    private IEnumerator DoubleClickDetection()
    {
        coroutineAllowed = false;
        while (Time.time<firstClickTime+timeBetweenClicks)
        {
            if (clickcounter==2)
            {
                ChangeColor();
                break;

            }
            yield return new WaitForEndOfFrame();
        }
        clickcounter = 0;
        firstClickTime = 0f;
        coroutineAllowed = true;
    }
    public void ChangeColor()
    {       
        rend.color = randomColor = new Color(
      UnityEngine.Random.Range(0f, 1f),
      UnityEngine.Random.Range(0f, 1f),
      UnityEngine.Random.Range(0f, 1f)
  );
    }

    private bool ClickShape()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
