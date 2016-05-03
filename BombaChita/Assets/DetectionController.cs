using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
public class DetectionController:MonoBehaviour {
//este controlador se encargara de manejar si el personaje puedesaltar, pasar la bomba
	//si 
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

	PlaceHolder placeHolder;
	[SerializeField]
	PhysicMove physicMove;
	public void Start()
	{
		placeHolder = new PlaceHolder (ref physicMove);
		boxcollider2D = GetComponent<BoxCollider2D> ();
		lastObjectData = new string[3];
		TimeController.Instance.CreateWatch("BombWatch");
		bombWatch = TimeController.Instance.FindWatch ("BombWatch");
		bombWatch.SetSecondsForPause =2f;//este valor siempre debe ser mayor al delay de la bomba!
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
			ObjectDetected (raysDetection.GetTopData[0],raysDetection.GetTopData[1]);
		}

		if (raysDetection.IsBottDetecting ()) {
			Debug.Log ("Botdetecting");
			raysDetection.SaveDataFromBottDetection ();
			ObjectDetected (raysDetection.GetBottData[0],raysDetection.GetBottData[1]);
		} else
		{
			NoneDetected ();
		}
		if(raysDetection.IsLeftDetecting())
		{
			raysDetection.SaveDataFromLeftDetection ();
			ObjectDetected (raysDetection.GetLeftData[0],raysDetection.GetLeftData[1]);
		}
		if(raysDetection.IsRightDetecting())
		{
			raysDetection.SaveDataFromRightDetection ();
			ObjectDetected (raysDetection.GetRightData[0],raysDetection.GetRightData[1]);

		}


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
		placeHolder.Ground ();
	}public void NoneDetected()
	{
		placeHolder.Air();
	}
	public void PlataformDetected(ref Vector2 plataformVelocity)
	{
		placeHolder.MovilPlataform (ref plataformVelocity);
	}

	public void ObjectDetected(string name,string tag)
	{
		//el orden de los datos enviados debe ser name,tag,layer, respectivamente
		lastObjectData[0]=name;
		lastObjectData[1]=tag;

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
		case"MPlataform":

			//PlataformDetected ();
		break;

		}
		
	}

}
