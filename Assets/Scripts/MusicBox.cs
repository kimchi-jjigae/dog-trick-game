using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {
    
    GameObject kick;
    GameObject highhat;

	void Start () {
	    kick = gameObject.transform.GetChild(0).gameObject;
	    highhat = gameObject.transform.GetChild(1).gameObject;
	}
	
	void Update () {
	
	}

    public void Kick() {
        kick.GetComponent<AudioSource>().Play();
    }

    public void HighHat() {
        highhat.GetComponent<AudioSource>().Play();
    }
}
