using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PhysicMove : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rigidBody2D;
	[SerializeField]
	DetectionController detectionController;
	PhysicMoveStates  physicMoveState;
	PhysicMove thisPhysicMove;
	System.Type moveStateType;
	/*public Rigidbody2D GetRigidBody2D
	{
		get{return  rigidBody2D;}
	}*/
	public void Init () 
	{
		rigidBody2D= GetComponent<Rigidbody2D> ();
		thisPhysicMove=this;
		physicMoveState = new OnGround ( rigidBody2D,ref detectionController);
		moveStateType = physicMoveState.GetType();
		if (GetComponent<DetectionController> () == null)
		{
			detectionController = GetComponent<DetectionController> ();
		}
	}

	// Update is called once per frame
	public void ChangeMoveState(PhysicMoveStates state)
	{
		physicMoveState = state;
		moveStateType = physicMoveState.GetType();
	}
	void Update () 
	{
		UpdateOnJump ();
	}
	void UpdateOnJump()
	{
		if (moveStateType== typeof(OnJump))// dado que modifique el patron state un poco las clases no seran todas monobehaviur. No tengo forma de hacer un update autonomo para saber en que momento en el estado ONjump se toco suelo
		{
			if (detectionController.GetLastGround == DetectionController.LastGround.Ground) 
			{
				 physicMoveState.ChangeState(ref thisPhysicMove, new  OnGround ( rigidBody2D,ref detectionController));
			}
			if(detectionController.GetLastGround == DetectionController.LastGround.Plataform) 
			{
				physicMoveState.ChangeState(ref thisPhysicMove, new  OnMovilePlataform ( rigidBody2D,ref detectionController));
			}

		}

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
