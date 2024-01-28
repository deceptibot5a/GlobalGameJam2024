using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportNivel2 : MonoBehaviour
{
    CamarasNivel2 camarasNivel2;
    public GameObject portal1; // [SerializeField]
    // Start is called before the first frame update
    void Awake()
    {

        camarasNivel2 = FindObjectOfType<CamarasNivel2>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D collider = this.GetComponent<Collider2D>();
        if (collision.tag == "NPC")
        {
            collision.transform.position = new Vector2(portal1.transform.position.x, portal1.transform.position.y);
        }
        if (collision.tag == "Player")
        {
            collision.transform.position = new Vector2(portal1.transform.position.x, portal1.transform.position.y);
            camarasNivel2.DetectCollision(collider);
        }
    }
}
