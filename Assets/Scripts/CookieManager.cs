using System;
using TMPro;
using UnityEngine;

public class CookieManager : MonoBehaviour
{

    public TextMeshProUGUI CookieText;
    public Cookies Cookies;
    public Upgrades Upgrades;


    private void OnEnable()
    {
        Cookies.OnCookieUpdate += UpdateCookieText;
    }

    private void OnDisable()
    {
        Cookies.OnCookieUpdate -= UpdateCookieText;
    }

    public void Increment()
    {
        Cookies.ChangeCookies(Cookies.amount + Upgrades.clickMultiplier);
    }

    private void UpdateCookieText()
    {
        CookieText.text = $"Cookies: {Cookies.amount.ToString()}";
    }
    
}
