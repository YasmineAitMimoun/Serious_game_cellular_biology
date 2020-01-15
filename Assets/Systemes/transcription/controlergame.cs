using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlergame : MonoBehaviour {
	public GameObject wintext;
	public GameObject button;

	// Use this for initialization
	void Start () {
		wintext.SetActive (false);
		button.SetActive (false);
	}

	public void back(){
		save_load.switchh = true;
		scoreARN.score = scoreARN.score + 1;
		scoreARN.update = true;
		SceneManager.LoadScene ("cell_city");

	}
	// Update is called once per frame
	void Update () {
		if (Cytosinesys.locked && Uracilesys.locked && Guaninesys.locked && Guaninesys2.locked && Adeninesys.locked){
			wintext.SetActive (true);
		button.SetActive (true);
	}
	}
}
