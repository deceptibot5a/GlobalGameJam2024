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
    [Header("Instances")]
    [SerializeField] GameObject diabloInstance;
    [SerializeField] GameObject corpseInstance;
    [SerializeField] Diablo diabloScriptInstance;
    [Header("")]
    [SerializeField] TextMeshProUGUI[] textMeshProUGUI;
    [SerializeField] NPC[] nPCs;
    [SerializeField] AudioManager audioManager;
    [Header("Data Managers")]
    [SerializeField] List<CharacterSO> characters = new List<CharacterSO>();
    [SerializeField] List<CharacterSO> usedCharacters = new List<CharacterSO>();
    [Header("Killing")]
    [SerializeField] float timeForKill;
    [SerializeField] float startKillingSpreeTime;
    [SerializeField] int looseCondition;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
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
        
        StartCoroutine(Esperar());


    }

    private void LateUpdate()
    {
        for (int i = 0; i < usedCharacters.Count; i++)
        {
            if (i < usedCharacters.Count)
            {
                if (usedCharacters[i].GetDeath())
                {
                    textMeshProUGUI[i].color = new Vector4(255, 0, 0, 1);
                    textMeshProUGUI[i].fontStyle = TMPro.FontStyles.Strikethrough;
                } 
            }
        }
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

    public int GetLooseCondition()
    {
        return looseCondition;
    }

    public float GetStartKillingSpreeTime()
    {
        return startKillingSpreeTime;
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(startKillingSpreeTime);
        StartCoroutine(SeleccionVictima());
    }
    IEnumerator SeleccionVictima()
    {
        int randomSelector = UnityEngine.Random.Range(0, usedCharacters.Count);

        if (usedCharacters[randomSelector].GetIsDiavlo() || usedCharacters[randomSelector].GetDeath())
        {
            yield return StartCoroutine(SeleccionVictima());
        }

        else
        {
            usedCharacters[randomSelector].SetIsDiavlo(true);
            usedCharacters[randomSelector].SetDeath(true);
            audioManager.NPCMuerte();


            yield return new WaitForSeconds(timeForKill);

            MatarNPC(); 
        }
    }

    private void MatarNPC()
    {
        if (usedCharacters.Count != 0)
        {
            for (int i = 0; i < usedCharacters.Count; i++)
            {
                if (usedCharacters[i].GetIsDiavlo() && usedCharacters[i] != null)
                {
                    Instantiate(corpseInstance, nPCs[i].transform.position, nPCs[i].transform.rotation);
                    diabloScriptInstance.Hunt(usedCharacters[i]);
                    
                    
                    nPCs[i].SetUnctive();


                }
            }

        }
        looseCondition--;
        timeForKill = timeForKill + 1f;
        StartCoroutine(SeleccionVictima());
    }
}
