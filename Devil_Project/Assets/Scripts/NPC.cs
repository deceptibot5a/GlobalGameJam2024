using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class NPC : MonoBehaviour
{
    
    [SerializeField] Sprite avatar;
    [SerializeField] GameObject nPC;
    [SerializeField] SpawnNPC spawnNPC;
    [SerializeField] CharacterSO characterSO;


    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        nPC = this.gameObject;
        
    }

    public void SetUnctive()
    {
        this.gameObject.SetActive(false);
    }
    public void SetSpawner(SpawnNPC spawn)
    {
        spawnNPC = spawn;
    }

    public void SetAvatar(Sprite sprite)
    {
        avatar = sprite;
        spriteRenderer.sprite = avatar;
    }

    public void SetCharacter(CharacterSO character)
    {
        characterSO = character;
    }

    public CharacterSO GetCharacter()
    {
        return characterSO; 
    }
}
