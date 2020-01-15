using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class membranesystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void membrane()
	{
		MainLoop.callAppropriateSystemMethod ("membranesystem", "membrane", null);
	}

}