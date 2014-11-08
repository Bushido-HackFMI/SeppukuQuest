using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;
    private DestroyableObject obstacle;


	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}

    void Update ()
    {
        // Read the jump input in Update so button presses aren't missed.
#if CROSS_PLATFORM_INPUT
        if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
#else
        if (Input.GetButtonDown("Jump")) jump = true;
#endif

    }

    void OnCollisionEnter(Collision coll )
    {
        if (coll.gameObject.name == "DestroyableObject")
        {
            Destroy(coll.gameObject);
        }
    }

	void FixedUpdate()
	{
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		#if CROSS_PLATFORM_INPUT
		float h = CrossPlatformInput.GetAxis("Horizontal");
		#else
		float h = Input.GetAxis("Horizontal");
		#endif
        bool sprintActive = Input.GetKey(KeyCode.LeftShift);

		// Pass all parameters to the character control script.
		character.Move( h, crouch , jump);

        // Reset the jump input once it has been used.
	    jump = false;
        
	}
}
