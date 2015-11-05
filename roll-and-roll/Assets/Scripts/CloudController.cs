using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {
	 int i = 0;
	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(i%60<30){

			transform.position+= new Vector3 (speed* Time.deltaTime, 0.15f*speed*Time.deltaTime, 0);
			i++;}
		else {

			transform.position+= new Vector3 (speed* Time.deltaTime, 0.15f*-speed*Time.deltaTime, 0);
			i++;};
		if (transform.position.x > 10) {
			transform.position= new Vector3 (-11.2f,Random.Range(1.81f,6.46f),0);
		}
	}
}
