using UnityEngine;
using System;

public class Dano : MonoBehaviour
{

    [SerializeField] private int dano;

    private Vida vida;


    private float proximoAtaque;
    private float cooldown = 0.5f;


    [SerializeField] private Transform meleeCheck;
    [SerializeField] private float tamanhoDetector;
    [SerializeField] private LayerMask layerInimigos;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        vida = player.GetComponent<Vida>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.X) && Time.time >= proximoAtaque)
        {
            proximoAtaque = Time.time + cooldown;
            Melee();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            CausarDano();
        }
    }

    
    void Melee() //ataque melee do player
    {
        Debug.Log("ataque melee");

        Collider2D[] inimigos = Physics2D.OverlapCircleAll(meleeCheck.position, tamanhoDetector, layerInimigos);
    
        foreach (Collider2D i in inimigos)
        {
            Debug.Log("loop foreach");
            Vida x = i.GetComponent<Vida>();
            x.setVida(dano);
        }    
    }
    

    void CausarDano() //função dos inimios
    {
        vida.setVida(dano);
    }

    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meleeCheck.position, tamanhoDetector);
    }

}
