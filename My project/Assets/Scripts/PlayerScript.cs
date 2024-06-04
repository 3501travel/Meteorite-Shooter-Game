using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D.IK;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public IKManager2D ikManager;
    public Transform leftHandTarget;
    public Transform rightHandTarget;
    public Transform rightShoulder;
    public Transform leftShoulder;
    public float armRatio = 0.35f;
    public Gun leftGun;
    public Gun rightGun;
    public TextMeshProUGUI rightBulletCountTMP;
    public TextMeshProUGUI leftBulletCountTMP;
    
    
    // Start is called before the first frame update
    void Start()
    {
        leftGun.bulletCount = 5;
        rightGun.bulletCount = 5;

    }

    void Update()
    {
        if (GameManager.Instance.GameFinished) return;
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
        UpdateBulletCountUI();
        
        if(GameManager.Instance.ShieldUp)
        {
            spriteRenderer.color = Color.HSVToRGB(Mathf.PingPong(Time.time, 1), 1, 1);
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
    private void UpdateBulletCountUI()
    {
        rightBulletCountTMP.text = "x" + rightGun.bulletCount.ToString();
        leftBulletCountTMP.text = "x" + leftGun.bulletCount.ToString();
    }
    
    public void MoveHand(Vector3 clickedPosition)
    {
        if (clickedPosition.x < 0)
        {
            // move left hand
            MoveHandHelper(leftHandTarget,  leftShoulder, leftGun, clickedPosition);
        }
        else
        {
            // move right hand
            MoveHandHelper(rightHandTarget, rightShoulder, rightGun, clickedPosition);
        }
    }
    
    private void MoveHandHelper(Transform handTarget, Transform shoulder, Gun gun, Vector3 clickedPosition)
    {
        Vector3 direction = clickedPosition - shoulder.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log("Angle: " + angle);
        // put the target in the right hand in a position that is 1 unit away from the center position in the direction of angle
        Vector3 targetPosition = shoulder.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * armRatio;
        handTarget.position = targetPosition;
        
        if (gun.bulletCount > 0)
        {
            gun.SpawnBullet(handTarget, angle);
            gun.bulletCount--;
        }
        else
        {
            Debug.Log("Out of bullets for " + gun.name);
        }

        UpdateBulletCountUI();
    }
}
