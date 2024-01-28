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
        Time.timeScale = 1.0f;
    }

    public void Machetear() 
    {
        print("Machetear");

        if (!character.GetIsDiavlo())
        {
            character.SetDeath(true);
            playerStats.life = playerStats.life - 1;
            playerStats.interactedNPC.SetUnctive();
            //desactivar personaje*/
        }
        
    }
}
