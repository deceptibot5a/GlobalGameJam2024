using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(menuName = "Character", fileName = "New Character")]
public class CharacterSO : ScriptableObject
{
    [TextArea(2, 6)][SerializeField] string name = "Enter a name";
    [TextArea(2, 6)][SerializeField] string Dialogue = "Enter a dialogue";
    [Header(" ")]
    [SerializeField] Sprite avatar;
    [SerializeField] bool isDead = false;
    [SerializeField] bool isDiablo = false;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        isDead = false;
        isDiablo = false;
    }
    public void SetText()
    {
        textMeshProUGUI.text = name;
    }
    public string GetCharacterName()
    {
        return name;
    }

    public bool GetIsDiavlo() { 
        return isDiablo;
    }
    public void SetIsDiavlo(bool temp)
    {
        isDiablo = temp;
    }
    public string GetDialogue ()
    {
        return Dialogue;
    }
    public Sprite GetAvatar()
    {
        return avatar;
    }
    public bool GetDeath()
    {
        return isDead;
    }

    public void SetDeath(bool temp)
    {
        isDead = temp;
    }
}

