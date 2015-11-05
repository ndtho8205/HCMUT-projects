using UnityEngine;
using System.Collections;
using UnityEngine.Sprites;
public class StarController : MonoBehaviour {
	public float speed;
	int k;
	public GameObject star;
	// Use this for initialization
	void Start () {
		star.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,0, 0.5f);
		if(k%100<50){
			transform.localScale += new Vector3 (0.5f*Time.deltaTime, 0.5f*Time.deltaTime, 1);
			k++;
		}
		else{ transform.localScale += new Vector3 (-0.5f*Time.deltaTime, -0.5f*Time.deltaTime, 1);
			k++;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Ball")) {
			Debug.Log ("OH!! Yes!!");
			this.gameObject.SetActive(false);
			star.gameObject.SetActive(true);
		}
		
	}
}
