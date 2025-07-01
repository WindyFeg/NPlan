using UnityEngine;
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
public class CharacterAnimation : MonoBehaviour, ICharacterAnimation
{
    [SerializeField] private PlayerModel characterModel;
    private Animator anim;
    public string currentAnimation;
    private string lastDirection = "Down";
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void PlayDirectionalAnimation(string baseName)
    {
        string animName = baseName + lastDirection;
        if (currentAnimation == animName) return;
        anim.Play(animName);
        currentAnimation = animName;
    }
    public void PlayIdleAnimation() => PlayDirectionalAnimation(AnimNames.Idle);
    public void PlayWalkingAnimation() => PlayDirectionalAnimation(AnimNames.Walking);
    public void PlayRunningAnimation() => PlayDirectionalAnimation(AnimNames.Running);
    public void PlayAttackAnimation() => PlayDirectionalAnimation(AnimNames.Attack);
    public void PlayHitAnimation() => PlayDirectionalAnimation(AnimNames.Hit);
    public void PlayDeathAnimation() => PlayDirectionalAnimation(AnimNames.Death);
    public void PlayGatheringAnimation() => PlayDirectionalAnimation(AnimNames.Gathering);


    public void SetDirection(string direction)
    {
        lastDirection = direction;
        characterModel.CurrentDirection = direction;
    }
    public void SetSpeed(float speed)
    {
        // Implement this method if you want to change the speed of the animation
    }
    public void SetAttackType(string attackType)
    {
        // Implement this method if you want to change the attack type of the animation
    }
}
