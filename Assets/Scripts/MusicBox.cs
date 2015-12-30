using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour, ITimerOnBeat {
    
    public LevelPlayer level;
    public GameObject kick;
    public GameObject highhat;
    public GameObject lose;

    void Start() {
        Timer timer = GameObject.Find("MainController").GetComponent<Timer>();
        timer.AddSubscriber(this);
    }

    public void Kick() {
        kick.GetComponent<AudioSource>().Play();
    }

    public void HighHat() {
        highhat.GetComponent<AudioSource>().Play();
    }

    public void Lose() {
        lose.GetComponent<AudioSource>().Play();
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
