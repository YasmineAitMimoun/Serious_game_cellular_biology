using UnityEngine;
using FYFY;

[ExecuteInEditMode]
public class mitochondrioncellSystem_wrapper : MonoBehaviour
{
	private void Start()
	{
		this.hideFlags = HideFlags.HideInInspector; // Hide this component in Inspector
	}

	public void Réplication_ADN()
	{
		MainLoop.callAppropriateSystemMethod ("mitochondrioncellSystem", "Réplication_ADN", null);
	}

	public void dupliquer()
	{
		MainLoop.callAppropriateSystemMethod ("mitochondrioncellSystem", "dupliquer", null);
	}

	public void click()
	{
		MainLoop.callAppropriateSystemMethod ("mitochondrioncellSystem", "click", null);
	}

	public void generATP()
	{
		MainLoop.callAppropriateSystemMethod ("mitochondrioncellSystem", "generATP", null);
	}

}