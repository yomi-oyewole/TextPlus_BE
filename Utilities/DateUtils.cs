namespace TextPlus_BE.Utilities
{

    public enum TimeSpanFormat
    {
        Seconds,
        Milliseconds
    }
    public static class DateUtils
    {
        public static long ConvertToUnixTimestamp(DateTime date, TimeSpanFormat format = TimeSpanFormat.Seconds)
        {
            TimeSpan diff = DateTime.UnixEpoch.Subtract(date);
            switch (format)
            {
                case TimeSpanFormat.Seconds:
                    return (long)Math.Floor(Math.Abs(diff.TotalSeconds));
                case TimeSpanFormat.Milliseconds:
                    return (long)Math.Floor(Math.Abs(diff.TotalMilliseconds));
                default:
                    return (long)Math.Floor(Math.Abs(diff.TotalSeconds));
            }

        }

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp, TimeSpanFormat format = TimeSpanFormat.Seconds)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = DateTime.UnixEpoch;
            switch (format)
            {
                case TimeSpanFormat.Seconds:
                    return dateTime.AddSeconds(unixTimeStamp);
                case TimeSpanFormat.Milliseconds:
                    return dateTime.AddMilliseconds(unixTimeStamp);
                default:
                    return dateTime.AddSeconds(unixTimeStamp);
            }
        }
    }
}

