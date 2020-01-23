using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;
    bool m_IsWall;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("wall"))
        {
            m_IsWall = true;
        }
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("wall"))
        {
            m_IsWall = false;
        }
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsPlayerInRange && !m_IsWall)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform.tag == "wall")
                {
                    m_IsPlayerInRange = false;
                }
                else if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
