/****************************************************************************
 * 2019.2 sysu_wuzh’s Mac mini
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace QFramework.MyGame
{
    public enum UICardState     // todo 是否可以做成响应式
    {
        ActivateCard,
        DeactivateCard,
    }

    public enum UICardType
    {
        OwnerCard,
        EnemyCard,
        PopCard,
    }

	public partial class UICard : UIElement
	{
		public Card Model = new Card();
        public UICardState State;
        public UICardType Type; 
        bool isDrag = false;


		public void Init(Card model, UICardState state, UICardType type)
		{
			Model = model;
            State = state;
            Type = type;

            MP_need.text = "消耗MP：" + Model.MP_need.ToString();
            HP_damage.text = "攻击HP：" + Model.HP_damage.ToString();

            RegisterUIEvent();
        }

        void RegisterUIEvent()
        {
            AreaClick.OnPointerEnterAsObservable().Subscribe((e) =>
            {
                UICardShow.Show();
            });

            AreaClick.OnPointerExitAsObservable().Subscribe((e) =>
            {
                UICardShow.Hide();
            });

            AreaClick.OnDragAsObservable().Subscribe((e) =>
            {
                if (State == UICardState.DeactivateCard)
                {
                    return;
                }
                UICardShow.Hide();
                Vector3 point = e.pressEventCamera.ScreenToWorldPoint(e.position);
                // todo UI闪动
                this.Position(point.x, point.y, this.Transform.position.z);
            });

            AreaClick.OnEndDragAsObservable().Subscribe((e) =>
            {
                if (State == UICardState.DeactivateCard)
                {
                    return;
                }
                
                if (this.Type == UICardType.OwnerCard)
                {
                    SendMsg(new OnUsrCardsDragMsg(this.Model));
                }
                else if (this.Type == UICardType.EnemyCard)
                {
                    SendMsg(new OnEnemyCardDragMsg(this.Model));
                }
            });
        }

		protected override void OnBeforeDestroy()
		{
            Model = null;
		}
    }
}