using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FYFY_plugins.Monitoring;
using System.IO;
using SimpleJSON;


public class mitochondrioncellSystem : FSystem {
	private Family mitochondie = FamilyManager.getFamily(new AllOfComponents(typeof(mitochondrioncell),typeof(PointerOver)));
	private Family _sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));

	public mitochondrioncellSystem(){
		foreach (GameObject go in mitochondie) {
			go.GetComponent<mitochondrioncell>().uiObject.SetActive (false);
		}
	}
		
	public void Réplication_ADN(){
		
			
		if (ATP.score >= 10) {
			if (niveau.score > 1) {
				bool done = false;
				foreach (GameObject go in mitochondie) {
					if (go.GetComponent<mitochondrioncell> ().done == false) {
						if (done == false) {
							GameObject cyto = GameObject.Find ("Cytoplasm");
							GameObject cito = GameObject.Find ("cito");
							GameObject plas = GameObject.Find ("PlasmaMembrane");
							if (cyto != null)
								cyto.transform.localScale *= 1.02f;
							if (cito != null)
								cito.transform.localScale *= 1.02f;
							if (plas != null)
								plas.transform.localScale *= 1.02f;
							done = true;
						}
						go.transform.localScale *= 1.2f;
						
						GameObject menu = GameObject.Find ("Menumito");
						menu.transform.localScale *= 0.8f;
						go.GetComponent<mitochondrioncell> ().done = true;
						ATP.score -= 10;
						Score_ADN.replicationmito = true;
				
					}
				}
			} else
				Debug.Log ("Cette fonctionalité n'est pas disponible");

		}else{
			Debug.Log ("Tu n'as pas assez d'énergie !!!");
		}
	}
	public void dupliquer(){
		if (ATP.score >= 10) { 
			if (niveau.score > 1) {
				foreach (GameObject go in mitochondie) {
					if (go.GetComponent<mitochondrioncell> ().done == true) {
						GameObject newgo = Object.Instantiate<GameObject> (go);
						newgo.transform.localScale *= 0.8f;
						go.transform.localScale *= 0.8f;
						newgo.transform.position = new Vector3 (newgo.transform.position.x + 5f, newgo.transform.position.y + 20f, newgo.transform.position.z + 10f);
						go.transform.position = new Vector3 (go.transform.position.x - 5f, go.transform.position.y - 20f, go.transform.position.z - 10f);
						ATP.score -= 10;
					} else {
						Debug.Log ("Il faut d'abord répliquer l'ADN de la mitochondrie avant de pouvoir la dupliquer");
					}
				}
			} else
				Debug.Log ("Cette fonctionnalité n'est pas encore disponible");
			
		} else
			Debug.Log ("Tu n'as pas assez d'énergie !!!");
	}


	public void click(){
		Save_load.save (_sucre);
		save_load.switchh = false;
		GameObjectManager.loadScene("Mitochondrion");

	}

	public void generATP(){
		if (Score_sucre.score >= 1 && score_oxygene.score >= 6) {
			Score_sucre.score = Score_sucre.score - 1;
			score_dechets.score += 1;
			score_dechets.update = true;
			score_oxygene.score = score_oxygene.score - 6;
			ATP.score = ATP.score + 30;
			Score_sucre.update = true;
			score_oxygene.update = true;
		}
		if (Score_sucre.score < 1)
			Debug.Log ("Vous n'avez pas assez de glucose pour effectuer cette action");
		if (score_oxygene.score < 5)
			Debug.Log ("Vous n'avez pas assez d'oxygène pour effectuer cette action");

	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {


	
		//mitochondrioncell mito = go.GetComponent<mitochondrioncell> ();
		if (mitochondie.First () != null) {
			//On teste si la souris est sur un objet de type mitochondrie
			mitochondie.First ().GetComponent<mitochondrioncell> ().uiObject.SetActive (true);

		} else {
			GameObject menu = GameObject.Find ("Menumito");
			if(menu != null && menu.activeSelf == true)
				menu.SetActive (false);
		}
			
					
	}
	
	
	
}