using System.Collections;
using System.Collections.Generic;
using Invector.vCharacterController;
using UnityEngine;

public class CollectionTree : CollectionObject
{
    public const float force = 30.0f;

    public GameObject _debrisPrefab;

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null)
            return;

        if (collision.collider == null)
            return;

        var playerController = collision.gameObject.GetComponent<vThirdPersonController>();
        if (playerController == null)
            return;

        if (playerController.isChopping && collision.collider.gameObject.tag == "Weapon")
        {
            MakeEffect(collision);
            Break(collision);
        }
    }

    private void MakeEffect(Collision collision)
    {
        var clone = Instantiate(_debrisPrefab, collision.contacts[0].point, collision.transform.rotation);
        clone.SetActive(true);
        Destroy(clone, 3.0f);
    }

    private void Break(Collision collision)
    {
        rigidBody.isKinematic = false;

        Vector3 dir = collision.contacts[0].point - transform.position;
        dir = -dir.normalized;
        rigidBody.AddForce(dir * force);

        Destroy(this, 3.0f);
    }
}
