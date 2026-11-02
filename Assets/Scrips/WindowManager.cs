using UnityEngine;
using System.Collections.Generic;
using System.Security.Principal;

public class WindowManager : MonoBehaviour
{
    public List<GenericWindow> Windows;
    public Windows defaultWindow;
    public Windows CurrentWindow {get; private set;}

    private void Start()
    {
        foreach (var window in Windows)
        {
            window.Init(this);
            window.gameObject.SetActive(false);
        }
        CurrentWindow = defaultWindow;
        Windows[(int)CurrentWindow].Open();
    }

    public void Open(Windows id)
    {
        Windows[(int)CurrentWindow].Close();
        CurrentWindow = id;
        Windows[(int)CurrentWindow].Open();
    }
}
