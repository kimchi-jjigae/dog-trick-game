using UnityEngine;
using System.Collections;

public class DogController : PlayerController {
    /* from the PlayerController
    public LevelPlayer level;
    protected DogState state;
    protected DogSoundController soundController;
    Animator animator;
    protected float timeAtNewState;
    float stateDuration;
    */
    
    public MoveVerifier verifier;

    public void StateButtonPressed(DogState buttonState) {
        if(!level.IsLeading()) {
            timeAtNewState = Time.time;
            state = buttonState;
            if(state == DogState.Bark) {
                soundController.Bark();
            }

            verifier.MovePlayed(buttonState);
        }
    }
}
