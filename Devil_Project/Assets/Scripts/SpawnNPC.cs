using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SpawnNPC : MonoBehaviour
{
    [SerializeField] GameObject diabloInstance;
    [SerializeField] Diablo diabloScriptInstance;

    [SerializeField] List<CharacterSO> characters = new List<CharacterSO>();
    [SerializeField] List<CharacterSO> usedCharacters = new List<CharacterSO>();
    [SerializeField] TextMeshProUGUI[] textMeshProUGUI;
    [SerializeField] NPC[] nPCs;

    private void Awake()
    {
        diabloScriptInstance = diabloInstance.GetComponent<Diablo>();
        nPCs = FindObjectsOfType<NPC>();
        textMeshProUGUI = FindObjectsOfType<TextMeshProUGUI>();
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

            if ( i < textMeshProUGUI.Length)
            {
                textMeshProUGUI[i].text = nPCs[i].GetCharacter().GetCharacterName();

            }
           
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
            usedCharacters[populatedIndex].SetDeath(false);
            usedCharacters[populatedIndex].SetIsDiavlo(false);
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
        yield return new WaitForSeconds(3);
        int randomSelector = UnityEngine.Random.Range(0, usedCharacters.Count);

        if (usedCharacters[randomSelector].GetIsDiavlo())
        {
            yield return StartCoroutine(SeleccionVictima());
        }
        usedCharacters[randomSelector].SetIsDiavlo(true);
        usedCharacters[randomSelector].SetDeath(true);

        for (int i = 0; i < usedCharacters.Count; i++)
        {
            if (usedCharacters[i].GetDeath())
            {
                textMeshProUGUI[i].color = new Vector4(255, 0, 0, 1);
            }
        }
        
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
        timeForKill = timeForKill + 1f;
        StartCoroutine(SeleccionVictima());
    }

}
