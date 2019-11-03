using UnityEngine;
using FYFY;

public class NoyauSystem : FSystem {
	private Family _noyau = FamilyManager.getFamily(new AllOfComponents(typeof(Noyau)));

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
		foreach (GameObject go in _noyau) {
			Noyau mito = go.GetComponent<Noyau> ();
			mito.transform.Rotate (new Vector3 (50f, 0f, 0f) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.Q)) {
			GameObjectManager.loadScene ("cell_city");
		} 
	}
}