using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class GolgiSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void cell_city()
	{
		MainLoop.callAppropriateSystemMethod ("GolgiSystem", "cell_city", null);
	}

}