using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawners;
	CoinsScript coins;

	// Use this for initialization
	void Start () {
		coins = GameObject.Find ("Main Camera").GetComponent<CoinsScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("x")) 
		{
			if(coins.playerCoins>=25)
			{
				coins.UpdateCoins(-25);
				GameObject clone;
				clone = Instantiate(spawners, transform.position, transform.rotation) as GameObject;
				clone.ToString();
			}

		}
	}


}
