using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class GameOver_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void menu()
	{
		MainLoop.callAppropriateSystemMethod ("GameOver", "menu", null);
	}

}