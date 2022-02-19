using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTree : CollectionObject
{
    //const
    public const float FORCE = 30;

    //public
    public GameObject _debrisPrefab;

    //private
    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        //_rigidBody.isKinematic = true;
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

        if(playerController.isChopping && collision.collider.gameObject.tag == "Weapon")
        {
            CreateEffect(collision);
            ProcessDestory(collision);
        }
    }
    private void CreateEffect(Collision collision)
    {
        var clone = Instantiate(_debrisPrefab, collision.contacts[0].point, collision.transform.rotation);
        clone.SetActive(true);
        Destroy(clone, 3.0f);
    }
    private void ProcessDestory(Collision collision)
    {
        //_rigidBody.isKinematic = false;
        Vector3 dir = collision.contacts[0].point - transform.position;
        dir = -dir.normalized;
        GetComponent<Rigidbody>().AddForce(dir * FORCE);
        Destroy(gameObject, 3.0f);
    }
}
