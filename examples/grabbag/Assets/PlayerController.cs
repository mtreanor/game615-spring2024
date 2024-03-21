using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject snowballPrefab;

    bool canThrow = true;

    private void OnEnable()
    {
        GameManager.FadeStarted += DisableShooting;
        GameManager.FadeComplete += EnableShooting;
    }
    private void OnDisable()
    {
        GameManager.FadeStarted -= DisableShooting;
        GameManager.FadeComplete -= EnableShooting;
    }

    void DisableShooting()
    {
        canThrow = false;
    }
    void EnableShooting()
    {
        canThrow = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canThrow)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Increase score
                GameManager.Instance.IncreaseScore(1);
                StartCoroutine(Throw());
            }
        }
    }

    IEnumerator Throw()
    {
        canThrow = false;

        GameObject snowball = Instantiate(snowballPrefab, transform.position, transform.rotation);
        Rigidbody rb = snowball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 1000);

        yield return new WaitForSeconds(1f);

        canThrow = true;
    }
}
