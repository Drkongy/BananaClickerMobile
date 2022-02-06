using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BananaAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform banana;
    public Vector2 regularSize;
    public Vector2 biggerSize;
    public bool bananaPressed;
    public Vector2 targetSize;
    public float time;
    Vector3 zero = Vector3.zero;
    void Update()
        {
            if (bananaPressed)
            {
                targetSize = biggerSize;
            }
            else
            {
                targetSize = regularSize;
            }

            //when the banana is pressed the size of the banana will increase
            // when the banana is not being pressed it will stay at the original size.
            banana.localScale = Vector3.SmoothDamp(banana.localScale, targetSize, ref zero, time, 150f);
        }
    public void OnPointerDown(PointerEventData eventData)
    {
        bananaPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bananaPressed = false;
        
    }

    public void click()
    {
        bananaPressed = !bananaPressed;


    }
    
}