using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCollision : MonoBehaviour
{
    [SerializeField] private GameObject Floor;
    [SerializeField] private GameObject RockMaker;

    public void OnCollisionEnter(Collision collision)
    {
        Floor.SetActive(false);
        RockMaker.SetActive(true);
    }
}
