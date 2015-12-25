using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {
    
    public GameObject kick;
    public GameObject highhat;

    public void Kick() {
        kick.GetComponent<AudioSource>().Play();
    }

    public void HighHat() {
        highhat.GetComponent<AudioSource>().Play();
    }
}
