using UnityEngine;
using System.Collections;

public class Camera_Zoom : MonoBehaviour
{

	public Camera _camera;
	public GameObject _player;
	public float speed;
	public float MaxSize = 7.5f;
	public float MinSize = 5.5f;
	float CameraSize = 6f;
	
	void Update ()
	{
		
		if (_player != null)
			//CameraSize = 5f + _player.transform.position.y;
			
		if (CameraSize >= MaxSize) {
			CameraSize = MaxSize;
		}
			
		if (CameraSize <= MinSize) {
			CameraSize = MinSize;
		}
			
			
		//단순히 카메라값을 바꾸는경우
		//_camera.orthographicSize = 4.5f+_player.transform.position.y;
			
		//카메라값을 부드럽게 바꾸는경우 
			
		_camera.orthographicSize = Mathf.Lerp (_camera.orthographicSize, CameraSize, Time.deltaTime / speed);
		
	}
}
