using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    public GameObject[] windows;

    GameObject nowOnWindow;

    public void SetSelectWindowActiveOn(int idx)
    {
        SetUnselectedActiveOff();
        nowOnWindow = windows[idx];
        nowOnWindow.SetActive(true);
    }

    private void SetUnselectedActiveOff()
    {
        if(nowOnWindow != null)
        {
            nowOnWindow.SetActive(false);
        }
    }
}
