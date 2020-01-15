using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;
using System;
using UnityEngine.EventSystems;

public class CytosineSystem : FSystem {
	private Family puzzle = FamilyManager.getFamily(new AllOfComponents(typeof(Cytosine),typeof(PointerOver)));


	private void OnMouseDown()
	{
		if (puzzle.First() != null && !puzzle.First ().GetComponent<Cytosine> ().locked) {
			puzzle.First ().GetComponent<Cytosine> ().deltaX =  Camera.main.ScreenToWorldPoint(Input.mousePosition).x - puzzle.First ().transform.position.x;
			puzzle.First ().GetComponent<Cytosine> ().deltaY =  Camera.main.ScreenToWorldPoint(Input.mousePosition).y - puzzle.First ().transform.position.y;
			puzzle.First ().GetComponent<Cytosine> ().deltaZ =  Camera.main.ScreenToWorldPoint(Input.mousePosition).z - puzzle.First ().transform.position.z;
		}

	}
	private void OnMouseDrag(){
		if (puzzle.First () != null && !puzzle.First ().GetComponent<Cytosine> ().locked) {
			puzzle.First ().GetComponent<Cytosine> ().mouseposition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			puzzle.First ().transform.position = new Vector3 (puzzle.First ().GetComponent<Cytosine> ().mouseposition.x - puzzle.First ().GetComponent<Cytosine> ().deltaX,
																puzzle.First ().GetComponent<Cytosine> ().mouseposition.y - puzzle.First ().GetComponent<Cytosine> ().deltaY,
																puzzle.First ().GetComponent<Cytosine> ().mouseposition.z - puzzle.First ().GetComponent<Cytosine> ().deltaZ);
		}
	}

	private void OnMouseUp(){
		if (puzzle.First () != null) {
			if (Mathf.Abs (puzzle.First ().transform.position.x - puzzle.First ().GetComponent<Cytosine> ().place.position.x) <= 0.5f &&
			    Mathf.Abs (puzzle.First ().transform.position.y - puzzle.First ().GetComponent<Cytosine> ().place.position.y) <= 0.5f &&
			    Mathf.Abs (puzzle.First ().transform.position.z - puzzle.First ().GetComponent<Cytosine> ().place.position.z) <= 0.5f) {
				puzzle.First ().transform.position = new Vector3 (puzzle.First ().GetComponent<Cytosine> ().place.position.x, puzzle.First ().GetComponent<Cytosine> ().place.position.y, puzzle.First ().GetComponent<Cytosine> ().place.position.z);
				puzzle.First ().GetComponent<Cytosine> ().locked = true;
			} else {
				puzzle.First ().transform.position = new Vector3 (puzzle.First ().GetComponent<Cytosine> ().initialPosition.position.x, puzzle.First ().GetComponent<Cytosine> ().initialPosition.position.y, puzzle.First ().GetComponent<Cytosine> ().initialPosition.position.z);

			}
		}
	}
	protected override void onProcess(int familiesUpdateCount) {
		OnMouseDown ();
		OnMouseDrag ();
		OnMouseUp ();
	}
	/*// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		GameObject nucleotide = puzzle.First ();
		Debug.Log (Input.touchCount);
		if (nucleotide!= null && Input.GetMouseButtonDown(0) && !(nucleotide.GetComponent<Cytosine> ().locked)) {

			Touch touch = Input.GetTouch (0);
			Vector3 touchpos = Camera.main.ScreenToWorldPoint (nucleotide.transform.position);
			switch (touch.phase) {
			case TouchPhase.Began:
					// déterminer la position initiale
				nucleotide.GetComponent<Cytosine> ().initialPosition = nucleotide.transform.position;
				if (nucleotide.GetComponent<Collider> () == Physics2D.OverlapPoint(touchpos)) {
					nucleotide.GetComponent<Cytosine> ().deltaX = touchpos.x - nucleotide.transform.position.x;
					nucleotide.GetComponent<Cytosine> ().deltaY = touchpos.y - nucleotide.transform.position.y;
					nucleotide.GetComponent<Cytosine> ().deltaZ = touchpos.z - nucleotide.transform.position.z;
				}
				break;
			
			case TouchPhase.Moved:
				if (nucleotide.GetComponent<Collider> () == Physics2D.OverlapPoint (touchpos)) {
					nucleotide.transform.position = new Vector3 (touchpos.x - nucleotide.GetComponent<Cytosine> ().deltaX,
						touchpos.y - nucleotide.GetComponent<Cytosine> ().deltaY,
						touchpos.z - nucleotide.GetComponent<Cytosine> ().deltaZ);
				}
				break;
			case TouchPhase.Ended:
				if (Mathf.Abs (nucleotide.transform.position.x - nucleotide.GetComponent<Cytosine> ().place.position.x) <= 0.5f &&
				    Mathf.Abs (nucleotide.transform.position.y - nucleotide.GetComponent<Cytosine> ().place.position.y) <= 0.5f &&
				    Mathf.Abs (nucleotide.transform.position.z - nucleotide.GetComponent<Cytosine> ().place.position.z) <= 0.5f) {
					nucleotide.transform.position = new Vector3 (nucleotide.GetComponent<Cytosine> ().place.position.x, nucleotide.GetComponent<Cytosine> ().place.position.y, nucleotide.GetComponent<Cytosine> ().place.position.z);
					nucleotide.GetComponent<Cytosine> ().locked = true;
				} else {
					nucleotide.transform.position = new Vector3 (nucleotide.GetComponent<Cytosine> ().initialPosition.x, nucleotide.GetComponent<Cytosine> ().initialPosition.y, nucleotide.GetComponent<Cytosine> ().initialPosition.z);

				}
				break;
			}
		}	

	}*/

}