using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

    public PlatformerCharacter2D player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    void OnTriggerEnter2D(Collider2D objectYouCollidedWith)
    {
        player.maxSpeed = 5;
        Debug.Log(player.maxSpeed);
    }

    void OnTriggerExit2D(Collider2D mamasdsamfmsdaf)
    {
        player.maxSpeed = 18;
    }
}
