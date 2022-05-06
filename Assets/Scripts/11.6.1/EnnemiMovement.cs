using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiMovement : MonoBehaviour
{
    private int speed = 3;

    private Rigidbody m_Ennemi;

    // Start is called before the first frame update
    void Start()
    {
        m_Ennemi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Ennemi.transform.Translate(Vector3.right * speed * Time.deltaTime);
        CheckDie();
    }

    void CheckDie()
    {
        if(m_Ennemi.transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
