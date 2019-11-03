using UnityEngine;
using FYFY;

public class GolgiSystem : FSystem {
	private Family _Golgi = FamilyManager.getFamily(new AllOfComponents(typeof(Golgi)));

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
		foreach (GameObject go in _Golgi) {
			Golgi mito = go.GetComponent<Golgi> ();
			mito.transform.Rotate (new Vector3 (0f, 0f, -50f) * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.Q)) {
			
			GameObjectManager.loadScene("cell_city");

			//GameObjectManager.loadScene ("cell_city");
		} 
	}
}