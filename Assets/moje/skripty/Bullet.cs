using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
      if (other.gameObject.tag=="Player"){
        GameObject.Find("Script holder").SendMessage("Reload_scene");
      }
    }
}
