using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Teletransporter : MonoBehaviour
{
    
    public Vector2 bounds;
    public Vector2 spawnPosition;
    public GameObject sceneToTP;
    public int entryPoint;

    private BoxCollider2D collider;

    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<BoxCollider2D>();
        collider = this.GetComponent<BoxCollider2D>();

        collider.size = bounds;

        spawnPosition += (Vector2)transform.position;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.tag == "Player") {
            GameControl.instance.LoadScene(sceneToTP, entryPoint);
        }
    }

    /* 
    void OnDrawGizmos() {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(transform.position, bounds);
        float cubeSize = 0.05f;
        if(!EditorApplication.isPlaying)
            Gizmos.DrawCube(transform.position + (Vector3)spawnPosition, new Vector2(cubeSize, cubeSize));
        else
            Gizmos.DrawCube(spawnPosition, new Vector2(cubeSize, cubeSize));
    }
    */
}
