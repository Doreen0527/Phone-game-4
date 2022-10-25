using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    CharacterController cc;
    public float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis ("Horizontal");
        float v = Input.GetAxis ("Vertical");

        Vector3 dir = new Vector3 (-h, 0, -v);

        if (dir.magnitude>0.1f)
        {
    
            float faceAngle = Mathf.Atan2 (h, v) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
        }

        Vector3 move = dir * speed * Time.deltaTime;

        if (!cc.isGrounded)
        {
            move.y = -9.8f * 30 * Time.deltaTime;
        }

         cc.Move (move * speed * Time.deltaTime);

         if (transform.position.y <= -10)
             transform.position = new Vector3 (0, 21.7f, 424); 
    }
}
