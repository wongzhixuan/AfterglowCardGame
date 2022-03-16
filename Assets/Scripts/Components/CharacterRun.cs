using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRun : CharacterComponents
{
    [SerializeField] private float runSpeed = 10f;


   // private bool isRunning;


    protected override void HandleInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
           // isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopRun();
            //isRunning = false;
        }
    }

    private void Run()
    {
        characterMovement.MoveSpeed = runSpeed;
        animator.SetFloat("speed", characterMovement.MoveSpeed);

    }

    private void StopRun()
    {
        characterMovement.ResetSpeed();
        animator.SetFloat("speed", characterMovement.MoveSpeed);

    }



}
