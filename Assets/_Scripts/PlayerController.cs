using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Rigidbody rb;
	
	void Main ()
	{
		// Preventing mobile devices going in to sleep mode 
		//(actual problem if only accelerometer input is used)
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	void start()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () 
	{
		
		if (SystemInfo.deviceType == DeviceType.Desktop) 
		{
			//get input by keyboard
			float movehorizontal = Input.GetAxis ("Horizontal");
			float movevertical = Input.GetAxis ("Vertical");
			
			Vector3 movement = new Vector3 (movehorizontal, 0.0f, movevertical);
			rb.AddForce (movement * speed * Time.deltaTime);
			//rb.velocity = movement * speed * Time.deltaTime;
		} else 
		{
			// Player movement in mobile devices
			// Building of force vector 
			Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
			// Adding force to rigidbody
			rb.AddForce (movement * speed * Time.deltaTime);
			//rb.velocity = movement * speed * Time.deltaTime;
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Target")) 
		{
			gameObject.SetActive(false);
			Invoke("closeApp", 1);
		}
	}
	
	void closeApp()
	{
		//Application.Quit();
		//if(Application.loadedLevel == 2){
			//Application.LoadLevel("Level_1");
			Application.Quit();
		//}else{
		//	Application.LoadLevel (Application.loadedLevel+1);
		//}
		//Application.LoadLevel (Application.loadedLevel);
	}
}
