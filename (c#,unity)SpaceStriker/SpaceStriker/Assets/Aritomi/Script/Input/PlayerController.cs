using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// プレイヤーコントローラー
/// 有冨勇帆
/// </summary>
public class PlayerController : Controller
{
    private bool bIsTouch;  //! タッチしているか？
    private Vector3 vec3FirstMousePosition;     //! 最初のマウスの位置
    private Vector3 vec3FinishMousePosition;    //1 マウスを放した位置

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        bIsTouch = false;
        vec3FirstMousePosition = Vector3.zero;
        vec3FinishMousePosition = Vector3.zero;

        base.Initialize();
    }

    /// <summary>
    /// タッチされたときの処理
    /// </summary>
    /// <param name="_vec3TouchPosition"></param>
    private void OnTouchEnter(Vector3 _vec3TouchPosition)
    {
        bIsTouch = true;
        vec3FirstMousePosition = _vec3TouchPosition;
        base.inputState = InputState.TOUCH_TRUE;
    }

    /// <summary>
    /// タッチされているときの処理
    /// </summary>
    private void OnTouchStay()
    {

    }

    /// <summary>
    /// フリックの処理
    /// </summary>
    private void Flick()
    {
        float fFirstX, fFinishX, fDistance;
        fFirstX = vec3FirstMousePosition.x;
        fFinishX = vec3FinishMousePosition.x;
        fDistance = Mathf.Abs(fFinishX - fFirstX);

        if (fDistance > PCConstant.FLICK_RANGE)
        {
            if (fFinishX > fFirstX) 
                base.inputState = InputState.FLICK_RIGHT;
            else 
                base.inputState = InputState.FLICK_LEFT;
        }
    }

    /// <summary>
    /// タッチし終わったときの処理
    /// </summary>
    /// <param name="_vec3TouchPosition"></param>
    private void OnTouchExit(Vector3 _vec3TouchPosition)
    {
        bIsTouch = false;
        vec3FinishMousePosition = _vec3TouchPosition;

        Flick();

        vec3FirstMousePosition = Vector3.zero;
        vec3FinishMousePosition = Vector3.zero;
    }

    /// <summary>
    /// 入力情報の更新
    /// </summary>
    protected override void InputStateUpdate()
    {
        if (!(bIsTouch)) base.inputState = InputState.TOUCH_FALSE;

        Vector3 vec3TouchPosition;

        vec3TouchPosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0)) OnTouchEnter(vec3TouchPosition);
        if (Input.GetMouseButton(0)) OnTouchStay();
        if (Input.GetMouseButtonUp(0)) OnTouchExit(vec3TouchPosition);
    }

    /// <summary>
    /// 右側のボタンを押したときの処理
    /// </summary>
    public void ButtonPushRight()
    {
        base.inputState = InputState.TOUCH_RIGHT;
    }

    /// <summary>
    /// 左側のボタンを押したときの処理
    /// </summary>
    public void ButtonPushLeft()
    {
        base.inputState = InputState.TOUCH_LEFT;
    }

    /// <summary>
    /// 上側のボタンを押したときの処理
    /// </summary>
    public void ButtonPushTop()
    {
        base.inputState = InputState.TOUCH_TOP;
    }

    /// <summary>
    /// 下側のボタンを押したときの処理
    /// </summary>
    public void ButtonPushBottom()
    {
        base.inputState = InputState.TOUCH_BOTTOM;
    }
}