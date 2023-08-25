using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D fisica;
    private Vector2 direcao;
    [SerializeField]private float velocidade = 100f;
    public Animator animacao;


    private void Start(){
        this.fisica=GetComponent<Rigidbody2D>();
    }
    private void Update(){
        this.direcao.x = Input.GetAxisRaw("Horizontal");
        this.direcao.y = Input.GetAxisRaw("Vertical");

        // Controle da animação
        Vector3 mov = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        animacao.SetFloat("Horizontal", mov.x);
        animacao.SetFloat("Vertical", mov.y);
        animacao.SetFloat("Speed", mov.magnitude);
    }
    private void FixedUpdate()
    {
        this.fisica.MovePosition(fisica.position + direcao * velocidade * Time.fixedDeltaTime);
    }
    
}
