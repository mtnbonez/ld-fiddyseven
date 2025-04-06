using UnityEngine;

public class IntroPlayerAnimation : MonoBehaviour
{

    [SerializeField] public bool firstboot = false;
    private Animation anim;
    public AnimationClip PlayIntro;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        anim = gameObject.GetComponent<Animation>();

        if (firstboot)
        {
            anim.clip = PlayIntro;
            anim.Play();
        }
    }

}
