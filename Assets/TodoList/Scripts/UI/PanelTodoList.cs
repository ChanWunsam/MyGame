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
    using System.Text;
    using UnityEngine;
    using UnityEngine.UI;
    using QFramework;
    using UniRx;

    //=============================     消息/事件    =========================================

    public enum PanelTodoListEvent
    {
        Start = QMgrID.UI,
        OnTodoItemSelect,
        End,
    }

    public class OnTodoItemSelectMsg : QMsg
    {
        public TodoItem ItemData;

        public OnTodoItemSelectMsg(TodoItem itemData) : base((int)PanelTodoListEvent.OnTodoItemSelect)
        {
            ItemData = itemData;
        }
    }

    //========================================================================================


    public class PanelTodoListData : QFramework.UIPanelData
    {
        // 测试数据
        public TodoList Model = new TodoList()
        {
            TodoItems = new ReactiveCollection<TodoItem>()
            {
                new TodoItem() { Completed = new BoolReactiveProperty(false), Content = new StringReactiveProperty("need to study") },
                new TodoItem() { Completed = new BoolReactiveProperty(false), Content = new StringReactiveProperty("need to have lunch") },
            }
        };
    }


    public partial class PanelTodoList : QFramework.UIPanel
    {
        
        void OnTodoItemAdd(TodoItem itemData)
        {
            Container.AddTodoItem(UITodoItem, itemData);
        }

        void OnTodoItemSelect(TodoItem itemData)
        {
            PanelAddItem.ModifyState(itemData);
        }

        // ==========================================================================

        protected override void RegisterUIEvent()
        {
            base.RegisterUIEvent();
            
            // 点击进入 completed list
            BtnCheckCompleted.onClick.AddListener(() =>
            {
                CloseSelf();
                UIMgr.OpenPanel<PanelCompletedList>(new PanelCompletedListData()
                {
                    Model = mData.Model,
                });
            });
            
        }

        protected override void ProcessMsg(int eventId, QFramework.QMsg msg)
        {
            if (eventId == (int)PanelTodoListEvent.OnTodoItemSelect)
            {
                // 选择todo事件
                var selectMsg = msg as OnTodoItemSelectMsg;
                OnTodoItemSelect(selectMsg.ItemData);
            }
        }
        
        protected override void OnInit(QFramework.IUIData uiData)
        {
            mData = uiData as PanelTodoListData ?? new PanelTodoListData();
            // please add init code here
            Container.GenerateTodoItem(mData.Model, UITodoItem);
            PanelAddItem.Init(mData.Model);

            PanelAddItem.State.Subscribe((state) => 
            {
                if (state == PanelInputState.Create)
                {
                    EventMask.Hide();
                }
                else
                {
                    EventMask.Show();
                }
            });

            mData.Model.TodoItems.ObserveAdd().Subscribe((newitem) =>
            {
                Container.AddTodoItem(UITodoItem, newitem.Value);
            });

            RegisterEvent(PanelTodoListEvent.OnTodoItemSelect);
        }
        
        protected override void OnOpen(QFramework.IUIData uiData)
        {
        }
        
        protected override void OnShow()
        {
        }
        
        protected override void OnHide()
        {
        }
        
        protected override void OnClose()
        {
        }
    }

}
