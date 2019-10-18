using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Image bg;
    public Sprite A;
    public Sprite B;
    public AudioClip audio;
    public float duration;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            SceneManager.LoadScene(1);
        }
    }
}
