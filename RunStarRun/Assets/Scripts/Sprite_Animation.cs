using UnityEngine;
using System.Collections;

public class Sprite_Animation : MonoBehaviour
{
	
	public Texture[] Run_Image;
	int _now_run_ani_count;
	public Texture[] Jump_Image;
	int _now_jump_ani_count;
	public Texture[] D_Jump_Image;
	int _now_d_jump_ani_count;
	public float Ani_Play_Speed;
	float Ani_Play_Time;
	public bool _run;
	public bool _jump;
	public bool _d_jump;

	void Update ()
	{
	
		Ani_Play_Time += Time.deltaTime;
		
		if (Ani_Play_Time >= Ani_Play_Speed) {
			
			Ani_Play_Time = 0;
			if (_run == true) {
				
				RUN_ANI_ing ();
			}
			
			if (_jump == true) {
				
				JUMP_ANI_ing ();
			}
			
			if (_d_jump == true) {
				
				D_JUMP_ANI_ing ();
			}
		}
		
		
	}
	
	void RUN_ANI_ing ()
	{
		
		_now_run_ani_count += 1;
		if (_now_run_ani_count >= Run_Image.Length) {
			_now_run_ani_count = 0;	
		}
		
		this.gameObject.renderer.material.mainTexture = Run_Image [_now_run_ani_count];
				
	}
	
	void JUMP_ANI_ing ()
	{
		
		_now_jump_ani_count += 1;
		if (_now_jump_ani_count >= Jump_Image.Length) {
			Run_Play ();
			return;
		}
		this.gameObject.renderer.material.mainTexture = Jump_Image [_now_jump_ani_count];
		
	}
	
	void D_JUMP_ANI_ing ()
	{
		
		_now_d_jump_ani_count += 1;
		if (_now_d_jump_ani_count >= D_Jump_Image.Length) {
			Run_Play ();
			return;
		}
		this.gameObject.renderer.material.mainTexture = D_Jump_Image [_now_d_jump_ani_count];
		
	}
		
	public void Run_Play ()
	{
		
		_run = true;
		_jump = false;
		_d_jump = false;
		_now_run_ani_count = 0;
	}
		
	public void Jump_Play ()
	{
		
		_run = false;
		_jump = true;
		_d_jump = false;
		_now_jump_ani_count = 0;
		
	}
		
	public void D_Jump_Play ()
	{
		
		_run = false;
		_jump = false;
		_d_jump = true;
		_now_d_jump_ani_count = 0;
		
		
	}
	
	
}
