using UnityEngine;
using FYFY;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Atp_system : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _ATP = FamilyManager.getFamily(new AllOfComponents(typeof(ATP)));

	protected override void onPause(int currentFrame) {
		
	}


	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		if (ATP.first == false && ATP.score == 1 && Score_sucre.score == 0) {
			_ATP.First ().GetComponent<ATP> ().ui.SetActive (true);
			ATP.time += Time.deltaTime;
			if (ATP.time >= _ATP.First ().GetComponent<ATP> ().seuiltime)
				ATP.first = true;

		} else {
			_ATP.First ().GetComponent<ATP> ().ui.SetActive (false);
		}
		GameObject.Find ("ATP").GetComponent<Text> ().text = "ATP: " + ATP.score;
	
	}
}