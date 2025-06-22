using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walking,
        Running,
        Gathering,
        Attacking,
        Hit,
        Dead
    }

    [SerializeField] private State currentState = State.Idle;
    private ICharacterAnimation characterAnimation;
    private void Awake()
    {
        characterAnimation = GetComponent<ICharacterAnimation>();
    }


    public State CurrentState
    {
        get { return currentState; }
        set
        {
            if (currentState != value)
            {
                currentState = value;
                OnStateChanged();
            }
        }
    }

    private void OnStateChanged()
    {
        // Handle state change logic here, e.g., update animations or UI
        switch (currentState)
        {
            case State.Idle:
                // Play idle animation
                characterAnimation.PlayIdleAnimation();
                break;
            case State.Walking:
                // Play walking animation
                characterAnimation.PlayWalkingAnimation();
                break;
            case State.Running:
                // Play running animation
                characterAnimation.PlayRunningAnimation();
                break;
            case State.Gathering:
                // Play gathering animation
                characterAnimation.PlayGatheringAnimation();
                break;
            case State.Attacking:
                // Play attack animation
                characterAnimation.PlayAttackAnimation();
                break;
            case State.Hit:
                // Play hit animation
                characterAnimation.PlayHitAnimation();
                break;
            case State.Dead:
                // Play death animation
                characterAnimation.PlayDeathAnimation();
                break;
        }

        Debug.Log("Character state changed to: " + currentState);
    }
}
