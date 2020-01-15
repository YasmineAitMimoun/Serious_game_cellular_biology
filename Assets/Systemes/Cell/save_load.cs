using UnityEngine;
using FYFY;
//using System;
using System.IO;
using SimpleJSON;

public class Save_load : FSystem {
	
	public static void save(Family _sucre){
		JSONObject list_suc = new JSONObject ();
		JSONArray sucpos = new JSONArray ();
		JSONArray suctarget = new JSONArray ();
		int i = 0;
		foreach (GameObject go in  _sucre) {
			sucpos.Add (go.GetComponent<Transform>().position.x);
			sucpos.Add (go.GetComponent<Transform>().position.y);
			sucpos.Add (go.GetComponent<Transform>().position.z);
			sucpos.Add (go.GetComponent<Sucre> ().arrive);
			suctarget.Add (go.GetComponent<Sucre>().target.x);
			suctarget.Add (go.GetComponent<Sucre>().target.y);
			suctarget.Add (go.GetComponent<Sucre>().target.z);
			string id = i.ToString();
			list_suc.Add ("sucre"+id, sucpos);
			list_suc.Add ("target" + id, suctarget);

			sucpos = new JSONArray ();
			suctarget = new JSONArray ();
			i = i + 1;
			GameObjectManager.unbind (go);
		}
		list_suc.Add ("nbsucre",i);
		list_suc.Add ("show", Dialog.show);
		Debug.Log (Dialog.show);

		Debug.Log (list_suc.ToString());

		//save in computer:
		string path = Application.persistentDataPath+"/GlucoseSave.json";
		File.WriteAllText (path, list_suc.ToString ());

	}
	public static void read (Family factory_F) {
		string path = Application.persistentDataPath + "/GlucoseSave.json";
		string jsonString = File.ReadAllText (path);
		JSONObject list_suc = (JSONObject)JSON.Parse (jsonString);
		int nbsucre = list_suc ["nbsucre"];

		for (int i = 0; i < nbsucre; i++) {
			Vector3 pos = new Vector3 (
				list_suc ["sucre" + i.ToString ()].AsArray [0],
				list_suc ["sucre" + i.ToString ()].AsArray [1],
				list_suc ["sucre" + i.ToString ()].AsArray [2]);
			Vector3 target = new Vector3 (
				list_suc ["target" + i.ToString ()].AsArray [0],
				list_suc ["target" + i.ToString ()].AsArray [1],
				list_suc ["target" + i.ToString ()].AsArray [2]);

			bool arrive = list_suc ["sucre" + i.ToString ()].AsArray [3];



			GameObject sugarFactory = factory_F.First ();
			Factory_sugar factory = sugarFactory.GetComponent<Factory_sugar> ();

			GameObject go = Object.Instantiate<GameObject> (factory.prefab);
			GameObjectManager.bind (go);
			go.transform.position = pos;
			go.GetComponent<Sucre> ().arrive = arrive;
			go.GetComponent<Sucre> ().target = target;


		}
		bool show = list_suc ["show"];
		Dialog.show = show;
		Debug.Log (show);
		Debug.Log ("dizzzaaaan");
		scoreARN.update = true;
		score_proteine.update = true;
		score_dechets.update = true;
	}
	public static void restart(){
		string path = Application.persistentDataPath+"/GlucoseSave.json";
		File.WriteAllText (path, " ".ToString());
	}
}