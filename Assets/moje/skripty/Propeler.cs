using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeler : MonoBehaviour
{
    public Transform Barrel;
    public CharacterController Player_body;
    public float Speed= 1f;
    public ParticleSystem Particles_object;
    private GameObject Vr_rig;
    public float Power_max=1f;
    private float Power;
    private bool Is_on=false;
    public Transform Ball;
    private bool Grounded_bool;
    public Continuous_movement Continuous_movement_script;

    private void Awake(){
      Vr_rig=GameObject.Find("XRRig");
      Power=Power_max;
    }

    public void Propel_on(){
      Is_on=true;
      Particles_object.Play();
    }
    public void Propel_off(){
      Is_on=false;
      Particles_object.Pause();
    }
    private void FixedUpdate()
    {
      Grounded_bool=Continuous_movement_script.Is_grounded;
      if (Is_on & (Power>0)) {
        Vr_rig.SendMessage("Stop_fall");
        Power=Power-0.01f;
        Player_body.Move(Barrel.forward * (-1) * Time.fixedDeltaTime * Speed * Power);
        Ball.localScale= new Vector3(Power,Power,Power);
        if (Power<=0) {
          Propel_off();
        }
      }else{
        if ((Power<Power_max) & Grounded_bool) {
          Power+=0.01f;
          Ball.localScale= new Vector3(Power,Power,Power);
        }
      }
    }
}
