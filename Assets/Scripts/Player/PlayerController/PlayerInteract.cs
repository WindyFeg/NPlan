using UnityEngine;
using System.Collections.Generic;
using LTK268.Interface;
using LTK268.Model.CommonBase;
using UnityEngine.InputSystem;

/// <summary>
/// Handles player interactions with nearby interactable entities (e.g., NPCs, items).
/// Attach this script to the player GameObject that has a Collider with "IsTrigger" enabled.
/// </summary>
public class PlayerInteract : MonoBehaviour
{
    #region Serialized Fields

    [Tooltip("Reference to the player's data model.")]
    [SerializeField] private PlayerModel playerModel;

    #endregion

    #region Private Fields

    private IEntity currentInteractable;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {

    }

    private void OnEnable()
    {
        // Hook input events if necessary.
    }

    private void OnDisable()
    {
        // Unhook input events to prevent memory leaks.
    }

    #endregion

    #region Interaction Events

    /// <summary>
    /// Called when the player performs an interact input.
    /// Interacts with the current interactable entity if available.
    /// </summary>
    public void OnInteract()
    {
        if (currentInteractable == null || ((MonoBehaviour)currentInteractable) == null) return;

        currentInteractable.InteractWithEntity(playerModel);
        currentInteractable = null;
    }

    /// <summary>
    /// Called when the player performs an attack input.
    /// Placeholder for combat logic.
    /// </summary>
    public void OnAttack()
    {
        // Implement attack logic if needed.
    }

    #endregion

    #region Trigger Handlers

    /// <summary>
    /// Called continuously while another collider stays inside this trigger.
    /// Sets the first detected interactable as the current one if none is active.
    /// </summary>
    /// <param name="other">Collider of the other object.</param>
    private void OnTriggerStay(Collider other)
    {
        if (currentInteractable != null) return;

        var interactable = other.GetComponent<IEntity>();
        if (interactable != null)
        {
            currentInteractable = interactable;
        }
    }

    /// <summary>
    /// Called when another collider exits this trigger.
    /// Clears the current interactable reference if it's the one leaving.
    /// </summary>
    /// <param name="other">Collider of the other object.</param>
    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponent<IEntity>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
        }
    }

    #endregion
}
