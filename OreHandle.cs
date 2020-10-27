using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreHandle : MonoBehaviour
{
    public Camera camera;

 
    public GameObject ore;
    private Transform rareOre;
    public Transform rareOreObject;
    private bool rareOreAppear = false;
    private float rotateZ;

    private Collider objectCollider;

    void Start()
    { 
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
                if (objectHit = ore.transform)
                {
                    
                }
                Debug.Log(objectHit);
            }
        }
    }

    void OnMouseOver()
    {
       
        Vector3 rareOreVector = new Vector3(
            ore.transform.position.x,
            ore.transform.position.y + 2f,
            ore.transform.position.z
            );


        rareOre = Instantiate(
            rareOreObject,
            rareOreVector,
            transform.rotation);


        rotateZ += Time.deltaTime * 62f;
        rareOre.transform.localRotation = Quaternion.Euler(90, 0, rotateZ);

        Destroy(rareOre.gameObject, 0.02f);

        CheckIfRayCastHit();
    }

    void OnMouseExit()
    {
        if (rareOre) Destroy(rareOre.gameObject);
    }

    void Update()
    {


    }


}
