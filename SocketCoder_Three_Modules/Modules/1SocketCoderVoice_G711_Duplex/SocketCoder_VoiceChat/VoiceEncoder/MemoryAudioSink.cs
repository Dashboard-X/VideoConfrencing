using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;

namespace VoiceEncoder
{

    public class MemoryAudioSink : AudioSink
    {
        public MemoryStream _stream;

        public AudioFormat _format;

        public event EventHandler OnBufferFulfill;

        public bool StartSending = false;

        protected override void OnCaptureStarted()
        {
            _stream = new MemoryStream();
        }

        protected override void OnCaptureStopped()
        {

        }

        protected override void OnFormatChange(AudioFormat Format)
        {
            _format = Format;
        }

        protected override void OnSamples(long sampleTime, long sampleDuration, byte[] sampleData)
        {
            if (_stream.Length >= 15840)
            {
                if (StartSending & OnBufferFulfill != null) OnBufferFulfill(_stream.GetBuffer(), null);

                _stream = new MemoryStream();
            }
            _stream.Write(sampleData, 0, sampleData.Length);
        }

    }
}
