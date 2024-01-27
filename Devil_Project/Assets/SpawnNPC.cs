using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    [SerializeField]List<CharacterSO> characters = new List<CharacterSO>();
    [SerializeField] List<CharacterSO> usedCharacters = new List<CharacterSO>();
    [SerializeField] NPC[] nPCs;
    [SerializeField] NPC[] usedNPCs;
    int index;
    private void Awake()
    {
        nPCs = FindObjectsOfType<NPC>();
    }
    private void Start()
    {
        int contador = 0;   
        print(characters.Count);
        while (contador < nPCs.Length)
        {
            GiveRandomCharacters();
            contador++;
        }
            
        
        for (int i = 0; i < usedCharacters.Count; i++)
        {
            PopulateNPCs(i);
        }
        
    }
    public void GiveRandomCharacters()
    {
        int populateIndex = UnityEngine.Random.Range(0, characters.Count);

        if (!usedCharacters.Contains(characters[populateIndex]))
        {
            usedCharacters.Add(characters[populateIndex]);

        }

    }

     void PopulateNPCs(int populatedIndex)
    {
        Debug.Log("nPCs.Length: " + nPCs.Length);
        Debug.Log("usedCharacters.Count: " + usedCharacters.Count);
        Debug.Log("populatedIndex: " + populatedIndex);
        if (populatedIndex < nPCs.Length)
        {
            nPCs[populatedIndex].SetAvatar(usedCharacters[populatedIndex].GetAvatar());
            nPCs[populatedIndex].SetCharacter(usedCharacters[populatedIndex]);
            nPCs[populatedIndex].SetSpawner(this);
        }
        else
        {
            Debug.LogError("Index out of range. populatedIndex: " + populatedIndex + ", nPCs.Length: " + nPCs.Length);
            return;
        }
    }
}
