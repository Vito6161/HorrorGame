using UnityEngine;
using System;
using UnityEngine.InputSystem;
using NUnit.Framework;
using UnityEditor;

public class Dano : MonoBehaviour
{


    [SerializeField] private int dano;

    [Header("Ataques do Player")]
    [SerializeField] private Transform meleeCheck;
    [SerializeField] private float tamanhoDetector;
    [SerializeField] private LayerMask layerInimigos;
    [SerializeField] private Transform firePoint;
    private GameObject projetil;
    [SerializeField] private GameObject prefab;
    private float proximoAtaque;
    private float cooldown = 0.5f;
    private bool isMelee = true;

    PlayerMovement move;
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        move = player.GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            isMelee = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isMelee = false;
        }


        if(Input.GetKeyDown(KeyCode.X) && Time.time >= proximoAtaque && isMelee)
        {
            proximoAtaque = Time.time + cooldown;
            Melee();
        }
        else if (Input.GetKeyDown(KeyCode.X) && Time.time >= proximoAtaque && !isMelee)
        {
            proximoAtaque = Time.time + cooldown;
            Atirar();
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

    void Atirar()
    {
        Debug.Log("atirando");
        projetil = Instantiate(prefab, firePoint.position, firePoint.rotation);   
        Rigidbody2D rbProjetil = projetil.GetComponent<Rigidbody2D>();

        
        rbProjetil.AddForce(new Vector2(500f * move.direção, 0));
    }
    

    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meleeCheck.position, tamanhoDetector);
    }

}
