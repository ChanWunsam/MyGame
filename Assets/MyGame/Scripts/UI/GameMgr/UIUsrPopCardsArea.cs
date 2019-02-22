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

	public partial class UIUsrPopCardsArea : UIElement
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

        public void OnPopCardNumPlus(UICard CardPrefab, Card data)
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
            AreaClick.transform.SetSiblingIndex(this.transform.childCount - 1); // 将AreaClick设置为子物体顺序最后
        }

        public void OnPopCardNumMinus(Card data)
        {
            UICard card = FromDataToCardDict[data];
            FromDataToCardDict.Remove(data);
            card.DestroyGameObj();
            Model.Data.Remove(data);
            distance = (right_point - left_point) / (Model.Data.Count + 1);
            for (int i = 0; i < Model.Data.Count - 1; i++)
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
                    .ApplySelfTo(self => self.Init(data, UICardState.InPop))
                    .Show();
        }


        public PopCardsAreaState State;

        private void Awake()
		{
            State = PopCardsAreaState.Normal;

            // todo 需优化，第一下不能响应
            AreaClick.OnPointerEnterAsObservable().Subscribe((e) =>
            {
                State = PopCardsAreaState.OnEnterTrigger;
            });

        }

		protected override void OnBeforeDestroy()
		{
            this.DestroyAllChild();
        }
	}
}