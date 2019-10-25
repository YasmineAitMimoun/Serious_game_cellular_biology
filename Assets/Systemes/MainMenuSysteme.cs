using UnityEngine;
using FYFY;
using UnityEngine.SceneManagement;

public class MainMenuSysteme : FSystem {

	private Family _menu = FamilyManager.getFamily(new AllOfComponents(typeof(MainMenu)));
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.

	public void play(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
		
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		

	}
}