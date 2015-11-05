using UnityEngine;
using System.Collections;

public class FlagController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Ball")) {
			Debug.Log ("OH!! Yes!!");
			Debug.LogError("oh!! yes!");
		}
		
	}
}
