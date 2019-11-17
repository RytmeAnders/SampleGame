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
            StartCoroutine(PickUp(other, gameObject.tag));
        }
    }

    IEnumerator PickUp(Collider player, string tag) // Green = You move faster
    {
        string tagCase = tag;
        movement playermovement = player.GetComponent<movement>();

        // Effects specific to the prefab
        switch (tagCase)
        {
            case "red":
                player.transform.localScale *= 3;
                break;
            case "green":
                playermovement.thrust *= 2;
                break;
            case "blue":
                break;
        }

        // Display the effect on the player
        GameObject effect = Instantiate(pickUpEffect, player.transform.position, Quaternion.identity);
        effect.transform.SetParent(player.transform);

        // Change the material of the player
        player.GetComponent<Renderer>().material = effectMaterial;
        player.tag = "Effected";

        // Disable the pick up prefab
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(Duration);

        // Ending the specific effects
        switch (tagCase)
        {
            case "red":
                player.transform.localScale /= 3;
                break;
            case "green":
                playermovement.thrust /= 2;
                break;
            case "blue":
                break;
        }

        // Setting the player back to normal
        player.GetComponent<Renderer>().material = defaultPlayer;
        player.tag = "Player";

        // Removing the effect and the pick up prefab
        Destroy(effect);
        Destroy(gameObject);
    }
}
