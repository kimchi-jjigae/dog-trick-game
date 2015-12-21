using UnityEngine;
using System.Collections;

public class DogStateButton : MonoBehaviour {
    public DogStateChanger stateChanger;

    public enum Blapp {
        Idle = 0,
        Sit,
        Bark
    }
    public Blapp targetState;

    public void ChangeState() {
        stateChanger.state = (DogState)targetState;
    }
}
