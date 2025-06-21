using UnityEngine;

public interface ICharacterAnimation
{
    void PlayIdleAnimation();
    void PlayWalkingAnimation();
    void PlayRunningAnimation();
    void PlayGatheringAnimation();
    void PlayAttackAnimation();
    void PlayHitAnimation();
    void PlayDeathAnimation();

    void SetDirection(string direction);
    void SetSpeed(float speed);
    void SetAttackType(string attackType);
    
    // Optional: Add methods for specific animations if needed
    // e.g., PlayJumpAnimation(), PlayCrouchAnimation(), etc.
}
