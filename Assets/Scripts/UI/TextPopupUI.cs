using aclf;
using DG.Tweening;
using LKT268.Interface;
using TMPro;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.LightTransport;
namespace LKT268
{
    public class TextPopupUI : MonoBehaviour
    {
        private TextMeshProUGUI textPopup;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            textPopup = GetComponentInChildren<TextMeshProUGUI>();
            this.on((int)EventID.Game.OnObjectInOfRange, (string text, Transform objectTransform) => ShowTextPopup(text, objectTransform));
            this.on((int)EventID.Game.OnObjectOutOfRange, () => HidePopup());
            this.deactive();
        }

        void ShowTextPopup(string text, Transform objectTransform)
        {
            this.transform.position = objectTransform.position + new Vector3(0, 1.5f, 0);
            this.active();
            this.rt().localScale = new Vector3(0, 0, 0);
            this.rt().DOScale(new Vector3(1, 1, 1), 0.4f).SetEase(Ease.OutBack);
            textPopup.text = text;
            Debug.Log($"TextPopupUI: ShowTextPopup: {text}");
        }

        void HidePopup()
        {
            this.deactive();
        }


    }
}