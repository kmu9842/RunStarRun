using UnityEngine;
using System.Collections;

public class Sound_Player : MonoBehaviour {

	//사용될 사운드를 셋팅해 놓는다.
	
	public AudioClip[] Sound;
	
	//0 : 점프사운드
	//1 : 코인획득사운드
	//2 : 죽음사운드
	
	public void SoundPlay(int SoundNumber){
         
         audio.clip = Sound[SoundNumber];
         audio.Play();
		
    }
	
}
