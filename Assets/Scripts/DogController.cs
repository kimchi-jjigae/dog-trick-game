using UnityEngine;
using System.Collections;

public enum DogState {
    Idle = 0,
    Sit,
    Bark
}

public class DogController : MonoBehaviour {

    public LevelPlayer level;
    public DogState state;
    DogSoundController soundController;
    Animator animator;
    float timeAtNewState;
    float stateDuration;

	void Start () {
	    state = DogState.Idle;
        animator = GetComponent<Animator>();
        soundController = GetComponent<DogSoundController>();
        stateDuration = 0.4f; // seconds
        timeAtNewState = 0.0f;
	}
	
	void Update() {
        // is it time to idle again?! //
        animator.SetInteger("DogState", (int)state);

        if(state != DogState.Idle) {
            if(stateTimeOver()) {
                state = DogState.Idle;
            }
        }
	}

    public void OnBeat() {
        if(!level.IsLeading()) {
            //state = level.CurrentDogState();
            timeAtNewState = Time.time;
        }
    }

    bool stateTimeOver() {
        return Time.time - timeAtNewState > stateDuration;
    }
}
