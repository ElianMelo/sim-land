using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class PlayerBodyPart : MonoBehaviour
{
    [SerializeField]
    private AccessorySO accessorySO;
    [SerializeField]
    private BodyPartType type;

    private Animator animator;
    private PlayerAnimationState currentState;

    private void ChangeAnimationState(PlayerAnimationState newState)
    {
        if (!animator.runtimeAnimatorController) return;
        // stop the same animation from interruption itself
        if (currentState == newState) return;
        // play the animation
        string enumString = Enum.GetName(typeof(PlayerAnimationState), newState);
        animator.Play(enumString);
        // reassign the current state
        currentState = newState;
    }

    public void ForceLastAnimation()
    {
        string enumString = Enum.GetName(typeof(PlayerAnimationState), currentState);
        animator.Play(enumString);
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
        if(accessorySO && accessorySO.playerBodyPartSO != null)
        {
            ChangePlayerBodyPartSO();
        }
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

    public BodyPartType GetBodyPartType()
    {
        return type;
    }

    public AccessorySO GetCurrentAccessorySO()
    {
        return accessorySO;
    }

    public void ChangeAccessorySO(AccessorySO newAccessorySO)
    {
        accessorySO = newAccessorySO;
        ChangePlayerBodyPartSO();
    }

    public void ChangePlayerBodyPartSO()
    {
        animator.runtimeAnimatorController =
                (RuntimeAnimatorController)Resources.Load("AnimationControllers/" +
                accessorySO.playerBodyPartSO.animatorControllerName, typeof(RuntimeAnimatorController));
    }
}
