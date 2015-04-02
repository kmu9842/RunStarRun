using UnityEngine;
using System.Collections;

public enum PlayerMoveStatus
{
	Run,
	Jump,
	DoubleJump,
	Die
};

public class Player_Move : MonoBehaviour
{
	public PlayerMoveStatus status;
	public Sprite_Animation _SA;
	public Sound_Player _SP;
	
	void Start ()
	{
	
	}

	void Update ()
	{
		KEYBOARD ();
		TOUCH ();
		rigidbody.WakeUp ();
	}
	
	void RUN ()
	{
		status = PlayerMoveStatus.Run;
		if (_SA != null)
			_SA.Run_Play ();
	}

	void KEYBOARD ()
	{
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.Translate(transform.up/10f);
		}
		else if (Input.GetKey(KeyCode.DownArrow)) {
			transform.Translate(-transform.up/10f);
		}
	}
	
	void OnCollisionEnter (Collision Get)
	{
		if (status != PlayerMoveStatus.Die)
			RUN ();
	}
	
	void TOUCH ()
	{
			
		if (Input.touchCount > 0) {                               
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
			}
			
			
		}	
	}
	
	
}
