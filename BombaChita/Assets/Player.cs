using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PhysicMove))]
public class Player : MonoBehaviour {

	// Use this for initialization


	public KeyCode keyUp, keyDown, keyLeft,keyRight;
	private PhysicMove moving;

	void Start () {
		moving = GetComponent<PhysicMove> ();
		moving.Init ();
	}
	
	// Update is called once per frame
	void Update () 
	{


		PlayerInputs ();
	
	}
	void PlayerInputs()
	{
		Vector2 moveDirection= Vector2.zero;
		if (Input.GetKeyDown (keyDown)) 
		{
			//moveDirection.y = -1*speed;
		
		}
		if (Input.GetKeyDown (keyUp)) 
		{
			moving.MoveUp ();
		
		}
		if (Input.GetKey (keyLeft)) 
		{
			moving.MoveLeft ();

		}
		if (Input.GetKey (keyRight)) 
		{
			moving.MoveRight ();

		}
		if (Input.GetKeyUp (keyUp) || Input.GetKeyUp (keyRight)|| Input.GetKeyUp (keyLeft))
		{
			moving.DontMove ();
		}

		//moving.Velocity = moveDirection;
	//	moving.Move (velocity);
	}

}
