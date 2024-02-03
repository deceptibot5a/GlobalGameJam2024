using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainItems;
    [SerializeField] GameObject creditsItems;
    [SerializeField] TextMeshProUGUI switchButtonText;
    private bool isCredits;

    public void SwitchEvent()
    {
        if (isCredits)
        {
            BackToMainMenu();
        }
        else
        {
            CreditsMenu();
        }
    }
    public void BackToMainMenu()
    {
        isCredits = false;
        mainItems.SetActive(true);
        creditsItems.SetActive(false);
        switchButtonText.text = "CRÉDITOS";
    }

    public void CreditsMenu()
    {
        isCredits = true;
        mainItems.SetActive(false);
        creditsItems.SetActive(true);
        switchButtonText.text = "REGRESAR";
    }
}
