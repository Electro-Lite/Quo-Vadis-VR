using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_destroy1 : MonoBehaviour
{
    public static Dont_destroy1 instance;
    void Awake(){
      if (instance !=null) {
        Destroy(gameObject);
      }else{
        instance=this;
        DontDestroyOnLoad(this.gameObject);
      }
    }
}
