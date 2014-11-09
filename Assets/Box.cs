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

    void OnCollisionEnter2D(Collision2D objectYouCollidedWith)
    {
        if(objectYouCollidedWith.gameObject.tag == "Player" && player.playerIsSprinting)
        {
            Destroy(this.gameObject);
            Debug.Log("hai");
        }
        
    }

    
}
