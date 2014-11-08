using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    public PlatformerCharacter2D player;
    public DestroyableObject destroy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Trigger");
            Destroy(destroy.gameObject);
        }
    }
}
