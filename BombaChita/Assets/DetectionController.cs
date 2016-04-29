using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
public class DetectionController:MonoBehaviour {
	

	private string [] lastObjectData;

	private GameObject bombWatchObject;
	private static Watch bombWatch;

	const float PLAYER_DELAY = 1f;
	const float BOMB_DELAY = 1f;
	const float POWERUP_DELAY = 1f;

	string OwnerDetection="OwnerName";

	BoxCollider2D boxcollider2D;
	RaysDetection raysDetection;
	[SerializeField]
	private LayerMask filterLayer;
	public  enum LastGround
	{
		None,Ground,Plataform
	};
	private LastGround lastGround=LastGround.None;
	public LastGround GetLastGround
	{
		get{return lastGround; }
	}



	public void Start()
	{
		boxcollider2D = GetComponent<BoxCollider2D> ();
		lastObjectData = new string[3];
		TimeController.Instance.CreateWatch("BombWatch");
		bombWatch = TimeController.Instance.FindWatch ("BombWatch");
		raysDetection = new RaysDetection (ref boxcollider2D, filterLayer);
		OwnerDetection = transform.gameObject.name;

	}
	public void FixedUpdate()
	{
		//esta la pura cagada! solucionar
		raysDetection.UpdateDettection ();
		if(raysDetection.IsTopDetecting())
		{
			raysDetection.SaveDataFromTopDetection ();
		}
		if(raysDetection.IsBottDetecting())
		{
			Debug.Log ("Botdetecting");
			raysDetection.SaveDataFromBottDetection ();
		}else
		{
			lastGround=LastGround.None;
		}
		if(raysDetection.IsLeftDetecting())
		{
			raysDetection.SaveDataFromLeftDetection ();
		}
		if(raysDetection.IsRightDetecting())
		{
			raysDetection.SaveDataFromRightDetection ();

		}

//		ObjectDetected (raysDetection.GetGameObjectName, raysDetection.GetGameObjectTag, "esto lo sacare");
	}
	public void PlayerDetected(string name)
	{
		if (!GameManager.Instance.GetBomb.Owner.Equals (name)) 
		{
			if (bombWatch.GetSeconds >= PLAYER_DELAY) 
			{
				GameManager.Instance.GetBomb.Owner = name;
				bombWatch.RestartWatch ();

			}



		}
		
	}

	public void BombDetected()
	{
		
	}private void PowerUpDetected()
	{
		
	}
	public void GroundDetected()
	{
		lastGround=LastGround.Ground;
	}
	public void PlataformDetected()
	{
		lastGround=LastGround.Plataform;
	}

	public void ObjectDetected(string name,string tag, string layer)
	{
		//el orden de los datos enviados debe ser name,tag,layer, respectivamente
		lastObjectData[0]=name;
		lastObjectData[1]=tag;
		lastObjectData[0]=layer;
		switch(tag)
		{
		case "Player":
			PlayerDetected (name);
			break;
		case "Bomb":
			break;
		case "PowerUp":
			break;
		case"Ground":
			
			GroundDetected ();
			break;
		case"Plataform":

			GroundDetected ();
		break;

		}
		
	}

}
