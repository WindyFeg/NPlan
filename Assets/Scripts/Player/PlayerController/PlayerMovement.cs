using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private MovementDataSO movementData;
    private Vector2 movementDirection;
    private Vector3 currentInput;

    [Header("Animations")]
    private string lastDirection = "Down";
    private ICharacterAnimation characterAnimation;
    private CharacterState characterState;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        characterAnimation = GetComponent<ICharacterAnimation>();
        characterState = GetComponent<CharacterState>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(movementDirection.x, movementDirection.y, 0) * movementData.moveSpeed;
    }

    private Vector2 GetDirection(Vector2 input)
    {
        Vector2 finalDirection = Vector2.zero;

        if (input.magnitude > 0.01f)
        {
            characterState.CurrentState = CharacterState.State.Walking;

            // Normalize input to handle diagonal speed correctly
            finalDirection = input.normalized;

            // Determine animation direction (optional: prioritize vertical or horizontal)
            if (input.y > 0.01f)
                lastDirection = "Up";
            else if (input.y < -0.01f)
                lastDirection = "Down";
            if (input.x > 0.01f)
                lastDirection = "Right";
            else if (input.x < -0.01f)
                lastDirection = "Left";

            characterAnimation.SetDirection(lastDirection);
        }
        else
        {
            characterState.CurrentState = CharacterState.State.Idle;
            characterAnimation.PlayIdleAnimation();
        }

        return finalDirection;
    }

    #region Input
    private void OnMove(InputValue value)
    {
        currentInput = value.Get<Vector2>().normalized;
        movementDirection = GetDirection(currentInput);
    }
    #endregion
}
