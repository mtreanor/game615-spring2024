using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public GameObject confettoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // This moves the cube forward toward the "Moon" (sphere). This is an example
            // of how to move things forward.
            gameObject.transform.position = gameObject.transform.position + gameObject.transform.forward;
        }
    }

    // Unity will tell the function below to run under the following conditions:
    //  1. Two objects with colliders are colliding
    //  2. At least one of the objects' colliders are marked as "Is Trigger"
    //  3. At least one of the objects has a Rigidbody
    private void OnTriggerEnter(Collider other)
    {
        // 'other' is the name of the collider that just collided with the object
        // that this script ("CubeScript") is attached to. So the if statment
        // below checks to see that that object has the tag "moon". Remember that
        // the tags for GameObjects are assigned in the top left area of the
        // inspector when you select the object inside of Unity.
        if (other.CompareTag("moon"))
        {
            Debug.Log(other.gameObject.name);
            Renderer rend = gameObject.GetComponent<Renderer>();
            rend.material.color = Color.green;

            // Instantiate 200 confetto, thus creating confetti.
            for (int i = 0; i < 200; i++)
            {
                GameObject confetto = Instantiate(confettoPrefab, gameObject.transform.position, Quaternion.identity);
                confetto.transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
                Rigidbody confettoRB = confetto.GetComponent<Rigidbody>();
                confettoRB.AddForce(confetto.transform.forward * Random.Range(10, 1000));
            }

            Destroy(gameObject);
        }
    }
}