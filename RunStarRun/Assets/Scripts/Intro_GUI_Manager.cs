using UnityEngine;
using System.Collections;

public class Intro_GUI_Manager : MonoBehaviour
{
	public Fade _fade;
	public Texture Play_btn;
	GUIStyle guiRectStyle;
	float screenX;
	float screenY;
	public bool _click;
	float _clickTime;	
	
	void Start ()
	{
		_fade.FadeIn ();
		SCREENSETTING ();
	}
	
	void Update ()
	{
		if (_click == true) {
			if (Time.time >= _clickTime + _fade.Fade_Time) {
				Debug.Log ("gotoPlay");
				_click = false;
				Application.LoadLevel ("[PlayScene]");
			}
		}
	}	
	
	void SCREENSETTING ()
	{
		
		screenX = Screen.width;
		screenY = Screen.height;	
		guiRectStyle = new GUIStyle ();
		guiRectStyle.border = new RectOffset (0, 0, 0, 0);
        
	}
	
	void OnGUI ()
	{
		if (GUI.Button (new Rect (screenX * 0.5f - Play_btn.width * 0.5f, screenY * 0.5f + Play_btn.height * 0.5f + 100f, Play_btn.width, Play_btn.height), Play_btn, guiRectStyle)) {
			if (_click == false) {
				_fade.FadeOut ();
				_click = true;
				_clickTime = Time.time;
			}
		}
	}
}