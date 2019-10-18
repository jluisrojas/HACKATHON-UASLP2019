using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Student : MonoBehaviour
{
    public float interactionArea = 1.0f;
    public bool playerInArea;
    public bool playerEntered;

    // Reference to the player
    public GameObject player;
    public TreeDialogue studentDialogue;

    public Sprite[] gauges;
    public int level;
    public int startLevel;

    public GameObject dialogueButton;


    // Start is called before the first frame update
    void Start()
    {
        level = startLevel;
        playerInArea = false;
        playerEntered = false;
        player = GameControl.instance.player;
        StartCoroutine(UpdateStatus());
    }

    // Update is called once per frame
    void Update()
    {
        //if(!GameControl.instance.interactionMode && playerInArea && Input.GetKeyDown(KeyCode.Space)) {
            //GameControl.instance.LoadDialogue(studentDialogue);
        //}
    }

    // Se utiliza un courutina para no forzar tanto al CPU en el update
    // el update lo hace cada 0.5 segundos
    IEnumerator UpdateStatus() {
        while(true) {

            if(!GameControl.instance.interactionMode) {
                if(Vector2.Distance(this.transform.position, player.transform.position) <= interactionArea) {
                    player.GetComponent<Player>().student = this;
                    playerInArea = true;
                    if(!playerEntered && player.GetComponent<AIPath>().velocity == Vector3.zero) {
                        if(!GameControl.instance.movementBloqued) {
                            //GameControl.instance.LoadDialogue(studentDialogue);
                            playerEntered = true;
                            dialogueButton.SetActive(true);
                            player.GetComponent<Player>().student = this;
                        }
                    }
                } else {
                    dialogueButton.SetActive(false);
                    if(player.GetComponent<Player>().student == this)
                        player.GetComponent<Player>().student = null;
                    playerInArea = false;
                    playerEntered = false;
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void LoadDialogue() {
        if(playerInArea && playerEntered) {
            GameControl.instance.movementBloqued = true;
            GameControl.instance.LoadDialogue(studentDialogue);
        }
    }

    void OnDrawGizmos() {
        if(!playerInArea)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;

        EntityUtils.DrawRadiusGizmos(this.transform.position, interactionArea);
    }
}
