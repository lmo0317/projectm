using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTree : CollectionObject
{
    public GameObject _debrisPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if(collision.collider.gameObject.tag == "Weapon")
        {
            Debug.Log("[CollectionTree] [OnCollisionEnter] [tag : weapon]");
            var clone = Instantiate(_debrisPrefab, collision.contacts[0].point, collision.transform.rotation);
            clone.SetActive(true);

            Destroy(clone, 3.0f);
        }
    }
}
