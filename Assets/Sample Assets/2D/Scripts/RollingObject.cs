using UnityEngine;
using System.Collections;

public class RollingObject : MonoBehaviour
{


   
    public float sphereX = -10f;
    public float sphereY = 0f;
    public DestroyableObject wall;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(sphereX * Time.deltaTime, sphereY * Time.deltaTime, 0f));

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Breakable Wall")
        {
            Destroy(wall.gameObject);
        }
    }
}
