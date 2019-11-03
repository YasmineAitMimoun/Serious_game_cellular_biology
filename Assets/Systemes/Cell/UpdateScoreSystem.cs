using UnityEngine;
using FYFY;
using UnityEngine.UI;

public class UpdateScoreSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _score_sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Score_sucre)));
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
			if (Score_sucre.update == true) {
				if (GameObject.Find ("scoresucre").GetComponent<Text> () == null)
					Debug.Log ("objet non trouvé");
				GameObject.Find ("scoresucre").GetComponent<Text> ().text = "Glucose: "+ Score_sucre.score ;
				Score_sucre.update = false;
			}

	}
}