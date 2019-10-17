using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    public float interactionArea = 1.0f;
    public bool playerInArea;

    // Reference to the player
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        playerInArea = false;
        player = GameControl.instance.player;
        StartCoroutine(UpdateStatus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Se utiliza un courutina para no forzar tanto al CPU en el update
    // el update lo hace cada 0.5 segundos
    IEnumerator UpdateStatus() {
        while(true) {

            if(!GameControl.instance.interactionMode) {
                if(Vector2.Distance(this.transform.position, player.transform.position) <= interactionArea) {
                    player.GetComponent<Player>().student = this;
                    playerInArea = true;
                } else {
                    player.GetComponent<Player>().student = null;
                    playerInArea = false;
                }
            }

            yield return new WaitForSeconds(0.5f);
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
