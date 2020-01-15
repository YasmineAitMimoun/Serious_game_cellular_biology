using UnityEngine;
using FYFY;
using System;
using FYFY_plugins.PointerManager;

public class RibosomeSystemecell : FSystem {
	private Family _ribosomepointer = FamilyManager.getFamily(new AllOfComponents(typeof(Ribosomecell),typeof(PointerOver)));
	private Family _sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));


	public void description(){
		Save_load.save (_sucre);
		save_load.switchh = false;
		GameObjectManager.loadScene ("ribosome");
	}
	public void Synthèse(){
		if (ATP.score > 0 && scoreARN.score >0) {
			score_dechets.score += 1;
			score_dechets.update = true;
			ATP.score = ATP.score - 1;
			score_proteine.score = score_proteine.score + 1;
			Debug.Log (score_proteine.score);
			score_proteine.update = true;
		}
		else
			if(ATP.score ==0)
				Debug.Log("Il n'y pas assez d'energie pour produire des protéines");
			else
				Debug.Log("Il faut produire l'ARN messager pour pouvoir faire la synthèse des protéines");
	}
	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		if (_ribosomepointer.First () != null) {
			_ribosomepointer.First ().GetComponent<Ribosomecell> ().ui.SetActive (true);

		} else {
			GameObject m= GameObject.Find ("ribmenu");
			if(m != null && m.activeSelf == true)
				m.SetActive (false);
		}
	}
}
