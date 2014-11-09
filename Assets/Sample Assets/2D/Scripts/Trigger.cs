using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    public Box box;
    public PlatformerCharacter2D player;
    public DestroyedByTrigger destroy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Box" || collider.gameObject.tag == "Player")
        {
            Debug.Log("Trigger");
            if (destroy.gameObject != null)
            {
                Destroy(destroy.gameObject);
            }
        }
    }
}
