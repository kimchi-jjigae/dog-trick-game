using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class State {
    public GameObject stateBg;
    public int stateNumber;

    public State(GameObject g, int s) {
        stateBg = g;
        stateNumber = s;
    }

    public abstract int StateLogic();
}

public class State_1 : State {
    public State_1(GameObject g, int s) : base(g, s) {}

    override public int StateLogic() {
        Debug.Log("one!");
        if(Time.time > 5.0f) {
            stateNumber++;
        }
        return stateNumber;
    }
}

class State_2 : State {
    public State_2(GameObject g, int s) : base(g, s) {}

    override public int StateLogic() {
        Debug.Log("two!");
        if(Time.time > 10.0f) {
            stateNumber++;
        }
        return stateNumber;
    }
}

class State_3 : State {
    public State_3(GameObject g, int s) : base(g, s) {}

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
