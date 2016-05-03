using UnityEngine;
using System.Collections;

public class OnGround : PhysicMoveStates {

	// Use this for initialization
	PhysicMoveStates instance;

	//Rigidbody2D rigidbody2D;
	//PhysicMove physicMove;
	//DetectionController detectionController;

	public OnGround()
	{
		instance = (OnGround)this;


	}


	public override void Update(ref PhysicMove physicMove)
	{
		//Debug.Log (raysDetection.IsBottDetecting ());

	
//		Debug.Log ("botGround> " + physicMove.GetRaysDetection.IsBottDetecting ());
	}

	public override void  MoveUp(ref PhysicMove physicMove)
	{
		

		if (physicMove.GetRaysDetection.IsBottDetecting()) 
		{
			
			float velocityY = Mathf.Pow(10,3.35f) * Time.deltaTime * 1 ;
			physicMove.GetRigidBody2D.velocity = new Vector2(physicMove.GetRigidBody2D.velocity.x,velocityY);//para comenzar esta bien
			instance= new OnAir();
			ChangeState (ref physicMove, instance);
			//podria ser necesario liberar la memoria de forma manual en este punto(en el que se cambia el estado de la clase physicmove)
		}


	}
	public override void MoveDown(ref PhysicMove physicMove)
	{

	}

	public override void  MoveLeft(ref PhysicMove physicMove)
	{	
		if (!physicMove.GetRaysDetection.IsLeftDetecting()) 
		{
			float velocityX = Mathf.Pow (10, 3) * Time.deltaTime * -1;
			physicMove.GetRigidBody2D.velocity = new Vector2 (velocityX, physicMove.GetRigidBody2D.velocity.y);
		}
	}
	public override void  MoveRight(ref PhysicMove physicMove)
	{	
		if (!physicMove.GetRaysDetection.IsRightDetecting()) {
			float velocityX = Mathf.Pow (10, 3) * Time.deltaTime * 1;
			physicMove.GetRigidBody2D.velocity = new Vector2 (velocityX, physicMove.GetRigidBody2D.velocity.y);
		}
	}
}
