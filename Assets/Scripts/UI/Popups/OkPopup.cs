using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OkPopup : BasePopup
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button[] actionButtons;
    [SerializeField] private TextMeshProUGUI[] actionTexts;

    private void OnValidate()
    {
        if (gameObject.name != GetType().Name)
        {
            gameObject.name = GetType().Name;
        }
    }
    
    private void Awake()
    {
        actionButtons[0].onClick.AddListener(() =>
        {
            // Handle your logic
            Hide();
        });
    }

    protected override void ApplyArgs(object[] args)
    {
        var message = args[0] as string;
        messageText.text = message;
        // Assign variable = arg[index] as Type
        actionTexts[0].text = args[1] as string;
    }
}