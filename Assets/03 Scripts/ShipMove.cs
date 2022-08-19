using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    public float mspd = 3f;
    public float rate = 0.1f;

    public float xmin;
    public float xmax;

    KeyCode key_left = KeyCode.LeftArrow;
    KeyCode key_right = KeyCode.RightArrow;
    float xspd;

    // Start is called before the first frame update
    void Start()
    {
        xspd = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var xx = (Input.GetKey(key_left) ? -1 : 0) + (Input.GetKey(key_right) ? 1 : 0);

        //if (detect_side) return;

        xspd = Mathf.Lerp(xspd, xx * mspd, rate);

        var xnew = Mathf.Clamp(transform.position.x + xspd * Time.deltaTime, xmin, xmax);

        transform.position = new Vector3(xnew, transform.position.y, transform.position.z);
    }
}
