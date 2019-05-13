using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WCCOACOMLib;

namespace KASKAD_DistSync
{
    class Program
    {
        public static int pState;
        public static int cState;
        public static string datapoint = Properties.Settings.Default["system"] + ":" + Properties.Settings.Default["dp"];
        static void Main(string[] args)
        {
            Console.WriteLine(@"================================================");
            Console.WriteLine(@"============= Не закрывайте это окно ===========");
            Console.WriteLine(@"================================================");
            Utils.wccInit();
            Timer cTm = new Timer(Utils.checkState, null, 0, 500);
            Console.ReadLine();
        }
    }
    public static class Utils
    {
        static ComManager wcc;
        static Timer tWorker;
        // Инициализация COM менеджера WinCC OA
        public static void wccInit()
        {
            wcc = new ComManager();
            wcc.Init("-currentproj");
            Program.cState = 0;
            Program.pState = 99;
            Thread.Sleep(500);
        }
        // Проверка точки данных менеджера dist
        public static bool checkDp()
        {
            object val;
            wcc.dpGet(Program.datapoint, out val);
            Int32[] systems = val as Int32[];
            if (systems.Length < 1)
                return false;
            else
                return true;
        }
        // Синхронизация времени с сервером БД
        public static void getTime()
        {
            //StarWars();
            Process.Start("net", @"time \\"+ Properties.Settings.Default["ip"] + " /set /y");
            Thread.Sleep(30000);
            Console.WriteLine("Set time");
            if (!checkDp())
                Program.cState = 2;
            else
                Program.cState = 0;
            Program.pState = 1;
        }
        // Завершение процесса DistManager
        public static void restartDist()
        {
            Process[] dist = Process.GetProcessesByName("WCCILdist");
            foreach (Process proc in dist)
            {
                proc.Kill();
            }

            //SuperMario();
            Console.WriteLine("Kill proc");
            Thread.Sleep(5000);
            if (!checkDp())
                Program.cState = 1;
            else
                Program.cState = 0;
            Program.pState = 2;
        }
        // Проверка состояния
        public static void checkState(object obj)
        {
            if (Program.cState == 9 && Program.pState != 9)
            {
                tWorker.Dispose();
                Program.pState = 9;
            }
            else if (Program.cState != 9 && (Program.pState > 0) ){
                tWorker = new Timer(worker, null, 0, 5000);
                Program.pState = 0;
            }
        }
        // Агрегирующая функция
        public static void worker(object obj)
        {
            if(Program.pState == 99 || (Program.pState == 0 && Program.cState!=2))
            {
                if (checkDp())
                {
                    Program.cState = 0;
                    Console.WriteLine("IS OK");
                }
                else
                {
                    Program.cState = 9;
                    getTime();
                }
            }else if(Program.cState == 2 && Program.pState == 0)
            {
                Program.cState = 9;
                restartDist();
            }
        }
        // Тема из марио ( Console.Beep() )
        public static void SuperMario()
        {
            Console.Beep(659, 125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(523, 125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(784, 125);
            Thread.Sleep(375);
            Console.Beep(392, 125);
            Thread.Sleep(375);
            Console.Beep(523, 125);
            Thread.Sleep(250);
            Console.Beep(392, 125);
            Thread.Sleep(250);
            Console.Beep(330, 125);
            Thread.Sleep(250);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(494, 125);
            Thread.Sleep(125);
            Console.Beep(466, 125);
            Thread.Sleep(42);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(392, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(880, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(587, 125);
            Console.Beep(494, 125);
            Thread.Sleep(125);
            Console.Beep(523, 125);
            Thread.Sleep(250);
            Console.Beep(392, 125);
            Thread.Sleep(250);
            Console.Beep(330, 125);
            Thread.Sleep(250);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(494, 125);
            Thread.Sleep(125);
            Console.Beep(466, 125);
            Thread.Sleep(42);
            Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(392, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(880, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(784, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(587, 125);
            Console.Beep(494, 125);
            Thread.Sleep(375);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(698, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(698, 125);
            Thread.Sleep(625);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(622, 125);
            Thread.Sleep(250);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(523, 125);
            Thread.Sleep(1125);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(698, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125);
            Console.Beep(698, 125);
            Thread.Sleep(625);
            Console.Beep(784, 125);
            Console.Beep(740, 125);
            Console.Beep(698, 125);
            Thread.Sleep(42);
            Console.Beep(622, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(415, 125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Thread.Sleep(125);
            Console.Beep(440, 125);
            Console.Beep(523, 125);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(622, 125);
            Thread.Sleep(250);
            Console.Beep(587, 125);
            Thread.Sleep(250);
            Console.Beep(523, 125);
            Thread.Sleep(625);
        }
        // Тема из звездных войн
        public static void StarWars()
        {
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
        }

    }
}
