using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;
using TMPro;


public class FactoryDechets : FSystem {
	private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Déchet)));
	private Family factory_F_pointer = FamilyManager.getFamily(new AllOfComponents(typeof(Déchet),typeof(PointerOver)));

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
		Déchet.time -= Time.deltaTime;
		GameObject time = GameObject.Find ("Time");
		int t = (int)(Déchet.time);
		time.GetComponent<TextMeshProUGUI>().text = "Time : " + t.ToString();

		foreach (GameObject go in factory_F) {
			while (Déchet.nbdechets < score_dechets.score) {
				GameObject newgo = Object.Instantiate<GameObject> (go.GetComponent<Déchet> ().prefab);
				GameObjectManager.bind (newgo);
				Vector3 position = new Vector3 (Random.Range (-70, 70), Random.Range (-40, 40), 84);
				Quaternion rotation = new Quaternion ();
				rotation.x = go.transform.rotation.x;
				rotation.y = go.transform.rotation.y;
				rotation.z = Random.Range (-100, 100);
				newgo.transform.position = position;
				if (go.name != "Bacterial") {
					newgo.transform.rotation = rotation;
				}
				Déchet.nbdechets = Déchet.nbdechets + 1;
			}
		}
		foreach (GameObject go in factory_F_pointer) {
			if (go != null) {
				if (Input.GetMouseButtonDown (0)) {
					GameObjectManager.unbind (go);
					UnityEngine.Object.Destroy (go);
					score_dechets.score -= 1;
				}
			}
		}

	
	}
					
	}


	


