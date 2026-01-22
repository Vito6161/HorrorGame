using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   
    [SerializeField] float velocidade;
    [SerializeField] private Transform patrulha1;
    [SerializeField] private Transform patrulha2;
    [SerializeField] private bool voa;
    [SerializeField] private GameObject area;
    private TriggerArea colliderArea;


    private bool isPerseguindo = false;
    private GameObject player;


    bool ponto1 = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        colliderArea = area.GetComponent<TriggerArea>();


    }

    
    void Update()
    {
        if(colliderArea.naArea)
        {
            isPerseguindo = true;
        }
        else if(!colliderArea.naArea)
        {
            isPerseguindo = false;
        }

        if(isPerseguindo)
        {
            Perseguir();  
        }
        else
        {
            Patrulha();
        }
    }

    void Patrulha()
    {

        if(!ponto1)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, patrulha1.position, velocidade * Time.deltaTime);
            Virar(patrulha1.position.x);

            
            if(transform.position == patrulha1.position)
            {
                
                ponto1 = true;
                return;
            }
        }

        if(ponto1)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, patrulha2.position, velocidade * Time.deltaTime);
            Virar(patrulha2.position.x);

            if(transform.position == patrulha2.position)
            {
                
                ponto1 = false;
                return;
            }
        }
    }


    void Perseguir()
    {
        
        

        if(voa)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidade * Time.deltaTime);
        }
        else if (!voa)
        {
            Vector2 alvo = new Vector2(player.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, alvo, velocidade * Time.deltaTime);
        }


        Virar(player.transform.position.x);

    }

    void Virar(float direção)
    {
        if(transform.position.x < direção && transform.localScale.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        else if(transform.position.x > direção && transform.localScale.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    
}

