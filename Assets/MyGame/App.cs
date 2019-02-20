using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace QFramework.MyGame
{
    public class App : MonoBehaviour
    {
        InitCard Model = new InitCard()
        { 
            Cards = new List<Card>()
            {
                new Card() {HP_damage = 10, MP_need = 10},
                new Card() {HP_damage = 10, MP_need = 10},
                new Card() {HP_damage = 10, MP_need = 10},
            }
        };
    

        // Use this for initialization
        void Start()
        {
            ResMgr.Init();
            UIMgr.SetResolution(1024, 768, 0);

            UIMgr.OpenPanel<GameMgr>(new GameMgrData()
            {
                Model = Model,
            });
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
