using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {
	public TextMeshProUGUI textDisplay;
	public string [] sentences;
	public float typingSpeed = 0.02f;
	public GameObject continuebutton;
	public GameObject arrowcell;
	public GameObject arrowinventory;
	public GameObject arrowatp;
	public GameObject arroworganites;
	public GameObject ui;
	public static bool show = false;
	[HideInInspector]
	public int index;
}