using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerPlusCiv : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Ennemi;

    [SerializeField]
    private GameObject m_Civ;

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
        if (m_Elapsed >= m_Interval)
        {
            int RandomNumber = Random.Range(1, 3);
            switch(RandomNumber)
            {
                case 1:
                    SpawnEnnemi();
                    break;
                case 2:
                    SpawnCiv();
                    break;
            }
            m_Elapsed = 0;
            m_Interval = 2.0f;
        }
    }

    private void SpawnEnnemi()
    {
        Instantiate(m_Ennemi, SpawnPosition, m_Ennemi.transform.rotation);
    }

    private void SpawnCiv()
    {
        Instantiate(m_Civ, SpawnPosition, m_Ennemi.transform.rotation);
    }
}
