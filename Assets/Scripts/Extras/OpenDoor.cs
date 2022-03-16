using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Animator animator;
    private bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpened == true)
        {
            animator.SetBool("OpenDoor", false);
            isOpened = false;
        }
        else
        {
            animator.SetBool("OpenDoor", true);
            isOpened = true;
        }
    }
}
