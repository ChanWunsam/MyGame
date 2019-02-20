using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace QFramework.MyGame
{
    public class App : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            ResMgr.Init();
            UIMgr.SetResolution(1024, 768, 0);

            UIMgr.OpenPanel<MyGameBg>();
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

    public class InitCard
    {
        public List<Card> Cards = new List<Card>();
    }

    public class Card
    {
        public string name = "万智卡";
        public int MP_need = 0;
        public int HP_damage = 0;
    }
}
