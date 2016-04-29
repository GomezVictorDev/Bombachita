using UnityEngine;
using System.Collections;

public class OnGround : PhysicMoveStates {

	// Use this for initialization
	PhysicMoveStates instance;
	RaysDetection raysDetection;
	DetectionController detectionController;
	public OnGround( Rigidbody2D rigidbody2D,ref DetectionController detectionController)
	{
		instance = (OnGround)this;
		base.rigidbody2D = rigidbody2D;
		this.detectionController = detectionController;
	
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
	public override void FixedUpdate(){
	}
	public override void  MoveUp(ref PhysicMove physicMove)
	{
		base.rigidbody2D.velocity = Vector2.up * 30f;//para comenzar esta bien
		instance=new OnJump(ref base.rigidbody2D,ref detectionController);
		ChangeState(ref physicMove,instance);

	}
	public override void MoveDown(ref PhysicMove physicMove)
	{

	}

	public override void  MoveLeft(ref PhysicMove physicMove)
	{	
		base.rigidbody2D.velocity = Vector2.left * 14f;
	}
	public override void  MoveRight(ref PhysicMove physicMove)
	{	
		base.rigidbody2D.velocity = -Vector2.left * 14f;
	}
}
