using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour, ITimerOnBeat {

    public ParticleSystem timerParticles;

    void Start() {
        Timer timer = GameObject.Find("MainController").GetComponent<Timer>();
        timer.AddSubscriber(this);
    }

    public void OnBeat() {
        timerParticles.Emit(30);
    }
}
