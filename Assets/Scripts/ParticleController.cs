using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    public ParticleSystem timerParticles;

    public void OnBeat() {
        timerParticles.Emit(30);
    }
}
