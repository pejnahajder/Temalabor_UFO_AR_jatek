using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    public GameObject objectToSpawn; 
    //private List<GameObject> SpawnedObjects;
    private GameObject circle1;
    private GameObject circle2;
    private GameObject circle3;
    private GameObject circle4;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject preGamePanel;
    public GameObject inGamePanel;
    public Text counter;
    public int NumberOfPellets = 4;
    private int i = 0;
    private bool AllIsPlaced = false;

    public int getNumberOfPellets()
    {
        return NumberOfPellets;
    }
    private void Awake()
    {
        preGamePanel.SetActive(true);
        inGamePanel.SetActive(false);
        _arRaycastManager = GetComponent<ARRaycastManager>();
        i = 4;
    }

    bool TryToGetPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    bool tooClose(GameObject gameObject, Vector3 p2)
    {
        if (gameObject == null)
            return true;
        var p1 = gameObject.transform.position;
        var distanceX = p2.x - p1.x;
        var distanceZ = p2.z - p1.z;
        var distance = Math.Sqrt((distanceX * distanceX) + (distanceZ * distanceZ));
        if (distance < 0.6)
            return true;
        
        return false;
    }
    void Update()
    {
        if (!TryToGetPosition(out Vector2 touchPosition))
                      return;
              if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
              {
                  var hitPose = hits[0].pose;
                  var newPosition = new Vector3(hitPose.position.x, hitPose.position.y+0.2f, hitPose.position.z);

                  if (circle1 == null)
                  {
                      circle1 = Instantiate(objectToSpawn, newPosition, hitPose.rotation);
                      i--;
                      counter.text = i.ToString();
                  }
                  else if (circle2 == null && !tooClose(circle1,hitPose.position))
                  {
                      circle2 = Instantiate(objectToSpawn, newPosition, hitPose.rotation);
                      i--;
                      counter.text = i.ToString();
                  }
                  else if (circle3 == null && !tooClose(circle1,hitPose.position) && !tooClose(circle2,hitPose.position))
                  {
                      circle3 = Instantiate(objectToSpawn, newPosition, hitPose.rotation);
                      i--;
                      counter.text = i.ToString();
                  }
                  else if (circle4 == null && !tooClose(circle1,hitPose.position) && !tooClose(circle2,hitPose.position)  && !tooClose(circle3,hitPose.position))
                  {
                      circle4 = Instantiate(objectToSpawn, newPosition, hitPose.rotation);
                      i--;
                      counter.text = i.ToString();
                      Thread.Sleep(500);
                      preGamePanel.SetActive(false);
                      inGamePanel.SetActive(true);

                  }
              }  
        
        
    }
}
