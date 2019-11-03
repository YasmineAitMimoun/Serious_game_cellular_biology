using UnityEngine;
using FYFY;
using UnityEngine.UI;

public class UpdateOxygeneSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _score_oxygene= FamilyManager.getFamily(new AllOfComponents(typeof(score_oxygene)));
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {

			if (score_oxygene.update == true) {
				if (GameObject.Find ("ScoreOxygene").GetComponent<Text> () == null)
					Debug.Log ("objet non trouvé");
				GameObject.Find ("ScoreOxygene").GetComponent<Text> ().text = "Oxygene: "+ score_oxygene.score ;
				score_oxygene.update = false;
			}

	}
}