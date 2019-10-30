using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {
	public void play(){
		SceneManager.LoadScene("cell_city");
	}
	//public  Scene scene = (Scene)("Cell_City");
}