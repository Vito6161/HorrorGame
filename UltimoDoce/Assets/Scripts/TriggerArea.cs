using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public bool naArea = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            naArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            naArea = false;
        }
    }
}
