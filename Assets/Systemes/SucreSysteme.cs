using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class SucreSysteme : FSystem {
	
	private Family _sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));
	//Pour traiter les intéractions 
	private Family _triggered = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered3D)));


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
			if (rt.target.Equals (tr.position) == false) {
				tr.position = Vector3.MoveTowards (tr.position,rt.target, rt.speed * Time.deltaTime);
			}
		}
		GameObject background = GameObject.Find ("background");
		foreach (GameObject go in _triggered) {
			Triggered3D t3d = go.GetComponent<Triggered3D> ();

			foreach (GameObject target in t3d.Targets) {
				if (target.Equals (background) == false) {
					
					//Transform tr = target.GetComponent<Transform> ();
					//Vector3 tar = new Vector3 ((Random.value) * 800, (Random.value) * 800);

					//tr.position = Vector3.MoveTowards (tr.position, tar, 100f * Time.deltaTime);
					//Debug.Log ("eurler angles "+tr.eulerAngles);
				}
			}
		}

	}
}