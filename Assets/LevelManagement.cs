using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{
    public class LevelManagement : MonoBehaviour
    {
        public List<map> maps;
        map mapins;
        public int curLevel;
        public Transform parent;
        public static LevelManagement ins;
        private void Awake()
        {
            ins = this;
        }
        void Start()
        {

            increaseLevel();
        }
        void increaseLevel()
        {
            curLevel = PlayerPrefs.GetInt("indexLevel");
            foreach (map levelid in maps)
            {
                if (levelid.mapId == curLevel)
                {
                    mapins = Instantiate(levelid, parent);
                    mapins.transform.position = Vector3.zero;
                    Debug.Log("ins map");
                }

            }
        }
    }
}
