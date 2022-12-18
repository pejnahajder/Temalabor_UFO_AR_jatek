using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class MovementControl : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform gamePad;
    private GameObject arObject;
    public float moveSpeed = 0.1f;
    private GameObject camera;
    private int lives;
    
    private Vector3 move;

    public int getLives()
    {
        return lives;
    }
    void Start()
    {
        lives = 3;
        arObject = GameObject.FindGameObjectWithTag("UFO");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = 
            Vector2.ClampMagnitude(eventData.position - (Vector2)gamePad.position, gamePad.rect.width * 0.5f);
        move = new Vector3(transform.localPosition.x, 0f, transform.localPosition.y).normalized;

        var rotation = new Quaternion(0f,camera.transform.rotation.y,0f,camera.transform.rotation.w);
       move =  rotation * move;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        StopCoroutine(PlayerMovement());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(PlayerMovement());
    }

    IEnumerator PlayerMovement()
    {
        while (true)
        {
           
             arObject.transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

                if (move != Vector3.zero)
            {
              //  arObject.transform.rotation =
                    Quaternion.Slerp(arObject.transform.rotation, Quaternion.LookRotation(move),Time.deltaTime*2.0f);

            }
            yield return true;
        }
    }
}
