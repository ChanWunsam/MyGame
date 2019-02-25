/****************************************************************************
 * 2019.2 DESKTOP-UFLMNH7
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UniRx;
using UniRx.Triggers;

namespace QFramework.MyGame
{
    public enum PopCardsAreaState
    {
        Normal,
        OnEnterTrigger,
    }

	public partial class UIPopCardsArea : UIElement
	{
        public CardList Model = new CardList();

        public int left_point = -250;
        public int right_point = 250;
        private int distance;

        public PopCardsAreaState State;

        Dictionary<Card, UICard> FromDataToCardDict = new Dictionary<Card, UICard>();
      
        private void Awake()
		{
            State = PopCardsAreaState.Normal;

            // todo 需优化，第一下不能响应
            AreaClick.OnPointerEnterAsObservable().Subscribe((e) =>
            {
                State = PopCardsAreaState.OnEnterTrigger;
            });

        }

        public void OnCardNumPlus(UICard CardPrefab, Card data)
        {
            int index = 0;
            UICard card = null;
            distance = (right_point - left_point) / (Model.Data.Count + 2); // 预留一个位置给新Card
            for (; index < Model.Data.Count; index++)
            {
                if (FromDataToCardDict.TryGetValue(Model.Data[index], out card))
                {
                    card.LocalIdentity()
                        .LocalPositionX(left_point + distance * (index + 1));
                }
                else
                {
                    Log.E("找不到key");
                }
            }
            Model.Data.Add(data);
            CreateCard(CardPrefab, data, index);
            AreaClick.transform.SetSiblingIndex(this.transform.childCount - 1); // 将AreaClick设置为子物体顺序最后
        }

        public void OnPopCardsClear()
        {
            FromDataToCardDict.Values.ForEach((card) =>
            {
                card.DestroyGameObj();
            });
            FromDataToCardDict.Clear();
            Model.Data.Clear();
            Log.I("Clear All Pop Card");
        }

        // index 从0开始
        void CreateCard(UICard CardPrefab, Card data, int index)
        {
            CardPrefab.Instantiate()
                    .Parent(this)
                    .LocalIdentity()
                    .LocalPositionX(left_point + distance * (index + 1))
                    .ApplySelfTo(self => FromDataToCardDict.Add(data, self))
                    .ApplySelfTo(self => self.Init(data, UICardState.DeactivateCard))
                    .Show();
        }


		protected override void OnBeforeDestroy()
		{
            this.DestroyAllChild();
        }
	}
}