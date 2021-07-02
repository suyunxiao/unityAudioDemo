//======================================================================================
/**
 *  时间：2021/7/1 19:27:38
 *  功能：
 *  版权声明：本文为CSDN博主「李本心明」的原创文章，遵循 CC 4.0 BY-SA 版权协议，
 *  转载请附上原文出处链接及本声明。 
 *  作者：李本心明 ：https://blog.csdn.net/KiTok/article/details/72811933 出处：csdn
 */
//======================================================================================

using System;
using System.IO;
using UnityEngine;

namespace Modle
{
    class AudioModle
    {
        /// <summary>
        /// 获取对应平台保存的文件路径
        /// </summary>
        public static string AssetCachesDir
        {
            get
            {
                string dir = "";
#if UNITY_EDITOR
                dir = Application.dataPath + "Caches/";//路径：/AssetsCaches/
#elif UNITY_IOS
            dir = Application.temporaryCachePath + "/";//路径：Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/Library/Caches/
#elif UNITY_ANDROID
            dir = Application.persistentDataPath + "/";//路径：/data/data/xxx.xxx.xxx/files/
#else
            dir = Application.streamingAssetsPath + "/";//路径：/xxx_Data/StreamingAssets/
#endif
                return dir;
            }
        }

        /// <summary>
        /// 保存MP3录音文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="clip"></param>
        /// <returns></returns>
        public static bool SaveWav(string filename, AudioClip clip)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filename));
                using (FileStream fileStream = createEmpty(filename))
                {
                    convertAndWrite(fileStream, clip);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static void convertAndWrite(FileStream fileStream, AudioClip clip)
        {
            float[] samples = new float[clip.samples];

            clip.GetData(samples, 0);
            Int16[] intData = new Int16[samples.Length];
            Byte[] bytesData = new Byte[samples.Length * 2];
            int rescaleFactor = 32767; //to convert float to Int16
            for (int i = 0; i < samples.Length; i++)
            {
                intData[i] = (short)(samples[i] * rescaleFactor);
                Byte[] byteArr = new Byte[2];
                byteArr = BitConverter.GetBytes(intData[i]);
                byteArr.CopyTo(bytesData, i * 2);
            }
            fileStream.Write(bytesData, 0, bytesData.Length);
            writeHeader(fileStream, clip);
        }

        private static void writeHeader(FileStream fileStream, AudioClip clip)
        {
            int hz = clip.frequency;
            int channels = clip.channels;
            int samples = clip.samples;
            fileStream.Seek(0, SeekOrigin.Begin);
            Byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
            fileStream.Write(riff, 0, 4);
            Byte[] chunkSize = BitConverter.GetBytes(fileStream.Length - 8);
            fileStream.Write(chunkSize, 0, 4);
            Byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
            fileStream.Write(wave, 0, 4);
            Byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
            fileStream.Write(fmt, 0, 4);
            Byte[] subChunk1 = BitConverter.GetBytes(16);
            fileStream.Write(subChunk1, 0, 4);
            UInt16 two = 2;
            UInt16 one = 1;
            Byte[] audioFormat = BitConverter.GetBytes(one);
            fileStream.Write(audioFormat, 0, 2);
            Byte[] numChannels = BitConverter.GetBytes(channels);
            fileStream.Write(numChannels, 0, 2);
            Byte[] sampleRate = BitConverter.GetBytes(hz);
            fileStream.Write(sampleRate, 0, 4);
            Byte[] byteRate = BitConverter.GetBytes(hz * channels * 2); // sampleRate * bytesPerSample*number of channels, here 44100*2*2  
            fileStream.Write(byteRate, 0, 4);
            UInt16 blockAlign = (ushort)(channels * 2);
            fileStream.Write(BitConverter.GetBytes(blockAlign), 0, 2);
            UInt16 bps = 16;
            Byte[] bitsPerSample = BitConverter.GetBytes(bps);
            fileStream.Write(bitsPerSample, 0, 2);
            Byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
            fileStream.Write(datastring, 0, 4);
            Byte[] subChunk2 = BitConverter.GetBytes(samples * 2 * channels);
            fileStream.Write(subChunk2, 0, 4);
            fileStream.Close();
        }

        private static FileStream createEmpty(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            byte emptyByte = new byte();
            for (int i = 0; i < 44; i++)
            {
                fileStream.WriteByte(emptyByte);
            }
            return fileStream;
        }
    }
}
