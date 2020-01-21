using UnityEngine;
using FYFY;
using System.IO;
using SimpleJSON;
using FYFY_plugins.PointerManager;

public class SugarFactorycell : FSystem {
	private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory_sugar)));


	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		
			if (save_load.switchh == true) {
				Save_load.read (factory_F);
				save_load.switchh = false;
			}
			
			GameObject sugarFactory = factory_F.First ();
			if (sugarFactory != null) {
				Factory_sugar factory = sugarFactory.GetComponent<Factory_sugar> ();
				if (factory != null) {
					factory.reloadProgress += Time.deltaTime;
					if (factory.reloadProgress >= factory.reloadTime) {
						GameObject go = Object.Instantiate<GameObject> (factory.prefab);
						GameObjectManager.bind (go);


						int i = (int)Random.Range (0, 4);
						//magouille
						Vector3 position = new Vector3 (0f, 0f, -50);
						if (i == 0)
							position = new Vector3 (Random.Range (0, 900), 600, -50);
						if (i == 1)
							position = new Vector3 (Random.Range (0, 900), 0, -50);
						if (i == 2)
							position = new Vector3 (0, Random.Range (0, 600), -50);
						if (i == 3)
							position = new Vector3 (900, Random.Range (0, 600), -50);
						


						go.transform.position = position;
						factory.reloadProgress = 0;
					}

				}
			}

	}

}
	
