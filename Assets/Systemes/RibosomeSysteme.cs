using UnityEngine;
using FYFY;
using System;
public class RibosomeSysteme : FSystem {
	private Family _scoreSucre= FamilyManager.getFamily(new AllOfComponents(typeof(Score_sucre)));
	private Family _ribosome = FamilyManager.getFamily(new AllOfComponents(typeof(Ribosome)));
	private Family _ATP = FamilyManager.getFamily(new AllOfComponents(typeof(ATP)));
	private Family _Sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));


	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
		
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		//pour savoir si on a fait passé la souri sur l'object 
		//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		foreach (GameObject go in _ribosome) {
			Ribosome rib = go.GetComponent<Ribosome> ();
			try{
				GameObject sug = _Sucre.getAt (1);
				Sucre sugar = sug.GetComponent<Sucre> ();
				if (rib.depart == true) {
					foreach (GameObject atp in _ATP) {
						ATP atp1 = atp.GetComponent<ATP> ();
						//tester si on a assez d'energie 
						if (atp1.score >= 1) {
							// tester si il y a du sucre disponible
							if (sug != null) {
								if (sugar != null && sugar.arrive == true) {
									// Aller chercher le sucre 
									GameObject cell = GameObject.Find ("PlasmaMembrane");
									Renderer rend = cell.GetComponent<Renderer> ();
									Vector3 target = new Vector3 ((rend.bounds.min.x + rend.bounds.max.x) / 2.0f, rend.bounds.max.y - 25f, rend.bounds.min.z);

									rib.target = target;
									rib.transform.position = Vector3.MoveTowards (rib.transform.position, rib.target, 100f * Time.deltaTime);
									if (rib.transform.position.Equals (rib.target)) {
										rib.arrivesucre = true;
										atp1.score = atp1.score - 1;

										GameObjectManager.unbind (sug);
										UnityEngine.Object.Destroy (sug);
										_scoreSucre.First ().GetComponent<Score_sucre> ().score = _scoreSucre.First ().GetComponent<Score_sucre> ().score + 1;
										sug = _Sucre.getAt (1);
										Debug.Log (sugar.transform.name);
									}
								} 
							}
						} else {
							if (Input.GetMouseButtonDown (0)) {
								Debug.Log (" Erreur : Pas assez d'energie pour effectuer cette action");
							}
						}
					}
				} else {
					if (rib.arrivesucre == true) {
						Debug.Log ("bien arrivé au sucre");	
					}
				}

				if (Input.GetMouseButtonDown (0) && sugar.arrive == true) {
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						RaycastHit hit;
						if (Physics.Raycast (ray, out hit)) {
							if (hit.transform.name == go.transform.name) {
							rib.depart = true;
						}
					}
				}else {
					if (sugar.arrive == false && Input.GetMouseButtonDown (0)) {
						Debug.Log ("Il n'y a pas de sucre disponible");
					}
				}
			}catch(ArgumentOutOfRangeException ){
			}
		}
	}
}
