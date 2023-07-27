using UnityEngine;

namespace Player_Scripts
{
    public class AttackUnversal : MonoBehaviour
    {

        public LayerMask collisionplayer;

        public float radious = 1f;
        public float damage = 2f;

        public bool isplayer, is_enemy;

        public GameObject hit_FX;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            DetectCollision();
        }

        void DetectCollision()
        {
            Collider[] hit = Physics.OverlapSphere(transform.position, radious, collisionplayer);

            if (hit.Length > 0)
            {
                if (isplayer)
                {
                    Vector3 hitFX_pos = hit[0].transform.position;
                    hitFX_pos.y += 1.3f;

                    if (hit[0].transform.forward.x > 0)
                    {
                        hitFX_pos.x += 0.3f;
                    } else if (hit[0].transform.forward.x < 0)
                    {
                        hitFX_pos.x -= 0.3f;
                    }

                    Instantiate(hit_FX, hitFX_pos, Quaternion.identity);
                }
                
                gameObject.SetActive(false); 
            }
        }
    }
}
