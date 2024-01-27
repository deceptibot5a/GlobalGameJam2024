using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Character", fileName = "New Character")]
public class CharacterSO : ScriptableObject
{
    [TextArea(2, 6)][SerializeField] string name = "Enter a name";
    [TextArea(2, 6)][SerializeField] string Dialogue = "Enter a dialogue";
    [Header(" ")]
    [SerializeField] Sprite avatar;
    [SerializeField] bool isDead = false;

    public string GetCharacterName()
    {
        return name;
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

    public void SetDeath()
    {
        isDead = true;
    }
}

