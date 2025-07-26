using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.EntityUI
{
    public class UIAction : MonoBehaviour
    {
        public TextMeshProUGUI keyText;
        public TextMeshProUGUI descriptionText;
        
        public void SetData(string key, string description)
        {
            keyText.text = key;
            descriptionText.text = description;
        }
    }
}