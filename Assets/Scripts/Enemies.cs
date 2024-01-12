using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Xml;
using TreeEditor;
using System.Data.Common;
 namespace DevDuck 
{
    public class Enemies : MonoBehaviour
    {
        public int index;
        public int hp;
        public int damage;
        public int speed;
        public bool isDead;
        public Animator anim;
        public List<GameObject> gift;
        bool isEnemyAttack;
        BoxCollider2D _col;


        void Start()
        {
            anim = GetComponent<Animator>();
            _col = GetComponent<BoxCollider2D>();
        }
        // Update is called once per frame
        void Update()
        {
            EnemyMovement();
            Flip();
        }
        void EnemyMovement()
        {
            if (EnemiesManager.instance.heroTransform != null && !isDead)
            {
                // Calculate the direction vector towards the player
                Vector3 direction = EnemiesManager.instance.heroTransform.position - transform.position;
                // Normalize the direction vector
                direction.Normalize();
                // Move the enemy in the calculated direction
                transform.position += direction * speed * Time.deltaTime;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("BrickProjectile"))
            {
               hp -= 4;

                CheckHp();
            }

            if (collision.gameObject.CompareTag("BladeProjectile"))
            {
                hp -= 2;
                CheckHp();
            }

            /*  if (collision.gameObject.CompareTag("DroneProjectile"))
              {
                  hp -= 1;
                  CheckHp();
              }*/

            if (collision.gameObject.CompareTag("Player"))
            {
                Player.instance.currrentHealth -= damage;
            }
        }

        void CheckHp()
        {
            if (hp <= 0)
            {
                isDead = true;
                anim.Play($"Dead{index + 1}");
                _col.enabled = false;
                Destroy(this.gameObject, 1f);
                EnemiesManager.instance.enemyInScene.Remove(this.gameObject);
                EnemiesManager.instance.countEnemiesKilled++;
                EnemiesManager.instance.CheckWinLose();

            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {

                if (!isEnemyAttack)
                {
                    Debug.Log("Player Get Damage");
                    StartCoroutine(TimeToAttackPlayer());
                    isEnemyAttack = true;
                    //Player.instance.currrentHealth -= damage;
                    Player.instance.TakeDamage(damage);
                }

            }
        }
        IEnumerator TimeToAttackPlayer()
        {
            yield return new WaitForSeconds(0.5f);
            isEnemyAttack = false;
        }

        void InstantiateGift()
        {
            //int randf = Random.Range(0, 10);
            int randf = 0;
            if (isDead)
            {
                if (index == 0 && randf == 0)
                {
                    GameObject gifts = Instantiate(gift[0], transform.position, Quaternion.identity);
                }
                if (index == 1)
                {

                }
            }

        }
        private void Flip()
        {
            Vector2 localScale = transform.localScale;
            if ((EnemiesManager.instance.heroTransform.position.x + 0.1f) >= transform.position.x)
            {
                localScale.x = 1f;
                transform.localScale = localScale;
            }
            else
            {
                localScale.x = -1;
                transform.localScale = localScale;
            }
        }


    }

}


