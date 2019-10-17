using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public GameObject player;

    public bool movementBloqued;
    public bool interactionMode;

    [Header("Scene Options")]
    public GameObject currentScene;

    void Awake() {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoadScene(GameObject scene, int entryPoint) {
        currentScene.SetActive(false);
        scene.SetActive(true);
        scene.GetComponent<Scene>().SetScene(entryPoint);
    }
}
