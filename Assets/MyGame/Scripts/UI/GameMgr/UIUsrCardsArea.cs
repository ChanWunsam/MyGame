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
		public CardList Model = new CardList();

        public int left_point = -250;
        public int right_point = 250;
        private int distance;
        
        Dictionary<Card, UICard> FromDataToCardDict = new Dictionary<Card, UICard>();

        public void Init(UICard CardPrefab, CardList model)
        {
            Model = model;
            distance = (right_point - left_point) / (Model.Data.Count + 1);
            for (int i = 0; i < model.Data.Count; i++)
            {
                Card data = model.Data[i];
                CreateCard(CardPrefab, data, i);
            }
        }

        public void OnUsrCardNumPlus(UICard CardPrefab, Card data)
        {
            int index = 0;
            UICard card = null;
            distance = (right_point - left_point) / (Model.Data.Count + 2); // 预留一个位置给新Card
            for (; index < Model.Data.Count; index++)
            {
                if (FromDataToCardDict.TryGetValue(Model.Data[index], out card))
                {
                    card.LocalPositionX(left_point + distance * (index + 1));
                }
                else
                {
                    Debug.Log("找不到key");
                }
            }
            Model.Data.Add(data);
            CreateCard(CardPrefab, data, index);
        }

        public void OnUsrCardNumMinus(Card data)
        {
            UICard card = FromDataToCardDict[data];
            Model.Data.Remove(data);
            FromDataToCardDict.Remove(data);
            card.DestroyGameObj();
            distance = (right_point - left_point) / (Model.Data.Count + 1);
            for (int i = 0; i < Model.Data.Count; i++)
            {
                FromDataToCardDict[Model.Data[i]].LocalPositionX(left_point + distance * (i + 1));
            }
        }

        // index 从0开始
        void CreateCard(UICard CardPrefab, Card data, int index)
        {
            CardPrefab.Instantiate()
                    .Parent(this)
                    .LocalIdentity()
                    .LocalPositionX(left_point + distance * (index + 1))
                    .ApplySelfTo(self => FromDataToCardDict.Add(data, self))
                    .ApplySelfTo(self => self.Init(data, UICardState.InHand))
                    .Show();
        }

        private void Awake()
		{

		}

		protected override void OnBeforeDestroy()
		{
            this.DestroyAllChild();
		}
	}
}