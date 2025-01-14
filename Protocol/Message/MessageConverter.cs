using System;
using System.Text;

namespace MultiGameModule
{
    public class MessageConverter
    {
        private byte[] _message;
        public byte[] Message { get { return _message; } }


        private byte _protocol;
        public byte Protocol { get { return _protocol; } }


        private int _messageSize;
        public int MessageSize { get { return _messageSize; } }


        private int nextIndex;
        private int lastIndex;


        private byte[] _remainMessage;
        public byte[] RemainMessage { get { return _remainMessage; } }

        public MessageConverter(byte[] message)
        {
            _message = message;
            _remainMessage = null;
            lastIndex = 0;
            nextIndex = 0;
        }

        public bool NextMessage()
        {
            nextIndex = lastIndex;

            // 프로토콜을 가져올 수 없으면 종료
            if (nextIndex > _message.Length - 1)
            {
                return false;
            }

            try
            {
                // 프로토콜 가져옴
                _protocol = NextByte();

                // 프로코톨이 0이면 종료
                if (_protocol == 0) return false;

                // 만약 메시지 사이즈를 가져올 수 없다면 다음에 처리하기 위해 저장
                if (nextIndex > _message.Length - 4)
                {
                    _remainMessage = new byte[_message.Length - nextIndex + 1];
                    Array.Copy(_message, nextIndex - 1, _remainMessage, 0, _message.Length - nextIndex + 1);
                    return false;
                }

                // 메시지 사이즈 가져옴
                _messageSize = NextInt();
                lastIndex += MessageSize;

                // 현재 읽어야 하는 메시지가 메시지 배열 사이즈를 넘어간다면 종료
                if (lastIndex > _message.Length)
                {
                    _remainMessage = new byte[_message.Length - nextIndex + 5];
                    Array.Copy(_message, nextIndex - 5, _remainMessage, 0, _message.Length - nextIndex + 5);
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                _remainMessage = null;
                return false;
            }
        }

        public int NextInt()
        {
            int result = BitConverter.ToInt32(Message, nextIndex);
            nextIndex += sizeof(int);
            return result;
        }

        public bool NextBool()
        {
            bool result = BitConverter.ToBoolean(Message, nextIndex);
            nextIndex += sizeof(bool);
            return result;
        }

        public float NextFloat()
        {
            float result = BitConverter.ToSingle(Message, nextIndex);
            nextIndex += sizeof(float);
            return result;
        }

        public byte NextByte()
        {
            byte result = Message[nextIndex];
            nextIndex += sizeof(byte);
            return result;
        }

        public string NextString()
        {
            // string 타입은 앞에 몇 byte인지 붙어서 옴
            int length = NextInt();
            string result = Encoding.UTF8.GetString(Message, nextIndex, length);
            nextIndex += Encoding.Default.GetByteCount(result);
            return result;
        }

    }
}
