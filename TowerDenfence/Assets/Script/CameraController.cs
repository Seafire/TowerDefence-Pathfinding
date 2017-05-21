using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	private float scrollSpeed = 5.0f;

	public float panSpeed = 30.0f;
	public float panBorderThick = 10.0f;
	public float minY = 10.0f;
	public float maxY = 80.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameManager.gameOver) 
		{
			this.enabled = false;
			return;
		}
		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - panBorderThick) 
		{
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey ("s") || Input.mousePosition.y <= panBorderThick) 
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width - panBorderThick) 
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey ("a") || Input.mousePosition.x <= panBorderThick) 
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= scroll * 1000.0f * scrollSpeed * Time.deltaTime;

		pos.y = Mathf.Clamp (pos.y, minY, maxY);

		transform.position = pos;
	}
}
