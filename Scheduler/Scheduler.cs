using System;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using WallChanger;

namespace Scheduler
{
    static class Scheduler
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            using (var taskService = new TaskService())
            {
                var wallChangerTask = GetWallChangerTask(taskService);
                Application.Run(new SysTrayIcon(wallChangerTask));
            }
        }

        public static Task GetWallChangerTask(TaskService ts)
        {
            var existingTask = ts.FindTask("WallChanger", false);
            if (existingTask != null)
            {
                return existingTask;
            }
            var td = ts.NewTask();
            td.RegistrationInfo.Description =
                "Fetches an image from wallbase.cc and sets it as the desktop background at fixed intervals";
            td.RegistrationInfo.Author = "Eddie Wang";
            td.Settings.StartWhenAvailable = true;
            var biHourly = new TimeTrigger { Repetition = { Interval = TimeSpan.FromMinutes(30) } };
            td.Triggers.Add(biHourly);
            td.Actions.Add(new ExecAction(WindowsOps.ExecutableDirectory + @"\WallChanger.exe"));
            return ts.RootFolder.RegisterTaskDefinition("WallChanger", td);
        }
    }
}
