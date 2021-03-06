using UnityEngine;
using System.Collections;

public class PaeDaeSample : MonoBehaviour 
{
	private string LabelMessage;
	public GUIStyle LabelStyle;
	
	private PaeDaeWrapper PaeDae;
	
	void Awake ()
	{
		Debug.Log ("Awake called");
		
		// Initialize the PaeDaeWrapper instance and attach it to this script's game object
		PaeDae = new PaeDaeWrapper(this.gameObject);
	}
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Start called");
		
		LabelMessage = "Initializing PaeDaeWrapper...";
		
		// Replace with your app's key, you only have to do this once in your app's lifecycle
		PaeDae.Init ("b00015e0-5cf7-012f-c818-12313f04f84c"); 
	}
	
	// Update is called once per frame
	void Update () 
	{
	    
	}
	
	void OnGUI () 
	{
        GUI.Label(new Rect(10, 10, 500, 250), LabelMessage, LabelStyle);
		
		Event Mouse = Event.current;
        if (Mouse.clickCount == 2)
        {
            PaeDae.ShowAd ("default.milestone");
        }
    }
	
	// PaeDaeWrapper init event handlers
	void PaeDaeInitialized ()
	{
	    string message = "PaeDaeWrapper loaded - double click to show";
		Debug.Log (message);
	    LabelMessage = message;
	}
	
	void PaeDaeInitializeFailed ()
	{
		string message = "PaeDaeWrapper failed to load";
		Debug.Log (message);
	    LabelMessage = message;
	}
	
	// PaeDaeWrapper ShowAd event handlers
	void PaeDaeAdWillDisplay ()
	{
	    string message = "PaeDaeWrapper: ad unit has been shown";
		Debug.Log (message);
		LabelMessage = message;
	}
	
	void PaeDaeAdUnloaded ()
	{
		string message = "PaeDaeWrapper: ad unit has been dismissed";
		Debug.Log (message);
		LabelMessage = message;
	}
	
	void PaeDaeAdUnavailable ()
	{
		string message = "PaeDaeWrapper: no ad available";
		Debug.Log (message);
		LabelMessage = message;
	}
}
