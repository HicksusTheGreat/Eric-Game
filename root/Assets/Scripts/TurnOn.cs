using UnityEngine;
using System.Collections;

public class TurnOn : MonoBehaviour 
{
	private int increment = 0;

	private	void Awake()
		{
			//Debug.Log ("I am an awake. "+"Yeah ya are");
		}

	public void Start()
		{
			//Debug.Log ("I'm a start.");
		}

	public void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			increment += 1;
		}
			
			//Debug.Log ("I'm updating. " + increment);
        //yaaaaaaaaaaaaaaaaaaaaaaa
	}
}
