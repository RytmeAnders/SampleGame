using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public float Duration;
    public GameObject pickUpEffect;
    public Material effectMaterial;
    public Material defaultPlayer;

    private void OnTriggerEnter(Collider other)
    {
        print("Pickup");
        if(other.CompareTag("Player"))
        {
            if(gameObject.CompareTag("green"))
            {
                Debug.Log("Green picked up !");
                StartCoroutine(PickUpGreen(other));
            }

            if (gameObject.CompareTag("red"))
            {
                Debug.Log("Red picked up !");
                StartCoroutine(PickUpRed(other));
            }
        }
    }

    IEnumerator PickUpGreen(Collider player) // Green = You move faster
    {

        movement playermovement = player.GetComponent<movement>();

        // When the effect kicks in
        playermovement.thrust *= 2;
        GameObject effect = Instantiate(pickUpEffect, player.transform.position, Quaternion.identity);
        effect.transform.SetParent(player.transform);

        player.GetComponent<Renderer>().material = effectMaterial;
        player.tag = "Effected";

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(Duration);

        // When the effect ends
        playermovement.thrust /= 2;
        player.GetComponent<Renderer>().material = defaultPlayer;

        player.tag = "Player";
        Destroy(effect);
        Destroy(gameObject);
    }

    IEnumerator PickUpRed(Collider player) // Red = You get bigger
    {
        // When the effect kicks in
        player.transform.localScale *= 3;
        player.GetComponent<Renderer>().material = effectMaterial;
        player.tag = "Effected";

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(Duration);

        // When the effect ends
        player.transform.localScale /= 3;
        player.GetComponent<Renderer>().material = defaultPlayer;

        player.tag = "Player";
        Destroy(gameObject);

    }
}
