using UnityEngine;
using FYFY;
using UnityEngine.SceneManagement;

public class mitochondrionsystem : FSystem {
	private Family _mitochondrion = FamilyManager.getFamily(new AllOfComponents(typeof(mitochondrion)));
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
		foreach (GameObject go in _mitochondrion) {
			mitochondrion mito = go.GetComponent<mitochondrion> ();
			mito.transform.Rotate (new Vector3 (0f, 0f, 50f) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.Q)) {
			SceneManager.LoadScene("cell_city");

			//GameObjectManager.loadScene ("cell_city");
		} 
	}
}