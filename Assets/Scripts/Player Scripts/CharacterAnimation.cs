using UnityEngine;

namespace Player_Scripts
{
    public class CharacterAnimation : MonoBehaviour
    {
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
        //Player Animations
        public void Walk(bool move)
        {
            anim.SetBool(TagManager.AnimationTags.MOVEMENT, move);
        }
        public void Punch_1()
        {
            anim.SetTrigger(TagManager.AnimationTags.PUNCH_1_TRIGGER);
        }
        public void Punch_2()
        {
            anim.SetTrigger(TagManager.AnimationTags.PUNCH_2_TRIGGER);
        }
        public void Punch_3()
        {
            anim.SetTrigger(TagManager.AnimationTags.PUNCH_3_TRIGGER);
        }
        public void Kick_1()
        {
            anim.SetTrigger(TagManager.AnimationTags.KICK_1_TRIGGER);
        }
        public void Kick_2()
        {
            anim.SetTrigger(TagManager.AnimationTags.KICK_2_TRIGGER);
        }
    

        //Enemy Animations
        public void EnemyAttack(int attack)
        {
            if (attack == 0)
            {
                anim.SetTrigger(TagManager.AnimationTags.ATTACK_1_TRIGGER);
            }
            if (attack == 1)
            {
                anim.SetTrigger(TagManager.AnimationTags.ATTACK_2_TRIGGER);
            }
            if (attack == 2)
            {
                anim.SetTrigger(TagManager.AnimationTags.ATTACK_3_TRIGGER);
            }
        }

        public void Play_Idle_Animation()
        {
            anim.Play(TagManager.AnimationTags.IDLE_ANIMATION);
        }

        public void Death()
        {
            anim.SetTrigger(TagManager.AnimationTags.DEATH_TRIGGER);
        }
    }
}
