using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -3)
        {
            Debug.Log("Game Over!");
            textBox.text = "GAME OVER! \n Press SPACE to restart";
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
