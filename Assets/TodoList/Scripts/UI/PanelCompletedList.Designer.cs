// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace QFramework.TodoList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    public partial class PanelCompletedList
    {
        
        public const string NAME = "PanelCompletedList";
        
        [SerializeField()]
        public RectTransform Container;
        
        [SerializeField()]
        public UICompletedItem UICompletedItem;
        
        [SerializeField()]
        public Button BtnCheckTodo;
        
        private PanelCompletedListData mPrivateData = null;
        
        public PanelCompletedListData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new PanelCompletedListData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            Container = null;
            UICompletedItem = null;
            BtnCheckTodo = null;
            mData = null;
        }
    }
}
