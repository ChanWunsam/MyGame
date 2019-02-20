/****************************************************************************
 * 2019.2 sysu_wuzh’s Mac mini
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MyGame
{
	public partial class UIUsrCardsArea : UIElement
	{
		public InitCard Model = new InitCard();

		public void Init(UICard CardPrefab, InitCard model)
		{
			Model = model;
			Model.Cards.ForEach(card =>
			{
				CardPrefab.Instantiate()
					.Parent(Container)
					.LocalIdentity()
					.ApplySelfTo(self => self.Init(card))
					.Show();
				
			});
		}
		
		private void Awake()
		{

		}

		protected override void OnBeforeDestroy()
		{
		}
	}
}