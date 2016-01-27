using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class State {
    public GameObject stateBg;
    private int stateNumber;

    State(GameObject g, int s) {
        stateBg = g;
        stateNumber = s;
    }

    abstract public int StateLogic();
}

class State_1 : State {
    override public int StateLogic() {
        Debug.Log("one!");
        return stateNumber;
    }
}

class State_2 : State {
    override public int StateLogic() {
        Debug.Log("two!");
        return stateNumber;
    }
}

class State_3 : State {
    override public int StateLogic() {
        Debug.Log("three!");
        return stateNumber;
    }
}

public class IntroStates : MonoBehaviour {

    public int firstState;
    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    int state;
    List<State> states;

	void Start() {
	    state = firstState;
        states = new List<State>();

        states.Add(new State_1(bg1, 0));
        states.Add(new State_2(bg2, 1));
        states.Add(new State_3(bg3, 2));
	}
	
	void Update() {
        state = states[state].StateLogic();
	}
}
