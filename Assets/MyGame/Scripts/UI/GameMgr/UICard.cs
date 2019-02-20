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
	public partial class UICard : UIElement
	{
		public Card Model = new Card();
		
		public void Init(Card model)
		{
			Model = model;
        }

		private void Awake()
		{
            AreaClick.OnClickAsObservable().Subscribe((on) =>
            {
                Debug.Log("click");
            });

            AreaClick.OnDragAsObservable().Subscribe((e) =>
            {
                Debug.Log("drag");
            });
		}

		protected override void OnBeforeDestroy()
		{
		}
    }
}