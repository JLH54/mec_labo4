using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int m_jumpForce = 10;

    [SerializeField]
    private Text Lost;

    [SerializeField]
    private GameObject m_Feet;

    private Rigidbody m_player;

    private bool m_OnGround;


    // Start is called before the first frame update
    void Start()
    {
        m_OnGround = true;
        m_player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Le joueur ne peut pas faire un double saut
        Vector3 m_velocity = m_player.velocity;
        if (Input.GetKeyDown(KeyCode.Space) && m_OnGround)
        {
            m_velocity.y = m_jumpForce;
            m_OnGround = false;
        }
        m_player.velocity = m_velocity;

        Vector3 rayOrigin = m_Feet.transform.position;
        Vector3 rayDirection = new Vector3(0, -0.2f, 0);
        Ray myRayCast = new Ray(rayOrigin, rayDirection);
        RaycastHit myRayCastInfo;
        Debug.DrawRay(rayOrigin, rayDirection, Color.red);
        if(Physics.Raycast(myRayCast, out myRayCastInfo))
        {
            //L’ennemi est détruit si le joueur saute dessus 
            if (myRayCastInfo.collider.tag == "Ennemi")
            {
                Destroy(myRayCastInfo.collider.gameObject);
                m_OnGround = true;
            }
            if(myRayCastInfo.collider.tag == "Ground")
            {
                m_OnGround = true;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Le joueur est détruit s’il entre en contact avec l’ennemi
        if (collision.collider.CompareTag("Ennemi"))
        {
            Destroy(gameObject);
            Lost.enabled = true;
        }
    }
}
