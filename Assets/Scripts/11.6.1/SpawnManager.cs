using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Ennemi;

    private Vector3 SpawnPosition = new Vector3(0, 1, 9.5f);

    private float m_StartDelay = 2.0f;

    private float m_Interval = 0.0f;

    private float m_Elapsed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Interval = m_StartDelay;  
    }

    // Update is called once per frame
    void Update()
    {
        m_Elapsed += Time.deltaTime;
        if(m_Elapsed >= m_Interval)
        {
            m_Elapsed = 0;
            SpawnEnnemi();
            m_Interval = 2.0f;
        }
    }

    private void SpawnEnnemi()
    {
        Instantiate(m_Ennemi, SpawnPosition, m_Ennemi.transform.rotation);
    }
}
