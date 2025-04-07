using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    [SerializeField] private float cooldown = 1.25f;
    private float timeStamp;
    private float nextPickAxeMissSFX;
    private float nextDougSwingSFX;
    private float raycastDistance = 26f;
    private float hitDistance = 3f;
    public bool IsGrounded = false;

    public AudioSource PickAxeHit;
    public AudioSource PickAxeMiss;
    public float PickAxeMissCooldown = 1.0f;
    
    public AudioSource DougSwing;
    public float DougSwingMissCooldown = 1.0f;

    public GameObject rockBreak;
    public float rockBreakdur = .1f;
        
    public BreakableType checkUnbreakable;
    
    public bool TryBreakBlock()
    {
        bool blockBroken = false;
        if (Time.time > timeStamp)
        {
            Vector3 mousePosition = Input.mousePosition;

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mouseWorldPosition.z = 0;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);            
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, raycastDistance))
            {
                float maxDistance = Vector3.Distance(transform.position, hit.point);

                //Debug.Log("ROCKS HERE" + hit.collider.tag);
                if(hit.collider.gameObject.TryGetComponent(out RockVision vision))
                {
                    // TODO: try to color the other rocks here?
                    if (vision != null)
                    {
                        AddToBreakablesStats( vision.GetBreakableType(), 1 );
                    }

                    if(vision.GetBreakableType() != BreakableType.Rock_Unbreakable && maxDistance <= hitDistance)
                    {
                        Destroy(hit.collider.gameObject);
                        PlayAxeHitSFX();
                        GameObject rockBreakVFX = Instantiate(rockBreak, hit.transform.position, Quaternion.identity);

                        Destroy(rockBreakVFX, rockBreakdur);
                        blockBroken = true;

                    }
                    else if(vision.GetBreakableType() == BreakableType.Rock_Unbreakable && maxDistance <= hitDistance)
                    {
                        PlayAxeHitSFX();
                    }
                    if(vision.GetBreakableType() == BreakableType.Rock_Gold && maxDistance <= hitDistance)
                    {
                        GameManager.Instance.GetStatsManager().AddGoldEarned(1);


                        //Debug.Log("im at least in here");
                        Debug.Log(GameManager.Instance.GetStatsManager().playerStats.GoldEarned);
                        //accrue gold here in gameManager & stats
                    }
                }
            }

            //Debug.DrawRay(ray.origin, ray.direction * 26, Color.red, 2f);
            timeStamp = Time.time + cooldown;
        }

        // DO: This logic should move to Player (pukes)
        if (Time.time > nextPickAxeMissSFX)
        {
            if (!blockBroken)
            {
                PlayAxeMissSFX();
                
            }
            nextPickAxeMissSFX = Time.time + PickAxeMissCooldown;
        }

        return blockBroken;
    }

    private void PlayAxeMissSFX()
    {
        PickAxeMiss.Play();
        
        // Special handling to keep Doug's swing SFX less often
        if (Time.realtimeSinceStartup > nextDougSwingSFX)
        {
            DougSwing.Play();
            nextDougSwingSFX = Time.time + DougSwingMissCooldown;
        }
        
    }

    private void PlayAxeHitSFX()
    {
        PickAxeHit.Play();
    }

    private void AddToBreakablesStats( BreakableType type, int amount )
    {
        StatsManager statsManager = GameManager.Instance.GetStatsManager();

        switch (type)
        {
            case BreakableType.Rock_Normal:
                statsManager.AddNormalRocksBroken( amount );
                break;

            case BreakableType.Rock_Hard:
                statsManager.AddHardRocksBroken( amount );
                break;

            case BreakableType.Rock_Gold:
                statsManager.AddGoldRocksBroken( amount );
                break;

            default:
                Debug.LogWarning( "Undefined breakable type." );
                break;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "pickaxe")
        {
            IsGrounded = true;
        }

        if (collision.collider.tag == "Win")
        {
            // Win condition
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "pickaxe")
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "pickaxe")
        {
            IsGrounded = false;
        }
    }

}
