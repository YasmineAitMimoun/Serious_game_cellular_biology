using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class Lysosomecellsystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void cell_city()
	{
		MainLoop.callAppropriateSystemMethod ("Lysosomecellsystem", "cell_city", null);
	}

	public void description()
	{
		MainLoop.callAppropriateSystemMethod ("Lysosomecellsystem", "description", null);
	}

	public void Digestion()
	{
		MainLoop.callAppropriateSystemMethod ("Lysosomecellsystem", "Digestion", null);
	}

}