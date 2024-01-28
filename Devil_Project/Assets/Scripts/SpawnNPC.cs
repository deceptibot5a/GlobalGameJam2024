using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SpawnNPC : MonoBehaviour
{
    [SerializeField] GameObject diabloInstance;
    [SerializeField] Diablo diabloScriptInstance;

    [SerializeField] List<CharacterSO> characters = new List<CharacterSO>();
    [SerializeField] List<CharacterSO> usedCharacters = new List<CharacterSO>();
    [SerializeField] NPC[] nPCs;

    private void Awake()
    {
        diabloScriptInstance = diabloInstance.GetComponent<Diablo>();
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
        
            StartCoroutine(SeleccionVictima());
        

    }
    public void GiveRandomCharacters()
    {
        int populateIndex = UnityEngine.Random.Range(0, characters.Count);
        int[] temp = new int[nPCs.Length];
        int tempIndex = 0;
        temp[tempIndex] = populateIndex;

        
        if (!usedCharacters.Contains(characters[populateIndex]))
        {
            usedCharacters.Add(characters[populateIndex]);
        }
        else
        {
            GiveRandomCharacters();
        }
    }

     void PopulateNPCs(int populatedIndex)
    {
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

    [SerializeField] float timeForKill;
    IEnumerator SeleccionVictima()
    {
        
        int randomSelector = UnityEngine.Random.Range(0, usedCharacters.Count);

        if (usedCharacters[randomSelector].GetIsDiavlo())
        {
            StartCoroutine(SeleccionVictima());
        }
        usedCharacters[randomSelector].SetIsDiavlo(true);

        yield return new WaitForSeconds(timeForKill);

        if (usedCharacters.Count != 0)
        {
            for (int i = 0; i < usedCharacters.Count; i++)
            {
                if (usedCharacters[i].GetIsDiavlo() && usedCharacters[i] != null)
                {

                    diabloScriptInstance.Hunt(usedCharacters[i]);
                    nPCs[i].SetUnctive();
                }
            }
                
        }
        timeForKill = timeForKill + 2f;
        StartCoroutine(SeleccionVictima());
    }

}
