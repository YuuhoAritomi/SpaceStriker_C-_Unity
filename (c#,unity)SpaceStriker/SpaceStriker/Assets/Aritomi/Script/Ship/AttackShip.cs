using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// アタックタイプの機体
    /// 有冨勇帆
    /// </summary>
    public class AttackShip : Player
    {
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            // ステータス初期化
            hp = Status.ATTACK_SHIP_HP;
            offensivePower = Status.ATTACK_SHIP_OFFENSIVE_POWER;

            base.Initialize();
        }

        /// <summary>
        /// 特殊行動
        /// </summary>
        protected override void ActSpecial()
        {
            // 何もしない
        }
    }
}
