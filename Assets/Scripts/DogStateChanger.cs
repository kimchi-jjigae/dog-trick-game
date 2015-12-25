using UnityEngine;
using System.Collections;

public enum DogState {
    Idle = 0,
    Sit,
    Bark
}

public class DogStateChanger : MonoBehaviour {

    public LevelPlayer level;
    public DogState state;
    public bool leader;
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
        // get level stuff //
        //if(leader == level.IsLeading()) {
        if(leader && level.IsLeading()) {
            state = level.CurrentDogState();
            timeAtNewState = Time.time;
            if(state == DogState.Bark) {
                soundController.Bark();
            }
        }
    }

    bool stateTimeOver() {
        return Time.time - timeAtNewState > stateDuration;
    }
}
