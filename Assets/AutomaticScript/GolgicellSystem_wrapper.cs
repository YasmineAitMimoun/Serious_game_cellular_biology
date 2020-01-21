using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class GolgicellSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void description()
	{
		MainLoop.callAppropriateSystemMethod ("GolgicellSystem", "description", null);
	}

	public void produire_lysosome()
	{
		MainLoop.callAppropriateSystemMethod ("GolgicellSystem", "produire_lysosome", null);
	}

}