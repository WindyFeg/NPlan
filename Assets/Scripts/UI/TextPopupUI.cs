// using DG.Tweening;
// using LTK268.Interface;
// using TMPro;
// using Unity.AppUI.UI;
// using UnityEngine;
// using UnityEngine.LightTransport;
// namespace LTK268
// {
//     public class TextPopupUI : MonoBehaviour
//     {
//         private TextMeshProUGUI textPopup;
//         // Start is called once before the first execution of Update after the MonoBehaviour is created
//         void Start()
//         {
//             textPopup = GetComponentInChildren<TextMeshProUGUI>();
//             this.SubcribeEvent((int)EventID.Game.OnObjectInOfRange, (string text, Transform objectTransform) => ShowTextPopup(text, objectTransform));
//             this.SubcribeEvent((int)EventID.Game.OnObjectOutOfRange, () => HidePopup());
//             this.deactive();

//             // EnventUIManager.Instance.Subscribe(EnventUIID.ID, ShowTextPopup());
//         }

//         void ShowTextPopup(string text, Transform objectTransform)
//         {
//             this.transform.position = objectTransform.position + new Vector3(0, 1.5f, 0);
//             this.active();
//             this.rt().localScale = new Vector3(0, 0, 0);
//             this.rt().DOScale(new Vector3(1, 1, 1), 0.4f).SetEase(Ease.OutBack);
//             textPopup.text = text;
//             Debug.Log($"TextPopupUI: ShowTextPopup: {text}");
//         }

//         void HidePopup()
//         {
//             this.deactive();
//         }


//     }
// }