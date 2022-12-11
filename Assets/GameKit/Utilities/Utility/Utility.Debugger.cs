using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using UnityEngine;
namespace GameKit
{
    public static partial class Utility
    {
        public static class Debugger
        {
            public static void Log(string info) => Debug.Log(info);
            public static void LogWarning(string info) => Debug.LogWarning(info);
            public static void LogError(string info) => Debug.LogError(info);
            public static void LogSuccess(string info) => Debug.Log(Utility.Text.Format("<b><color=green>[Success]</color></b> {0}", info));
            public static void LogFail(string info) => Debug.Log(Utility.Text.Format("<b><color=red>[Failed]</color></b> {0}", info));
            public static void LogExcute(string info, bool success)
            {
                if (success)
                    LogSuccess(info);
                else
                    LogFail(info);
            }
        }
    }
}

