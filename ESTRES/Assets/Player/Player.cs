using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    // Control de inteaccion
    [Header("Student interaction")]
    public Student student;

    private Vector2 movement;

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
    }

    // Update para el movimiento
    void FixedUpdate()
    {
        if(!GameControl.instance.movementBloqued) {
            rb.MovePosition(rb.position + movement*moveSpeed*Time.fixedDeltaTime);
        }
    }
}
