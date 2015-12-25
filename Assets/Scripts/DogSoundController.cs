using UnityEngine;
using System.Collections;

public class DogSoundController : MonoBehaviour {
    public AudioSource bark;

    public void Bark() {
        bark.Play();
    }
}
