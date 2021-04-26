using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VanguardEngine;

public class RotateTest : MonoBehaviour
{
    public Camera cam;
    public GameObject Card;

    // Start is called before the first frame update
    void Start()
    {
        //Card.transform.LookAt(cam.transform);
        Card.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, cam.transform.rotation, 0);
        Card.transform.rotation = Quaternion.Euler(Card.transform.rotation.eulerAngles.x - 90, Card.transform.rotation.eulerAngles.y, Card.transform.rotation.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void test()
    {

    }
}
