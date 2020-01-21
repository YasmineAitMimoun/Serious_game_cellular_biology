using UnityEngine;
using FYFY;
using FYFY_plugins.PointerManager;

public class Lysosomecellsystem : FSystem {
	private Family _Lysosome_pointer = FamilyManager.getFamily(new AllOfComponents(typeof(Lysosome),typeof(PointerOver)));
	private Family _sucre = FamilyManager.getFamily(new AllOfComponents(typeof(Sucre)));

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
		score_dechets.update = true;
		Déchet.time = 5f;
		GameObjectManager.loadScene ("cell_city");
	}

	public void description(){
		Save_load.save (_sucre);
		save_load.switchh = false;
		GameObjectManager.loadScene ("Lysosome");
	}

	public void Digestion(){
		if(ATP.score >=10){
			if (score_dechets.score > 10) {
				ATP.score += 10;
				Déchet.seen = true;
				Save_load.save (_sucre);
				save_load.switchh = false;
				GameObjectManager.loadScene ("Dechets");
			}
		}
	}
	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {

		if (_Lysosome_pointer.First () != null) {
			//On teste si la souris est sur un objet de type mitochondrie
			_Lysosome_pointer.First ().GetComponent<Lysosome> ().menu.SetActive (true);

		} else {
			GameObject menu = GameObject.Find ("lys");
			if(menu != null && menu.activeSelf == true)
				menu.SetActive (false);
		}
		/*if (_Lysosome_pointer.First () != null) {

			if (Input.GetMouseButtonDown (0)) {
				Save_load.save (_sucre);
				save_load.switchh = false;
				GameObjectManager.loadScene ("Lysosome");

			}
		}*/
	}
}