using System.Collections;
using UnityEngine;

public class AudioCntrl : MonoBehaviour {

	private bool play;

	void Start () {
		//not destroy to reload new scene
		DontDestroyOnLoad (transform.gameObject);
		StartCoroutine (horn());
	}

	//on or off the music
	void Update () {
		//if our music is on, but not plays, then we are playing it
		if (PlayerPrefs.GetString ("Music") != "no" && !play) {
			GetComponent <AudioSource> ().Play ();
			play = true;
			//if our music is off, but it plays, then we are pausing it
		}
		else if (PlayerPrefs.GetString ("Music") == "no" && play) {
			GetComponent <AudioSource> ().Pause ();
			play = false;
		}
	}

	IEnumerator horn () {
		//play sound of horn allways whith some range
		while (true) {
			yield return new WaitForSeconds (Random.Range (12f, 22f));
			if (PlayerPrefs.GetString ("Music") != "no")
				transform.GetChild(0).GetComponent <AudioSource> ().Play ();
		}
	}

}
