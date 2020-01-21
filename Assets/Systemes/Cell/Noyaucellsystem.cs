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
	public void Replication(){
		if (niveau.score > 1) {
			if (ATP.score >= 10 && Score_ADN.prodlysosome == true && Score_ADN.replicationmito == true) {
				Score_ADN.score += 1;
				Score_ADN.update = true;	
				ATP.score -= 10;
			} else {
				Debug.Log ("Vous n'avez pas assez d'energie !");
			}
		} else
			Debug.Log ("Votre niveau est insuffisant pour effectuer cette action ");
	}
	public void transcription(){
		if (ATP.score < 10)
			Debug.Log ("Pas assez d'énergie pour effectuer cette action");
		else {
			
			if (transcriptioncomp.first == true) {
				Save_load.save (_sucre);
				save_load.switchh = false;
				score_dechets.score += 1;
				score_dechets.update = true;
				ATP.score = ATP.score - 10;
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