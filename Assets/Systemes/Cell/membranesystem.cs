using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;
using System;

public class membranesystem : FSystem {
	private Family _membranepointer = FamilyManager.getFamily(new AllOfComponents(typeof(membrane),typeof(PointerOver)));
	private Family _sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));

	private Family _membrane = FamilyManager.getFamily(new AllOfComponents(typeof(membrane)));
	public membranesystem(){
		foreach (GameObject go in _membrane) {
			go.GetComponent<membrane> ().ui.SetActive (false);
		}
	}

	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}
	public void membrane(){
		Save_load.save (_sucre);
		save_load.switchh = false;
		GameObjectManager.loadScene("membraneplasmique");
	}
	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		if (_membranepointer.First () != null) {
			_membranepointer.First ().GetComponent<membrane> ().ui.SetActive (true);
		} else {
			GameObject memplas = GameObject.Find ("memb");
			if(memplas != null)
				memplas.SetActive (false);
		}

	}
}