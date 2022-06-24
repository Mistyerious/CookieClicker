using System;
using Unity.VisualScripting;
using UnityEngine;

public class Cookies : MonoBehaviour
{
    public int amount = 0;
    public static event Action OnCookieUpdate;

    public void ChangeCookies(int change)
    {
        if (OnCookieUpdate != null)
        {
            amount = change;
            OnCookieUpdate();
        }
    }
}
