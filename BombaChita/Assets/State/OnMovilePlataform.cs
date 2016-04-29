using UnityEngine;
using System.Collections;

public class OnMovilePlataform : PhysicMoveStates {

	 PhysicMoveStates instance;
	private Vector2 plataformVelocity;
	DetectionController detectionController;


	public OnMovilePlataform(Rigidbody2D rigidbody2D,ref DetectionController detectionController)
	{
		instance = (OnMovilePlataform)this;
		base.rigidbody2D = rigidbody2D;
		this.detectionController = detectionController;
	}

	public OnMovilePlataform()
	{
		instance = (OnMovilePlataform)this;

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
		base.rigidbody2D.velocity = (plataformVelocity.x+ 7f) * Vector2.left ;
	}
	public override void  MoveRight(ref PhysicMove physicMove)
	{	
		base.rigidbody2D.velocity = (plataformVelocity.x+ 7f) * -Vector2.left ;
	}
}
