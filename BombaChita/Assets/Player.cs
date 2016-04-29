using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PhysicMove))]
public class Player : MonoBehaviour {

	// Use this for initialization
	public float speed;

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
		if (Input.GetKey (keyDown)) 
		{
			//moveDirection.y = -1*speed;
		
		}
		if (Input.GetKey (keyUp)) 
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
		//moving.Velocity = moveDirection;
	//	moving.Move (velocity);
	}

}
