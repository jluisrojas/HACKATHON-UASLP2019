using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public GameObject player;
    public int ninosAyudar = 4;

    public bool movementBloqued;
    public bool interactionMode;

    [Header("Scene Options")]
    public GameObject currentScene;

    [Header("Interaction Options")]
    public PlayInteraction interactionPlayer;
    public Fade fade;
    public Text score;
    public Text ayudado;
    public int totalAyudar = 4;

    void Awake() {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        score.text = "score: " + player.GetComponent<Player>().score;
        ayudado.text = "Ayudado " + player.GetComponent<Player>().ninosAyudados + "/"+totalAyudar;
    }

    public void LoadScene(GameObject scene, int entryPoint) {
        //currentScene.SetActive(false);
        StartCoroutine(LoadSceneCourutine(scene, entryPoint));
        /* 
        fade.StartFade();
        currentScene.GetComponent<Scene>().camera.enabled = false;
        currentScene.GetComponent<Scene>().camera.gameObject.SetActive(false);
        scene.SetActive(true);
        scene.GetComponent<Scene>().SetScene(entryPoint);
        currentScene = scene;*/
    }

    IEnumerator LoadSceneCourutine(GameObject scene, int entryPoint) {
        fade.StartFade();
        yield return new WaitForSeconds(0.5f);
        currentScene.GetComponent<Scene>().camera.enabled = false;
        currentScene.GetComponent<Scene>().camera.gameObject.SetActive(false);
        scene.SetActive(true);
        scene.GetComponent<Scene>().SetScene(entryPoint);
        currentScene = scene;
    }

    public void LoadDialogue(TreeDialogue dialogue) {
        StartCoroutine(LoadDialogueCourutine(dialogue));
        /* 
        interactionPlayer.gameObject.SetActive(true);

        movementBloqued = true;
        interactionMode = true;

        interactionPlayer.currentDialogue = dialogue;
        interactionPlayer.StartDialogue();
        */
    }

    IEnumerator LoadDialogueCourutine(TreeDialogue dialogue) {
        fade.StartFade();
        yield return new WaitForSeconds(0.5f);

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
