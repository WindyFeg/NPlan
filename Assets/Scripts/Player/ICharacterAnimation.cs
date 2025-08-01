using UnityEngine;

public interface ICharacterAnimation
{
    // void PlayIdleAnimation();
    // void PlayWalkingAnimation();
    // void PlayRunningAnimation();
    // void PlayPickupAnimation();
    // void PlayAttackAnimation();
    // void PlayHitAnimation();
    // void PlayDeathAnimation();
    void SetAnimState(AnimState state);

    // void SetDirection(string direction);
    void SetSpeed(float speed);
    void SetAttackType(string attackType);
    
    // Optional: Add methods for specific animations if needed
    // e.g., PlayJumpAnimation(), PlayCrouchAnimation(), etc.
}
