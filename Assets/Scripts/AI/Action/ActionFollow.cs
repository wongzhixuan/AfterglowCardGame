using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Follow", fileName = "ActionFollow")]
public class ActionFollow : AIAction
{
    public float minDistanceToFollow = 2f;

    public override void Act(StateController controller)
    {
        FollowTarget(controller);
    }

    private void FollowTarget(StateController controller)
    {
        if (controller.Target == null)
        {
            return;
        }
        //Follow horizontal
        if(controller.transform.position.x < controller.Target.position.x)
        {
            controller.CharacterMovement.SetHorizontal(1);
        }
        else
        {
            controller.CharacterMovement.SetHorizontal(-1);
        }

        //follow vertical
        if(controller.transform.position.y < controller.Target.position.y)
        {
            controller.CharacterMovement.SetVertical(1);
        }
        else
        {
            controller.CharacterMovement.SetVertical(-1);
        }

        //stop if min distance reached (horizontal)
        if(Mathf.Abs(controller.transform.position.x - controller.Target.position.x) < minDistanceToFollow)
        {
            controller.CharacterMovement.SetHorizontal(0);
        }

        //stop if min distance reached (vertical)
        if(Mathf.Abs(controller.transform.position.y - controller.Target.position.y) < minDistanceToFollow)
        {
            controller.CharacterMovement.SetVertical(0);
        }
    }
}
