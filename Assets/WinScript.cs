using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour 
{
    public PlatformerCharacter2D player;
    public Camera camera;
    public bool winEvent = false;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Debug.Log("OK");
            winEvent = true;
        }
    }
}
