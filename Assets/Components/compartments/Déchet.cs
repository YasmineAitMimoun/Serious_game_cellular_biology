using UnityEngine;
using TMPro;

public class Déchet : MonoBehaviour {
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
	public static int nbdechets = 0;
	public static float time = 5f;
	public static bool seen = false;
	public GameObject prefab;
	public GameObject duplic;
}