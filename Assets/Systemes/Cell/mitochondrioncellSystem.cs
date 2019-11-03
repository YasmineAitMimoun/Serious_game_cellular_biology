using UnityEngine;
using FYFY;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mitochondrioncellSystem : FSystem {
	private Family mitochondie = FamilyManager.getFamily(new AllOfComponents(typeof(mitochondrioncell)));

	public mitochondrioncellSystem(){
		foreach (GameObject go in mitochondie) {
			go.GetComponent<mitochondrioncell>().uiObject.SetActive (false);
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
	public void click(){
		GameObjectManager.loadScene("Mitochondrion");
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in mitochondie) {
			mitochondrioncell mito = go.GetComponent<mitochondrioncell> ();

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.GetInstanceID () == go.transform.GetInstanceID ()) {
					mito.uiObject.SetActive (true);
				} else {
					if (hit.transform.GetInstanceID () == mito.uiObject.transform.GetInstanceID ()){
						mito.uiObject.SetActive (true);
		
					}
					else
					mito.uiObject.SetActive (false);
				}
			} 

			/*if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.GetInstanceID() == go.transform.GetInstanceID()) {
						SceneManager.LoadScene("Mitochondrion");
						//GameObjectManager.loadScene ("Mitochondrion");
					}
				}
			}*/

		}
	}
}