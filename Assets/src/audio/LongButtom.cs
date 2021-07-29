//======================================================================================
/**
 *  时间：2021/7/1 14:05:01
 *  功能：自定义按钮
 */
//======================================================================================


using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ChatAudio
{
    public class LongButtom : Button,IPointerDownHandler, IPointerUpHandler
    {

        /// <summary>
        /// 按下或者抬起响应
        /// </summary>
        public UnityAction<LongTouchCallType> touchCall;

        /// <summary>
        /// 取消响应
        /// </summary>
        public UnityAction<bool> cancelCall;

        private bool touchState = false;

        private double time = 0;

        private LongTouchCallType longCall = new LongTouchCallType();

        /// <summary>
        /// 按下
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnPointerDown(PointerEventData eventData)
        {
            time = GetTimeStamp();
            longCall.longTouchTime = time;
            longCall.state = true;
            setTouchCallState(longCall);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            longCall.longTouchTime = GetTimeStamp() - time + 1;
            Debug.Log("TouchTime:" + longCall.longTouchTime);
            GetTimeStamp();
            if (eventData.position.y - eventData.pressPosition.y > 50)
            {
                setCancelCall(true);
            }
            else
            {
                longCall.state = false;
                setTouchCallState(longCall);
            }
        }

        //public override void OnPointerExit(PointerEventData eventData)
        //{
        //    setTouchCallState(false);
        //}

        private void setTouchCallState(LongTouchCallType data)
        {
            if(touchState == data.state)
            {
                return;
            }
            touchState = data.state;
            if (touchCall != null)
            {
                touchCall(data);
            }
        }

        private void setCancelCall(bool state)
        {
            if( cancelCall!= null)
            {
                
                cancelCall(state);
            }
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public double GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Math.Round(ts.TotalSeconds);
        }

        public struct LongTouchCallType
        {
            /// <summary>
            /// 按钮状态
            /// </summary>
            public bool state;

            /// <summary>
            /// 长按时间
            /// </summary>
            public double longTouchTime;
        }

    }
}
