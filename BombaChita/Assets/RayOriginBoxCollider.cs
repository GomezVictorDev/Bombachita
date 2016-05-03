using UnityEngine;
using System.Collections;

public class RayOriginBoxCollider
{
	private BoxCollider2D origin;
	private Ray2D[] ray2DTop,ray2DRight,ray2DBottom,ray2DLeft;

	private float xSpaceBetweenRays;
	private float ySpaceBetweenRays;
	private const float OFFSIZE_X=0.05f, OFFSIZE_Y=0.08f;
	private int raysNumbers;

	public Ray2D[] GetTopRays
	{
		get{ return  ray2DTop; }

	}
	public Ray2D[] GetBottRays
	{
		get{ return ray2DBottom; }

	}
	public Ray2D[] GetRightRays
	{
		get{ return ray2DRight; }

	}
	public Ray2D[] GetLeftRays
	{
		get{ return ray2DLeft; }

	}
	public int GetNumbersOfRays
	{
		get{ return raysNumbers;}
	}
	public RayOriginBoxCollider(BoxCollider2D  boxcoll2d,int raysNumbers)
	{
		origin = boxcoll2d;
		this.raysNumbers = raysNumbers;

		Bounds boxBounds = origin.bounds;
		xSpaceBetweenRays = (boxBounds.size.x-OFFSIZE_X*2) / (raysNumbers-1);
		ySpaceBetweenRays= (boxBounds.size.y-OFFSIZE_Y*2) / (raysNumbers-1);
		ray2DTop = new Ray2D[raysNumbers];
		ray2DRight = new Ray2D[raysNumbers];
		ray2DBottom = new Ray2D[raysNumbers];
		ray2DLeft = new Ray2D[raysNumbers];





	}
	public void UpdateRays(BoxCollider2D boxcoll2d)
	{
		origin = boxcoll2d;
		SetSidePoints ();
	}
	private void SetSidePoints()
	{
		Bounds boxBounds = origin.bounds;
		Vector2 firstTopSidePoint = new Vector2 (boxBounds.min.x+OFFSIZE_X, boxBounds.max.y);
		Vector2 firstRightSidePoint = new Vector2 (boxBounds.max.x, boxBounds.max.y-OFFSIZE_Y);
		Vector2 firstBottSidePoint = new Vector2 (boxBounds.min.x+OFFSIZE_X, boxBounds.min.y);
		Vector2 firstLeftSidePoint = new Vector2 (boxBounds.min.x, boxBounds.max.y-OFFSIZE_Y);


		ray2DTop[0] = new Ray2D (firstTopSidePoint, Vector2.up);
		ray2DRight[0] = new Ray2D (firstRightSidePoint, Vector2.right);
		ray2DLeft[0] = new Ray2D (firstLeftSidePoint, -Vector2.right);
		ray2DBottom[0] = new Ray2D (firstBottSidePoint, -Vector2.up);
		for (int actualNumber = 1; actualNumber < raysNumbers; actualNumber++)
		{
			Vector2 topSidePoint= new Vector2 (firstTopSidePoint.x + actualNumber * xSpaceBetweenRays,firstTopSidePoint.y);
			Vector2 bottSidePoint = new Vector2 (firstBottSidePoint.x + actualNumber * xSpaceBetweenRays,firstBottSidePoint.y);
			Vector2 leftSidePoint = new Vector2 ( firstLeftSidePoint.x,  firstLeftSidePoint.y- actualNumber * ySpaceBetweenRays);
			Vector2 rightSidePoint = new Vector2 (firstRightSidePoint.x,firstRightSidePoint.y- actualNumber * ySpaceBetweenRays);

			ray2DTop[actualNumber] = new Ray2D (topSidePoint, Vector2.up);
			ray2DRight[actualNumber] = new Ray2D (rightSidePoint, Vector2.right);
			ray2DLeft[actualNumber] = new Ray2D (leftSidePoint, -Vector2.right);
			ray2DBottom[actualNumber] = new Ray2D (bottSidePoint, -Vector2.up);
		
		}

	}

}
