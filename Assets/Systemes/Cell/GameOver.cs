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


	public void menu(){
		Save_load.restart ();
		transcriptioncomp.first = true;
		scoreARN.score = 0;
		ATP.score = 2;
		score_oxygene.score = 0;
		Score_sucre.score = 0;
		score_proteine.score = 0;
		score_dechets.score = 0;
		GameObjectManager.loadScene ("cell_city");
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

		if (score_dechets.score == 30) {
			_over.First().GetComponent<over>().text.SetActive (true);
			foreach (FSystem sys in FSystemManager.lateUpdateSystems()) 
				sys.Pause = true;
		}
	}
}