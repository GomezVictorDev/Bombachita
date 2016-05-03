using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]

public class SimplePlataformMove : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rigidBody2D;
	float localLimits=2f;
	float lLimit,rLimit;
	short xDir=1;
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D> ();
		rLimit = transform.position.x + localLimits;
		lLimit = transform.position.x - localLimits;
	}
	
	// Update is called once per frame
	void Update ()
	{
		rigidBody2D.velocity = Vector2.right * 2*xDir;
		if (transform.position.x >= rLimit) {
			xDir = -1;
		} if(transform.position.x <= lLimit) 
		{
			xDir = 1;
		}
	
	}
}
