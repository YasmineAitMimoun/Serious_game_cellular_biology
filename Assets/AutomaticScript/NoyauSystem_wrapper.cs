using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class NoyauSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void cell_city()
	{
		MainLoop.callAppropriateSystemMethod ("NoyauSystem", "cell_city", null);
	}

}