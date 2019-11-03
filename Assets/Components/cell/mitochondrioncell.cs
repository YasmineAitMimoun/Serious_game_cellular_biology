using UnityEngine;
using FYFY;
using UnityEngine.UI;

public class mitochondrioncell: MonoBehaviour {
	public GameObject uiObject;
	public void descrip(){
		GameObjectManager.loadScene("Mitochondrion");
	}
	public void generATP(){
		if (Score_sucre.score >= 1 && score_oxygene.score >= 5) {
			Score_sucre.score = Score_sucre.score - 1;
			score_oxygene.score = score_oxygene.score - 5;
			ATP.score = ATP.score + 2;
			Score_sucre.update = true;
			score_oxygene.update = true;
		}
		if (Score_sucre.score < 1)
			Debug.Log ("Vous n'avez pas assez de glucose pour effectuer cette action");
		if (score_oxygene.score < 5)
			Debug.Log ("Vous n'avez pas assez d'oxygène pour effectuer cette action");
			
	}
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
}