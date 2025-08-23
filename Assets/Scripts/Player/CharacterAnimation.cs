using LTK268.Interface;
using LTK268.Model.CommonBase;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

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
        public const string Pickup = "Pickup";
        public const string Attack = "Attack";
        public const string Hit = "Hit";
        public const string Death = "Death";
        public const string Cure = "Cure";
    }

    #endregion

    #region Serialized Fields

    [SerializeField] private Rigidbody rb;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator anim;
    [SerializeField] private EntityBase entityBase;

    [Header("Append Direction Suffix")] 
    [SerializeField] private bool idle = true;
    [SerializeField] private bool walking = true;
    [SerializeField] private bool running = true;
    [SerializeField] private bool pickup = true;
    [SerializeField] private bool attack = true;
    [SerializeField] private bool hit = true;
    [SerializeField] private bool death = true;
    [SerializeField] private bool cure = true;
    
    #endregion

    #region Private Fields

    public string currentAnimation;
    public string lastDirection = "None";
    public string currentDirection = "None";
    [SerializeField] private AnimState currentAnimState = AnimState.Idle;

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

        if (currentAnimState == AnimState.Walking || currentAnimState == AnimState.Running)
        {
            PlayAnimationByState(currentAnimState);
        }
    }

    #endregion

    #region Animation Control
    public void SetAnimator(AnimatorController animatorController)
    {
        anim.runtimeAnimatorController = animatorController;
    }

    private bool CheckAppendSuffix(AnimState state)
    {
        return state switch
        {
            AnimState.Idle => idle,
            AnimState.Walking => walking,
            AnimState.Running => running,
            AnimState.Pickup => pickup,
            AnimState.Attack => attack,
            AnimState.Hit => hit,
            AnimState.Death => death,
            AnimState.Cure => cure,
            _ => false
        };
    }

    private void PlayAnimationByState(AnimState state)
    {
        // Check if there is anmation playing dont play
        if (state != AnimState.Walking && state == currentAnimState) return;
        if (state == currentAnimState && currentDirection == lastDirection)
        {
            return;
        }

        bool appendSuffix = CheckAppendSuffix(state);
        string baseName = state switch
        {
            AnimState.Idle => AnimNames.Idle,
            AnimState.Walking => AnimNames.Walking,
            AnimState.Running => AnimNames.Running,
            AnimState.Pickup => AnimNames.Pickup,
            AnimState.Attack => AnimNames.Attack,
            AnimState.Hit => AnimNames.Hit,
            AnimState.Death => AnimNames.Death,
            AnimState.Cure => AnimNames.Cure,
            _ => AnimNames.Idle
        };
        PlayDirectionalAnimation(baseName, appendSuffix);
        currentAnimState = state;

    }

    private void PlayDirectionalAnimation(string baseName, bool appendSuffix)
    {
        string animName = $"{entityBase.Name}_{baseName}";
        // Debug.Log($"[PlayDirectionalAnimation] animName: {animName}");
        if (appendSuffix)
        {
            animName += $"{currentDirection}";
        }
        Debug.Log($"[PlayDirectionalAnimation] animName: {animName}");
        
        // Không phát lại nếu đang phát đúng animation theo hướng
        if (currentAnimation == animName)
            return;
        // Debug.Log($"[PlayDirectionalAnimation] baseName: {baseName}, currentDirection: {currentDirection}, animName: {animName}");
        if (currentAnimation.StartsWith($"{entityBase.Name}_{baseName}") && lastDirection != currentDirection)
        {
            // Debug.Log($"[DirectionChanged] Switching direction from {lastDirection} to {currentDirection}");
        }
        else if (currentAnimation.StartsWith($"{entityBase.Name}_{baseName}"))
        {
            // Cùng animation và cùng hướng => không cần cập nhật lại
            return;
        }

        // Debug.Log($"[AnimationPlay] Playing: {animName}");
        anim.Play(animName);
        currentAnimation = animName;
        lastDirection = currentDirection;
    }


    #endregion

    #region Animation Parameters

    public void SetAnimState(AnimState state)
    {

        Vector3 velocity = navMeshAgent != null ? navMeshAgent.velocity : rb.linearVelocity;
        UpdateDirectionFromVelocity(velocity);
        PlayAnimationByState(state);
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
        if (Mathf.Abs(velocity.z) > 0 && Mathf.Abs(velocity.x) <= Mathf.Abs(velocity.z))
        {
            currentDirection = velocity.z > 0 ? "Up" : "Down";
        }
        else if (Mathf.Abs(velocity.x) > 0)
        {
            currentDirection = velocity.x > 0 ? "Right" : "Left";
        }
        if (currentDirection != lastDirection)
        {
            PlayAnimationByState(currentAnimState); // Update animation state when direction changes
        }
    }

    #endregion
}
