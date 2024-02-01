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

    public bool IsPlaying()
    {
        if (
            audioMachete.isPlaying ||
            audioPasos.isPlaying ||
            audioTeleport.isPlaying ||
            audioMuerte.isPlaying 
        )
        {
            return true;
        }
        else { return false; }
    }

    public void ForceStopSteps ()
    {
        audioPasos.Stop ();
    }
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

    public void Teleport ()
    {
        audioTeleport.Play();
    }
    public void Steps()
    {
        audioPasos.Play();
    }
}
