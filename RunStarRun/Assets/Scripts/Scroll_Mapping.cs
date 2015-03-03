using UnityEngine;
using System.Collections;

public class Scroll_Mapping : MonoBehaviour
{
	
	public float ScrollSpeed = 0.5f;
	float Offset;
	
	void Update ()
	{
	
		Offset += Time.deltaTime * ScrollSpeed;
		renderer.material.mainTextureOffset = new Vector2 (Offset, 0);
		
	}
}



