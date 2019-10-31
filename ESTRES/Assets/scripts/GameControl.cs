using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public GameObject player;
    public int ninosAyudar = 4;

    public bool movementBloqued;
    public bool interactionMode;

    [Header("Scene Options")]
    public GameObject currentScene;
    public SoundManager sound;

    [Header("Interaction Options")]
    public PlayInteraction interactionPlayer;
    public Fade fade;
    public Text score;
    public Text ayudado;
    public Text debug;
    public int totalAyudar = 4;

    void Awake() {
        instance = this;
        //player = GameObject.FindGameObjectWithTag("Player");
        //sound.PlaySound(0);
    }

    public void PlaySteps() {
        int s = currentScene.GetComponent<Scene>().clip;
        sound.PlayLoop(s);
    }

    public void StopSteps() {
        sound.StopLoop();
    }

    void Update() {
        score.text = "score: " + player.GetComponent<Player>().score;
        ayudado.text = "Ayudado " + player.GetComponent<Player>().ninosAyudados + "/"+totalAyudar;

        if(player.GetComponent<Player>().ninosAyudados == totalAyudar) {
            PlayerPrefs.SetInt("Score", player.GetComponent<Player>().score);
            SceneManager.LoadScene(2);
        }
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
        if(player.GetComponent<Player>().student != null)
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
        movementBloqued = true;
        interactionMode = true;

        fade.StartFade();
        yield return new WaitForSeconds(0.5f);

        interactionPlayer.gameObject.SetActive(true);


        interactionPlayer.currentDialogue = dialogue;
        interactionPlayer.StartDialogue();
    }

    public void ExitDialogue() {
        movementBloqued = false;
        interactionMode = false;
    }
}
