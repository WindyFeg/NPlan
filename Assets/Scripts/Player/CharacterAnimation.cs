using UnityEngine;

public class CharacterAnimation : MonoBehaviour, ICharacterAnimation
{
    private Animator anim;
    public string currentAnimation;
    private string lastDirection = "Down";
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayIdleAnimation()
    {
        if (currentAnimation == "Idle") return;
        anim.Play("Idle");
        currentAnimation = "Idle";
    }
    public void PlayWalkingAnimation()
    {
        if (currentAnimation == "Walking") return;
        anim.Play("Walking" + lastDirection);
        Debug.Log("Walking" + lastDirection);
        currentAnimation = "Walking";
    }
    public void PlayRunningAnimation()
    {
        if (currentAnimation == "Running") return;
        anim.Play("Running" + lastDirection);
        currentAnimation = "Running";
    }
    public void PlayGatheringAnimation()
    {
        if (currentAnimation == "Gathering") return;
        anim.Play("Gathering" + lastDirection);
        currentAnimation = "Gathering";
    }
    public void PlayAttackAnimation()
    {
        if (currentAnimation == "Attack" + lastDirection) return;
        anim.Play("Attack" + lastDirection);
        currentAnimation = "Attack" + lastDirection;
    }
    public void PlayHitAnimation()
    {
        if (currentAnimation == "Hit" + lastDirection) return;
        anim.Play("Hit" + lastDirection);
        currentAnimation = "Hit" + lastDirection;
    }
    public void PlayDeathAnimation()
    {
        if (currentAnimation == "Death" + lastDirection) return;
        anim.Play("Death" + lastDirection);
        currentAnimation = "Death" + lastDirection;
    }

    public void SetDirection(string direction)
    {
        lastDirection = direction;
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
