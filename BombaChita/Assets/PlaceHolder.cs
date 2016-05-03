using UnityEngine;
using System.Collections;

public class PlaceHolder  {

	// Use this for initialization
	PhysicMove physicMove;
	public  enum ActualGround
	{
		OnAir,OnGround,OnPlataform
	};
	private ActualGround lastGround=ActualGround.OnGround;
	public ActualGround GetLastGround
	{
		get{return lastGround; }
	}

	public PlaceHolder(ref PhysicMove physicMove)
	{
		this.physicMove = physicMove;
	}
	public void Ground()
	{
		lastGround = ActualGround.OnGround;
		//PhysicMoveStates OnGround = new on
//		physicMove.ChangeMoveState(new OnGround(physicMove.GetRigidBody2D));
	}
	public void Air()
	{
		lastGround = ActualGround.OnAir;
		//PhysicMoveStates OnGround = new on
	//	physicMove.ChangeMoveState(new OnAir(physicMove.GetRigidBody2D));
	}
	public void MovilPlataform(ref Vector2 plataformVelocity)
	{
		lastGround = ActualGround.OnPlataform;
		physicMove.ChangeMoveState (new OnMovilePlataform (physicMove.GetRigidBody2D, ref plataformVelocity));
	}
	public void Wall()
	{
//		physicMove.ChangeMoveState (new OnWall (physicMove.GetRigidBody2D));
	}


}
