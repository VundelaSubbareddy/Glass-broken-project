using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBrakeScript : MonoBehaviour
{
    public Transform prefab;
    public float Force = 1f;
    public float radius, power, upwards;
    public AudioSource Audioclip;
   // public AudioClip audiO;

    
    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > Force)
        {
            Destroy(gameObject);
            Instantiate(prefab,transform.position,transform.rotation);
            prefab.localScale = transform.localScale;
           // Audioclip.GetComponent<AudioSource>().playOnAwake = enabled;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit.gameObject.GetComponent<Rigidbody>())
                {
                    hit.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    hit.gameObject.GetComponent<Rigidbody>().AddExplosionForce(power * col.relativeVelocity.magnitude, explosionPos, radius, upwards);
                   AudioSource Audioclp = GetComponent<AudioSource>();
                    Audioclp.Play();
                }

            }
                Debug.Log("prefabActive");
        }
        Debug.Log("Sphere ToucH");
    }
}
