using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyPart : MonoBehaviour
{
    [SerializeField]
    private PlayerBodyPartSO playerBodyPartSO;

    private Animator animator;

    public enum PlayerAnimationState
    {
        IDLE_DOWN,
        IDLE_LEFT,
        IDLE_RIGHT,
        IDLE_UP,
        WALK_DOWN,
        WALK_LEFT,
        WALK_RIGHT,
        WALK_UP
    }

    private PlayerAnimationState currentState;

    void ChangeAnimationState(PlayerAnimationState newState)
    {
        // stop the same animation from interruption itself
        if (currentState == newState) return;
        // play the animation
        string enumString = Enum.GetName(typeof(PlayerAnimationState), newState);
        animator.Play(enumString);
        // reassign the current state
        currentState = newState;
    }

    void GoToIdleAnimationState()
    {
        switch (currentState)
        {
            case PlayerAnimationState.WALK_DOWN:
                ChangeAnimationState(PlayerAnimationState.IDLE_DOWN);
                break;
            case PlayerAnimationState.WALK_LEFT:
                ChangeAnimationState(PlayerAnimationState.IDLE_LEFT);
                break;
            case PlayerAnimationState.WALK_RIGHT:
                ChangeAnimationState(PlayerAnimationState.IDLE_RIGHT);
                break;
            case PlayerAnimationState.WALK_UP:
                ChangeAnimationState(PlayerAnimationState.IDLE_UP);
                break;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = playerBodyPartSO.animatorController;
    }

    public void ChangeAnimation(float xInput, float yInput)
    {
        var xFormated = Mathf.Abs(xInput);
        var yFormated = Mathf.Abs(yInput);

        if (xFormated > yFormated && xInput > 0)
        {
            ChangeAnimationState(PlayerAnimationState.WALK_RIGHT);
        }
        else if (xFormated > yFormated && xInput < 0)
        {
            ChangeAnimationState(PlayerAnimationState.WALK_LEFT);
        }
        else if (xFormated < yFormated && yInput > 0)
        {
            ChangeAnimationState(PlayerAnimationState.WALK_UP);
        }
        else if (xFormated < yFormated && yInput < 0)
        {
            ChangeAnimationState(PlayerAnimationState.WALK_DOWN);
        }
        else
        {
            GoToIdleAnimationState();
        }
    }
}
