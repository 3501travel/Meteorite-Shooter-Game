using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public IKManager2D ikManager;
    public Transform leftHand;
    public Transform rightHand;
    public Transform rightShoulder;
    public Transform leftShoulder;
    public float armRatio = 0.35f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Debug.Log("Screen touched at position: " + touchPosition);
                MoveHand(touchPosition);
            }
        }
        
        // Handle mouse input
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Mouse clicked at position: " + mousePosition);
            MoveHand(mousePosition);
        }
    }
    
    public void MoveHand(Vector3 clickedPosition)
    {
        if (clickedPosition.x < 0)
        {
            // move left hand
            MoveHandHelper(leftHand,  leftShoulder, clickedPosition);
        }
        else
        {
            // move right hand
            MoveHandHelper(rightHand, rightShoulder, clickedPosition);
        }
    }
    
    private void MoveHandHelper(Transform hand, Transform shoulder, Vector3 clickedPosition)
    {
        Vector3 direction = clickedPosition - shoulder.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log("Angle: " + angle);
        // put the target in the right hand in a position that is 1 unit away from the center position in the direction of angle
        Vector3 targetPosition = shoulder.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * armRatio;
        hand.position = targetPosition;
    }
}
