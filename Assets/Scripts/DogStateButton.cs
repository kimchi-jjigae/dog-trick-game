using UnityEngine;
using System.Collections;

public class DogStateButton : MonoBehaviour {
    public DogController dog;

    // a hack to make it appear in the script
    // as a drop-down menu, forgive me.
    public enum DogStateEnum {
        Idle = 0,
        Sit,
        Bark
    }
    public DogStateEnum targetState;

    public void ChangeState() {
        dog.state = (DogState)targetState;
    }
}
