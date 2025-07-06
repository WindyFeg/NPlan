using UnityEngine; // Essential for Debug.Log
using System.Runtime.CompilerServices; // For Caller attributes
using System.IO;
using LKT268.Model.CommonBase; // For Path.GetFileName

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
            string logMessage = $"[258LTK LOG] - NOT IMPLEMENTED \nClass: {typeName}, \nFile: {fileName}, \nFunction: {memberName}, \nLine: {lineNumber}\n\n";

            // *** Use Unity's Debug.LogWarning or Debug.LogError for better visibility in the Unity Console ***
            Debug.LogWarning(logMessage);
        }

        public static void LogInfo(string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            string fileName = Path.GetFileName(filePath);
            // Format the log so that the file and line are clickable in Unity Console
            string logMessage = $"[258LTK LOG] - INFO: {message} \n({fileName}:{lineNumber}) in {memberName}";
            Debug.Log(logMessage, null); // The null context allows Unity to make the file:line clickable
        }

        public static void LogEntity(EntityBase entityBase)
        {
            Debug.Log($"[258LTK LOG] - ENTITY: \n{entityBase}\n\n");
        }

        public static void LogEntityAction(EntityBase entityBase, string action)
        {
            Debug.Log($"[258LTK LOG] - ENTITY ACTION: \nEntity: {entityBase.Name}, Action: {action}\n\n");
        }

        public static void LogFalseConfig<T>(
            string message,
            T obj,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            string typeName = typeof(T).Name;
            string fileName = Path.GetFileName(filePath);
            string logMessage = $"[258LTK LOG] - FALSE CONFIG: \nFile: {fileName}, \nFunction: {memberName}, \nLine: {lineNumber}\n\n Message: {message}\n\n";

            // *** Use Unity's Debug.LogWarning or Debug.LogError for better visibility in the Unity Console ***
            Debug.LogWarning(logMessage);
        }

        /// <summary>
        /// Manager log errors
        /// </summary>
        /// <param name="filePath">Automatically filled by the compiler with the caller's file path.</param>
        /// <param name="lineNumber">Automatically filled by the compiler with the caller's line number.</param>
        /// <param name="memberName">Automatically filled by the compiler with the caller's member name (function/property).</param>
        public static void ManagerError(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            string fileName = Path.GetFileName(filePath);
            string logMessage = $"[258LTK LOG] - MANAGER ERROR: \nFile: {fileName}, \nFunction: {memberName}, \nLine: {lineNumber}\n\nMessage: {message}\n\n";

            // Log the error message to the Unity Console
            Debug.LogError(logMessage);
        }

        /// <summary>
        /// Your custom log
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="filePath">Automatically filled by the compiler with the caller's file path.</param>
        /// <param name="lineNumber">Automatically filled by the compiler with the caller's line number.</param>
        /// <param name="memberName">Automatically filled by the compiler with the caller's member name (function/property).</param>
        public static void ManagerLog(
            string message,
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "")
        {
            string fileName = Path.GetFileName(filePath);
            string logMessage = $"[258LTK LOG] - MANAGER LOG: \nFile: {fileName}, \nFunction: {memberName}, \nLine: {lineNumber}\n\nMessage: {message}\n\n";

            // Log the error message to the Unity Console
            Debug.Log(logMessage);
        }
    }
}