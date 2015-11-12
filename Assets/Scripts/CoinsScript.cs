using UnityEngine;
using System.Collections;

public class CoinsScript : MonoBehaviour {

	public float playerCoins = 50;
	// Used to change the appearance of the GUI
	public GUIStyle labelStyle;
	public int fontSize = 45;
	
	void Start()
	{

	}
	
	void Update()
	{
		playerCoins += Time.deltaTime;
	}
	
	public void UpdateCoins(int amt)
	{
		playerCoins += amt;
	}

	
	void OnGUI ()
	{
		// Make the text bigger and white
		labelStyle.fontSize = fontSize;
		labelStyle.fontStyle = FontStyle.Bold;
		labelStyle.normal.textColor = Color.white;
		GUI.Label (new Rect (10, 10, 100, 30), "Score: " + (int)playerCoins, labelStyle);

	}
}
