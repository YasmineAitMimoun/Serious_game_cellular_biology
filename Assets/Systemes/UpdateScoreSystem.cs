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
		foreach (GameObject go in _score_sucre) {
			Score_sucre score = go.GetComponent<Score_sucre> ();
			if (score.update == true) {
				if (GameObject.Find ("scoresucre").GetComponent<Text> () == null)
					Debug.Log ("objet non trouvé");
				GameObject.Find ("scoresucre").GetComponent<Text> ().text = "Sugar: "+ score.score ;
				score.update = false;
			}
		}
	}
}