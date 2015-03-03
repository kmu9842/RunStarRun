using UnityEngine;
using System.Collections;

public class Box_Loop : MonoBehaviour {
	
	public GameObject[] Box;
	public GameObject A_Zone;
	public GameObject B_Zone;
	
	public float Speed = 5f;
	
	void Update () {
	
			MOVE();
	}
	
	//만들자
	
	public void MAKE(){
		
		B_Zone=A_Zone;
		int a = Random.Range(0,5);
        A_Zone = Instantiate(Box[a], new Vector3(30,0,0), transform.rotation) as GameObject;
		
	}

	//움직이자
	
	public void MOVE(){
		
		A_Zone.transform.Translate(Vector3.left * Speed *Time.deltaTime, Space.World);
		B_Zone.transform.Translate(Vector3.left * Speed *Time.deltaTime, Space.World);
			
		if(A_Zone.transform.position.x<=0){
				DEATH();
		}
	}
	
	//없애자
	
	public void DEATH(){
		Destroy(B_Zone);
		MAKE();
			
	}
}
