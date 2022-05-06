using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Transform m_HandGun;

    private int count;

    [SerializeField]
    private float GetOutOfTheWay;

    // Start is called before the first frame update
    void Start()
    {
        m_HandGun = GetComponent<Transform>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = m_HandGun.transform.position;
        Vector3 rayDirection = new Vector3(0, 0, 10);
        Ray myRayCast = new Ray(rayOrigin, rayDirection);
        Debug.DrawRay(rayOrigin, rayDirection, Color.red);
        //if (Input.GetMouseButton(0))
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] myRayCastInfo = Physics.RaycastAll(myRayCast);
            for (int i = 0; i < myRayCastInfo.Length; i++)
            {
                if (myRayCastInfo[i].collider.tag == "Ennemi")
                {
                    Destroy(myRayCastInfo[i].collider.gameObject);
                }
                if(myRayCastInfo[i].collider.tag == "Player")
                {
                    myRayCastInfo[i].collider.transform.position += new Vector3(GetOutOfTheWay, 0,0);
                }
                count++;
            }
        }

        if(count > 0)
        {
            Debug.Log("Nombre d'object toucher : " + count);
        }
        count = 0;
    }
}
