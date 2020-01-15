using UnityEngine;
using FYFY;

public class Dechetsystem : FSystem {
	private Family _dechets = FamilyManager.getFamily(new AllOfComponents(typeof(score_dechets)));

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
		if (_dechets.First ().GetComponent<score_dechets>().first == true &&  score_dechets.score == 25) {
			 score_dechets.time += Time.deltaTime;
			_dechets.First ().GetComponent<score_dechets> ().ui.SetActive (true);
			if (score_dechets.time >= _dechets.First ().GetComponent<score_dechets> ().seuil)
				_dechets.First ().GetComponent<score_dechets> ().first = false;
		}else
			_dechets.First ().GetComponent<score_dechets> ().ui.SetActive (false);

	}
}