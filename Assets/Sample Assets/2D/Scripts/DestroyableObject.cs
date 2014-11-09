using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {

    public PlatformerCharacter2D player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (this.gameObject != null && player.playerIsSprinting)
            {
                Destroy(this.gameObject);
            }
            Debug.Log("Destroy");
        }
    }
}


