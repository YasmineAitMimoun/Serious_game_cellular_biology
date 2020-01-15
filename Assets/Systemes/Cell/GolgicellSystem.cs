using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;

public class GolgicellSystem : FSystem {
	private Family _Golgi_pointer = FamilyManager.getFamily(new AllOfComponents(typeof(Golgicell),typeof(PointerOver)));
	private Family _sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));

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
		if (_Golgi_pointer.First () != null) {
			
			if (Input.GetMouseButtonDown (0)) {
				Save_load.save (_sucre);
				save_load.switchh = false;
				GameObjectManager.loadScene ("Golgi");

			}
		}

	}
}