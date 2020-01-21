using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class GameOver_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void continuer()
	{
		MainLoop.callAppropriateSystemMethod ("GameOver", "continuer", null);
	}

	public void menu()
	{
		MainLoop.callAppropriateSystemMethod ("GameOver", "menu", null);
	}

	public void duplicationcellule()
	{
		MainLoop.callAppropriateSystemMethod ("GameOver", "duplicationcellule", null);
	}

}