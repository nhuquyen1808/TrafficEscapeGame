using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{
    public class LevelManagement : MonoBehaviour
    {
        public List<GameObject> maps;
        public int curLevel;

        public void InsMap()
        {
            if(curLevel == 0)
            {
                for(int i = 0; i < maps.Count; i++)
                {
                    GameObject map = Instantiate(maps[i]);
                }
            }
        }
    }
}
