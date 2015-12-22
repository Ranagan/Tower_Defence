using UnityEngine;
using System.Collections;

public class StabbyScript : MonoBehaviour {

	public Transform target;
	public float speed = 2f;
	public bool facingRight;
	Animator anim;
	Rigidbody2D rigidbod;
	public GameObject p1;
	public GameObject p2;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		rigidbod = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{


		
		float toTheRight = target.position.x - transform.position.x;
		
		// So the character is always facing the correct way.
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

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			// When your minion collides with an enemy he is sent backwards for 2 seconds
			// then proceeds to move forwards again.
			rigidbod.velocity = new Vector2(-5, 0);

			StartCoroutine(SpeedCheck ());
		}

		if (col.gameObject.tag == "PlayerMelee") 
		{
			Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
		}
	}

	IEnumerator SpeedCheck()
	{
			yield return new WaitForSeconds (1.75f);
			rigidbod.velocity = Vector2.zero;
	}
}
