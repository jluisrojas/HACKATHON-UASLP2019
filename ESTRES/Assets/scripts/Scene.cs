﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Scene : MonoBehaviour
{
    // Objeto que guarda informacion del la escena actual dentro del juego
    // La escene se ve de la siguiente manera
    // En donde ubicamos ciertos puntos de entrada, no en todas se puede entrar\
    // por todos los lados
    //              0
    //      --------------
    //     |              |
    //  3  |              |  1
    //      --------------
    //              2

    public bool[] entries = new bool[4];
    public int clip;
    public Teletransporter[] teletransporters = new Teletransporter[4];

    public Camera camera;

    public void SetScene(int entryPoint) {
        if(entries[entryPoint] == false) {
            Debug.LogError("Not a valid entry point");
            return;
        }
        
        camera.gameObject.SetActive(true);
        camera.enabled = true;
        camera.tag = "MainCamera";
        
        GameControl.instance.player.GetComponent<AIPath>().canMove = false;
        GameControl.instance.player.transform.position = teletransporters[entryPoint].spawnPosition;
        //GameControl.instance.player.GetComponent<Seeker>().StartPath(GameControl.instance.player.transform.position, teletransporters[entryPoint].spawnPosition);
        //GameControl.instance.player.GetComponent<AIPath>().canMove = false;
    }

    void OnDrawGizmos() {
        //Gizmos.color = Color.white;

        //Gizmos.DrawWireCube(transform.position, camera.orthographicSize*new Vector2(1080f/100f, 720f/100f));
    }
}
