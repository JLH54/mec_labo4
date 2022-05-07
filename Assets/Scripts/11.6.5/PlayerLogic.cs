using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    private Camera m_MainCamera;

    [SerializeField]
    private float m_speed;

    [SerializeField]
    private NavMeshAgent m_agent;

    [SerializeField]
    private float m_rayonX;

    [SerializeField]
    private int m_damage;

    private Ray m_LasRay;

    private Vector3 pointDepart;

    private Vector3 pointArriver;

    private float m_DistanceToTravel;

    private float timer;

    private float m_TimeOnClick = 0;

    [SerializeField]
    [Range(0f, 1f)] private float pourcentage;

    // Start is called before the first frame update
    void Start()
    {
        pointArriver = transform.position;
        pointDepart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //tempsRendu = Mathf.Lerp(min, max, pourcentage);
        if (Input.GetMouseButtonDown(0))
        {
            m_LasRay = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(m_LasRay, out hitInfo))
            {
                m_agent.SetDestination(hitInfo.point);
                timer = 0;
                m_TimeOnClick = Time.time;
            }
        }

        Collider[] hitColliders = Physics.OverlapSphere(m_agent.transform.position, m_rayonX);
        foreach(var hitCollider in hitColliders)
        {
            if(hitCollider.CompareTag("Ennemi"))
            {
                m_agent.isStopped = true;
                EnnemiBehavior ennemi = hitCollider.gameObject.GetComponent<EnnemiBehavior>();
                ennemi.takeHit(m_damage);
                if(ennemi.returnHealth() <= 0)
                {
                    m_agent.isStopped = false;
                }
            }
        }

        timer += Time.deltaTime;
        float elapsedTime = Time.time - m_TimeOnClick;

        Debug.DrawRay(m_LasRay.origin, m_LasRay.direction * 20, Color.red);
    }
}
