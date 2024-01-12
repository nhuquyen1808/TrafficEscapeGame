using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using DG.Tweening;

namespace DevDuck 
{
    public class Projectile : MonoBehaviour
    {
        public Animator anim;

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
/*            Vector2 posE = Player.instance.enemyPos.transform.position - this.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, posE, 20 * Time.deltaTime);
            if (transform.position == (Vector3)Player.instance.enemyPos.transform.position)
            {
                anim.Play("DestroyProjectile");
                Destroy(this.gameObject, 0.3f);
            }*/
            transform.DOMove(Player.instance.enemyPos.transform.position, 0.5f).OnComplete(() =>
            {
                anim.Play("DestroyProjectile");
                Destroy(this.gameObject, 0.3f);
            });
        }
    }

}

