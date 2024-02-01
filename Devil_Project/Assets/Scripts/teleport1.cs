//using Cinemachine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class teleport1 : MonoBehaviour
//{
//    public teleport1  portal1; // [SerializeField]
//    private GameObject player;

//    //public CinemachineVirtualCamera micamara;
//    // Start is called before the first frame update
//    void Start()
//    {
//        player = GameObject.FindWithTag("Player");
//    }

//    // Update is called once per frame
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.tag == "Player")
//        {
//            player.transform.position = new Vector2(portal1.transform.position.x, portal1.transform.position.y);
//            //salida();
//        }
//    }

//    public void llegada()
//    {
//        player.transform.position = new Vector2(portal1.transform.position.x, portal1.transform.position.y);

//    }

//    public void salida ()
//    {
//        portal1.llegada();
//        //micamara.Priority = portal1.micamara.Priority - 1;
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport1 : MonoBehaviour
{
    Camaras camaras;
    public GameObject portal1; // [SerializeField]
    // Start is called before the first frame update
    void Awake()
    {
       
       camaras = FindObjectOfType<Camaras>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D collider = this.GetComponent<Collider2D>();
        if (collision.tag == "NPC")
        {
            collision.transform.position = new Vector2(portal1.transform.position.x, portal1.transform.position.y);
        }
        if (collision.tag == "Player" )
        {
            collision.transform.position = new Vector2(portal1.transform.position.x, portal1.transform.position.y);
            camaras.DetectCollisionLvl1(collider);
        }
    }
}
