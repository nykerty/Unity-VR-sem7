using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door4Behaviour : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;
    private bool isMovingToEnd = false;
    private bool isMoving = false;

    public LayerMask platformLayer;
    public Transform remote; 
    public Transform player;

    private void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
    }

    public void Activated()
    {
        if (!isMoving)
        {
            isMovingToEnd = !isMovingToEnd;
            isMoving = true;
        }
    }

    private void MovePlatform()
    {       
        Transform target = isMovingToEnd ? endPoint : startPoint;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Ray ray = new Ray(remote.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f, platformLayer))
        {
            player.SetParent(transform, true);
        }

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            isMoving = false;
            player.parent = null;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        coll.gameObject.transform.SetParent(transform, true);
    }

    void OnCollisionExit(Collision coll)
    {
        coll.gameObject.transform.parent = null;
    }
}
