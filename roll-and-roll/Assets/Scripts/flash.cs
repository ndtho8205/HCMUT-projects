using UnityEngine;
using System.Collections;

public class flash : MonoBehaviour {
	int k=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(k%100<50){
			transform.localScale += new Vector3 (0.5f*Time.deltaTime, 0.5f*Time.deltaTime, 1);
			k++;
		}
		else{ transform.localScale += new Vector3 (-0.5f*Time.deltaTime, -0.5f*Time.deltaTime, 1);
			k++;
		}
	}
}
