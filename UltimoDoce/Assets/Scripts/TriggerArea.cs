using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public bool naArea = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entrou na area");
        if(other.gameObject.CompareTag("Player"))
        {
            naArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("saiu da area");
        if(other.gameObject.CompareTag("Player"))
        {
            naArea = false;
        }
    }
}
