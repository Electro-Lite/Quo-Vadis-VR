using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield1 : MonoBehaviour
{
  public GameObject Shield_gloss;
  public GameObject New_gloss;
  public Transform Spawn_point;
  private GameObject Spawned_shield;
  private bool Shield_on = true;

  public void Use_shield_power(){
    if (Shield_on) {
      Gloss_drop();
    }else{
      Gloss_take();
    }
  }

  void Gloss_drop(){
    Shield_on = false;
    Spawned_shield = Instantiate(New_gloss, Spawn_point.position, Spawn_point.rotation);
    Shield_gloss.SetActive(false);
  }
  void Gloss_take(){
    Shield_on = true;
    Destroy(Spawned_shield);
    Shield_gloss.SetActive(true);
  }
}
