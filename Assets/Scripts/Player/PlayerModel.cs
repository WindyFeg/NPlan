using LTK268.Model.CommonBase;
using UnityEngine;
using LTK268.Interface;
using LTK268.Utils;
using LTK268.Manager;
public enum State
{
    Idle,
    Walking,
    Running,
    Pickup,
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
        Name = "Player";
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

    #region Unity Methods
    private void Start()
    {
        Initialization();
        PlayerManager.Instance.RegisterPlayer(this);
    }
    private void OnDestroy()
    {
        PlayerManager.Instance.UnregisterPlayer(this);
    }
    #endregion
    private void OnStateChanged()
    {
        // Handle state change logic here, e.g., update animations or UI
        switch (currentState)
        {
            case State.Idle:
                // Play idle animation
                characterAnimation.SetAnimState(AnimState.Idle);
                break;
            case State.Walking:
                // Play walking animation
                characterAnimation.SetAnimState(AnimState.Walking);
                break;
            case State.Running:
                // Play running animation
                characterAnimation.SetAnimState(AnimState.Running);
                break;
            case State.Pickup:
                // Play Pickup animation
                characterAnimation.SetAnimState(AnimState.Pickup);
                break;
            case State.Attacking:
                // Play attack animation
                characterAnimation.SetAnimState(AnimState.Attack);
                break;
            case State.Hit:
                // Play hit animation
                characterAnimation.SetAnimState(AnimState.Hit);
                break;
            case State.Dead:
                // Play death animation
                characterAnimation.SetAnimState(AnimState.Death);
                break;
        }

        Debug.Log("Character state changed to: " + currentState);
    }

}
