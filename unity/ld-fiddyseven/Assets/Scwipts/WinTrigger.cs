using UnityEngine;

public class WinTrigger : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.TryGetComponent<LavaStripsHandler>(out LavaStripsHandler test))
        {
            GameManager.Instance.LevelCompleted += 1;

            //GameManager.Instance.SwitchScene_Shop();
            if (GameManager.Instance.LevelCompleted >= GameManager.Instance.GetNumOfScenes())
            {
                GameManager.Instance.LevelCompleted = 0;
            }

            GameManager.Instance.SwitchSceneToIndex(GameManager.Instance.LevelCompleted);
            
            Debug.Log("Level trigger was hit by " + collision.gameObject.name);
        }

    } 

}

