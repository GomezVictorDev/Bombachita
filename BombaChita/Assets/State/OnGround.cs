using UnityEngine;
using System.Collections;

public class OnGround : PhysicMoveStates {

	// Use this for initialization
	PhysicMoveStates instance;
	RaysDetection raysDetection;
	Rigidbody2D rigidbody2D;
	//DetectionController detectionController;
	public OnGround( Rigidbody2D rigidbody2D/*,ref DetectionController detectionController*/)
	{
		instance = (OnGround)this;
		this.rigidbody2D = rigidbody2D;
		//this.detectionController = detectionController;
	
	}
	public OnGround()
	{
		instance = (OnGround)this;


	}

	public OnGround Instance
	{
		get
		{
			if (instance == null)
				instance = this;
			return (OnGround)instance;
		}
	}
	public override void Update(){
	}
	public override void  MoveUp(ref PhysicMove physicMove)
	{
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,rigidbody2D.velocity.y+10);//para comenzar esta bien


	}
	public override void MoveDown(ref PhysicMove physicMove)
	{

	}

	public override void  MoveLeft(ref PhysicMove physicMove)
	{	
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x  -170*Time.deltaTime, rigidbody2D.velocity.y);
	}
	public override void  MoveRight(ref PhysicMove physicMove)
	{	
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x + 170 *Time.deltaTime, rigidbody2D.velocity.y);
	}
}
