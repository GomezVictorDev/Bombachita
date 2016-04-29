using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	private  Bomb bomb;
	Observer bombObs;

	//TimeController timecontroller;
	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance=FindObjectOfType<GameManager> ();
			}
		
			return instance;
		}
	}
	void Start () {//la bomba debe ser creada despues de la clase timer dado que la clase bomba ocupa a timer  en su creacion
		
		bomb = new Bomb ();
		bomb.Owner = "Player1";
		bombObs = bomb;
		TimeController.Instance.GetCountDown.AddObserver (ref bombObs);
	
	}
	public  Bomb GetBomb
	{
		get{return bomb;}
	


	}
	void Update () {
	
	}
}
