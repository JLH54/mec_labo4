using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    public void PutItBackToWhiteClick()
    {
        cube.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
