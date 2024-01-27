using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiEventManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialog;
    [SerializeField] GameObject chatBox;
    [SerializeField] Image avatar;
    [SerializeField] CharacterSO character;
    private void Start()
    {
        nameText.text = character.GetCharacterName();
        dialog.text = character.GetDialogue();
        avatar.sprite = character.GetAvatar();
    }

    public void CloseDialogue()
    {
        chatBox.SetActive(false);
    }

    public void Machetear() 
    {
        print("Machetear");
    }
}
