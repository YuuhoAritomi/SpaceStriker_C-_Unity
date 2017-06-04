using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// エネミー１
    /// 有冨勇帆
    /// </summary>
    public class Enemy1 : Enemy
    {
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_1_HP;
            offensivePower  = Status.ENEMY_SHIP_1_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_1_AI;

            base.Initialize();
        }
    }
}