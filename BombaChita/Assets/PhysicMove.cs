using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PhysicMove : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rigidBody2D;

	//DetectionController detectionController;
	PhysicMoveStates  physicMoveState;
	PhysicMove thisPhysicMove;
	System.Type moveStateType;

	RaysDetection raysDetection;
	[SerializeField]
	BoxCollider2D boxCollider2D;
	[SerializeField]
	LayerMask layerFilterRay;
	public Rigidbody2D GetRigidBody2D
	{
		get{return  rigidBody2D;}
	}
	public RaysDetection GetRaysDetection
	{
		get{return raysDetection;}
	}

	public void Init () 
	{
		if(GetComponent<Rigidbody2D> ()!=null)
		rigidBody2D= GetComponent<Rigidbody2D> ();
		if(GetComponent<BoxCollider2D> ()!=null)
		boxCollider2D = GetComponent<BoxCollider2D>();
		raysDetection = new RaysDetection ( boxCollider2D, layerFilterRay);
		thisPhysicMove=this;
		physicMoveState = new OnGround ();
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
		raysDetection.UpdateDettection ();
		if(physicMoveState!=null)
			physicMoveState.Update (ref thisPhysicMove);
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
