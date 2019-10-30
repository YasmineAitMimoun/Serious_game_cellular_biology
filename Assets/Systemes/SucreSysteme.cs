using UnityEngine;
using FYFY;

public class SucreSysteme : FSystem {
	private float speed = 100f;
	private Family _sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));
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
		Transform tr = sucre.GetComponent<Transform> ();
		Sucre rt = sucre.GetComponent<Sucre> ();

		Renderer rend = cell.GetComponent<Renderer> ();
		Vector3 target = new Vector3 ((rend.bounds.min.x + rend.bounds.max.x) / 2.0f,rend.bounds.max.y, rend.bounds.min.z);
		rt.target = target;
	}


	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		
		foreach (GameObject sucre in _sucre) {
			Transform tr = sucre.GetComponent<Transform> ();
			Sucre rt = sucre.GetComponent<Sucre> ();
			if (rt.target.Equals (tr.position) == false) {
				tr.position = Vector3.MoveTowards (tr.position,rt.target, speed * Time.deltaTime);
			}

		}
	}
}