using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {
    
    public LevelPlayer level;
    public GameObject kick;
    public GameObject highhat;

    public void Kick() {
        kick.GetComponent<AudioSource>().Play();
    }

    public void HighHat() {
        highhat.GetComponent<AudioSource>().Play();
    }

    public void OnBeat() {
        if(level.CurrentMoveNumber() < 3) {
            Kick();
        }
        else {
            HighHat();
        }
    }
}
