using UnityEngine;
using FYFY;
using UnityEngine.UI;

public class Atp_system : FSystem {
	private Family _atp = FamilyManager.getFamily(new AllOfComponents(typeof(ATP)));
	int n = 1;
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
		foreach (GameObject atp in _atp) {
			ATP Atp = atp.GetComponent<ATP> ();
			if (n == 1) {
				Atp.score = Atp.score + 1;
				n = n +1;
			}
			GameObject.Find ("ATP").GetComponent<Text> ().text = "ATP: "+ Atp.score ;

			//GUI.color = Color.red;
			//GUI.Label (new Rect (10, 5, 300, 5), "ATP : " +Atp.cpt );
			//Atp.OnGUI();
		}
	}
}