using UnityEngine;
using System.Collections.Generic;

public class Ribosome : MonoBehaviour {
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
	public Vector3 target;
	public List<Sucre> sucre_list;
	public bool depart = false;
	public bool arrivesucre = false;
	public bool arrivegolgi = false;
}