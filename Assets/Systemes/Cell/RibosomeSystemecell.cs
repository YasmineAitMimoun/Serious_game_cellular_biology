using UnityEngine;
using FYFY;
using System;
public class RibosomeSystemecell : FSystem {
	private Family _ribosome = FamilyManager.getFamily(new AllOfComponents(typeof(Ribosomecell)));


	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _ribosome) {
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.GetInstanceID() == go.transform.GetInstanceID()) {
						GameObjectManager.loadScene ("ribosome");
					}
				}
			}
		}
	}
}
