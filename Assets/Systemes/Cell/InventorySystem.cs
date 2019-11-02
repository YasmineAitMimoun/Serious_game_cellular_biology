using UnityEngine;
using FYFY;

public class InventorySystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family Inventory = FamilyManager.getFamily(new AllOfComponents(typeof(Inventory)));

	protected override void onPause(int currentFrame) {		
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject inv in Inventory) {
			Inventory inventory = inv.GetComponent<Inventory> ();
			if (Input.GetKey (KeyCode.I) && Time.time-inventory.pressed_time > 0.5f) {
				inventory.activation = !inventory.activation;
				GameObject Invent = GameObject.Find ("Inventaire");
				Invent.GetComponent<Canvas> ().enabled = inventory.activation;
				inventory.pressed_time = Time.time;
			} 
		}
	}
}