using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidad;
    public float fuerzasalto;
    public LayerMask capaSuelo;


    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private bool MirandoDerecha = true;
    
    // Update is called once per frame
    private void Start() {
        
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }
    
    void ProcesarSalto()
    {
        if(Input.GetKeyDown(KeyCode.Space) )
        {
            rigidbody.AddForce(Vector2.up * fuerzasalto, ForceMode2D.Impulse);
        }
    }
    void ProcesarMovimiento()
    {
        // logica del movimiento.
        float inputmovimiento = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(inputmovimiento * velocidad, rigidbody.velocity.y);

        GestionarOrientacion(inputmovimiento);
    }
    void GestionarOrientacion(float inputmovimiento)
    {
        //si se cumple
        if( (MirandoDerecha == true && inputmovimiento < 0) || (MirandoDerecha == false && inputmovimiento >0) )
        {
            MirandoDerecha = !MirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
           //ejecutar codigo de volteado
        
    }
}
