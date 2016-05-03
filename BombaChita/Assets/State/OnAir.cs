using UnityEngine;
using System.Collections;

public class OnAir : PhysicMoveStates {

	 PhysicMoveStates instance;


	//establecer un rayo que cuando toque el suelo me avise
	//DetectionController detectionController;
	//Rigidbody2D rigidbody2D;


	public OnAir()
	{
		
		instance = (OnAir)this;
		                         
	}

	public override void Update(ref PhysicMove physicMove)
	{
		
		if (physicMove.GetRigidBody2D.velocity.y <= 0)//comprobar si esta cayendo 
		{
			if (physicMove.GetRaysDetection.IsBottDetecting ()) 
			{
				
				instance= new OnGround();
				ChangeState (ref physicMove, instance);
			}
		}
		
	}
	public override void  MoveUp(ref PhysicMove physicMove)
	{


	}
	public override void  MoveDown(ref PhysicMove physicMove)
	{
		//solo debo poder mover mi direccion
	}

	public override void  MoveLeft(ref PhysicMove physicMove)
	{	if (!physicMove.GetRaysDetection.IsLeftDetecting ())
		{
			float velocityX = Mathf.Pow (10, 3) * Time.deltaTime * -1;
			physicMove.GetRigidBody2D.velocity = new Vector2 (velocityX, physicMove.GetRigidBody2D.velocity.y);
		}
	}
	public override void  MoveRight(ref PhysicMove physicMove)
	{	if (!physicMove.GetRaysDetection.IsRightDetecting ())
		{
			float velocityX = Mathf.Pow (10, 3) * Time.deltaTime * 1;
			physicMove.GetRigidBody2D.velocity = new Vector2 (velocityX, physicMove.GetRigidBody2D.velocity.y);
		}
	}
}
