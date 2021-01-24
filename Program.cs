using System;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Diagnostics;

namespace ConsoleApp
{
    public static class Himekuri
    {
        public static void Main()
        {
            try
            {
                // 宣言
                var dt = DateTime.Now;
                const string reiwa_kanji = "令和";
                const string reiwa_alpha = "R0";
                const string OneYear = "年";
                const string OneMonth = "月";
                const string Onedays = "日";
                const string OneHour = "時";
                const string OneMinutes = "分";
                // const string Oneseconds = "秒";
                const string comma = ".";
                const string koron = " : ";
                const string next_year = "来年の1月1日まであと：";
                const string message = "日です";

                // 曜日を日本語化
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");

                // 計算
                var reiwa = (reiwa_kanji + (dt.Year - 2018) + OneYear + dt.Month + OneMonth + dt.Day + Onedays);
                var reiwa2 = (reiwa_alpha + (dt.Year - 2018) + comma + dt.Month + comma + dt.Day);

                // 入れ子
                var count = new DateTime(dt.Year, dt.Month, dt.Day);
                var count2 = new DateTime(dt.Year + 1, 1, 1);
                var gantan = (count2 - count).TotalDays;

                // 参照先
                var nengo = (dt.Year + OneYear + dt.Month + OneMonth + dt.Day + Onedays + koron + dt.Hour + OneHour + dt.Minute + OneMinutes +
                             dt.Second + OneMinutes + " : " + dt.ToString("dddd"));
                var hagoita = reiwa + " : " + reiwa2;
                var oshogatsu = next_year + (gantan - 1) + message;

                // 安定ソート
                var takoage = new[]
                {
                    oshogatsu,
                    hagoita,
                    nengo
                };

                var orderByList = takoage.OrderBy(x => x);
                foreach (var x in orderByList)
                {
                    Console.WriteLine(x);
                }
            }

            catch (Exception e)
            {
                // 出力
                Trace.WriteLine(e.Message);
            }
            finally
            {
                try
                {
                    // 宣言
                    const string himekuri_version = "1.1.0";
                    const string himekuri_Sharper = "日めくりの数え番号：";
                    const string version = himekuri_Sharper + himekuri_version;

                    // 安定ソート
                    var new_version = new[]
                    {
                        version
                    };

                    var orderList = new_version.OrderBy(y => y);

                    foreach (var y in orderList)
                    {
                        Console.WriteLine(y);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
        }
    }
}