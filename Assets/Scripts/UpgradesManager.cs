using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    
    public TextMeshProUGUI ClickUpgradeLevelText;
    public Button ClickUpgradeLevelButton;
    public Upgrades Upgrades;
    public Cookies Cookies;
    public TextMeshProUGUI CookieAmountText;

    private void IncrementClickMultiplier()
    {
        Upgrades.clickMultiplier++;
        UpdateClickMultiplierText(Upgrades.clickMultiplier.ToString());
    }

    private void IncrementClickMultiplierCost()
    {
        Upgrades.clickMultiplierCost *= 2;
        UpdateClickMultiplierCostText(Upgrades.clickMultiplierCost.ToString());
    }

    private void UpdateClickMultiplierText(string clickUpgradeLevelText)
    {
        ClickUpgradeLevelText.text = $"Level: {clickUpgradeLevelText}";
    }

    private void UpdateCookiesText()
    {
        CookieAmountText.text = $"Cookies: {Cookies.amount}";
    }

    private void UpdateClickMultiplierCostText(string text)
    {
        ClickUpgradeLevelButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Cost: {text}";
    }

    private void OnEnable()
    {
        Cookies.OnCookieUpdate += UpdateCookiesText;
    }

    private void OnDisable()
    {
        Cookies.OnCookieUpdate -= UpdateCookiesText;
    }

    public void BuyClickMultiplier()
    {
        if (Cookies.amount < Upgrades.clickMultiplierCost)
        {
            // alert user they don't have enough
            return;
        }
        
        Cookies.ChangeCookies(Cookies.amount - Upgrades.clickMultiplierCost);
        IncrementClickMultiplier();
        IncrementClickMultiplierCost();
    }
}
