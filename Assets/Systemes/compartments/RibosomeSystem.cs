using UnityEngine;
using FYFY;

public class RibosomeSystem : FSystem {
	private Family _ribosome = FamilyManager.getFamily(new AllOfComponents(typeof(ribosome)));

	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	public void cell_city(){
		save_load.switchh = true;
		GameObjectManager.loadScene ("cell_city");
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _ribosome) {
			ribosome mito = go.GetComponent<ribosome> ();
			mito.transform.Rotate (new Vector3 (0f, -50f, 0f) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.Q)) {
			GameObjectManager.loadScene ("cell_city");
		} 
	}
}