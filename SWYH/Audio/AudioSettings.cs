﻿/*
 *	 Stream What Your Hear
 *	 Assembly: SWYH
 *	 File: AudioSettings.cs
 *	 Web site: http://www.streamwhatyouhear.com
 *	 Copyright (C) 2012-2015 - Sebastien Warin <http://sebastien.warin.fr>	   	
 *
 *   This file is part of Stream What Your Hear.
 *	 
 *	 Stream What Your Hear is free software: you can redistribute it and/or modify
 *	 it under the terms of the GNU General Public License as published by
 *	 the Free Software Foundation, either version 2 of the License, or
 *	 (at your option) any later version.
 *	 
 *	 Stream What Your Hear is distributed in the hope that it will be useful,
 *	 but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *	 GNU General Public License for more details.
 *	 
 *	 You should have received a copy of the GNU General Public License
 *	 along with Stream What Your Hear. If not, see <http://www.gnu.org/licenses/>.
 */

namespace SWYH.Audio
{
    using SWYH.Properties;

    internal static class AudioSettings
    {
        public static uint GetMP3Bitrate()
        {
            return Settings.Default.Mp3Bitrate;
        }

        public static NAudio.Wave.WaveFormat GetAudioFormat()
        {
            switch (Settings.Default.CaptureFormat)
            {
                case "Pcm32kHz16bitMono":
                    return AudioFormats.Pcm32kHz16bitMono;
                case "Pcm32kHz16bitStereo":
                    return AudioFormats.Pcm32kHz16bitStereo;
                case "Pcm44kHz16bitMono":
                    return AudioFormats.Pcm44kHz16bitMono;
                case "Pcm44kHz16bitStereo":
                    return AudioFormats.Pcm44kHz16bitStereo;
                case "Pcm48kHz16bitMono":
                    return AudioFormats.Pcm48kHz16bitMono;
                case "Pcm48kHz16bitStereo":
                default:
                    return AudioFormats.Pcm48kHz16bitStereo;
            }
        }

        public static AudioFormats.Format GetStreamFormat()
        {
            switch (Settings.Default.StreamPreferenceFormat)
            {
                case "Pcm":
                    return AudioFormats.Format.Pcm;
                case "Mp3":
                default:
                    return AudioFormats.Format.Mp3;
            }
        }

        public static void SetMP3Bitrate(uint bitrate)
        {
            Settings.Default.Mp3Bitrate = bitrate;
        }
        
        public static void SetAudioFormat(NAudio.Wave.WaveFormat format)
        {
            if (format == AudioFormats.Pcm32kHz16bitMono)
                Settings.Default.CaptureFormat = "Pcm32kHz16bitMono";
            else if (format == AudioFormats.Pcm32kHz16bitStereo)
                Settings.Default.CaptureFormat = "Pcm32kHz16bitStereo";
            else if (format == AudioFormats.Pcm44kHz16bitMono)
                Settings.Default.CaptureFormat = "Pcm44kHz16bitMono";
            else if (format == AudioFormats.Pcm44kHz16bitStereo)
                Settings.Default.CaptureFormat = "Pcm44kHz16bitStereo";
            else if (format == AudioFormats.Pcm48kHz16bitMono)
                Settings.Default.CaptureFormat = "Pcm48kHz16bitMono";
            else
                Settings.Default.CaptureFormat = "Pcm48kHz16bitStereo";
        }

        public static void SetStreamFormat(AudioFormats.Format format)
        {
            if (format == AudioFormats.Format.Pcm)
            {
                Settings.Default.StreamPreferenceFormat = "Pcm";
            }
            else
            {
                Settings.Default.StreamPreferenceFormat = "Mp3";
            }
        }
    }

    internal static class AudioFormats
    {
        public enum Format { Pcm, Mp3 };

        public static uint[] Mp3BitRates = new uint[] { 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320 };

        public static readonly NAudio.Wave.WaveFormat Pcm32kHz16bitMono = new NAudio.Wave.WaveFormat(32000, 16, 1);
        public static readonly NAudio.Wave.WaveFormat Pcm32kHz16bitStereo = new NAudio.Wave.WaveFormat(32000, 16, 2);
        public static readonly NAudio.Wave.WaveFormat Pcm44kHz16bitMono = new NAudio.Wave.WaveFormat(44100, 16, 1);
        public static readonly NAudio.Wave.WaveFormat Pcm44kHz16bitStereo = new NAudio.Wave.WaveFormat(44100, 16, 2);
        public static readonly NAudio.Wave.WaveFormat Pcm48kHz16bitMono = new NAudio.Wave.WaveFormat(48000, 16, 1);
        public static readonly NAudio.Wave.WaveFormat Pcm48kHz16bitStereo = new NAudio.Wave.WaveFormat(48000, 16, 2);

        public static string AsString(NAudio.Wave.WaveFormat format)
        {
            string channelsText;
            switch (format.Channels)
            {
                case 1:
                    channelsText = "Mono";
                    break;
                case 2:
                    channelsText = "Stereo";
                    break;
                default:
                    channelsText = format.Channels + " channels";
                    break;
            };
            return string.Format("{0} Hz, {1} bit, {2}", format.SampleRate, format.BitsPerSample, channelsText);
        }
    }
}
