using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;

public class GolgicellSystem : FSystem {
	private Family _Golgi_pointer = FamilyManager.getFamily(new AllOfComponents(typeof(Golgicell),typeof(PointerOver)));
	private Family _sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));
	public Vector3 target = new Vector3 (Random.Range(280,400),Random.Range(180,230), -111f);
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.



	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}
	public void description(){
		Save_load.save (_sucre);
		save_load.switchh = false;
		GameObjectManager.loadScene ("Golgi");
	}

	public void produire_lysosome(){
		if (ATP.score >= 10) {
			if (score_proteine.score > 4) {
				if (niveau.score > 1) {
					target = new Vector3 (Random.Range (280, 400), Random.Range (180, 230), -111f);
					GameObject newgo = Object.Instantiate<GameObject> (_Golgi_pointer.First ().GetComponent<Golgicell> ().prefablysosome);
					GameObjectManager.bind (newgo);
					newgo.transform.position = _Golgi_pointer.First ().transform.position;

					Golgicell.lysosome = newgo;
					ATP.score -= 10;
					Score_ADN.prodlysosome = true;
					score_proteine.score -= 5;
				}
			} else
				Debug.Log ("Tu n'as pas assez de protéines pour produire un lysosome");
		} else
			Debug.Log ("Tu n'as pas assez d'énergie!!!");

	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		if (Golgicell.lysosome != null) {
			//Vector3 target = new Vector3 (Random.Range(900,350),Random.Range(180,220), -111f);
			Golgicell.lysosome.transform.position = Vector3.MoveTowards (Golgicell.lysosome.transform.position, target, 20f * Time.deltaTime);

		}
		if (_Golgi_pointer.First () != null) {
			//On teste si la souris est sur un objet de type mitochondrie
			_Golgi_pointer.First ().GetComponent<Golgicell> ().uiObject.SetActive (true);

		} else {
			GameObject menu = GameObject.Find ("menugolgi");
			if(menu != null && menu.activeSelf == true)
				menu.SetActive (false);
		}

	}
}