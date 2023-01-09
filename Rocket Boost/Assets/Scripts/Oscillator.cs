using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
  Vector3 startingPosition;
  [SerializeField] Vector3 movementVector;
  //Remove sliding capabilities later.
  [SerializeField] [Range(0, 1)] float movementFactor;
  [SerializeField] float period = 2f;
    
  void Start() {
    //transform.position gets the current x, y, z of the object it's attached to.
    startingPosition = transform.position;      
  }

    
  void Update() {
    //To make sure it isn't 0, but yeah.
    if (period <= Mathf.Epsilon) {
      return;
    }
    float cycles = Time.time / period;

    //There's a whole thing about Tau apparently, look into it!
    const float tau = Mathf.PI * 2;
    //This will give us a value between -1 and 1;
    float rawSinWave = Mathf.Sin(cycles * tau);

    //goes from 0 to 1 after dividing.
    movementFactor = (rawSinWave + 1f) / 2f;

    Vector3 offset = movementVector * movementFactor;
    transform.position = startingPosition + offset;
  }
}
