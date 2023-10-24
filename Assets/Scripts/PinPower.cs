using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPower : MonoBehaviour
{
    [SerializeField] private Sprite sp_NotElectric;
    [SerializeField] private Sprite sp_Electric;
    [SerializeField] private GameObject sprite;
    [SerializeField] private GameController gameController;

    // Nếu Pin chạm vào Power sẽ tăng số lượng pin đã kích hoạt lên
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Electric")
        {
            sprite.GetComponent<SpriteRenderer>().sprite = sp_Electric; // thay đổi sprite của Power
            gameController.updatePin(1);
        }
    }

    // Nếu Pin rời Power sẽ giảm số lượng pin đã kích hoạt lên
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Electric")
        {
            sprite.GetComponent<SpriteRenderer>().sprite = sp_NotElectric;
            gameController.updatePin(-1);
        }
    }
}
