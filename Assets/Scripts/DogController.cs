using UnityEngine;
using System.Collections;

public class DogController : PlayerController {
    
    public override void OnBeat() {
        if(!level.IsLeading()) {
            //state = level.CurrentDogState();
            timeAtNewState = Time.time;
        }
    }
}
