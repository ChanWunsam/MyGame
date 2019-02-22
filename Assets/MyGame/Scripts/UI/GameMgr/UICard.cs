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
    public enum UICardState
    {
        InHand,     // 手牌区
        InPop,      // 出牌区
    }

	public partial class UICard : UIElement
	{
		public Card Model = new Card();
        public UICardState State;
        bool isDrag = false;


		public void Init(Card model, UICardState state)
		{
			Model = model;
            State = state;
        }

		private void Awake()
		{
            //AreaClick.OnMouseEnterAsObservable().Subscribe((e) =>
            //{
            //    Debug.Log("enter");
            //});

            AreaClick.OnPointerEnterAsObservable().Subscribe((e) =>
            {
                if (State == UICardState.InPop)
                {
                    return;
                }
                UICardShow.Show();
            });

            AreaClick.OnPointerExitAsObservable().Subscribe((e) =>
            {
                if (State == UICardState.InPop)
                {
                    return;
                }
                UICardShow.Hide();
            });

            AreaClick.OnDragAsObservable().Subscribe((e) =>
            {
                //Debug.Log(e.position);
                if (State == UICardState.InPop)
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
                // todo
                if (State == UICardState.InPop)
                {
                    return;
                }
                Vector3 point = e.pressEventCamera.ScreenToWorldPoint(e.position);
                SendMsg(new OnUsrCardDragMsg(this.Model));
            });
		}

		protected override void OnBeforeDestroy()
		{
            Model = null;
		}
    }
}