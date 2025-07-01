using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private MovementDataSO movementData;
    private Vector2 movementInput;
    private Vector3 currentInput;

    [Header("Animations")]
    private ICharacterAnimation characterAnimation;
    [SerializeField] private PlayerModel characterModel;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        characterAnimation = GetComponent<ICharacterAnimation>();
        characterModel = GetComponent<PlayerModel>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(movementInput.x, 0f, movementInput.y) * movementData.moveSpeed;
    }

    private Vector2 ProcessInput(Vector2 input)
    {
        if (input.magnitude > 0.01f)
        {
            characterModel.CurrentState = State.Walking;
            return input.normalized;
        }

        characterModel.CurrentState = State.Idle;
        characterAnimation.PlayIdleAnimation();
        return Vector2.zero;
    }

    private void UpdateLastDirection(Vector2 input)
    {
        if (Mathf.Abs(input.y) != 0)
        {
    
            characterAnimation.SetDirection(input.y > 0 ? "Up" : "Down");
        }
        else if (Mathf.Abs(input.x) != 0 && Mathf.Abs(input.y) == 0)
        {

            characterAnimation.SetDirection(input.x > 0 ? "Right" : "Left");
        }
    }

    #region Input Handling
    private void OnMove(InputValue value)
    {
        currentInput = value.Get<Vector2>();
        UpdateLastDirection(currentInput);
        movementInput = ProcessInput(currentInput);

    }
    #endregion
}
