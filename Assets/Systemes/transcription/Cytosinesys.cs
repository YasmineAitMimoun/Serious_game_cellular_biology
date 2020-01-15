using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Cytosinesys : MonoBehaviour {

	public Transform place;
	public Vector3 initialPosition ;
	public Vector3 mouseposition;
	public float deltaX, deltaY,deltaZ;
	public static bool locked = false ;

	// Use this for initialization
	void Start () {


		initialPosition = transform.position;
	}
	public void OnMouseDown()
	{

		if (!locked) {

			Vector3 vec = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 88f);
			print (Camera.main.ScreenToWorldPoint(vec));

			deltaX =  Camera.main.ScreenToWorldPoint(vec).x - transform.position.x;
			deltaY =  Camera.main.ScreenToWorldPoint(vec).y - transform.position.y;

		}

	}
	public void OnMouseDrag(){

		if ( !locked) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (GetComponent<Transform> ().position);
			Vector3 vec = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, pos.z);
			mouseposition = Camera.main.ScreenToWorldPoint (vec);

			GetComponent<Transform>().position = new Vector3 (mouseposition.x- deltaX ,mouseposition.y - deltaY , transform.position.z);
		}
	}

	public void OnMouseUp(){


		if (Mathf.Abs (transform.position.x - place.position.x) <= 4f &&
			Mathf.Abs (transform.position.y -place.position.y) <= 4f ) {
			GetComponent<Transform>().position = new Vector3 (place.position.x, place.position.y, initialPosition.z);
			locked = true;
		} else {
			transform.position = new Vector3 (initialPosition.x, initialPosition.y, initialPosition.z);

		}
	}

}

