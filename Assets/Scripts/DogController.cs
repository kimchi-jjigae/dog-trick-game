using UnityEngine;
using System.Collections;

public class DogController : PlayerController {
    
    public override void OnBeat() {
    }

    public void StateButtonPressed(DogState buttonState) {
        if(!level.IsLeading()) {
            timeAtNewState = Time.time;
            state = buttonState;
            if(state == DogState.Bark) {
                soundController.Bark();
            }
        }
    }
}
