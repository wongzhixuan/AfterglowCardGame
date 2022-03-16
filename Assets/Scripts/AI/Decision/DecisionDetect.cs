using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Detect Target", fileName = "DecisionDetect")]
public class DecisionDetect : AIDecision
{
    public float detectArea = 3f;
    public LayerMask targetMask;
    // protected Character character;
    // public Animator animator;

    private Collider2D targetCollider2D;

    public override bool Decide(StateController controller)
    {
        // animator = character.CharacterAnimator;
        return CheckTarget(controller);
    }

    private bool CheckTarget(StateController controller)
    {
        targetCollider2D = Physics2D.OverlapCircle(controller.transform.position, detectArea, targetMask);
        if (targetCollider2D != null)
        {
            // animator.SetTrigger("Attack");
            controller.Target = targetCollider2D.transform;
            return true;
        }
        return false;
    }
}
