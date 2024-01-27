using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListManager : MonoBehaviour
{
    [SerializeField] List<CharacterSO> namesList = new List<CharacterSO>();

    [SerializeField] TextMeshProUGUI myText;

    void Start()
    {
        myText.text = "";
        for (int i = 0; i < namesList.Count; i++)
        {
            Debug.Log(namesList[i].name);
            myText.text += "\n"+namesList[i].name;

        }
    }
}
