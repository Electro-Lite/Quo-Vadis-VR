using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_next_level1 : MonoBehaviour
{
  public string Next_level;
  public void Load_scene(){
    SceneManager.LoadScene(Next_level);
  }
  public void Reload_scene(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
