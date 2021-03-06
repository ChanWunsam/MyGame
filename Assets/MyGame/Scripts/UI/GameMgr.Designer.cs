// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace QFramework.MyGame
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    public partial class GameMgr
    {
        
        public const string NAME = "GameMgr";
        
        [SerializeField()]
        public Timer Timer;
        
        [SerializeField()]
        public UIUsrMsg UIUsrMsg;

        [SerializeField()]
        public UIEnemyMsg UIEnemyMsg;

        [SerializeField()]
        public UICard UICard;
        
        [SerializeField()]
        public UIUsrCardsArea UIUsrCardsArea;
        
        [SerializeField()]
        public UIPopCardsArea UIPopCardsArea;
        
        [SerializeField()]
        public UIEnemyCardsArea UIEnemyCardsArea;
        
        private GameMgrData mPrivateData = null;
        
        public GameMgrData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new GameMgrData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            Timer = null;
            UIUsrMsg = null;
            UIEnemyMsg = null;
            UICard = null;
            UIUsrCardsArea = null;
            UIPopCardsArea = null;
            UIEnemyCardsArea = null;
            mData = null;
        }
    }
}
