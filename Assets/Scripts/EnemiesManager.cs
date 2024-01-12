using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{
    public class EnemiesManager : MonoBehaviour
    {
        public List<Enemies> enemies;
        public List<DataEnemies> dataEnemies;
        public bool isEnemyGetDamage;
        public int countEnenmyInstantiate;
        public int countEnemiesKilled;
        public int maxEnemyIns;
        public int indexLevel;


        public float timer;
        public Transform heroTransform;
        public Vector3 posToIns;
        public static EnemiesManager instance;

        public List<Enemies> listEnemiesLevel1;
        public List<Enemies> listEnemiesLevel2;
        public List<Enemies> listEnemiesLevel3;

        public List<GameObject> enemyInScene;


        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            // SetDataEnemies();
            // SetMaxEnemies();
        }

        private void Update()
        {
            CalculateTimer();
        }

        void SetMaxEnemies()
        {
            if (indexLevel == 1)
            {
                maxEnemyIns = 50;
            }
            if (indexLevel == 2)
            {
                maxEnemyIns = 70;
            }
            if (indexLevel == 3)
            {
                maxEnemyIns = 100;
            }
        }

        void CalculateTimer()
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                if (countEnenmyInstantiate < maxEnemyIns)
                {
                    countEnenmyInstantiate++;

                    InstantiateEnemy();
                }
                else
                {
                    return;
                }
            }
        }
        public void CheckWinLose()
        {
            if (countEnemiesKilled == maxEnemyIns)
            {
                Debug.Log("Player Winnnn");
            }
        }

        void SetDataEnemies()
        {
            if (indexLevel == 1)
            {
                for (int i = 0; i < listEnemiesLevel1.Count; i++)
                {
                    for (int j = 0; j < dataEnemies.Count; j++)
                    {
                        if (listEnemiesLevel1[i].index == dataEnemies[j].indexEnemy)
                        {
                            listEnemiesLevel1[i].hp = dataEnemies[j].hp;
                            listEnemiesLevel1[i].damage = dataEnemies[j].damageEnemy;
                            listEnemiesLevel1[i].speed = dataEnemies[j].speedEnemy;
                        }
                    }
                }
            }

        }
        void InstantiateEnemy()
        {
            int a = Random.Range(0, listEnemiesLevel1.Count);
            for (int i = 0; i < listEnemiesLevel1.Count; i++)
            {
                if (a == i)
                {
                    posToIns = heroTransform.position * Random.insideUnitCircle * 10;
                    GameObject enemy = Instantiate(listEnemiesLevel1[i].gameObject, posToIns, Quaternion.identity);
                    enemyInScene.Add(enemy);
                    SetDataEnemies();
                }
            }
        }

    }

}

