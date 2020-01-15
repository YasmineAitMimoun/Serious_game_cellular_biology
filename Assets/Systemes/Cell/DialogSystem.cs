using UnityEngine;
using FYFY;
using System.Collections;
using TMPro;
using FYFY_plugins;

public class DialogSystem : FSystem {
	private Family dialog = FamilyManager.getFamily(new AllOfComponents(typeof(Dialog)));



	public DialogSystem()
	{
		if (Application.isPlaying == true) {
			dialog.First ().GetComponent<Dialog> ().textDisplay.text = "";
			MainLoop.instance.StartCoroutine (coroutinedialog ());
		}
	}

	private IEnumerator coroutinedialog()
	{
		GameObject dia = dialog.First ();
		if (dia.GetComponent<Dialog> ().index < dia.GetComponent<Dialog> ().sentences.Length) {
			foreach (char letter in  dia.GetComponent<Dialog> ().sentences[dia.GetComponent<Dialog> ().index].ToCharArray()) {
				dia.GetComponent<Dialog> ().textDisplay.text += letter;
				yield return new WaitForSeconds (dia.GetComponent<Dialog> ().typingSpeed);
			}
		}
	}
	public void nextSentence()
	{
		
		GameObject dia = dialog.First ();
		dia.GetComponent<Dialog> ().continuebutton.SetActive (false);
		if (dia.GetComponent<Dialog> ().index < dia.GetComponent<Dialog> ().sentences.Length ) {
			dia.GetComponent<Dialog> ().index = dia.GetComponent<Dialog> ().index + 1;
			dia.GetComponent<Dialog> ().textDisplay.text = "";
			MainLoop.instance.StartCoroutine (coroutinedialog ());
		} else{
			dia.GetComponent<Dialog> ().textDisplay.text = "";
			dia.GetComponent<Dialog> ().continuebutton.SetActive (false);
		}

	}
	protected override void onProcess(int familiesUpdateCount) {
		if (Dialog.show == true) {
			dialog.First ().GetComponent<Dialog> ().ui.SetActive (false);
			foreach (FSystem sys in FSystemManager.lateUpdateSystems()) {
				sys.Pause = false;
			}
		} else {
			GameObject dia = dialog.First ();
			if (dia.GetComponent<Dialog> ().index < dia.GetComponent<Dialog> ().sentences.Length) {
				foreach (FSystem sys in FSystemManager.lateUpdateSystems()) {
					sys.Pause = true;

				}
		
			

			
				
				if (dia.GetComponent<Dialog> ().textDisplay.text == dia.GetComponent<Dialog> ().sentences [dia.GetComponent<Dialog> ().index]) {
					dia.GetComponent<Dialog> ().continuebutton.SetActive (true);
				}

				if (dia.GetComponent<Dialog> ().index == 1)
					dialog.First ().GetComponent<Dialog> ().arrowcell.SetActive (true);
				else
					dialog.First ().GetComponent<Dialog> ().arrowcell.SetActive (false);

				if (dia.GetComponent<Dialog> ().index == 2)
					dialog.First ().GetComponent<Dialog> ().arrowinventory.SetActive (true);
				else
					dialog.First ().GetComponent<Dialog> ().arrowinventory.SetActive (false);

				if (dia.GetComponent<Dialog> ().index == 3)
					dialog.First ().GetComponent<Dialog> ().arrowatp.SetActive (true);
				else
					dialog.First ().GetComponent<Dialog> ().arrowatp.SetActive (false);

				if (dia.GetComponent<Dialog> ().index == 4) {
					dialog.First ().GetComponent<Dialog> ().arroworganites.SetActive (true);

				}
				if (dia.GetComponent<Dialog> ().index == 5) {
					Dialog.show = true;
					dialog.First ().GetComponent<Dialog> ().arroworganites.SetActive (false);
				}
				if (dia.GetComponent<Dialog> ().index == 6) {
					Dialog.show = true;
				}
			} else {
				dialog.First ().GetComponent<Dialog> ().arroworganites.SetActive (false);
				foreach (FSystem sys in FSystemManager.lateUpdateSystems()) {
					sys.Pause = false;
				}
			}
		}

	}

}