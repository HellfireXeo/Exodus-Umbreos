using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandle : MonoBehaviour
{
    private float speed = 0.125f;
    public GameObject playerContainer;
    private Rigidbody playerBody;
    private Animator animation;

    public Transform healthContainer;
    private float healthValue = 1f;
    private float scale_y = 0.1f;
    private float scale_z = 0.1f;

    public GameObject cam;
    private float minX = -45.0f; private float maxX = 45.0f;
    private float minY = -45.0f; private float maxY = 45.0f;

    private float sensX = 100.0f; private float sensY = 100.0f;
    private float rotationY = 0.0f; private float rotationX = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        cam = GameObject.Find("Camera");
        animation = GetComponent<Animator>();
        animation.speed = 1;

    }

    public void measureLife(float value)
    {
        Vector3 barVector = new Vector3(
            playerContainer.transform.position.x,
            playerContainer.transform.position.y + 0.8f,
            playerContainer.transform.position.z
            );

        Transform bar;
        bar = Instantiate(
            healthContainer,
            barVector,
            transform.rotation);

        bar.transform.localScale = new Vector3(value, scale_y, scale_z);

        Destroy(bar.gameObject, 0.02f);
    }

    bool isWalking = false;

    // Update is called once per frame
    void Update()
    {

        /*------------: Player Movement :-------------*/

        playerContainer.transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        playerContainer.transform.position += transform.forward * speed * Input.GetAxis("Vertical");
        
        isWalking = (Input.GetAxis("Vertical") != 0);
        animation.SetBool("b_walk", isWalking);

            /*------------: Camera Movement :-------------*/

            if (Input.GetMouseButton(0))
        {
            rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotationX = Mathf.Clamp(rotationX, minX, maxX);
            rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            cam.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }

        
    }
}
