using UnityEngine; // Essential for Debug.Log
using System.Runtime.CompilerServices; // For Caller attributes
using System.IO; // For Path.GetFileName

namespace LKT268.Utils
{
    public static class LTK268Log
    {
        /// <summary>
        /// Logs a "Not Implemented" message to the Unity Console,
        /// including the class name, file, function, and line number where it was called.
        /// </summary>
        /// <typeparam name="T">The type of the object being logged.</typeparam>
        /// <param name="obj">The object instance or type that is not implemented.</param>
        /// <param name="filePath">Automatically filled by the compiler with the caller's file path.</param>
        /// <param name="lineNumber">Automatically filled by the compiler with the caller's line number.</param>
        /// <param name="memberName">Automatically filled by the compiler with the caller's member name (function/property).</param>
        public static void LogNotImplement<T>(
            T obj,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            string typeName = typeof(T).Name;
            string fileName = Path.GetFileName(filePath);
            string logMessage = $"[258LTK LOG] - NOT IMPLEMENTED Class: {typeName}, File: {fileName}, Function: {memberName}, Line: {lineNumber}";

            // *** Use Unity's Debug.LogWarning or Debug.LogError for better visibility in the Unity Console ***
            Debug.LogWarning(logMessage);
        }

        public static void LogInfo(string message)
        {
            // Log an informational message to the Unity Console
            Debug.Log($"[258LTK LOG] - INFO: {message}");
        }
    }
}