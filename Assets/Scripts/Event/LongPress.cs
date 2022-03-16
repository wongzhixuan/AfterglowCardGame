using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPress : MonoBehaviour
{
    private float startTime, endTime;
    public bool isLongClick = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = 0f;
        endTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
        }
        if(Input.GetMouseButtonUp(0))
        {
            endTime= Time.time;
        }
        if(endTime - startTime > 0.5f)
        {
            // thisgameobject.GetComponent<CardDisplay>().NowisLongClicked = true;
            // Debug.Log("LongClick");
            isLongClick = true;
            startTime = 0f;
            endTime = 0f;
        }
        else
        {
            // thisgameobject.GetComponent<CardDisplay>().NowisLongClicked = false;
            isLongClick = false;
        }
        
    }

    public void StartClick()
    {
        startTime = Time.time;
    }
}
