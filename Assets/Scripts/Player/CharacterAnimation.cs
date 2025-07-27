using LTK268.Interface;
using LTK268.Model.CommonBase;
using UnityEngine;
using UnityEngine.AI;

public enum AnimState
{
    Idle,
    Walking,
    Running,
    Gathering,
    Attack,
    Hit,
    Death
}

/// <summary>
/// Controls the animation states of a character based on direction and action.
/// </summary>
public class CharacterAnimation : MonoBehaviour, ICharacterAnimation
{
    #region Constants

    private static class AnimNames
    {
        public const string Idle = "Idle";
        public const string Walking = "Walking";
        public const string Running = "Running";
        public const string Gathering = "Gathering";
        public const string Attack = "Attack";
        public const string Hit = "Hit";
        public const string Death = "Death";
    }

    #endregion

    #region Serialized Fields

    [SerializeField] private Rigidbody rb;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator anim;
    [SerializeField] private EntityBase entityBase;

    #endregion

    #region Private Fields

    private string currentAnimation;
    private string lastDirection = "Down";
    private string currentDirection = "Down";
    private AnimState currentAnimState = AnimState.Idle;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        // Any required initialization can go here.
    }

    private void OnValidate()
    {
        anim ??= GetComponentInChildren<Animator>();
        rb ??= GetComponent<Rigidbody>();
        navMeshAgent ??= GetComponent<NavMeshAgent>();
        entityBase ??= GetComponent<EntityBase>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = navMeshAgent != null ? navMeshAgent.velocity : rb.linearVelocity;
        UpdateDirectionFromVelocity(velocity);
        PlayAnimationByState(currentAnimState);
    }

    #endregion

    #region Animation Control

    private void PlayAnimationByState(AnimState state)
    {
        string baseName = state switch
        {
            AnimState.Idle => AnimNames.Idle,
            AnimState.Walking => AnimNames.Walking,
            AnimState.Running => AnimNames.Running,
            AnimState.Gathering => AnimNames.Gathering,
            AnimState.Attack => AnimNames.Attack,
            AnimState.Hit => AnimNames.Hit,
            AnimState.Death => AnimNames.Death,
            _ => AnimNames.Idle
        };

        PlayDirectionalAnimation(baseName);
    }

    private void PlayDirectionalAnimation(string baseName)
    {
        if (currentDirection != lastDirection)
            lastDirection = currentDirection;

        string animName = $"{entityBase.Name}_{baseName}{lastDirection}";

        if (currentAnimation == animName) return;

        Debug.Log($"Playing animation: {animName}");
        anim.Play(animName);
        currentAnimation = animName;
    }

    #endregion

    #region Animation Parameters

    public void SetAnimState(AnimState state)
    {
        currentAnimState = state;
    }

    public void SetSpeed(float speed)
    {
        // Placeholder for future animation blend/speed adjustment
    }

    public void SetAttackType(string attackType)
    {
        // Placeholder for future attack type switching
    }

    private void UpdateDirectionFromVelocity(Vector3 velocity)
    {
        if (Mathf.Abs(velocity.z) > Mathf.Epsilon)
        {
            currentDirection = velocity.z > 0 ? "Up" : "Down";
        }
        else if (Mathf.Abs(velocity.x) > Mathf.Epsilon && Mathf.Abs(velocity.z) <= Mathf.Epsilon)
        {
            currentDirection = velocity.x > 0 ? "Right" : "Left";
        }

    }

    #endregion
}
