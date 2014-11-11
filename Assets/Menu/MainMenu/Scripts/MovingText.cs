using UnityEngine;
using System.Collections;



public class MovingText : MonoBehaviour {


    public float timer = 5f;
    public float speed = 5.0f;


	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            this.gameObject.active = false;
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("here");
        if (collision.gameObject.tag == "Invisible")
        {
            speed = 0;
        }
    }
}
