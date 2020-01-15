using UnityEngine;
using FYFY;

public class membranesystemcomp : FSystem {
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
		if (Input.GetKey (KeyCode.Q)) {
			save_load.switchh = true;
			GameObjectManager.loadScene ("cell_city");
		} 
	}

}