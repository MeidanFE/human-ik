using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float velocity = 20f;
    public float life = 1f;

    private float lifeTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, velocity * Time.deltaTime))
        {
            //transform.position = hit.point;
            //Debug.Log(hit.point);
            //Vector3 reflected = Vector3.Reflect(transform.forward, hit.normal);
            //Debug.Log(reflected);
            //Vector3 direction = transform.forward;
            //Vector3 vop = Vector3.ProjectOnPlane(reflected, Vector3.forward);
            //transform.forward = vop;
            //transform.rotation = Quaternion.LookRotation(vop, Vector3.forward);
            //Hit(transform.position, direction, reflected, hit.collider);
            Hit(); 
        }
        else
        {
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        }

        if (Time.time > lifeTimer +life)
        {
            Destroy(gameObject);
        }
    }

    private void Hit()
    {
        Destroy(gameObject);
    }

    public void Fire(Vector3 position, Vector3 euler, int layer)
    {
        lifeTimer = Time.time;
        transform.position = position;
        transform.eulerAngles = euler;
        transform.position = new Vector3(transform.position.x,transform.position.y,0);
        Vector3 vop = Vector3.ProjectOnPlane(transform.forward, Vector3.forward);
        transform.forward = vop;
        transform.rotation = Quaternion.LookRotation(vop, Vector3.forward);
    }
}
