using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private int NumPin = 0;
    private bool openDoor = false; // điều kiện mở cửa
    private int pinOn; // Số lượng pin đã được kích hoạt
    void Start()
    {
        pinOn = 0; // mặc định là chưa có pin nào kích hoạt
    }

    void Update()
    {
        //Restart level
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // Có thể mở cửa khi số pin được kích hoạt bằng số lượng pin có trong level đó
        openDoor = NumPin==pinOn?true:false; 
    }
    public void updatePin(int x)
    {
        pinOn+=x;
    }
    public int numPin() { return NumPin; }
    public bool isOpenDoor() { return openDoor; }
}
