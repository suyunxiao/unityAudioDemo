//======================================================================================
/**
 *  时间：2021/7/1 11:17:41
 *  功能：聊天的语音频道
 */
//======================================================================================

using Modle;
using UnityEngine;
using UnityEngine.UI;

namespace ChatAudio
{
    class ChatAudioSource : MonoBehaviour
    {
        /// <summary>
        /// 音频组件
        /// </summary>
        //[AttComInfo ("AudioSource")]
        public AudioSource audioSource;

        /// <summary>
        /// 录音按钮
        /// </summary>
        //[AttComInfo ("DeviceBtn")]
        public LongButtom deviceBtn;

        /// <summary>
        /// 录音状态
        /// </summary>
        public Text audioStateText;


        public AudioClip audioTest;

        /// <summary>
        /// 播放MP3
        /// </summary>
        public Button playMp3;

        /// <summary>
        /// 路径
        /// </summary>
        public Text pathUrl;

        /// <summary>
        /// 录音频率
        /// </summary>
        private string _frequency = "44100";

        /// <summary>
        /// 录音最大时长
        /// </summary>
        private int _maxAudioTime = 200;

        protected void OnEnable ()
        {
            addEventList ();
            Application.RequestUserAuthorization(UserAuthorization.Microphone);
        }

        protected void OnDisable ()
        {
            removeEventList ();
        }

        private void addEventList ()
        {
            deviceBtn.touchCall = onTouchAudioState;
            playMp3.onClick.AddListener(onPlayMp3);
        }

        private void removeEventList ()
        {
            deviceBtn.touchCall = null;
            playMp3.onClick.RemoveListener(onPlayMp3);
        }

        /// <summary>
        /// 是否存在麦克风设备
        /// </summary>
        public bool GetMicrophoneDevice ()
        {
            bool isHave = true;
            string [] mDevice = Microphone.devices;
            if ( mDevice.Length == 0 )
            {
                isHave = false;
                audioStateText.text = "找不到麦克风设备";
            }
            return isHave;
        }

        private void onTouchAudioState(bool state)
        {
            if(state)
            {
                audioStateText.text = "按下";
                beginRecording();
            }
            else
            {
                audioStateText.text = "抬起";
                stopRecording();
            }
        }

        private void onPlayMp3()
        {
            //保存录音
            string path = $"{AudioModle.AssetCachesDir}/audio/world/Audio2021Uid001.mp3";
            if (audioSource.clip != null)
            {
                AudioModle.SaveWav(path, audioSource.clip);
            }
            else
            {
                audioStateText.text = "not find clip ,please touch startAudio bottom";
            }
        }

        private void beginRecording()
        {
            if (!GetMicrophoneDevice())
            {
                return;
            }
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.mute = true;
            audioStateText.text = "开始录音";
            audioSource.clip = Microphone.Start(null, true, _maxAudioTime, int.Parse(_frequency));
            audioSource.Play();
        }

        private void stopRecording()
        {
            if (!Microphone.IsRecording(null))
            {
                return;
            }
            Microphone.End(null);
            audioSource.Stop();
            playAudio(audioSource.clip,new Vector3());
        }

        private void playAudio(AudioClip clip, Vector3 pos)
        {
            if( clip != null )
            {
                audioStateText.text = "开始播放录音";
                AudioSource.PlayClipAtPoint(clip, pos);
            }
            else
            {
                audioStateText.text = "录音clip不存在";
            }
        }

    }
}
