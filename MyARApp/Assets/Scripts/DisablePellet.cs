using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePellet : MonoBehaviour
{
    public GameObject Pellet;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;
    public Material newMat;

    private void OnCollisionEnter(Collision collision)
    {
        Pellet.SetActive(false);
        cube1.tag = "Finished";
        cube1.GetComponent<MeshRenderer> ().material = newMat;
        cube2.tag = "Finished";
        cube2.GetComponent<MeshRenderer> ().material = newMat;
        cube3.tag = "Finished";
        cube3.GetComponent<MeshRenderer> ().material = newMat;
        cube4.tag = "Finished";
        cube4.GetComponent<MeshRenderer> ().material = newMat;
        cube5.tag = "Finished";
        cube5.GetComponent<MeshRenderer> ().material = newMat;
        cube6.tag = "Finished";
        cube6.GetComponent<MeshRenderer> ().material = newMat;
    }
    
}
