using UnityEngine;
using System.Collections;

public enum DogState {
    Idle = 0,
    Sit,
    Bark
}

public class DogStateChanger : MonoBehaviour {

    public DogState state;
    Animator animator;
    public int stateCounterStart;
    int stateCounter;

	void Start () {
	    state = DogState.Idle;
        animator = GetComponent<Animator>();
        stateCounter = stateCounterStart;
	}
	
	void FixedUpdate () {
        animator.SetInteger("DogState", (int)state);

        if(state != DogState.Idle) {
            stateCounter--;
            if(stateCounter == 0) {
                state = DogState.Idle;
                stateCounter = stateCounterStart;
            }
        }
	}
}
