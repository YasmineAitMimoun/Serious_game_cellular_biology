using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;

public class Noyaucellsystem : FSystem {
	private Family _Noyau_pointer = FamilyManager.getFamily(new AllOfComponents(typeof(Noyau),typeof(PointerOver)));
	private Family _sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));


	public void description(){
		Save_load.save (_sucre);
		save_load.switchh = false;
		GameObjectManager.loadScene ("Noyau");
	}

	public void transcription(){
		if (ATP.score < 0)
			Debug.Log ("Pas assez d'energie pour effectuer cette action");
		else {
			Save_load.save (_sucre);
			save_load.switchh = false;
			if (transcriptioncomp.first == true) {
				score_dechets.score += 1;
				score_dechets.update = true;
				ATP.score = ATP.score - 1;
				transcriptioncomp.first = false;
				GameObjectManager.loadScene ("Transcription de l'ADN");
			} else
				Debug.Log ("ADN deja transcrit");
		}
	}
	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		if (_Noyau_pointer.First () != null) {
			_Noyau_pointer.First ().GetComponent<Noyau> ().ui.SetActive (true);

		} else {
			GameObject m= GameObject.Find ("Menu");
			if(m != null && m.activeSelf == true)
				m.SetActive (false);
	     }
	}
}