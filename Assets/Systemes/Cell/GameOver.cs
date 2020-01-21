using UnityEngine;
using FYFY;
using System.IO;
using SimpleJSON;

public class GameOver : FSystem {
	private Family _over = FamilyManager.getFamily(new AllOfComponents(typeof(over)));

	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	public void continuer(){
		niveau.score += 1;
		niveau.update = true;
		GameObject menu = GameObject.Find ("level");
		menu.SetActive (false);

		foreach (FSystem sys in FSystemManager.lateUpdateSystems()) {
			sys.Pause = false;
		}
	}


	public void menu(){
		Save_load.restart ();
		transcriptioncomp.first = true;
		scoreARN.score = 0;
		ATP.score = 30;
		score_oxygene.score = 0;
		Score_sucre.score = 0;
		score_proteine.score = 0;
		score_dechets.score = 0;
		GameObjectManager.loadScene ("cell_city");
	}

	public void duplicationcellule(){
		if (Score_ADN.update == true) {
			GameObjectManager.loadScene ("Finalscene");
		}
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		if (Score_sucre.score == 0 && ATP.score == 0) {
			
			foreach(GameObject go in _over)
				go.GetComponent<over>().text.SetActive (true);
				foreach (FSystem sys in FSystemManager.lateUpdateSystems()) 
					sys.Pause = true;
		}
		else
			foreach(GameObject go in _over)
				go.GetComponent<over>().text.SetActive (false);

		if (score_dechets.score == 20) {
			_over.First().GetComponent<over>().text.SetActive (true);
			foreach (FSystem sys in FSystemManager.lateUpdateSystems()) 
				sys.Pause = true;
		}

		if (score_proteine.score > 0 && Déchet.seen == true ) {
			foreach(GameObject go in _over){
				go.GetComponent<over>().level.SetActive (true);
									
			}
		
		}
		if (Score_ADN.update == true) {
			foreach (GameObject go in _over) {
				go.GetComponent<over> ().duplic.SetActive (true);
			}
		}

	}

}