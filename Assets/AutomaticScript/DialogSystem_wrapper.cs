using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class DialogSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void nextSentence()
	{
		MainLoop.callAppropriateSystemMethod ("DialogSystem", "nextSentence", null);
	}

}