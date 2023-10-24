using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject iconKeyE;
    private bool nextScene = false; // lưu khả năng của trạng thái có thể chuyển màn

    // tạo biến static prevDoor để lưu tên của cửa trước (cửa mà người chơi đi vào ở scene trước)
    private static string prevDoor = "DoorBack"; // để static để khi chuyển scene vẫn lưu
    private bool openDoor = true; // Mặc định cửa mở (Cho trường hợp ko level không có pin)
    void Start()
    {
        iconKeyE.SetActive(false);
        if (prevDoor == "DoorNext") // nếu như cửa trước là cửa vào, thì ở scene này, người chơi phải ở cửa ra
        {
            if (gameObject.tag == "DoorBack")
                FindObjectOfType<Player>().gameObject.transform.position = transform.position;
        }
        else if (prevDoor == "DoorBack") // ngược lại
        {
            if (gameObject.tag == "DoorNext")
                FindObjectOfType<Player>().gameObject.transform.position = transform.position;
        }
    }

    void Update()
    {
        if (FindObjectOfType<GameController>().numPin() > 0) // Nếu level có pin, update khả năng mở cửa
            openDoor = FindObjectOfType<GameController>().isOpenDoor();
        if (nextScene)
        {
            if (this.gameObject.tag == "DoorNext") // nếu là cửa next thì nhảy đến scene tiếp theo
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    prevDoor = this.gameObject.tag;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else if (this.gameObject.tag == "DoorBack") // nếu là cửa back thì quay về scene trước đó
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    prevDoor = this.gameObject.tag;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && openDoor)
        {
            iconKeyE.SetActive(true);
            nextScene = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && openDoor)
        {
            iconKeyE.SetActive(false);
            nextScene = false;
        }
    }
}