using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.EntityUI
{
    public class UIRequiredItem : MonoBehaviour
    {
        
        public Image itemIcon;
        public TextMeshProUGUI text;
        
        [Header("Colors")]
        public Color inactiveColor = Color.white;
        public Color activeColor = Color.green;
        
        private int requireItemId;
        private int total;
        private int current;
        

        public void SetData(int totalCost, int current)
        {
            this.total = totalCost;
            this.current = current;
            
            UpdateUI();
        }

        public void SetSprite(Sprite icon)
        {
            itemIcon.sprite = icon;
        }
        
        public void UpdateUI()
        {
            text.text = $"{current}/{total}";
            if (current >= total)
            {
                text.color = activeColor;
            }
            else
            {
                text.color = inactiveColor;
            }
        }
    }
}