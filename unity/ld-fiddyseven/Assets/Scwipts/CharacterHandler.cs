using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    [SerializeField] private float pickAxeCooldown = 0.01f;
    [SerializeField] private float damageBlockCooldown = 0.2f;
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
    public GameObject rockBreakGold;
    public float rockBreakdur = .1f;
        
    public BreakableType checkUnbreakable;

    private float HitDistanceWithMultipliter => hitDistance * GameManager.Instance.GetAttackRangeBuffMultiplier();

    public bool TryBreakBlock()
    {
        bool blockBroken = false;
        if (Time.realtimeSinceStartup > timeStamp)
        {
            bool blockWasDamage = false;
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
                    if(vision.GetBreakableType() != BreakableType.Rock_Unbreakable && maxDistance <= HitDistanceWithMultipliter)
                    {
                        // TODO: have this modified by an ability
                        vision.HealthValue -= 1;
                       

                        if (vision.HealthValue <= 0)
                        {
                            //GameManager.Instance.GetStatsManager().AddNormalRocksBroken(1);


                            AddToBreakablesStats(vision.GetBreakableType(), 1);
                            Destroy(hit.collider.gameObject);
                            PlayAxeHitSFX();
                            

                            if (vision.GetBreakableType() == BreakableType.Rock_Gold)
                            {
                                GameManager.Instance.GetStatsManager().AddGoldEarned(1);
                                GameObject rockBreakVFX = Instantiate(rockBreakGold, hit.transform.position, Quaternion.identity);
                                Destroy(rockBreakVFX, rockBreakdur);
                            }
                            else
                            {
                                GameObject rockBreakVFX = Instantiate(rockBreak, hit.transform.position, Quaternion.identity);
                                Destroy(rockBreakVFX, rockBreakdur);
                            }
                                
                            blockBroken = true;
                        }
                        else
                        {
                            vision.PaintDamage();
                            blockWasDamage = true;
                        }
                    }
                    else if(vision.GetBreakableType() == BreakableType.Rock_Unbreakable && maxDistance <= HitDistanceWithMultipliter)
                    {
                        //PlayAxeHitSFX();
                    }
                }
            }

            //Debug.DrawRay(ray.origin, ray.direction * 26, Color.red, 2f);
            timeStamp = Time.realtimeSinceStartup + pickAxeCooldown;
            if (blockWasDamage)
            {
                timeStamp += damageBlockCooldown;
            }
        }

        // DO: This logic should move to Player (pukes)
        if (Time.realtimeSinceStartup > nextPickAxeMissSFX)
        {
            if (!blockBroken)
            {
                PlayAxeMissSFX();
                nextPickAxeMissSFX = Time.realtimeSinceStartup + PickAxeMissCooldown;
            }
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
            nextDougSwingSFX = Time.realtimeSinceStartup + DougSwingMissCooldown;
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
