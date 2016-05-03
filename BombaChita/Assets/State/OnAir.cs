using UnityEngine;
using System.Collections;

public class OnAir : PhysicMoveStates {

	 PhysicMoveStates instance;
	//establecer un rayo que cuando toque el suelo me avise
	//DetectionController detectionController;
	Rigidbody2D rigidbody2D;
	public OnAir(Rigidbody2D rigidbody2D/*,ref DetectionController detectionController*/)
	{
		instance = (OnAir)this;
		this.rigidbody2D = rigidbody2D;
		//this.detectionController = detectionController;
	}

	public OnAir()
	{
		
		instance = (OnAir)this;
		                         
	}
	public OnAir Instance
	{
		get
		{
			if (instance == null)
				instance = this;
			return (OnAir)instance;
		}
	}
	public override void Update(){
		
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
		rigidbody2D.velocity = Vector2.left * 14f;
	}
	public override void  MoveRight(ref PhysicMove physicMove)
	{	
		rigidbody2D.velocity = -Vector2.left * 14f;
	}
}
