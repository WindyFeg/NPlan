using LTK268.Interface;
using LTK268.Model.CommonBase;
using UnityEngine;
using UnityEngine.AI;

public enum AnimState
{
    Idle,
    Walking,
    Running,
    Pickup,
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
        public const string Pickup = "Pickup";
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

    public string currentAnimation;
    public string lastDirection = "None";
    public string currentDirection = "None";
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

        // Luôn cập nhật animation khi đang Walking hoặc Running
        if (currentAnimState == AnimState.Walking || currentAnimState == AnimState.Running)
        {
            PlayAnimationByState(currentAnimState);
        }
    }
    private void Update()
    {
        if (!IsTransientAnim(currentAnimState)) return;

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1f && !anim.IsInTransition(0))
        {
            SetAnimState(AnimState.Idle);
        }
    }

    private bool IsTransientAnim(AnimState state)
    {
        return state is AnimState.Attack or AnimState.Pickup or AnimState.Hit or AnimState.Death;
    }



    #endregion

    #region Animation Control

    private void PlayAnimationByState(AnimState state)
    {
        // Check if there is anmation playing dont play
        if (state == currentAnimState && currentDirection == lastDirection)
        {
            return;
        }
        string baseName = state switch
        {
            AnimState.Idle => AnimNames.Idle,
            AnimState.Walking => AnimNames.Walking,
            AnimState.Running => AnimNames.Running,
            AnimState.Pickup => AnimNames.Pickup,
            AnimState.Attack => AnimNames.Attack,
            AnimState.Hit => AnimNames.Hit,
            AnimState.Death => AnimNames.Death,
            _ => AnimNames.Idle
        };

        PlayDirectionalAnimation(baseName);
        currentAnimState = state;

    }

    private void PlayDirectionalAnimation(string baseName)
    {
        string animName = $"{entityBase.Name}_{baseName}{currentDirection}";
        // Không phát lại nếu đang phát đúng animation theo hướng
        if (currentAnimation == animName)
            return;
        Debug.Log($"[PlayDirectionalAnimation] baseName: {baseName}, currentDirection: {currentDirection}, animName: {animName}");
        // Nếu cùng loại animation (VD: Walking -> Walking) nhưng hướng thay đổi => phát lại
        if (currentAnimation.StartsWith($"{entityBase.Name}_{baseName}") && lastDirection != currentDirection)
        {
            Debug.Log($"[DirectionChanged] Switching direction from {lastDirection} to {currentDirection}");
        }
        else if (currentAnimation.StartsWith($"{entityBase.Name}_{baseName}"))
        {
            // Cùng animation và cùng hướng => không cần cập nhật lại
            return;
        }

        Debug.Log($"[AnimationPlay] Playing: {animName}");
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
