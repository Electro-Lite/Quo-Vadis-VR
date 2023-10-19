using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnInputAnimation : MonoBehaviour
{
    public InputActionProperty Pinch_animation_action;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      float Triger_value = Pinch_animation_action.action.ReadValue<float>();
      Debug.Log(Triger_value);
    }
}
