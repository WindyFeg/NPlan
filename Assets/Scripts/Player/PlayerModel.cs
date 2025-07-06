using LTK268.Model.CommonBase;
using UnityEngine;
using LTK268.Interface;
using LTK268.Utils;
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

public class PlayerModel : HumanBase
{
    private State currentState = State.Idle;
    private ICharacterAnimation characterAnimation;
    private string currentDirection = "Down";
    public string CurrentDirection
    {
        get => currentDirection;
        set
        {
            currentDirection = value;
            OnStateChanged();
    
        }
}
    public PlayerModel(int id, string name, int maxHealth, int level, int damage) : base(id, name, maxHealth, level, damage)
    {
    }

    public override void Initialization()
    {
        // This is temp initialization all if the init will be handle by game manager
        Id = 1;
        Name = "Default Player";
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        Level = 1;
        Damage = 10;
        Armor = 0;
        EntityType = EntityType.Player;

        characterAnimation = GetComponentInChildren<ICharacterAnimation>();
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
