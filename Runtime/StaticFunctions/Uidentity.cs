using System;

namespace U.Gears
{


    public static class Uidentity
    {
        /*
         * Creates a new Guid
         */
        public static Guid NewGuid()
        {
            return Guid.NewGuid();
        }

        /*
         * Creates a new 19 chars UInt64 Id
         */
        public static string NewIdLong()
        {

            byte[] buffer = NewGuid().ToByteArray();

            var sid = BitConverter.ToUInt64(buffer, 0).ToString();

            if (sid.Length < 19)
            {
                for (int i = 0; i < 19 - sid.Length; i++)
                {
                    sid = sid + "0";
                }
            }

            if (sid.Length > 19)
            {
                for (int i = 0; i < sid.Length - 19; i++)
                {
                    sid = sid.TrimEnd(sid[sid.Length - 1]);
                }
            }

            return sid;

        }

        /*
         * Creates a new 10 chars UInt32 Id
         */
        public static string NewIdShort()
        {

            byte[] buffer = NewGuid().ToByteArray();

            var sid = BitConverter.ToUInt32(buffer, 0).ToString();

            if (sid.Length < 10)
            {
                for (int i = 0; i < 10 - sid.Length; i++)
                {
                    sid = sid + "0";
                }
            }

            if (sid.Length > 10)
            {
                for (int i = 0; i < sid.Length - 10; i++)
                {
                    sid = sid.TrimEnd(sid[sid.Length - 1]);
                }
            }

            return sid;

        }

    }
}
