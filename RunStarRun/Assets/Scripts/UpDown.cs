using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour
{
	
	public float Speed;
	public float ChangeTime;
	float _time;
	public bool UpOrDown = true;
	public float Up_Position;
	public float Down_Position;
	
	void Start ()
	{
		
		Up_Position = transform.position.y + Up_Position;
		Down_Position = transform.position.y;
	}
	
	void Update ()
	{
				
		_time += Time.deltaTime;
		
		
		
		if (UpOrDown == true) {
			transform.position = new Vector3 (transform.position.x, Mathf.Lerp (transform.position.y, Up_Position, Time.deltaTime / Speed), transform.position.z);
			if (_time >= Speed) {
				_time = 0;
				UpOrDown = false;
			}
		} else {
			transform.position = new Vector3 (transform.position.x, Mathf.Lerp (transform.position.y, Down_Position, Time.deltaTime / Speed), transform.position.z);
			if (_time >= Speed) {
				_time = 0;
				UpOrDown = true;
			}
			
		}
		
	}
}
