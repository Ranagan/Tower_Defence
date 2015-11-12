using UnityEngine;
using System.Collections;

public class StabbyScript : MonoBehaviour {

	public Transform target;
	public float speed = 2f;
	public bool facingRight;
	Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		float toTheRight = target.position.x - transform.position.x;
		
		
		if (toTheRight > 0 && !facingRight)
		{
			Flip ();
		}
		else if (toTheRight < 0 && facingRight) 
		{
			Flip ();
		}
		
		transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		
		anim.SetBool("Moving", true);
		
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
