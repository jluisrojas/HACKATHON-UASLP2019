using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public enum Context {
    Dialogo,
    Estres,
    Acoso
}

public class Player : MonoBehaviour
{
    public int score;
    public int ninosAyudados;
    public float moveSpeed = 5f;
    public Seeker seeker;
    public Rigidbody2D rb;
    public AIPath path;
    public Animator animator;

    // Control de inteaccion
    [Header("Student interaction")]
    public Student student;

    private Vector2 movement;
    public bool playingAudio = false;


    // Start is called before the first frame update
    void Start()
    {
        if(rb == null) {
            rb = this.GetComponent<Rigidbody2D>();
        }

    }

    // Metodo update
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (!GameControl.instance.movementBloqued && Input.GetMouseButtonDown(0)) {
            Camera camara = GameControl.instance.currentScene.GetComponent<Scene>().camera;
            seeker.StartPath(this.transform.position,camara.ScreenToWorldPoint(Input.mousePosition));// + GameControl.instance.currentScene.transform.position);//, ArrivedDetination);
            GameControl.instance.player.GetComponent<AIPath>().canMove = true;
        }

        if(GameControl.instance.movementBloqued) {
            GameControl.instance.player.GetComponent<AIPath>().canMove = false;
        }

        animator.SetFloat("Horizontal", path.velocity.x);
        animator.SetFloat("Vertical", path.velocity.y);
        animator.SetFloat("Speed", path.velocity.magnitude);

        if(!playingAudio && path.velocity.magnitude > 0f) {
            GameControl.instance.PlaySteps();
            playingAudio = true;
        } else if(playingAudio && path.velocity.magnitude == 0f) {
            playingAudio = false;
            GameControl.instance.StopSteps();
        }
    }

    // Update para el movimiento
    void FixedUpdate()
    {
        if(!GameControl.instance.movementBloqued) {
            //rb.MovePosition(rb.position + movement*moveSpeed*Time.fixedDeltaTime);
        }
    }

    void ArrivedDetination(Path p) {
        if(student != null && p.IsDone()) {
            if(!GameControl.instance.interactionMode) {
                GameControl.instance.LoadDialogue(student.studentDialogue);
            }
        }
    }
}
