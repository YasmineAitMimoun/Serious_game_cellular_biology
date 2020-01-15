using UnityEngine;
using FYFY;
using UnityEngine.SceneManagement;

public class transcriptionfyfy : FSystem {
	private Family _transcription2 = FamilyManager.getFamily(new AllOfComponents(typeof(transcription)));

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
		bool locked = true;
		foreach (GameObject go in _transcription2) {
			if (go.GetComponent<transcription> ().locked == false)
				locked = false;
			else {
				Debug.Log ("iiiiiiizzzzzzzzzzzzzzzzaaaaaaaaaaaaaaaaan");
				Debug.Log (go.GetComponent<transcription> ().locked+"first");
				Debug.Log (locked+"second");
			}
		}
		if (locked) {
			if (Input.GetKey (KeyCode.Q)) {
				save_load.switchh = true;
				SceneManager.LoadScene ("cell_city");
			}
		} else
			Debug.Log ("tu dois faire la transcription de l'ADN pour quitter");
	}
}