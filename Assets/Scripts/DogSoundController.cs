using UnityEngine;
using System.Collections;

public class DogSoundController : MonoBehaviour {
    public DogStateChanger dog;
    public AudioSource bark;

	void Start () {
	
	}
	
	void Update () {
	    if(dog.state == DogState.Bark) {
            bark.Play();
        }
	}
}
