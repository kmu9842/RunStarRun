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
	
	public float Jump_Power;
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
	
	void JUMP ()
	{
		
		status = PlayerMoveStatus.Jump;
		rigidbody.AddForce (0, Jump_Power * 1.5f, 0);
		
		//점프 애니메이션을 재생한다.
		
		if (_SA != null)
			_SA.Jump_Play ();
		
		//점프하는 소리를 재생한다.
		if (_SP != null)
			_SP.SoundPlay (0);
		
	}
	
	void DOUBLEJUMP ()
	{
		
		status = PlayerMoveStatus.DoubleJump;
		rigidbody.AddForce (0, Jump_Power, 0);
		
		//더블 점프 애니메이션을 재생한다.
		if (_SA != null)
			_SA.D_Jump_Play ();
		
		//점프하는 소리를 재생한다.
		if (_SP != null)
			_SP.SoundPlay (0);
	}
	
	void KEYBOARD ()
	{
		
			
		//점프 버튼이 눌린경우
		
		if (Input.GetButtonDown ("Jump")) {
			//주인공이 점프상태인 경우 
			if (status == PlayerMoveStatus.Jump) {
				DOUBLEJUMP ();
			}
			
			//주인공이 달리기 상태인 경우	
			if (status == PlayerMoveStatus.Run) {
				JUMP ();
			}
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
				
				if (status == PlayerMoveStatus.Jump) {
					DOUBLEJUMP ();
				}
				
				if (status == PlayerMoveStatus.Run) {
					JUMP ();
				}
			}
			
			
		}	
	}
	
	
}
