using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool is_Player, is_Enemy;

    public GameObject hit_FX_prefab;
 
    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }
    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        if (hit.Length > 0)
        {
            if (is_Player)
            {
                Vector3 hitFx_Pos = hit[0].transform.position;
                hitFx_Pos.y += 1.3f;
                if (hit[0].transform.forward.x > 0)
                {
                    hitFx_Pos.x += 0.3f;
                }else if (hit[0].transform.forward.x < 0)
                {
                    hitFx_Pos.x -= 0.3f;
                }
                Instantiate(hit_FX_prefab, hitFx_Pos, Quaternion.identity);
            }
            print("damage " + hit[0].gameObject.name);
            gameObject.SetActive(false);
        }
          
    }
}
