using UnityEngine;
using FYFY;

public class Factory_sugar : MonoBehaviour {
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
	public float reloadTime = 120f;
	public float reloadProgress = 0f;

	public GameObject prefab;
}