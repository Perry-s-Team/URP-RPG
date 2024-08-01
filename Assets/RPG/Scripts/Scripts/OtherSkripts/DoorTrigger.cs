using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject _imageE;
    [SerializeField] Animator _changeScene;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _imageE?.SetActive(true);
            print("E");

            if (Input.GetKey(KeyCode.E))
            {
                _changeScene.SetBool("Fade", true);
                print("E");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            if(_imageE !=  null)
            _imageE?.SetActive(false);
    }
}
