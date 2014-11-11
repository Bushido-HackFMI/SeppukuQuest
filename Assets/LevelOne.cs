using UnityEngine;
using System.Collections;

public class LevelOne : MonoBehaviour {

    public float levelTimer;
    public GUIStyle guiStyle;
    private Color32 stepsTextColor = new Color32(255, 255, 255, 255);
    public Font fontHUD;
    public Canvas canvas;
    public WinScript win;
    public PlatformerCharacter2D player;
    public Camera mainCam;
    public AnimationClip gosho;
    public suicide suicido;
    
    
    
	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        levelTimer -= Time.deltaTime;
	    if(!Timer())
        {
            Debug.Log("game over");
            
            Time.timeScale = 0.0f;
        }
        Debug.Log(levelTimer);
	}

    public bool Timer()
    {
        if(levelTimer <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void OnGUI()
    {
        guiStyle = GUI.skin.label;
        guiStyle.font = fontHUD;
        guiStyle.fontSize = 50;
        guiStyle.alignment = TextAnchor.MiddleCenter;
        guiStyle.normal.textColor = stepsTextColor;
        
        if(Timer() && !win.winEvent)
        {
            GUI.TextArea(new Rect(1100, 20, 100, 100), ((int)levelTimer + 1).ToString(), guiStyle);
            canvas.gameObject.SetActive(false);
        }

        if(win.winEvent)
        {
            levelTimer = 1f;
            mainCam.orthographic = true;
            mainCam.orthographicSize = 4;
            mainCam.transform.position = new Vector3(-20, 8, -10);
            win.gameObject.transform.position = new Vector3(win.gameObject.transform.position.x,win.transform.position.y,-100);
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -20);
            suicido.transform.position = new Vector3(suicido.transform.position.x, suicido.transform.position.y, 5);
            
        }
        if (!Timer())
        {
            canvas.gameObject.SetActive(true);
            GUI.depth = -1;
        }
    }

    public void onClick()
    {
        Application.LoadLevel("Level1Skeleton");
        Time.timeScale = 1.0f;
        
    }

    public bool isDead()
    {
        if(true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
