using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    private Camera m_MainCamera;

    [SerializeField]
    private float m_speed;

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
                //transform.position = hitInfo.point;
                pointDepart = transform.position;
                pointArriver = hitInfo.point + new Vector3(0, GetComponent<Collider>().bounds.size.y / 2, 0);
                m_DistanceToTravel = Vector3.Distance(pointDepart, pointArriver);
                timer = 0;
                m_TimeOnClick = Time.time;
            }
        }
        timer += Time.deltaTime;
        float elapsedTime = Time.time - m_TimeOnClick;
        transform.position = Vector3.Lerp(pointDepart, pointArriver, elapsedTime * m_speed / m_DistanceToTravel);
        Debug.DrawRay(m_LasRay.origin, m_LasRay.direction * 20, Color.red);
    }
}
