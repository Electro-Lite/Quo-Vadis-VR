using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform Player_transform;
    public Transform Turret_head;
    public GameObject Projectile;
    public float Range;
    public float Bullet_speed;
    public float Next_fire, Fire_rate;
    public float Bullet_time;
    private Transform This_transform;
    private float dist;
    private AudioSource Shoot_sound;


    void Start(){
      This_transform = this.gameObject.transform;
      Shoot_sound = this.gameObject.GetComponent<AudioSource>();
    }

    void Update(){
      dist = Vector3.Distance(Player_transform.position, This_transform.position);
      if (dist<=Range){
        Turret_head.LookAt(Player_transform);
        if (Time.time >= Next_fire) {
          Next_fire= Time.time + 1f / Fire_rate;
          shoot();
        }
      }
    }
    private void shoot(){
      GameObject Spawned_bullet = Instantiate(Projectile, Turret_head.position, Turret_head.rotation);
      Shoot_sound.Play();
      Spawned_bullet.GetComponent<Rigidbody>().velocity = Bullet_speed * Turret_head.forward;
      Destroy(Spawned_bullet,Bullet_time);
    }


}
