using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices.ComTypes;
using Unity.Profiling;
using UnityEngine;

namespace DevDuck
{
    public class Player : MonoBehaviour
    {
        [SerializeField] Vector2 moveDirection;
        [SerializeField] float speed;
        [SerializeField] bool isFacingRight;
        [SerializeField] bool isAttack;
        [SerializeField] Joystick _joyStick;
        public GameObject projectile;
        public int range;
        public List<GameObject> weapons;
        public bool isSword;
        public bool isDart;

        public Rigidbody2D rb;
        public Animator anim;

        float moveX;
        float moveY;

        public int currrentHealth;
        public int maxHealth = 100;

        public LoadingBar healthBar;
        public static Player instance;
        int idWeapon;

        public GameObject enemyPos;
        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            currrentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        void Update()
        {
            ProcessInput();
            Flip();
            //  detectEnemies();
            Attack();
        }

        private void FixedUpdate()
        {
            StatePlayer();
        }

        void ProcessInput()
        {
            moveX = _joyStick.Horizontal;
            moveY = _joyStick.Vertical;
            moveDirection = new Vector2(moveX, moveY).normalized;
        }

        void StatePlayer()
        {
            rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

            if (moveDirection.x != 0f)
            {
                anim.Play("Run");
            }
            else if (moveDirection.x == 0f && !isAttack)
            {
                anim.Play("Idle");
            }
        }
        void Flip()
        {
            if (isFacingRight && moveX > 0f || !isFacingRight && moveX < 0f)
            {
                isFacingRight = !isFacingRight;
                Vector2 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
        float timer;

        public void Attack()
        {
            timer += Time.deltaTime;
            isAttack = false;

            if (timer >= 1f)
            {
                if (!isAttack)
                {
                    timer = 0;
                    isAttack = true;
                   // StartCoroutine(checkAttack());
                    if (EnemiesManager.instance.enemyInScene.Count > 0)
                    {
                        detectEnemies();
                        if (projectile != null && isDetectEnemy)
                        {
                            GameObject bullet = Instantiate(projectile, transform.position/*+ new Vector3(2,0,0)*/, Quaternion.identity);
                        }
                    }

                }
            }
           
        }
        IEnumerator checkAttack()
        {
            yield return new WaitForSeconds(2f);
            isAttack = false;
        }

        public void TakeDamage(int damage)
        {
            currrentHealth -= damage;
            healthBar.SetHealth(currrentHealth);
            if (currrentHealth <= 0)
            {
                //  Debug.Log("PlayerDead");
            }
        }
        public bool isDetectEnemy;
        void detectEnemies()
        {

            for (int i = 0; i < EnemiesManager.instance.enemyInScene.Count; i++)
            {
                float dis = Vector2.Distance(transform.position, EnemiesManager.instance.enemyInScene[i].transform.position);
                if (dis <= 15f)
                {
                    isDetectEnemy = true;
                    enemyPos = EnemiesManager.instance.enemyInScene[i].transform.gameObject;
                }
                else
                {
                    isDetectEnemy = false;
                   // enemyPos =(Vector2) transform.position + new Vector2(Random.Range(1, 5), Random.Range(1, 5));
                    Debug.Log("No enemy here");
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Blade"))
            {
                Destroy(col.gameObject);
                projectile = weapons[0];
                idWeapon = 0;
                ChangeRange();


            }

            if (col.gameObject.CompareTag("Brick"))
            {
                Destroy(col.gameObject);
                projectile = weapons[1];
                idWeapon = 1;
                ChangeRange();
            }



        }

        public void ChangeRange()
        {
            if (idWeapon == 0)
            {
                //brick
                range = 5;
            }
            else if (idWeapon == 1)
            {
                //blade
                range = 6;
            }
            else if (idWeapon == 2)
            {
                range = 7;
            }
            else
            {
                range = 4;
            }
        }
    }

}


