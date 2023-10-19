using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
  public float Speed = 40;
  public GameObject Bullet;
  public Transform Barrel;
  public AudioSource Audio_source;
  public AudioClip Audio_clip;

  public void Fire()
  {
    GameObject Spawned_bullet = Instantiate(Bullet, Barrel.position, Barrel.rotation);
    Spawned_bullet.GetComponent<Rigidbody>().velocity = Speed * Barrel.forward;
    Audio_source.PlayOneShot(Audio_clip);
    Destroy(Spawned_bullet,2);
  }
}
