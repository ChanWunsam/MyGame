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
    
    
    public partial class MyGameBg
    {
        
        public const string NAME = "MyGameBg";
        
        [SerializeField()]
        public UIUsrCardsArea UIUsrCardsArea;
        
        [SerializeField()]
        public UICard UICard;
        
        private MyGameBgData mPrivateData = null;
        
        public MyGameBgData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new MyGameBgData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            UIUsrCardsArea = null;
            UICard = null;
            mData = null;
        }
    }
}