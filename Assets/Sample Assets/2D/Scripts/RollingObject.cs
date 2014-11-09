using UnityEngine;
using System.Collections;

public class RollingObject : MonoBehaviour
{
    public Rabbit rabbit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rabbit")
        {
            Debug.Log("Rabbit");
            rabbit.gameObject.collider2D.isTrigger = true;
            this.gameObject.collider2D.isTrigger = true;
        }
    }
}
