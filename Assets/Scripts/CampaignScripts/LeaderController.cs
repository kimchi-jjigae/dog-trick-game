using UnityEngine;
using System.Collections;

public class LeaderController : PlayerController {

    public override void OnTimerBeat() {
        if(level.IsLeading()) {
            state = level.CurrentDogState();
            timeAtNewState = Time.time;
            if(state == DogState.Bark) {
                soundController.Bark();
            }
        }
    }
}
