using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour { // This public class is to set the Timer of the game //
	// Everytime a specific chunk of time has been studied, this Timer will trigger an increase in XP //
	
	Text text; // You are setting the text variable //
	float theTime; // You are setting the time float variable //
	public float speed = 1; // You are setting the speed at which the Timer is working through a float variable //
	bool playing; // This boolean variable is meant to trigger the Timer to play //
	
	// Start is called before the first frame update //
	void Start() // This void is meant to establish the starting function of the Timer //
	{
		text = GetComponent<Text>(); // You are telling the system that the text variable must connect with the 'Text' component of the Unity engine //
	}
	
	// Update is called once per frame
	void Update() // You are telling the system to called the update once per frame //
	{
		if (playing == true) // If the activation of the timer is true //
		{
			theTime += Time.deltaTime * speed; // Multiply the time of the Timer with the speed at which it is functioning //
			string hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00"); // You are setting up the pace of the hour component of the Timer //
			string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00"); // You are setting up the pace of the Timer responsible for minutes //
			string seconds = (theTime % 60).ToString("00"); // You are setting up the pace of the Timer responsible for seconds //
			text.text = hours + ":" + minutes + ":" + seconds; // You are organizing the timer in a way that 00:00:00, is organized through Hours : Minutes : Seconds //
		}
	}
	
	public void ClickPlay() // This is a button function meant to Play the timer //
	{
		playing = true;
	}
	
	public void ClickStop() // This is a button function meant to Stop the timer //
	{
		playing = false;
	}
	
	public void ClickRestart() // This is a button function meant to Restart the timer //
	{
		bool resetted = true; // This boolean variable is meant to make it true that the time has been resetted to //
		if (resetted) // If the timer has been resetted //
		{
			text.text = "00:00:00"; // This specific arrangement of the timer //
			theTime = 0; // You are confirming that the timer has been set to 0 //
		}
	}
}
	
