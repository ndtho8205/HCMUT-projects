using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WoodController : MonoBehaviour
{
	public GameObject woodPrefab;

	private Vector3 startPoint, endPoint;
	private float height, length;
	private float storeRotation, storeScale;
	private GameObject wood1, wood2;

	// Use this for initialization
	void Start ()
	{
		Init ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnMouseDown() {
		Init ();
		if (length <= 0.1f)
			return;
		Explosive(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

	void Init ()
	{
		storeRotation = transform.eulerAngles.z;
		storeScale = transform.localScale.x;
		height = GetComponent<BoxCollider2D>().bounds.size.y;
		length = storeScale * 2;

		float deltaX = Mathf.Cos (storeRotation * 2* Mathf.PI / 360) * length / 2;
		float deltaY = Mathf.Sin (storeRotation * 2* Mathf.PI / 360) * length / 2;
		startPoint = new Vector3 (transform.position.x - deltaX, transform.position.y - deltaY, 0);
		endPoint = new Vector3(transform.position.x + deltaX, transform.position.y + deltaY, 0);

		Debug.DrawLine(startPoint, new Vector3(0,0,0), Color.red, 10f, false);
		Debug.DrawLine(endPoint, new Vector3(0,0,0), Color.green, 10f, false);

	}

	void Explosive(Vector3 position) {
		Vector3 firstPosition = new Vector3((startPoint.x + position.x) /2, (startPoint.y + position.y)/2, transform.position.z);
		float firstLength = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(position.x - startPoint.x), 2) + Mathf.Pow(Mathf.Abs(position.y - startPoint.y), 2));
		print (firstLength + "\t" + (length - firstLength));

		Vector3 secondPosition = new Vector3((endPoint.x + position.x) /2, (endPoint.y + position.y)/2, transform.position.z);
		float secondLength = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(position.x - endPoint.x), 2) + Mathf.Pow(Mathf.Abs(position.y - endPoint.y), 2));
		print (firstLength + "\t" + secondLength);

		if (firstLength <= 0.2f || secondLength <=0.2f)
			return;

		Debug.DrawLine(position, new Vector3(-3,-3,0), Color.green, 10f, false);
		Debug.DrawLine(firstPosition, new Vector3(-3,-3,0), Color.green, 10f, false);
		Debug.DrawLine(secondPosition, new Vector3(-3,-3,0), Color.green, 10f, false);
	

		Destroy(GetComponent<SpriteRenderer>() as SpriteRenderer);
		Destroy(GetComponent<BoxCollider2D>() as BoxCollider2D);


		wood1 = (GameObject) Instantiate(woodPrefab, firstPosition, Quaternion.identity);
		wood1.transform.localScale = new Vector3(firstLength * storeScale/length, 1, 1);
		wood1.transform.eulerAngles = new Vector3(0, 0, storeRotation);
		//wood1.GetComponent<WoodController>().clicked = true;
	

		wood2 = (GameObject) Instantiate(woodPrefab, secondPosition, Quaternion.identity);
		wood2.transform.localScale = new Vector3(secondLength * storeScale/length,1, 1);
		wood2.transform.eulerAngles = new Vector3(0, 0, storeRotation);
		//wood2.GetComponent<WoodController>().clicked = true;

		wood1.GetComponent<Rigidbody2D>().AddForce(new Vector2(7f, 7f));
		Destroy(this);
	}
}