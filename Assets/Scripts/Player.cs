using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private Rigidbody rigidbody;

	public Text test;

	private int scores = 0;

	private Vector3 OriginalScale;

	public GameObject Victery;

	public int force = 5;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		OriginalScale = rigidbody.transform.localScale;	
	}

	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		rigidbody.AddForce (new Vector3(h, 0, v) * force);
	}

	void OnCollisionEnter(Collision collision){
		//string name = collision.collider.name;
		//print (name);
		if(collision.collider.tag == "Food"){
			Destroy (collision.collider.gameObject);
		}
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Food") {
			Destroy (collider.gameObject);
			scores++;
			if (scores == 8) {
				Victery.SetActive (true);
			}
			test.text = "scores : " + scores.ToString(); 
		}
	}
			
}
