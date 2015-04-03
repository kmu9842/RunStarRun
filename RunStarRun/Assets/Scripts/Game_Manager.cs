using UnityEngine;
using System.Collections;

//게임의 진행중인 상태를 정의
public enum GameState
{
	Play,
	Pause,
	End,
}

public class Game_Manager : MonoBehaviour
{
	public GameState GS;
	public int GameLv;
	public float GameSpeed;
	public Scroll_Mapping _SM;


	//계속 유동적인 수

	public float Meter;
	public int[] Item = new int[4];


	//GUI 관련

	//public GUIText Gold_Label;
	public GUIText Meter_Label;
	public GUITexture Black_screen;
	public GUIText result_Gold_Label;
	public GUIText result_Meter_Label;
	GUIStyle guiRectStyle;
	public Fade _fade;
	public Texture Pause_btn;
	public Texture Go_btn;
	public Texture Replay_btn;
	public Texture Main_btn;

	public GUITexture Attack1_btn;
	public GUITexture Attack2_btn;
	public GUITexture Attack3_btn;
	public GUITexture Attack4_btn;


	public GameObject result_window;
	float screenX;
	float screenY;
	
	void Start ()
	{
		SCREENSETTING ();
	}

	void Update ()
	{
		if (GS == GameState.Play) {
			METERUPDATE ();
		}

		if (Input.touchCount > 0) {
			if (Attack1_btn.HitTest (Input.GetTouch (1).position)) {

			}

			else if (Attack2_btn.HitTest (Input.GetTouch (1).position)) {
				
			}

			else if (Attack3_btn.HitTest (Input.GetTouch (1).position)) {
				
			}

			else if (Attack4_btn.HitTest (Input.GetTouch (1).position)) {
				
			}
		}
	}
	
	void SCREENSETTING ()
	{
		screenX = Screen.width;
		screenY = Screen.height;
		guiRectStyle = new GUIStyle ();
		guiRectStyle.border = new RectOffset (0, 0, 0, 0);
		_fade.FadeIn ();
	}
	
	void OnGUI ()
	{
		//플레이상태일때 존재 할 일시정지버튼

		if (GS == GameState.Play) {

			if (GUI.Button (new Rect (20, 20, Pause_btn.width, Pause_btn.height), Pause_btn, guiRectStyle)) {
				Black_screen.color = new Color (0, 0, 0, 0.4f);
				GS = GameState.Pause;
				Time.timeScale = 0;
			}
		}


		//일시정지 상태에 들어가면 버튼을 띄웁니다.

		if (GS == GameState.Pause) {

			if (GUI.Button (new Rect (screenX * 0.5f - Go_btn.width * 0.5f, screenY * 0.5f + Replay_btn.height * 0.5f + 10f, Go_btn.width, Go_btn.height), Go_btn, guiRectStyle)) {
				Black_screen.color = new Color (0, 0, 0, 0);
				Time.timeScale = 1;
				GS = GameState.Play;

			}

			if (GUI.Button (new Rect (screenX * 0.5f - Replay_btn.width * 0.5f, screenY * 0.5f - Replay_btn.height * 0.5f, Replay_btn.width, Replay_btn.height), Replay_btn, guiRectStyle)) {
				Time.timeScale = 1;
				Application.LoadLevel ("[PlayScene]");
			}

			if (GUI.Button (new Rect (screenX * 0.5f - Main_btn.width * 0.5f, screenY * 0.5f - Replay_btn.height * 0.5f - Main_btn.height - 10f, Main_btn.width, Main_btn.height), Main_btn, guiRectStyle)) {
				Time.timeScale = 1;
				Application.LoadLevel ("[IntroScene]");
			}
		}

		//게임이 종료됐을시 띄울 버튼

		if (GS == GameState.End) {
			if (GUI.Button (new Rect (screenX * 0.5f - Replay_btn.width * 0.5f, screenY * 0.5f + 10f, Replay_btn.width, Replay_btn.height), Replay_btn, guiRectStyle)) {
				Application.LoadLevel ("[PlayScene]");
			}

			if (GUI.Button (new Rect (screenX * 0.5f - Main_btn.width * 0.5f, screenY * 0.5f + Replay_btn.height + 20f, Main_btn.width, Main_btn.height), Main_btn, guiRectStyle)) {
				Application.LoadLevel ("[IntroScene]");
			}
		}
	}
   
	public void GAMEOVER ()
	{
		GS = GameState.End;
		_fade.FadeOut ();
		result_window.gameObject.SetActive (true);
		result_Meter_Label.text = string.Format ("{0:N0}", Meter);
	}
	
	public void GETCOIN ()
	{
		//Gold_Label.text = string.Format ("{0:N0}", GetMoney);
	}

	public void METERUPDATE ()
	{
		Meter += Time.deltaTime * GameSpeed;
		Meter_Label.text = string.Format ("{0:N0}", Meter);

		//시간이 지날수록 속도가 점점 빨라지게 한다.
		/*
		if (Meter >= 50 && GameLv == 1) {
			GameLevelUp ();
		}

		if (Meter >= 100 && GameLv == 2) {
			GameLevelUp ();
		}

		if (Meter >= 150 && GameLv == 3) {
			GameLevelUp ();
		}

		if (Meter >= 200 && GameLv == 4) {
			GameLevelUp ();
		}

		if (Meter >= 250 && GameLv == 5) {
			GameLevelUp ();
		}

		if (Meter >= 300 && GameLv == 6) {
			GameLevelUp ();
		}*/
	}

	public void GameLevelUp ()
	{
		GameLv += 1;
		GameSpeed += 3;
		_SM.ScrollSpeed += 0.1f;
	}
}