using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform firePos;
    public GameObject snowballPrefab;
    public float launchSpeed = 10f;
    public int ammo = 10;

    void Update()
    {
        if (transform.position.y < -0.5f)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }

    public void FireSnowball()
    {
        if (ammo > 0 )
        {
            GameObject snowball = Instantiate(snowballPrefab, firePos.position, firePos.rotation);
            snowball.GetComponent<Rigidbody>().velocity = firePos.forward * launchSpeed;
            ammo--;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SnowballAmmo")
        {
            Destroy(other.gameObject);
            ammo = 10;
        }
    }
}
