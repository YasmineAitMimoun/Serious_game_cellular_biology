using UnityEngine;
using FYFY;

public class SugarFactorycell : FSystem {
	private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory_sugar)));
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		GameObject sugarFactory = factory_F.First ();
		if (sugarFactory != null) {
			Factory_sugar factory = sugarFactory.GetComponent<Factory_sugar> ();
			if (factory != null) {
				factory.reloadProgress += Time.deltaTime;
				if (factory.reloadProgress >= factory.reloadTime) {
					GameObject go = Object.Instantiate<GameObject> (factory.prefab);
					GameObjectManager.bind (go);
					go.transform.position = new Vector3 ((Random.value * 250) + 500, (Random.value * 100) + 450);
					Debug.Log (go.transform.position);
					factory.reloadProgress = 0;
				}

			}
		}
	}
}