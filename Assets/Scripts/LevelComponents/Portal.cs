using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject PortalSprite;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = new Vector2(PortalSprite.transform.position.x, PortalSprite.transform.position.y);
    }

}
