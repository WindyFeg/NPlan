using UnityEngine;

/// <summary>
/// Static class containing the base names of animation states used in character animations.
/// These names are concatenated with direction (e.g., "IdleDown", "WalkingLeft").
/// </summary>
public static class AnimNames
{
    public const string Idle = "Idle";
    public const string Walking = "Walking";
    public const string Running = "Running";
    public const string Gathering = "Gathering";
    public const string Attack = "Attack";
    public const string Hit = "Hit";
    public const string Death = "Death";
}

/// <summary>
/// Controls the animation states of a character based on direction and action.
/// </summary>
public class CharacterAnimation : MonoBehaviour, ICharacterAnimation
{
    #region Serialized Fields

    [Tooltip("Reference to the character's data model.")]
    [SerializeField] private PlayerModel characterModel;

    #endregion

    #region Private Fields

    private Animator anim;
    private string currentAnimation;
    private string lastDirection = "Down"; // Default direction

    #endregion

    #region Unity Methods

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    #endregion

    #region Animation Control

    /// <summary>
    /// Plays an animation based on the base name and the current direction (e.g., "WalkingUp").
    /// </summary>
    /// <param name="baseName">The base name of the animation.</param>
    private void PlayDirectionalAnimation(string baseName)
    {
        string animName = baseName + lastDirection;

        if (currentAnimation == animName) return;

        anim.Play(animName);
        currentAnimation = animName;
    }

    /// <summary>Plays the idle animation based on direction.</summary>
    public void PlayIdleAnimation() => PlayDirectionalAnimation(AnimNames.Idle);

    /// <summary>Plays the walking animation based on direction.</summary>
    public void PlayWalkingAnimation() => PlayDirectionalAnimation(AnimNames.Walking);

    /// <summary>Plays the running animation based on direction.</summary>
    public void PlayRunningAnimation() => PlayDirectionalAnimation(AnimNames.Running);

    /// <summary>Plays the attack animation based on direction.</summary>
    public void PlayAttackAnimation() => PlayDirectionalAnimation(AnimNames.Attack);

    /// <summary>Plays the hit animation based on direction.</summary>
    public void PlayHitAnimation() => PlayDirectionalAnimation(AnimNames.Hit);

    /// <summary>Plays the death animation based on direction.</summary>
    public void PlayDeathAnimation() => PlayDirectionalAnimation(AnimNames.Death);

    /// <summary>Plays the gathering animation based on direction.</summary>
    public void PlayGatheringAnimation() => PlayDirectionalAnimation(AnimNames.Gathering);

    #endregion

    #region Animation Parameters

    /// <summary>
    /// Sets the character's facing direction for animation (e.g., "Up", "Down", "Left", "Right").
    /// </summary>
    /// <param name="direction">The new facing direction.</param>
    public void SetDirection(string direction)
    {
        lastDirection = direction;
        characterModel.CurrentDirection = direction;
    }

    /// <summary>
    /// Optionally adjusts the speed of the animation (e.g., based on character movement).
    /// </summary>
    /// <param name="speed">The movement speed value.</param>
    public void SetSpeed(float speed)
    {
        // Optional: Adjust animation playback speed or blend tree
    }

    /// <summary>
    /// Optionally changes the attack animation variant (e.g., "Slash", "Thrust").
    /// </summary>
    /// <param name="attackType">The type of attack animation to use.</param>
    public void SetAttackType(string attackType)
    {
        // Optional: Change animation trigger or override controller based on attackType
    }

    #endregion
}