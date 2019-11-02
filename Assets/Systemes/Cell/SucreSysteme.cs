using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;
using System.Collections;

public class SucreSysteme : FSystem {
	
	private Family _scoreSucre= FamilyManager.getFamily(new AllOfComponents(typeof(Score_sucre)));
	private Family _sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));
	//Pour traiter les intéractions 
	private Family _ATP = FamilyManager.getFamily(new AllOfComponents(typeof(ATP)));


	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	public SucreSysteme(){
		foreach (GameObject sucre in _sucre) {
			onGOEnter (sucre);
		}
		_sucre.addEntryCallback (onGOEnter);


	}

	private void onGOEnter(GameObject sucre){
		GameObject cell = GameObject.Find ("PlasmaMembrane");
		Sucre rt = sucre.GetComponent<Sucre> ();

		Renderer rend = cell.GetComponent<Renderer> ();
		Vector3 target = new Vector3 ((rend.bounds.min.x + rend.bounds.max.x) / 2.0f+Random.value*10,rend.bounds.max.y+Random.value*10, rend.bounds.min.z+Random.value*10);
		rt.target = target;
	}


	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		
		foreach (GameObject sucre in _sucre) {
			Transform tr = sucre.GetComponent<Transform> ();
			Sucre rt = sucre.GetComponent<Sucre> ();
			if (rt.target.Equals (tr.position) == false && tr.name != "Sucre") {
				tr.position = Vector3.MoveTowards (tr.position, rt.target, rt.speed * Time.deltaTime);
			} else {
				if (rt.target.Equals (tr.position)) {
					rt.arrive = true;
				}
			}
		}
		foreach (GameObject sucre in _sucre){
			Sucre rt = sucre.GetComponent<Sucre> ();
			rt.pressed = false;
			if (Input.GetMouseButtonDown (0) ) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.GetInstanceID() == sucre.transform.GetInstanceID()) {
						rt.pressed = true;
					}
				}

			}
			GameObject atp = _ATP.getAt (1);
			if(rt.pressed == true)	{
				ATP atp1 = atp.GetComponent<ATP> ();
				if (atp1.score < 1) {
					Debug.Log ("Pas assez d'énergie pour effectuer cette action "); 
				} else {
					if (rt.arrive == false) {
						Debug.Log ("Le sucre n'est pas sur la membrane");
					} else { 
						_scoreSucre.First ().GetComponent<Score_sucre> ().score = _scoreSucre.First ().GetComponent<Score_sucre> ().score + 1;
						_scoreSucre.First ().GetComponent<Score_sucre> ().update = true;
						atp1.score = atp1.score - 1;
						Debug.Log (sucre.name);
						GameObjectManager.unbind (sucre);
						UnityEngine.Object.Destroy (sucre);
					}
				}
			}
		}


	}
}