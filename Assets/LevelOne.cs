using UnityEngine;
using System.Collections;

public class LevelOne : MonoBehaviour {

    public float levelTimer;
    public GUIStyle guiStyle;
    private Color32 stepsTextColor = new Color32(255, 255, 255, 255);
    public Font fontHUD;
    public Canvas canvas;
    public WinScript win;
    
    
    
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
        else
        {
            canvas.gameObject.SetActive(true);
            GUI.depth = -1;
        }
    }

    public void onClick()
    {
        Application.LoadLevel("Level1");
        Time.timeScale = 1.0f;
        
    }
}
