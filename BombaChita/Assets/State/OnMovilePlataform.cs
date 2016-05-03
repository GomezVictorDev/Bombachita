using UnityEngine;
using System.Collections;

public class OnMovilePlataform : PhysicMoveStates {

	PhysicMoveStates instance;
	private Vector2 plataformVelocity= Vector2.zero;
	//DetectionController detectionController;
	Rigidbody2D rigidbody2D;

	public OnMovilePlataform(Rigidbody2D rigidbody2D/*,ref DetectionController detectionController*/, ref Vector2 plataformVelocity)
	{
		instance = (OnMovilePlataform)this;
		this.rigidbody2D = rigidbody2D;
		this.plataformVelocity = plataformVelocity;
	//	this.detectionController = detectionController;
	}

	public OnMovilePlataform()
	{
		instance = (OnMovilePlataform)this;

	}
	public override void Update(ref PhysicMove physicMove)
	{
		
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
		rigidbody2D.velocity = (plataformVelocity.x+ 7f) * Vector2.left ;
	}
	public override void  MoveRight(ref PhysicMove physicMove)
	{	
		rigidbody2D.velocity = (plataformVelocity.x+ 7f) * -Vector2.left ;
	}
}
