using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestHandle : MonoBehaviour
{
    public Camera camera;
    private PlayerHandle p_handle;

    public Animator animation;

    public GameObject chest;
    private Transform eye;
    public Transform eyeObject;
    private bool eyeAppear = false;
    private float rotateZ;

    private Collider objectCollider;

    void Start()
    {
        animation = GetComponent<Animator>();
        animation.speed = 0;

        objectCollider = GetComponent<Collider>();
    }

    void CheckIfRayCastHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit = chest.transform)
                {
                    animation.speed = 1;
                    animation.SetTrigger("Open");
                }
                Debug.Log(objectHit);
            }
        }
    }
    
    void OnMouseOver()
    {
        Vector3 eyeVector = new Vector3(
            chest.transform.position.x,
            chest.transform.position.y + 2f,
            chest.transform.position.z
            );

        
        eye = Instantiate(
            eyeObject,
            eyeVector,
            transform.rotation);
        

        rotateZ += Time.deltaTime * 62f;
        eye.transform.localRotation = Quaternion.Euler(90, 0, rotateZ);

        Destroy(eye.gameObject, 0.02f);

        CheckIfRayCastHit();
    }

    void OnMouseExit()
    {
        if(eye)Destroy(eye.gameObject);
    }

    void Update()
    {
        

    }

 
}
