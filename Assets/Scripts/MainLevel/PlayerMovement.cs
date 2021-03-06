using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public Camera camera;
    public Vector2 wayPoint;
    private float ConstZ = -10;
    public float Offset;
    public GameObject waypoint;
    public ParticleSystem PlayerEffect;
    public Animator animator;
    public AudioSource walkingSound;
    private Rigidbody2D rb;
    private void Start()
    {
        camera = FindObjectOfType<Camera>();
        rb = FindObjectOfType<Rigidbody2D>();

    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            camera.orthographicSize--;
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camera.orthographicSize++;
        }

        if (camera.orthographicSize < 0)
        {
            camera.orthographicSize = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            wayPoint = camera.ScreenToWorldPoint(Input.mousePosition);

        }
        
        camera.transform.position = Vector3.Lerp( new Vector3(camera.transform.position.x, camera.transform.position.y, ConstZ), 
            new Vector3(wayPoint.x, wayPoint.y, ConstZ), 10 * Time.deltaTime);
            
        if (!waypoint && rb.position.y != wayPoint.y || rb.position.x != wayPoint.x)
            
        {
            waypoint.SetActive(true);
            waypoint.transform.position = wayPoint;
            walkingSound.Play();
        }
        else
        { 
            waypoint.SetActive(false);
           
           

        }

        



        animator.SetFloat("Horizontal", rb.position.x);
        animator.SetFloat("Vertical", rb.position.y);
        animator.SetFloat("Magnitude", transform.position.magnitude);
      
    }

    private void FixedUpdate()
    {
        rb.position = Vector2.MoveTowards(rb.position, wayPoint, 10 * Time.deltaTime);
    }
}
