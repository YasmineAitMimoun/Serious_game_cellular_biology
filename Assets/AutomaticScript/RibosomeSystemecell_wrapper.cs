using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class RibosomeSystemecell_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void description()
	{
		MainLoop.callAppropriateSystemMethod ("RibosomeSystemecell", "description", null);
	}

	public void Synthèse()
	{
		MainLoop.callAppropriateSystemMethod ("RibosomeSystemecell", "Synthèse", null);
	}

}