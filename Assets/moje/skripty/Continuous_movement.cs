using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine.SceneManagement;

public class Continuous_movement : MonoBehaviour
{
    public LayerMask Ground_layer;
    public float Gravity= -9.81f;
    public float Speed=1;
    public XRNode Input_source;
    public float Additional_height = 0.2f;
    public bool Is_grounded=false;
    private XROrigin Vr_rig;
    private Vector2 Input_axis;
    private CharacterController Character;
    private float Falling_speed=0;

    // Start is called before the first frame update
    void Start()
    {
      Character = GetComponent<CharacterController>();
      Vr_rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
      InputDevice Device = InputDevices.GetDeviceAtXRNode(Input_source);
      Device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Input_axis);
    }
    private void FixedUpdate()
    {
        Capsule_follow_headset();
        Quaternion Head_yaw = Quaternion.Euler(0, Vr_rig.Camera.transform.eulerAngles.y, 0);
        Vector3 Direction = Head_yaw * new Vector3(Input_axis.x,0, Input_axis.y);

        Character.Move(Direction * Time.fixedDeltaTime * Speed);
        if (this.GetComponent<Transform>().position.y<(-20)) {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //Gravity
        Is_grounded = Check_if_grounded();
        if(Is_grounded){Falling_speed= 0;}
        else
        {
          Falling_speed+= Gravity * Time.fixedDeltaTime;
          Character.Move(Vector3.up * Falling_speed * Time.fixedDeltaTime);
        }
    }
    void Capsule_follow_headset()
    {
      Character.height = Vr_rig.CameraInOriginSpaceHeight + Additional_height;
      Vector3 Capsule_center = transform.InverseTransformPoint(Vr_rig.Camera.transform.position);
      Character.center = new Vector3(Capsule_center.x , Character.height/2 + Character.skinWidth, Capsule_center.z);
    }
    bool Check_if_grounded()
    {
      Vector3 Ray_start = transform.TransformPoint(Character.center);
      float Ray_length = Character.center.y + 0.01f;
      bool Has_hit = Physics.SphereCast(Ray_start, Character.radius, Vector3.down, out RaycastHit HitInfo, Ray_length, Ground_layer);
      return Has_hit;
    }
    private void Stop_fall(){
      Falling_speed=0;
    }
}
