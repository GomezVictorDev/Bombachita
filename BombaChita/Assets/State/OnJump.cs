using UnityEngine;
using System.Collections;

public class OnJump : PhysicMoveStates {

	 PhysicMoveStates instance;
	//establecer un rayo que cuando toque el suelo me avise
	DetectionController detectionController;
	bool isOnAir=false;
	public OnJump(ref Rigidbody2D rigidbody2D,ref DetectionController detectionController)
	{
		instance = (OnJump)this;
		base.rigidbody2D = rigidbody2D;
		this.detectionController = detectionController;
	}

	public OnJump()
	{
		
		instance = (OnJump)this;
		                         
	}
	public OnJump Instance
	{
		get
		{
			if (instance == null)
				instance = this;
			return (OnJump)instance;
		}
	}
	public override void FixedUpdate(){
		
	}
	public override void  MoveUp(ref PhysicMove physicMove)
	{


	}
	public override void  MoveDown(ref PhysicMove physicMove)
	{
		//solo debo poder mover mi direccion
	}

	public override void  MoveLeft(ref PhysicMove physicMove)
	{	
		base.rigidbody2D.velocity = Vector2.left * 7f;
	}
	public override void  MoveRight(ref PhysicMove physicMove)
	{	
		base.rigidbody2D.velocity = -Vector2.left * 7f;
	}
}
