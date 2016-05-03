using UnityEngine;
using System.Collections;
using observerPattern;
public class CountDown : Subject {
	//esto es un contador countDown
	private static CountDown instance;
	private float totalValue;
	private float actualValue;

	public CountDown(float totalValue)
	{
		this.totalValue = totalValue;
		this.actualValue = totalValue;
		
	}
	public float GetActualValue
	{
		
		get{ 
			return  actualValue;
			}
			
	}
	public CountDown GetInstance
	{

		get{ 
			instance = this;
			return  instance;
		}

	}
	public void UpdateState(float value)
	{
		if (actualValue > 0f) 
		{
			actualValue = totalValue - value;
			//Debug.Log (actualValue);
			Notify ();
		}
	}


}
