using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using ServerSnitch.Controllers;

namespace ServerSnitch
{
    public partial class ServerSnitch : ServiceBase
    {
        System.Timers.Timer _timer;
        DateTime _scheduleTime;

        int count;

        public ServerSnitch()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer();
            //_scheduleTime = DateTime.Today.AddDays(1).AddHours(7); // Schedule to run once a day at 7:00 a.m.
            _scheduleTime = DateTime.Today.AddDays(1).AddHours(11).AddMinutes(31);
            
        }

        protected override void OnStart(string[] args)
        {
            
            ServiceStart();
        }

        protected override void OnStop()
        {
        }


        public void ServiceStart()
        {
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);


            _timer.Enabled = true;
            _timer.Interval = _scheduleTime.Subtract(DateTime.Now).TotalSeconds * 1000;
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            _timer.Start();

           
        }

        protected void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // 1. Process Schedule Task
            // ----------------------------------
            // Add code to Process your task here
            // ----------------------------------

            // Real magic:
            //Controller control = new Controller();
            //control.Run();

            count++;

            // 2. If tick for the first time, reset next run to every 24 hours
            //if (_timer.Interval != 24 * 60 * 60 * 1000)
            //{
            //    _timer.Interval = 24 * 60 * 60 * 1000;
            //    count = 1;
            //} 
            if (_timer.Interval !=  60 * 1000)
            {
                _timer.Interval =  60 * 1000;
                count = 1;
            }
            Console.WriteLine(count);
            System.IO.File.WriteAllText(@"C:\Users\Public\Time.txt", count.ToString() + " " + DateTime.Now.TimeOfDay.ToString());

        }

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);

        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public long dwServiceType;
            public ServiceState dwCurrentState;
            public long dwControlsAccepted;
            public long dwWin32ExitCode;
            public long dwServiceSpecificExitCode;
            public long dwCheckPoint;
            public long dwWaitHint;
        };

    }
}
