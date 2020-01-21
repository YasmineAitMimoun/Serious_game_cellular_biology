using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class Noyaucellsystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void description()
	{
		MainLoop.callAppropriateSystemMethod ("Noyaucellsystem", "description", null);
	}

	public void Replication()
	{
		MainLoop.callAppropriateSystemMethod ("Noyaucellsystem", "Replication", null);
	}

	public void transcription()
	{
		MainLoop.callAppropriateSystemMethod ("Noyaucellsystem", "transcription", null);
	}

}