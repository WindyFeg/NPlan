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
    [SerializeField] private Transform rootTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        characterAnimation = GetComponentInChildren<ICharacterAnimation>();
        characterModel = GetComponent<PlayerModel>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if(movementInput == Vector2.zero)
        {
            characterModel.CurrentState = State.Idle;
            rb.linearVelocity = Vector3.zero;
            return;
        }
        rb.linearVelocity = new Vector3(movementInput.x, 0f, movementInput.y) * movementData.moveSpeed;
        characterModel.CurrentState = State.Walking;
    }

    private Vector2 ProcessInput(Vector2 input)
    {
        if (input.magnitude > 0.01f)
        {
            return input.normalized;
        }
        return Vector2.zero;
    }

    // private void UpdateLastDirection(Vector2 input)
    // {
    //     if (Mathf.Abs(input.y) != 0)
    //     {
    
    //         characterAnimation.SetDirection(input.y > 0 ? "Up" : "Down");
    //     }
    //     else if (Mathf.Abs(input.x) != 0 && Mathf.Abs(input.y) == 0)
    //     {

    //         characterAnimation.SetDirection(input.x > 0 ? "Right" : "Left");
    //     }
    // }

    #region Input Handling
    private void OnMove(InputValue value)
    {
        currentInput = value.Get<Vector2>();
        // UpdateLastDirection(currentInput);
        movementInput = ProcessInput(currentInput);

    }
    #endregion
}
