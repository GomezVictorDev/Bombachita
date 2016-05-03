using UnityEngine;
using System.Collections;

public class RaysDetection  {//esta clase debe decir quien tiene la bomba y otra debe ser la encargada de pasar la bomba

	// el que tiene la bomba no es un game object sino mas bien un estado q se genera cuando un usuario q tiene el estado bombra lo pasa a otro usuario q tiene el estado bomba
	//public static  Bomb bomb;
	private  string []topData=new string[2],bottData=new string[2],leftData=new string[2],rightData= new string[2];

	private BoxCollider2D boxCollider2D;
	private RayOriginBoxCollider raysOrigin;


	private LayerMask layerFilterDetection;

	public string[] GetTopData
	{
		get{return topData; }
	}
	public string[] GetBottData
	{
		get{return bottData; }
	}
	public string[] GetLeftData
	{
		get{return leftData; }
	}
	public string[] GetRightData
	{
		get{return rightData; }
	}

	public RaysDetection (BoxCollider2D boxCollider2D,LayerMask layerFilter) 
	{
		this.boxCollider2D =boxCollider2D;
		raysOrigin = new RayOriginBoxCollider ( boxCollider2D, 4);
		this.layerFilterDetection = layerFilter;
	
	}
	
	// Update is called once per frame

	public void UpdateDettection ()
	{
		raysOrigin.UpdateRays ( boxCollider2D);

		SeeRaycast ();





	}
	public void SaveDataFromTopDetection()
	{
		RaycastHit2D hit = GetTopHit ();

		topData[0] = hit.transform.gameObject.name;
		topData[1] = hit.transform.gameObject.tag;
			
		
	}
	public void SaveDataFromBottDetection()
	{
		RaycastHit2D hit = GetBottHit ();

		bottData[0] = hit.transform.gameObject.name;
		bottData[1] = hit.transform.gameObject.tag;


	}
	public void SaveDataFromLeftDetection()
	{
		RaycastHit2D hit = GetLeftHit ();

		leftData[0] = hit.transform.gameObject.name;
		leftData[1] = hit.transform.gameObject.tag;

	}
	public void SaveDataFromRightDetection()
	{
		RaycastHit2D hit = GetRightHit ();

		rightData[0] = hit.transform.gameObject.name;
		rightData[1]= hit.transform.gameObject.tag;


	}
	public RaycastHit2D GetTopHit()
	{
		RaycastHit2D hit=new RaycastHit2D();
		for (int i = 0; i < raysOrigin.GetTopRays.Length; i++) 
		{

			hit = Physics2D.Raycast(raysOrigin.GetTopRays[i].origin,raysOrigin.GetTopRays[i].direction,
				.05f,layerFilterDetection);
			if (hit) {

				return hit;
			} 

		}
		return hit;
	}
	public RaycastHit2D GetBottHit()
	{
		RaycastHit2D hit=new RaycastHit2D();
		for (int i = 0; i < raysOrigin.GetBottRays.Length; i++) 
		{
			
			hit = Physics2D.Raycast(raysOrigin.GetBottRays[i].origin,raysOrigin.GetBottRays[i].direction,
				.05f,layerFilterDetection);
			
			if (hit) 
			{
				
				return hit;
			}

		}

		return hit;
	}
	public RaycastHit2D GetLeftHit()
	{
		RaycastHit2D hit=new RaycastHit2D();
		for (int i = 0; i < raysOrigin.GetLeftRays.Length; i++) 
		{

			hit = Physics2D.Raycast(raysOrigin.GetLeftRays[i].origin,raysOrigin.GetLeftRays[i].direction,
				.5f,layerFilterDetection);
			if (hit) 
			{

				return hit;
			}

		}
		return hit;
	}
	public RaycastHit2D GetRightHit()
	{
		RaycastHit2D hit=new RaycastHit2D();

		for (int i = 0; i < raysOrigin.GetRightRays.Length; i++) 
		{

			hit = Physics2D.Raycast(raysOrigin.GetRightRays[i].origin,raysOrigin.GetRightRays[i].direction,
				.5f,layerFilterDetection);
			if (hit) 
			{
				return hit;
			}

		}
		return hit;
	}
	public bool IsTopDetecting()
	{
		
			
		if (GetTopHit()) {

			//collisionInfo.collisionTop=true;
			return true;
		}


		return false;
	}
	public bool IsBottDetecting()
	{
		
		if (GetBottHit().transform) 
			{
				/*gameObjectTag = hit.transform.gameObject.tag;
				gameObjectName = hit.transform.gameObject.name;
				gameObjectLayer = hit.transform.gameObject.layer;*/
				return true;
			}

		
		return false;
	}
	public bool IsRightDetecting()
	{
		
		if (GetRightHit()) 
			{
				
				return true;
			}

		
		return false;
	}
	public bool IsLeftDetecting()
	{
		
		if (GetLeftHit()) 
			{
				
				return true;
			}

		
		return false;
	}


	void SeeRaycast()
	{
		Color color=Color.black;
		for(int x=0 ;x<raysOrigin.GetNumbersOfRays;x++)
		{

			switch (x) 
			{
			case 0:
				color = Color.white;
				break;
			case 1:
				color = Color.red;
				break;
			case 2:
				color = Color.blue;
				break;
			case 3:
				color = Color.green;
				break;
			}
			Debug.DrawRay (raysOrigin.GetTopRays [x].origin, raysOrigin.GetTopRays [x].direction,
				color);
			Debug.DrawRay (raysOrigin.GetBottRays [x].origin, raysOrigin.GetBottRays [x].direction,
				color);
			Debug.DrawRay (raysOrigin.GetLeftRays [x].origin, raysOrigin.GetLeftRays [x].direction,
				color);
			Debug.DrawRay (raysOrigin.GetRightRays [x].origin, raysOrigin.GetRightRays [x].direction,
				color);

		}
	}

}
