using UnityEngine;
using FYFY;

public class Gestiontime : FSystem {
	private Family button = FamilyManager.getFamily(new AllOfComponents(typeof(Button)));

	public Gestiontime(){
		GameObject menu = GameObject.Find ("Back");
		if (menu != null && menu.activeSelf == true)
			menu.SetActive (false);
		Déchet.time = 5f;
		Déchet.nbdechets = 0;
	}

	public void back(){
		save_load.switchh = true;
		GameObjectManager.loadScene("cell_city");
	}


	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		if (Déchet.time <= 0) {
			button.First ().GetComponent<Button>().go.SetActive (true);
		
			foreach (FSystem sys in FSystemManager.lateUpdateSystems()) {
				sys.Pause = true;
			}

		} else {
			GameObject menu = GameObject.Find ("Back");
			if (menu != null && menu.activeSelf == true)
				menu.SetActive (false);
		}
	}
}