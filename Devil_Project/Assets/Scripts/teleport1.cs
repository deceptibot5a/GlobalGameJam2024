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
    public GameObject portal1; // [SerializeField]
    private GameObject player;
    private GameObject npcChar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        npcChar = GameObject.FindWithTag("NPC");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            player.transform.position = new Vector2(portal1.transform.position.x, portal1.transform.position.y);
        }
        else if (collision.tag == "NPC")
        {
            npcChar.transform.position = new Vector2(portal1.transform.position.x, portal1.transform.position.y);
        }
    }
}
