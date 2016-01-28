using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class State {
    public GameObject stateBg;
    public GameObject panel;
    public String text1;
    public String text2;
    public int stateNumber;
    protected GameObject textObject1;
    protected GameObject textObject2;
    protected GameObject pawImage;
    protected float timeActivated;
    protected float timeText1On;
    protected float timeText1Off;
    protected float timeText2On;
    protected float timeText2Off;
    protected float timeOff;
    protected int stringCharacters;
    protected int fixedFrameCounter;

    public State(GameObject bg, GameObject p, int s) {
        stateBg = bg;
        panel = p;
        stateNumber = s;
        text1 = "";
        text2 = "";

        textObject1 = panel.transform.GetChild(0).gameObject;
        textObject2 = panel.transform.GetChild(1).gameObject;
        pawImage    = panel.transform.GetChild(2).gameObject;

        timeText1On  = 2.0f;
        timeText1Off = timeText1On  + 7.0f;
        timeText2On  = timeText1Off + 3.0f;
        timeText2Off = timeText2On  + 7.0f;
        timeOff      = timeText2Off + 3.0f;

        stringCharacters = 0;
        fixedFrameCounter = 0;
    }

    public int StateUpdate() {
        Initialise();

        StateLogic();
        
        float timeElapsed = Time.time - timeActivated;

        // in reverse order //
        if(timeElapsed > timeOff) {
            Denitialise();
        }
        else if(timeElapsed > timeText2Off) {
            textOff(textObject2);
        }
        else if(timeElapsed > timeText2On) {
            textOn(text2, textObject2);
        }
        else if(timeElapsed > timeText1Off) {
            textOff(textObject1);
        }
        else if(timeElapsed > timeText1On) {
            textOn(text1, textObject1);
        }

        return stateNumber;
    }

    protected void textOn(String text, GameObject textObject) {
        if(text != "" && !panel.activeSelf) {
            panel.SetActive(true);
            textObject.SetActive(true);
            textObject.GetComponent<Text>().text = text;
        }
        if(fixedFrameCounter % 3 == 0) {
            textObject.GetComponent<Text>().text = text.Substring(0, stringCharacters);
            stringCharacters++;
            stringCharacters = Math.Min(stringCharacters, text.Length);
        }
        fixedFrameCounter++;
    }

    protected void textOff(GameObject textObject) {
        panel.SetActive(false);
        textObject.SetActive(false);
        stringCharacters = 0;
    }

    protected void Initialise() {
        if(!stateBg.activeSelf) {
            stateBg.SetActive(true);
            timeActivated = Time.time;
        }
    }

    protected abstract void StateLogic();

    protected void Denitialise() {
        stateNumber++;
        stateBg.SetActive(false);
    }

    public void SetText(int index, String text) {
        if(index == 1) {
            text1 = text;
        }
        else {
            text2 = text;
        }
    }
}

public class State_1 : State {
    public State_1(GameObject bg, GameObject p, int s) : base(bg, p, s) {}

    override protected void StateLogic() {
        stateBg.transform.localScale += new Vector3(-0.005f, -0.005f, 0.0f);
        if(stateBg.transform.localScale.x < 1.0f) {
            stateBg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}

class State_2 : State {
    public State_2(GameObject bg, GameObject p, int s) : base(bg, p, s) {}

    override protected void StateLogic() {
        stateBg.transform.position += new Vector3(-0.02f, 0.0f, 0.0f);
        if(stateBg.transform.position.x < -10.0f) {
            stateBg.transform.localScale += new Vector3(-10.0f, 0.0f, 0.0f);
        }
    }
}

class State_3 : State {
    public State_3(GameObject bg, GameObject p, int s) : base(bg, p, s) {}

    override protected void StateLogic() {
        stateBg.transform.localScale += new Vector3(0.005f, 0.005f, 0.0f);
        if(stateBg.transform.localScale.x > 5.0f) {
            stateBg.transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
        }
    }
}

public class IntroStates : MonoBehaviour {

    public int firstState;
    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    public GameObject panel;
    int state;
    List<State> states;

	void Start() {
	    state = firstState;
        states = new List<State>();

        State_1 state1 = new State_1(bg1, panel, 0);
        State_2 state2 = new State_2(bg2, panel, 1);
        State_3 state3 = new State_3(bg3, panel, 2);

        state1.SetText(2, "ONE DAY, SHERRY AND DJANGO WENT TO THE LOCAL DOG SHOW.");

        state2.SetText(1, "THERE WERE SO MANY DOGS THERE, OF ALL SHAPES AND SIZES...");
        state2.SetText(2, "...COMPETING IN ALL SORTS OF COMPETITIONS.");

        state3.SetText(1, "ONE OF THE PRIZES IN THE CORNER CAUGHT SHERRY'S EYE.");
        state3.SetText(2, "\"DJANGO!\", SHERRY EXCLAIMED, \"YOU'VE GOTTA WIN THOSE FOR ME, BOY\"");

        states.Add(state1);
        states.Add(state2);
        states.Add(state3);
	}
	
	void FixedUpdate() {
        state = states[state].StateUpdate();
	}
}
