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

    [Header("Interaction Options")]
    public PlayInteraction interactionPlayer;

    void Awake() {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoadScene(GameObject scene, int entryPoint) {
        currentScene.SetActive(false);
        scene.SetActive(true);
        scene.GetComponent<Scene>().SetScene(entryPoint);
    }

    public void LoadDialogue(TreeDialogue dialogue) {
        interactionPlayer.gameObject.SetActive(true);
        
        movementBloqued = true;
        interactionMode = true;

        interactionPlayer.currentDialogue = dialogue;
        interactionPlayer.StartDialogue();
    }

    public void ExitDialogue() {
        movementBloqued = false;
        interactionMode = false;
    }
}
