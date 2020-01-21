using UnityEngine;
using FYFY;
using UnityEngine.UI;

public class updatescore : FSystem {
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
		if (score_oxygene.update == true) {
			if (GameObject.Find ("ScoreOxygene").GetComponent<Text> () == null)
				Debug.Log ("objet non trouvé");
			GameObject.Find ("ScoreOxygene").GetComponent<Text> ().text = "Oxygene: "+ score_oxygene.score ;
			score_oxygene.update = false;
		}
		if (Score_sucre.update == true) {
			if (GameObject.Find ("scoresucre").GetComponent<Text> () == null)
				Debug.Log ("objet non trouvé");
			GameObject.Find ("scoresucre").GetComponent<Text> ().text = "Glucose: "+ Score_sucre.score ;
			Score_sucre.update = false;
		}
		if (scoreARN.update == true) {
			if (GameObject.Find ("scoreARN").GetComponent<Text> () == null)
				Debug.Log ("objet non trouvé");
			GameObject.Find ("scoreARN").GetComponent<Text> ().text = "ARN Messager: "+ scoreARN.score ;
			scoreARN.update = false;
		}

		if (score_proteine.update == true) {
			if (GameObject.Find ("scorepro").GetComponent<Text> () == null)
				Debug.Log ("objet non trouvé");
			GameObject.Find ("scorepro").GetComponent<Text> ().text = "Protéines: "+ score_proteine.score ;
			score_proteine.update = false;
		}
		if (score_dechets.update == true) {
			if (GameObject.Find ("scoredech").GetComponent<Text> () == null)
				Debug.Log ("objet non trouvé");
			GameObject.Find ("scoredech").GetComponent<Text> ().text = "Déchets: "+ score_dechets.score ;
			score_dechets.update = false;
		}
		if (niveau.update == true) {
			if (GameObject.Find ("niveau").GetComponent<Text> () == null)
				Debug.Log ("objet non trouvé");
			if (niveau.score == 1) {
				GameObject.Find ("niveau").GetComponent<Text> ().text = "Niveau: phase G1";
			}
			if (niveau.score == 2) {
				GameObject.Find ("niveau").GetComponent<Text> ().text = "Niveau: phases S et G2";
			}
			niveau.update = false;
		}
	
		if (Score_ADN.update == true) {
			if (GameObject.Find ("scoreadn").GetComponent<Text> () == null)
				Debug.Log ("objet non trouvé");
			GameObject.Find ("scoreadn").GetComponent<Text> ().text = "ADN: "+ Score_ADN.score ;
		}
	}
}