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
    public class PcmToWave
    {

        private T InlineAssignHelper<T>(ref T target, T value)
        {
            target = value;
            return value;
        }
        public void SavePcmToWav(Stream Data, Stream Output, int BitPerSample, int SamplePeerSecond, int Channels)
        {

            BinaryWriter _output = new BinaryWriter(Output);
            // WAV header
            _output.Write("RIFF".ToCharArray());
            // RIFF chunk
            _output.Write((uint)(Data.Length + 36));
            // Total Length Of Package To Follow
            _output.Write("WAVE".ToCharArray());
            // WAV chunk
            _output.Write("fmt ".ToCharArray());
            // FORMAT chunk
            _output.Write((uint)0x10);
            // Length Of FORMAT Chunk (Binary, always 0x10)
            _output.Write((ushort)0x1);
            // Always 0x01
            // Channel Numbers (Always 0x01=Mono, 0x02=Stereo)
            _output.Write((ushort)Channels);
            _output.Write((uint)SamplePeerSecond);
            // Sample Rate (Binary, in Hz)
            _output.Write((uint)(BitPerSample * SamplePeerSecond * Channels / 8));
            // Bytes Per Second
            // Bytes Per Sample: 1=8 bit Mono, 2=8 bit Stereo or 16 bit Mono, 4=16 bit Stereo
            _output.Write((ushort)(BitPerSample * Channels / 8));
            _output.Write((ushort)BitPerSample);
            // Bits Per Sample
            _output.Write("data".ToCharArray());
            // DATA chunk
            _output.Write((uint)Data.Length);
            // Length Of Data To Follow
            // Raw PCM data
            long originalPosition = Data.Position;
            // Remember Original Position
            Data.Seek(0, SeekOrigin.Begin);
            // Reset position in Data
            // Append all data from Data stream into output stream.
            byte[] buffer = new byte[4096];
            int read = 0;

            // number of bytes read in one iteration
            while ((InlineAssignHelper(ref read, Data.Read(buffer, 0, 4096))) > 0)
            {
                _output.Write(buffer, 0, read);

            }
            // Restore Original Position
            Data.Seek(originalPosition, SeekOrigin.Begin);
        }
        public void SavePcmToWav(Stream Data, Stream Output,AudioFormat format)
        {
            int BitPerSample = format.BitsPerSample;
            int SamplePeerSecond = format.SamplesPerSecond;
            int Channels = format.Channels;

            BinaryWriter _output = new BinaryWriter(Output);
            // WAV header
            _output.Write("RIFF".ToCharArray());
            // RIFF chunk
            _output.Write((uint)(Data.Length + 36));
            // Total Length Of Package To Follow
            _output.Write("WAVE".ToCharArray());
            // WAV chunk
            _output.Write("fmt ".ToCharArray());
            // FORMAT chunk
            _output.Write((uint)0x10);
            // Length Of FORMAT Chunk (Binary, always 0x10)
            _output.Write((ushort)0x1);
            // Always 0x01
            // Channel Numbers (Always 0x01=Mono, 0x02=Stereo)
            _output.Write((ushort)Channels);
            _output.Write((uint)SamplePeerSecond);
            // Sample Rate (Binary, in Hz)
            _output.Write((uint)(BitPerSample * SamplePeerSecond * Channels / 8));
            // Bytes Per Second
            // Bytes Per Sample: 1=8 bit Mono, 2=8 bit Stereo or 16 bit Mono, 4=16 bit Stereo
            _output.Write((ushort)(BitPerSample * Channels / 8));
            _output.Write((ushort)BitPerSample);
            // Bits Per Sample
            _output.Write("data".ToCharArray());
            // DATA chunk
            _output.Write((uint)Data.Length);
            // Length Of Data To Follow
            // Raw PCM data
            long originalPosition = Data.Position;
            // Remember Original Position
            Data.Seek(0, SeekOrigin.Begin);
            // Reset position in Data
            // Append all data from Data stream into output stream.
            byte[] buffer = new byte[4096];
            int read = 0;

            // number of bytes read in one iteration
            while ((InlineAssignHelper(ref read, Data.Read(buffer, 0, 4096))) > 0)
            {
                _output.Write(buffer, 0, read);

            }
            // Restore Original Position
            Data.Seek(originalPosition, SeekOrigin.Begin);
        }
    }
}
