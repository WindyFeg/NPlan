// using System;
// using LTK268.Define;
// using Unity.VisualScripting;
// using UnityEngine;
//
// namespace LTK268.Manager
// {
//     public class TimeManager : MonoBehaviour
//     {
//         [Header("Date & Time")]
//         [Range(1, 31)]
//         public int dateInMonth;
//         public Season seasonInYear = Season.Spring;
//         [Range(1, 12)]
//         public int monthInYear = 12;
//         [Range(1, 99)]
//         public int yearInGame = 99;
//         [Range(1, 24)]
//         public int hourInDay = 24;
//
//         [Header("Tick Settings")] 
//         public float tickDuration = 1;
//         public int minutePerTick = 10;
//
//         private DateTime dateTime;
//         private float timeElapsed;
//         
//         public static Action<DateTime> OnDateTimeChanged;
//         
//         private void Awake()
//         {
//             // Initialize dateTime with the current values
//             dateTime = new DateTime(yearInGame, monthInYear, dateInMonth, hourInDay, 0, 0);
//             UpdateSeason();
//             timeElapsed = 0f;
//         }
//
//         private void FixedUpdate()
//         {
//             if (timeElapsed >= tickDuration)
//             {
//                 timeElapsed -= tickDuration;
//                 Tick();
//             }
//             else
//             {
//                 timeElapsed += Time.fixedDeltaTime;
//             }
//         }
//
//         private void Tick()
//         {
//             AdvanceMinutes();
//             OnDateTimeChanged?.Invoke(dateTime);
//         }
//         
//         #region Time Advancement
//         
//         private void AdvanceMinutes()
//         {
//             dateTime = dateTime.AddMinutes(minutePerTick);
//             UpdateSeason();
//             Debug.Log($"New Date & Time: {dateTime}");
//         }
//
//         private void UpdateSeason()
//         {
//             seasonInYear = monthInYear switch
//             {
//                 1 or 2 or 3 => Season.Spring,
//                 4 or 5 or 6 => Season.Summer,
//                 7 or 8 or 9 => Season.Autumn,
//                 10 or 11 or 12 => Season.Winter,
//                 _ => seasonInYear
//             };
//         }
//         
//         #endregion
//     }
// }