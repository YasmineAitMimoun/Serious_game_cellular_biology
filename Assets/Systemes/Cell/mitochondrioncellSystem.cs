using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FYFY_plugins.Monitoring;
using System;
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
		



	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
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
			ATP.score = ATP.score + 2;
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