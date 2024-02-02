using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

public class UiEventManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialog;
    [SerializeField] GameObject chatBox;
    [SerializeField] Image avatar;
    [SerializeField] CharacterSO character;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] AudioManager audioManager;
    [SerializeField] GameObject corpseInstance;

    [SerializeField] GameObject winMessage;
    [SerializeField] GameObject loseMessage;
    [SerializeField] GameObject endingCanvas;

    bool listIsOpen = true;

    public void SetListIsOpen (bool isOper)
    {
        listIsOpen = isOper;
    }
    public bool GetListIsOpen()
    {
        return listIsOpen;
    }
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        SetSkins();
    }

    private void SetSkins()
    {
        nameText.text = character.GetCharacterName();
        dialog.text = character.GetDialogue();
        avatar.sprite = character.GetAvatar();
    }

    public void SetCharacter(CharacterSO characterSO)
    {
        character = characterSO;
        SetSkins();
    }
    public void CloseDialogue()
    {
        chatBox.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Machetear()
    {
        print("Machetear");
        Instantiate(corpseInstance, playerStats.interactedNPC.transform.position, playerStats.interactedNPC.transform.rotation);
        audioManager.Machetear();
        character.SetDeath(true);
        playerStats.interactedNPC.SetUnctive();
        CloseDialogue();

        if (!character.GetIsDiavlo())
        {
            playerStats.life = playerStats.life - 1;
            if (playerStats.life <= 0)
            {
                LoseScreen();
            }
        }
        else
        {
            WinScreen();
            audioManager.DiabloMuerte();
            
        }

    }
    public void WinScreen()
    {
        Time.timeScale = 0.1f;
        listIsOpen = !listIsOpen;
        endingCanvas.SetActive(true);
        winMessage.SetActive(true);
        
    }
    public void LoseScreen()
    {
        Time.timeScale = 0.1f;
        listIsOpen = !listIsOpen;
        endingCanvas.SetActive(true);
        loseMessage.SetActive(true);   
    }
}
