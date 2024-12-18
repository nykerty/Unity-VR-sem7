using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanBeh : MonoBehaviour
{
    public Light lightSource1;
    public Light lightSource2;
    public int HP = 2;
    public float speed = 10f;

    public GameObject snowballPackPrefab;

    private bool isDead = false;
    private bool isDropped = false;

    void Update()
    {
        if (isDead == false)
        {
            transform.LookAt(new Vector3(4f, 0.5f, 0f));
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(4f, 0.35f, 0f), speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Snowball" && HP > 0)
        {
            HP--;
        }

        if (HP == 0)
        {
            SnowmanDeath();
        }
    }

    public void SnowmanDeath()
    {
        if (isDropped == false)
        {
            isDead = true;
            lightSource1.enabled = false;
            lightSource2.enabled = false;
            Instantiate(snowballPackPrefab, new Vector3(transform.position.x - 1f, 0.85f, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
            Destroy(gameObject, 1f);
        }

        isDropped = true;
    }

}
