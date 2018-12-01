using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<HostageManager>() != null)
        {
            //Add collision force
            collision.GetComponent<Rigidbody2D>().AddForce(GetComponent<Rigidbody2D>().GetPointVelocity(collision.transform.position) * GetComponent<Rigidbody2D>().mass);

            //'Disable' bullet
            this.GetComponent<Rigidbody2D>().isKinematic = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(DestroySelf());
        }
    }


    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(0.375f);
        Destroy(this.gameObject);
    }
}