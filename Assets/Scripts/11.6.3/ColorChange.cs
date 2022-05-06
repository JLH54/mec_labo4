using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField]
    private Camera m_MainCamera;

    private Ray m_LastRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            m_LastRay = m_MainCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit myRayinfo;
            if(Physics.Raycast(m_LastRay, out myRayinfo))
            {
                if(myRayinfo.collider.CompareTag("Player"))
                {
                    int nombreRandom = Random.Range(1, 4);
                    switch (nombreRandom)
                    {
                        case 1:
                            myRayinfo.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                            break;
                        case 2:
                            myRayinfo.transform.GetComponent<MeshRenderer>().material.color = Color.green;
                            break;
                        case 3:
                            myRayinfo.transform.GetComponent<MeshRenderer>().material.color = Color.blue;
                            break;
                    }
                }
                
            }
        }

        Debug.DrawRay(m_LastRay.origin, m_LastRay.direction * 100);
    }

    
}
