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
	public partial class UICard : UIElement, IDragHandler
	{
		public Card Model = new Card();
		
		public void Init(Card model)
		{
			Model = model;


			AreaClick.OnDragAsObservable();


//			AreaClick.OnDragAsObservable().Subscribe((e) =>
//			{
//				
//				this.LocalPosition(e.position); 
//				Debug.Log(e.position);
//			});
		}

		private void Drag(PointerEventData )

		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}
	}
}