using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;
using System.Collections;

public class OxygeneSystem : FSystem {
	private Family _oxygene = FamilyManager.getFamily(new AllOfComponents(typeof(Oxygène)));
	//Pour traiter les intéractions 


	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	public OxygeneSystem(){
		foreach (GameObject go in _oxygene) {
			onGOEnter (go);
		}
		_oxygene.addEntryCallback (onGOEnter);


	}

	private void onGOEnter(GameObject go){
		GameObject cell = GameObject.Find ("PlasmaMembrane");
		Oxygène ox = go.GetComponent<Oxygène> ();

		Renderer rend = cell.GetComponent<Renderer> ();
		Vector3 target = new Vector3 (((rend.bounds.min.x + rend.bounds.max.x) / 2.0f)-30f+Random.value*10,rend.bounds.max.y-10f+Random.value*10, rend.bounds.min.z+Random.value*10);
		ox.target = target;
	}


	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {

		foreach (GameObject go in _oxygene) {
			Transform tr = go.GetComponent<Transform> ();
			Oxygène ox = go.GetComponent<Oxygène> ();
			if (ox.target.Equals (tr.position) == false && tr.name != "Oxygene") {
				tr.position = Vector3.MoveTowards (tr.position, ox.target, ox.speed * Time.deltaTime);
			} else {
				if (ox.target.Equals (tr.position)) {
					ox.arrive = true;
				}
			}
		}
		foreach (GameObject go in _oxygene){
			Oxygène ox = go.GetComponent<Oxygène> ();
			ox.pressed = false;
			if (Input.GetMouseButtonDown (0) ) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.GetInstanceID() == go.transform.GetInstanceID()) {
						ox.pressed = true;
					}
				}

			}
			if(ox.pressed == true)	{
				if (ox.arrive == false) {
					Debug.Log ("L'oxygène n'est pas sur la membrane");
				} else { 
					score_oxygene.score =score_oxygene.score + 1;
					score_oxygene.update = true;
					GameObjectManager.unbind (go);
					UnityEngine.Object.Destroy (go);
				}
			}
		}
	}
}