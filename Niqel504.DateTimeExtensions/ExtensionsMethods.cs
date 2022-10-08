namespace Niqel504.DateTimeExtensions
{
    public static class ExtensionsMethods
    {
        public static RankTime GetRankTime(this DateTime value, DateTime initialDatetime, DateTime finalDatetime)
        {
            byte rankDays = 0;
            byte rankMonths = 0;
            int rankYears = 0;

            byte initialDatetimeDays = Convert.ToByte(initialDatetime.Day);
            byte initialDatetimeMonths = Convert.ToByte(initialDatetime.Month);
            int initialDatetimeYears = initialDatetime.Year;    

            byte finalDatetimeDays = Convert.ToByte(finalDatetime.Day);
            byte finalDatetimeMonths = Convert.ToByte(finalDatetime.Month);
            int finalDatetimeYears = finalDatetime.Year;

            if (finalDatetimeDays < initialDatetimeDays)
            {
                if (
                    finalDatetimeMonths == 1 ||
                    finalDatetimeMonths == 3 ||
                    finalDatetimeMonths == 5 ||
                    finalDatetimeMonths == 7 ||
                    finalDatetimeMonths == 8 ||
                    finalDatetimeMonths == 10 ||
                    finalDatetimeMonths == 12)
                {
                    finalDatetimeDays += 31;
                    finalDatetimeMonths -= 1;
                }
                else if (
                    finalDatetimeMonths == 4 ||
                    finalDatetimeMonths == 6 ||
                    finalDatetimeMonths == 9 ||
                    finalDatetimeMonths == 11)
                {
                    finalDatetimeDays += 30;
                    finalDatetimeMonths -= 1;
                }
                else
                {
                    if (finalDatetimeYears % 4 == 0)
                    {
                        if (finalDatetimeYears % 100 == 0)
                        {
                            if (finalDatetimeYears % 400 == 0)
                            {
                                finalDatetimeDays += 29;
                                finalDatetimeMonths -= 1;
                            }
                            else
                            {
                                finalDatetimeDays += 28;
                                finalDatetimeMonths -= 1;
                            }
                        }
                        else
                        {
                            finalDatetimeDays += 29;
                            finalDatetimeMonths -= 1;
                        }
                    }
                    else
                    {
                        finalDatetimeDays += 28;
                        finalDatetimeMonths -= 1;
                    }
                }
            }

            rankDays =  Convert.ToByte(finalDatetimeDays - initialDatetimeDays);

            if (finalDatetimeMonths < initialDatetimeMonths)
            {
                finalDatetimeMonths += 12;
                finalDatetimeYears -= 1;
            }

            rankMonths = Convert.ToByte(finalDatetimeMonths - initialDatetimeMonths);
            rankYears = finalDatetimeYears - initialDatetimeYears;

            RankTime rankTime = new RankTime(rankDays, rankMonths, rankYears);
            return rankTime;
        }

    }

    public class RankTime
    {
        private byte days;
        private byte months;
        private int years;

        public int Days { get => days; }
        public int Months { get => months; }
        public int Years { get => years; }

        public RankTime(byte days, byte months, int years)
        {
            this.days = days;
            this.months = months;
            this.years = years;
        }
    }
}