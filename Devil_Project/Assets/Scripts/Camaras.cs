using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Cinemachine;
using static UnityEditor.Progress;

public class Camaras : MonoBehaviour
{
    // #region Fields

    [SerializeField] private GameObject teleport1;
    //detectar si hace colision con el trigger de teleport1
    

    [SerializeField] private CinemachineVirtualCamera virtualCamera1;
    [SerializeField] private CinemachineVirtualCamera virtualCamera2;
    [SerializeField] private CinemachineVirtualCamera virtualCamera3;
    [SerializeField] private CinemachineVirtualCamera virtualCamera4;
    [SerializeField] private CinemachineVirtualCamera virtualCamera5;


    // #endregion

    private void Start()
    {
        virtualCamera1.Priority = 15;
        virtualCamera2.Priority = 0;
        virtualCamera3.Priority = 0;
        virtualCamera4.Priority = 0;
        virtualCamera5.Priority = 0;

    }



    public void DetectCollision(Collider2D collision)
    {
        GameObject item = collision.gameObject;
        if (item)
        {

            virtualCamera2.Priority = virtualCamera1.Priority + 1;
            virtualCamera1.Priority = 0;

        }
        //intento

        if (true)
        {
            if (item.CompareTag("habitacion1"))
            {
                virtualCamera1.Priority = 15;
                virtualCamera2.Priority = 0;
                virtualCamera3.Priority = 0;
                virtualCamera4.Priority = 0;
                virtualCamera5.Priority = 0;
            }

            if (item.CompareTag("habitacion2"))
            {
                virtualCamera1.Priority = 0;
                virtualCamera2.Priority = 15;
                virtualCamera3.Priority = 0;
                virtualCamera4.Priority = 0;
                virtualCamera5.Priority = 0;
            }
            //aca sirve

            if (item.CompareTag("habitacion3"))
            {
                virtualCamera1.Priority = 0;
                virtualCamera2.Priority = 0;
                virtualCamera3.Priority = 15;
                virtualCamera4.Priority = 0;
                virtualCamera5.Priority = 0;
            }

            if (item.CompareTag("habitacion4"))
            {
                virtualCamera1.Priority = 0;
                virtualCamera2.Priority = 0;
                virtualCamera3.Priority = 0;
                virtualCamera4.Priority = 15;
                virtualCamera5.Priority = 0;
            }
            //intento

            if (item.CompareTag("habitacion5"))
            {
                virtualCamera1.Priority = 0;
                virtualCamera2.Priority = 0;
                virtualCamera3.Priority = 0;
                virtualCamera4.Priority = 0;
                virtualCamera5.Priority = 15;
            } 
        }



    }
}



