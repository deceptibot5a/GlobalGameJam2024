using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    SpawnNPC spawn;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] GameObject textGameObject;
    [SerializeField] private Image uiFill;

    [SerializeField] int Duration;

    private int remainingDuration;

    private bool Pause;
    private void Awake()
    {
        spawn = FindObjectOfType<SpawnNPC>();    
    }
    void Start()
    {
        Being(Duration);
        textGameObject.SetActive(true);
        StartCoroutine(diabloEnabled());
    }
    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (!Pause)
            {
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }
    IEnumerator diabloEnabled()
    {
        yield return new WaitForSeconds(spawn.GetStartKillingSpreeTime());
        textMesh.text = "Objetivo: El diablo se hace pasar por el ultimo que mató, usa la lista y tu memoria para encontrarlo y machetearlo";
    }
}
