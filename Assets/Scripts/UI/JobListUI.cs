// using Unity.Jobs.LowLevel.Unsafe;
// using UnityEngine;
// using LTK268.Utils;
// using System.Collections.Generic;
// using DG.Tweening;

// namespace LTK268
// {
//     public class JobListUI : MonoBehaviour
//     {
//         // Start is called once before the first execution of Update after the MonoBehaviour is created
//         [SerializeField] private GameObject jobListPanel;
//         private List<JobItemUI> listJobItemUI = new List<JobItemUI>();
//         void Start()
//         {
//             listJobItemUI = new List<JobItemUI>(GetComponentsInChildren<JobItemUI>());
//             SubcribeEvents();
//             this.deactive();
//         }

//         void SubcribeEvents()
//         {
//             this.SubcribeEvent((int)EventID.Game.OnOpenJobList, (NPCFunctionType jobType) => OpenJobList(jobType));
//             this.SubcribeEvent((int)EventID.Game.OnCloseJobList,  CloseJobList);
//             this.SubcribeEvent((int)EventID.Game.OnSwipeLeftJobList, SwipeLeftJobList);
//             this.SubcribeEvent((int)EventID.Game.OnSwipeRightJobList, SwipeRightJobList);
//         }


//         void OpenJobList(NPCFunctionType jobType)
//         {
//             this.active();
//             JobItemUI centerItemUI = GetCurrentCenterItem();
//             JobItemUI leftItemUI = GetCurrentLeftItem();
//             JobItemUI rightItemUI = GetCurrentRightItem();


//             centerItemUI.SetItem(jobType);
//             leftItemUI.SetItem(jobType - 1);
//             rightItemUI.SetItem(jobType + 1);
//         }
//         void SwipeLeftJobList()
//         {
//             if (IsAnimating()) return;
//             JobItemUI leftItemUI = GetCurrentLeftItem();
//             JobItemUI centerItemUI = GetCurrentCenterItem();
//             JobItemUI rightItemUI = GetCurrentRightItem();
//             Vector3 leftPos = leftItemUI.transform.localPosition;
//             Vector3 centerPos = centerItemUI.transform.localPosition;
//             Vector3 rightPos = rightItemUI.transform.localPosition;
//             rightItemUI.rt().DOLocalMove(centerPos, 0.3f).SetEase(Ease.OutCubic)
//             .OnComplete(() =>
//             {
//                 rightItemUI.jobItemPos = JobItemPos.Center;
//                 rightItemUI.rt().DOScale(Vector3.one * 1.3f, 0.3f).SetEase(Ease.OutCubic);
//             });
//             centerItemUI.rt().DOLocalMove(leftPos, 0.3f).SetEase(Ease.OutCubic)
//             .OnComplete(() =>
//             {
//                 centerItemUI.jobItemPos = JobItemPos.Left;
//                 centerItemUI.rt().DOScale(Vector3.one, 0.3f).SetEase(Ease.OutCubic);
//             });
//             leftItemUI.rt().DOLocalMove(rightPos, 0.3f).SetEase(Ease.OutCubic)
//             .OnComplete(() =>
//             {
//                 leftItemUI.jobItemPos = JobItemPos.Right;
//             });
//         }

//         void SwipeRightJobList()
//         {
//             if (IsAnimating())
//                 return;
//             JobItemUI leftItemUI = GetCurrentLeftItem();
//             JobItemUI centerItemUI = GetCurrentCenterItem();
//             JobItemUI rightItemUI = GetCurrentRightItem();
//             Vector3 leftPos = leftItemUI.transform.localPosition;
//             Vector3 centerPos = centerItemUI.transform.localPosition;
//             Vector3 rightPos = rightItemUI.transform.localPosition;
//             leftItemUI.rt().DOLocalMove(centerPos, 0.3f).SetEase(Ease.OutCubic)
//             .OnComplete(() =>
//             {
//                 leftItemUI.jobItemPos = JobItemPos.Center;
//                 leftItemUI.rt().DOScale(Vector3.one * 1.3f, 0.3f).SetEase(Ease.OutCubic);
//             });
//             centerItemUI.rt().DOLocalMove(rightPos, 0.3f).SetEase(Ease.OutCubic)
//             .OnComplete(() =>
//             {
//                 centerItemUI.jobItemPos = JobItemPos.Right;
//                 centerItemUI.rt().DOScale(Vector3.one, 0.3f).SetEase(Ease.OutCubic);
//             });
//             rightItemUI.rt().DOLocalMove(leftPos, 0.3f).SetEase(Ease.OutCubic)
//             .OnComplete(() =>
//             {
//                 rightItemUI.jobItemPos = JobItemPos.Left;
//             });
//         }
//         void CloseJobList()
//         {
//             this.deactive();
//         }
//         JobItemUI GetCurrentCenterItem()
//         {
//             foreach (var item in listJobItemUI)
//             {
//                 if (item.jobItemPos == JobItemPos.Center)
//                 {
//                     return item;
//                 }
//             }
//             return null;
//         }
//         JobItemUI GetCurrentLeftItem()
//         {
//             foreach (var item in listJobItemUI)
//             {
//                 if (item.jobItemPos == JobItemPos.Left)
//                 {
//                     return item;
//                 }
//             }
//             return null;
//         }
//         JobItemUI GetCurrentRightItem()
//         {
//             foreach (var item in listJobItemUI)
//             {
//                 if (item.jobItemPos == JobItemPos.Right)
//                 {
//                     return item;
//                 }
//             }
//             return null;
//         }
//         bool IsAnimating()
//         {
//             return DOTween.IsTweening(GetCurrentLeftItem().rt())
//                 || DOTween.IsTweening(GetCurrentCenterItem().rt())
//                 || DOTween.IsTweening(GetCurrentRightItem().rt());
//         }

//     }
// }