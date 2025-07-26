using System;
using UnityEngine;

public abstract class BasePopup : MonoBehaviour
{
    public string PopupName;

    protected Action onCloseCallback;

    public virtual void ShowWithArgs(object[] args)
    {
        gameObject.SetActive(true);
        ApplyArgs(args);
    }

    protected virtual void ApplyArgs(object[] args)
    {
        // To be overridden by child classes
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        onCloseCallback?.Invoke();
        onCloseCallback = null;
    }
}