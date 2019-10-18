using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            SceneManager.LoadScene(0);
        }
    }
}
