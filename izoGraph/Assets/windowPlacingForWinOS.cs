using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class windowPlacingForWinOS : MonoBehaviour
{


#if UNITY_STANDALONE_WIN || UNITY_EDITOR
    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    private static extern bool SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    [DllImport("user32.dll", EntryPoint = "FindWindow")]
    public static extern IntPtr FindWindow(System.String className, System.String windowName);
    /*[DllImport("user32.dll", EntryPoint = "ShowWindow")]
    public static extern IntPtr ShowWindow(IntPtr hwnd, int nCmdShow);*/

    public static void SetPosition(int x, int y, int resX = 0, int resY = 0)
    {
        SetWindowPos(FindWindow(null, "izoGraph"), 0, x, y, resX, resY, resX * resY == 0 ? 1 : 0);
    }

   /* public static void maximize()
    {
        ShowWindow(FindWindow(null, "izoGraph"), 3);
    }*/
#endif

    // Use this for initialization
    public void Awake()
    {
     // Debug.Log("setPos reached");
        
       // maximize();
        Screen.SetResolution(Screen.currentResolution.width - 600, Screen.currentResolution.height, false);
        SetPosition(600, 0);
    }
}
