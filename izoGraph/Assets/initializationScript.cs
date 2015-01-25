using UnityEngine;
using System.Collections;


public class initializationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

       // Screen.fullScreen = false;
        
//        windowPlacingForWinOS windowPlacing = new windowPlacingForWinOS();
//        windowPlacing.Awake();
        gameObject.AddComponent("windowPlacingForWinOS");
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
