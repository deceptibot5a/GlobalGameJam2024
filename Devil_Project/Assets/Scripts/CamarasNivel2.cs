using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamarasNivel2 : MonoBehaviour
{
    // #region Fields

    [SerializeField] private CinemachineVirtualCamera virtualCamera1;
    [SerializeField] private CinemachineVirtualCamera virtualCamera2;
    [SerializeField] private CinemachineVirtualCamera virtualCamera3;
    [SerializeField] private CinemachineVirtualCamera virtualCamera4;


    // #endregion

    private void Start()
    {
        virtualCamera1.Priority = 15;
        virtualCamera2.Priority = 0;
        virtualCamera3.Priority = 0;
        virtualCamera4.Priority = 0;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent<teleport1>(out teleport1 item);
        if (item)
        {

            virtualCamera2.Priority = virtualCamera1.Priority + 1;
            virtualCamera1.Priority = 0;

        }
        //intento

        if (item.CompareTag("habitacion1"))
        {
            virtualCamera1.Priority = 15;
            virtualCamera2.Priority = 0;
            virtualCamera3.Priority = 0;
            virtualCamera4.Priority = 0;
        }

        if (item.CompareTag("habitacion2"))
        {
            virtualCamera1.Priority = 0;
            virtualCamera2.Priority = 15;
            virtualCamera3.Priority = 0;
            virtualCamera4.Priority = 0;
        }
        //aca sirve

        if (item.CompareTag("habitacion3"))
        {
            virtualCamera1.Priority = 0;
            virtualCamera2.Priority = 0;
            virtualCamera3.Priority = 15;
            virtualCamera4.Priority = 0;
        }

        if (item.CompareTag("habitacion4"))
        {
            virtualCamera1.Priority = 0;
            virtualCamera2.Priority = 0;
            virtualCamera3.Priority = 0;
            virtualCamera4.Priority = 15;
        }
        //intento
    }
}
