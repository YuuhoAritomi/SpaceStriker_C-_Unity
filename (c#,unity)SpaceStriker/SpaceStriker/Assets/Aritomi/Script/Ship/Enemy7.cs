﻿using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// エネミー７
    /// </summary>
    public class Enemy7 : Enemy
    {
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_7_HP;
            offensivePower  = Status.ENEMY_SHIP_7_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_7_AI;

            base.Initialize();
        }
    }
}