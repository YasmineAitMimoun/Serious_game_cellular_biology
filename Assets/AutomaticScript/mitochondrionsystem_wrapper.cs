using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class mitochondrionsystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void cell_city()
	{
		MainLoop.callAppropriateSystemMethod ("mitochondrionsystem", "cell_city", null);
	}

}