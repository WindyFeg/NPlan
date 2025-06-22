using UnityEngine;
using System.Collections.Generic;
using LKT268.Interface;
using LKT268.Model.CommonBase;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private InputAction interactAction;
    private PlayerBehavior playerBehavior;
    private List<IEntity> interactablesInRange = new List<IEntity>();
    private IEntity currentInteractable;

    void Start()
    {
        playerBehavior = GetComponent<Player>().playerBehavior;
        interactAction = InputSystem.actions.FindAction("Interact");
    }
    void OnEnable()
    {
    }
    void OnDisable()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<IEntity>();
        if (interactable != null)
        {
            Debug.Log("PlayerInteract - OnTriggerEnter: Interactable found.");
            interactablesInRange.Add(interactable);
        }
    }

    void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponent<IEntity>();
        if (interactable != null)
        {
            interactablesInRange.Remove(interactable);
        }
    }

    void Update()
    {
        UpdateClosestInteractable();

        if (interactAction.WasPressedThisFrame() && currentInteractable != null)
        {
            playerBehavior.InteractWithObject(currentInteractable);
        }
    }

    void UpdateClosestInteractable()
    {
        float closestDistance = float.MaxValue;
        IEntity closest = null;

        foreach (var interactable in interactablesInRange)
        {
            float dist = Vector3.Distance(transform.position, ((MonoBehaviour)interactable).transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closest = interactable;
            }
        }

        currentInteractable = closest;
    }

}
