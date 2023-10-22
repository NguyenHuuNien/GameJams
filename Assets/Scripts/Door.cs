using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject iconKeyE;
    private bool nextScene = false;
    private static string prevDoor;
    // Start is called before the first frame update
    void Start()
    {
        iconKeyE.SetActive(false);
        if (prevDoor == "DoorNext")
        {
            if(gameObject.tag == "DoorBack")
                FindObjectOfType<Player>().gameObject.transform.position = transform.position;
        }
        else if (prevDoor == "DoorBack")
        {
            if(gameObject.tag == "DoorNext")
                FindObjectOfType<Player>().gameObject.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(nextScene)
        {
            if(this.gameObject.tag == "DoorNext")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else if (this.gameObject.tag == "DoorBack")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }
            }
        }   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            iconKeyE.SetActive(true);
            prevDoor = this.gameObject.tag;
            nextScene = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            iconKeyE.SetActive(false);
            nextScene = false;
        }
    }
}
