using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnemy : MonoBehaviour 
{
    public Animator animator;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Attack");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("Stop", true);

    }
}
