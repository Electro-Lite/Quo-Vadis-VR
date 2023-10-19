using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_switch1 : MonoBehaviour
{
  public GameObject Light_source;
    public void Switch(){
      if (Light_source.activeSelf) {
        Light_source.SetActive(false);
      }else{
        Light_source.SetActive(true);
      }
    }
}
