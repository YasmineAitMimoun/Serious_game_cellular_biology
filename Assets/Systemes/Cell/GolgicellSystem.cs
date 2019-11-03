using UnityEngine;
using FYFY;

public class GolgicellSystem : FSystem {
	private Family _Golgi = FamilyManager.getFamily(new AllOfComponents(typeof(Golgicell)));

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
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.GetInstanceID() == go.transform.GetInstanceID()) {
						GameObjectManager.loadScene ("Golgi");
					}
				}
			}
		}
	}
}