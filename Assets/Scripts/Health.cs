using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		// This function is called when the bullets collide with the enemy gameobject.
		// It is used to deduct health from the enemy's float "health" and destroy the bullet objects when the
		// health is deducted.
		
		if(coll.gameObject.tag == "PlayerMelee")
		{
			health -= 25;
		}
		
		if (health == 0)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy (gameObject,0.5f);
	}
}
