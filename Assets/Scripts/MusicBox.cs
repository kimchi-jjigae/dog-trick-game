using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {
    
    GameObject kick;
	// Use this for initialization
	void Start () {
	    kick = gameObject.transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Kick() {
        kick.GetComponent<AudioSource>().Play();
    }
}
