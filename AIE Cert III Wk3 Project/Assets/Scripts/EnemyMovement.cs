using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	public float m_CloseDistance = 0.1f;
	
	private GameObject m_Player;
    private NavMeshAgent m_NavAgent;
    private Rigidbody m_Rigidbody;
	
	private bool m_Follow;

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
    }
	
	private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
    }

    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }
	
	private void OnTriggerEnter(Collider other)
    {
        Debug.Log(" Player in range");
        m_Follow = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(" Player out of range");
        m_Follow = true;
    }
	
	void Update ()
    {
        if (m_Follow == false)
            return;

        float distance = (m_Player.transform.position - transform.position).magnitude;
        if (distance > m_CloseDistance)
        {
            Debug.Log("Following Player");
            Debug.Log(m_Player.transform.position);
            m_NavAgent.SetDestination(m_Player.transform.position);
            m_NavAgent.Resume();
        }
		else if (m_NavAgent.transform.position != m_Player.transform.position)
		{
			m_NavAgent.SetDestination(m_Player.transform.position);
			m_NavAgent.Resume();
		}
        else
        {
            m_NavAgent.Stop();
        }
		
	}
}
