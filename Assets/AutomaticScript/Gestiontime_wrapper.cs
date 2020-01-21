using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class Gestiontime_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void back()
	{
		MainLoop.callAppropriateSystemMethod ("Gestiontime", "back", null);
	}

}