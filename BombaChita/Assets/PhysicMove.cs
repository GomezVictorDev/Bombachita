using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PhysicMove : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rigidBody2D;
	[SerializeField]
	//DetectionController detectionController;
	PhysicMoveStates  physicMoveState;
	PhysicMove thisPhysicMove;
	System.Type moveStateType;
	public Rigidbody2D GetRigidBody2D
	{
		get{return  rigidBody2D;}
	}
	public void Init () 
	{
		rigidBody2D= GetComponent<Rigidbody2D> ();
		thisPhysicMove=this;
		//physicMoveState = new OnGround ( rigidBody2D/*,ref detectionController*/);
		//moveStateType = physicMoveState.GetType();
		/*if (GetComponent<DetectionController> () == null)
		{
			detectionController = GetComponent<DetectionController> ();
		}*/
	}

	// Update is called once per frame
	public void ChangeMoveState(PhysicMoveStates state)//en el nuevo modelo estos estados seran manejados por el placeHolder
	{
		physicMoveState = state;
		moveStateType = physicMoveState.GetType();
	}
	void Update () 
	{
		Debug.Log (physicMoveState);
	}


	public void  MoveUp()
	{
		
		physicMoveState.MoveUp (ref thisPhysicMove);
	}
	public void  MoveDown()
	{
		physicMoveState.MoveDown (ref thisPhysicMove);
	}

	public void MoveLeft()
	{	
		physicMoveState.MoveLeft (ref thisPhysicMove);
	}
	public void MoveRight()
	{	
		physicMoveState.MoveRight (ref thisPhysicMove);
	}



}
