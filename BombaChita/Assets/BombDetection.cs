using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
public class BombDetection:MonoBehaviour {
//este controlador solo se encargara de saber si el personaje puede pasar la bomba
	//si 

	private GameObject bombWatchObject;
	private static Watch bombWatch;

	public static string bombOwner= "Player1";
	const float PLAYER_DELAY = 1f;


	//esta clase solo deberia encargarse de obtener los datos de los objetos con los que puede interactuar

	BoxCollider2D boxcollider2D;
	RaysDetection raysDetection;

	[SerializeField]
	private LayerMask filterLayer;




	public void Start()
	{
	//	placeHolder = new PlaceHolder (ref physicMove);
		boxcollider2D = GetComponent<BoxCollider2D> ();
		TimeController.Instance.CreateWatch("BombWatch");
		bombWatch = TimeController.Instance.FindWatch ("BombWatch");
		bombWatch.SetSecondsForPause =2f;//este valor siempre debe ser mayor al delay de la bomba!
		raysDetection = new RaysDetection (boxcollider2D, filterLayer);

		                                         
	}
	public void FixedUpdate()
	{
		raysDetection.UpdateDettection ();
		DetectingBomb ();





	}
	public void DetectingBomb()
	{
			string name="";
			if(raysDetection.IsTopDetecting() && raysDetection.GetTopHit().transform.tag.Equals("Player"))
			{
				raysDetection.SaveDataFromTopDetection ();
				name = raysDetection.GetTopData [0];
			}
			if(raysDetection.IsBottDetecting ()  && raysDetection.GetBottHit().transform.tag.Equals("Player"))
			{
				raysDetection.SaveDataFromBottDetection ();
				name = raysDetection.GetBottData [0];
			}
			if(raysDetection.IsLeftDetecting()&& raysDetection.GetLeftHit().transform.tag.Equals("Player"))
			{
				raysDetection.SaveDataFromLeftDetection ();
				name = raysDetection.GetLeftData [0];
			}
			if(raysDetection.IsRightDetecting()&& raysDetection.GetRightHit().transform.tag.Equals("Player"))
			{
				raysDetection.SaveDataFromRightDetection ();
				name = raysDetection.GetRightData [0];
			}
		Debug.Log ("Detecting Bomb: " + name);
		if (!name.Equals ("")) 
		{
			PlayerDetected(name);
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
	/*public void AirDetection()
	{
		if (raysDetection.IsLeftDetecting()) 
		{
			ObjectDetected (raysDetection.GetLeftData[0],raysDetection.GetLeftData[1]);
		}else if(raysDetection.IsRightDetecting ())
		{
			ObjectDetected (raysDetection.GetRightData[0],raysDetection.GetRightData[1]);
		} else 
		{
			NoneDetected ();
		}
		ObjectDetected (raysDetection.GetRightData[0],raysDetection.GetRightData[1]);
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
	public void WallDetected()
	{
		placeHolder.Wall();
	}
	public void PlataformDetected(ref Vector2 plataformVelocity)
	{
		placeHolder.MovilPlataform (ref plataformVelocity);
	}

	public void ObjectDetected(string name,string tag)
	{
		//el orden de los datos enviados debe ser name,tag,layer, respectivamente
		//Debug.Log("name: "+ name +"|Tag: "+tag);
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
		case"Wall":

			WallDetected ();
			break;

		}
		
	}*/

}
