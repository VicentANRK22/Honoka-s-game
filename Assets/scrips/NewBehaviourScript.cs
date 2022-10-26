using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidad;
    public float fuerzasalto;
    public float saltosmaximos;
    public LayerMask capaSuelo;


    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private bool MirandoDerecha = true;
    private float saltosRestantes;
    private Animator animator;
    
    // Update is called once per frame
    private void Start() {
        
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosmaximos;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y),0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }
    
    void ProcesarSalto()
    {
        if (EstaEnSuelo ())
        {
            saltosRestantes = saltosmaximos;
        }
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0 )
        {
            saltosRestantes --;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            rigidbody.AddForce(Vector2.up * fuerzasalto, ForceMode2D.Impulse);
        }
    }
    void ProcesarMovimiento()
    {
        // logica del movimiento.
        float inputmovimiento = Input.GetAxis("Horizontal");
        if(inputmovimiento != 0f)
        {
            animator.SetBool("isRuning", true);
        }
        else
        {
            animator.SetBool("isRuning", false);
        }

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
