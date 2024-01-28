using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport1 : MonoBehaviour
{
    public GameObject portal1; // [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.transform.position = new Vector2(portal1.transform.position.x, portal1.transform.position.y);
        }
    }
}
