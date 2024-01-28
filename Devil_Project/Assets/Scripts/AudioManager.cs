using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioMusica;
    [SerializeField] AudioSource audioMachete;
    [SerializeField] AudioSource audioPasos;
    [SerializeField] AudioSource audioMuerte;
    [SerializeField] AudioSource audioTeleport;

    public void ToggleMute()
    {
        if (audioMusica.volume > 0)
        {
            audioMusica.volume = 0;
        }
        else
        {
            audioMusica.volume = 1;
        }
    }
    public void Machetear()
    {
        audioMachete.Play();
    }
    public void DiabloMuerte()
    {
        audioMuerte.Play();
    }
}
