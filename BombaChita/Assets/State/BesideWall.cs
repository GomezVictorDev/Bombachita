using UnityEngine;
using System.Collections;

public class BesideWall : PhysicMoveStates {

	 PhysicMoveStates instance;
	RaysDetection raysDetection;
	//establecer un rayo que cuando toque el suelo me avise
	//DetectionController detectionController;
	Rigidbody2D rigidbody2D;
	public BesideWall(Rigidbody2D rigidbody2D,ref RaysDetection raysDetection)
	{
		instance = (BesideWall)this;
		this.raysDetection = raysDetection;
		//this.detectionController = detectionController;
	}

	public BesideWall()
	{
		
		instance = (BesideWall)this;
		                         
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
	public override void Update(ref PhysicMove physicMove)
	{
		//float velocityY = Mathf.Pow(10,3.35f) * Time.deltaTime * 1 ;
		rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
	}
	public override void  MoveUp(ref PhysicMove physicMove)
	{


	}
	public override void  MoveDown(ref PhysicMove physicMove)
	{
		//solo debo poder mover mi direccion
	}

	public override void  MoveLeft(ref PhysicMove physicMove)
	{	float velocityX = Mathf.Pow(10,3) * Time.deltaTime * -1 ;
		rigidbody2D.velocity = new Vector2 (velocityX, rigidbody2D.velocity.y);
	}
	public override void  MoveRight(ref PhysicMove physicMove)
	{	float velocityX =  Mathf.Pow(10,3) * Time.deltaTime * 1 ;
		rigidbody2D.velocity = new Vector2 (velocityX, rigidbody2D.velocity.y);
	}
	public override void DontMove (ref  PhysicMove physicMove)
	{
		
	}
}
