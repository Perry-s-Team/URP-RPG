using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private GameObject imageGameObject;
    private void changeScene(int _scene)
    {
        SceneManager.LoadScene(_scene);
        Destroy(imageGameObject);
    }
}
