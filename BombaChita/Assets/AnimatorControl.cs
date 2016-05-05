using UnityEngine;
using System.Collections;

public class AnimatorControl  
{

	private Animator animator;//todo los del animator se deberia manejar en esta clase
	private int animatorLayer=0;
	private string lastTrigguer="";
	public void SetTransition(string name)
	{
		
		if (!lastTrigguer.Equals ("name")) {
			animator.SetTrigger (name);
			lastTrigguer = name;
		}
		else
		{
			animator.ResetTrigger (name);
		}

		
	}
	public void SetTransition(string name, bool flag)
	{
		animator.SetBool(name,flag);

	}
	public void SetTransition(string name, float value)
	{
		animator.SetFloat(name,value);

	}
	public void SetTransition(string name, int value)
	{
		animator.SetInteger(name,value);

	}
	public AnimatorControl(Animator animator)
	{
		this.animator = animator;
	}

}
