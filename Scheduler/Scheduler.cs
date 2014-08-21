using System;
using System.IO;
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
            var wallChangerTask = CreateWallChangerTask();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SysTrayIcon(wallChangerTask));
        }

        public static RunningTask CreateWallChangerTask()
        {
            using (var taskService = new TaskService())
            {
                var existingTask = taskService.FindTask("WallChanger", false);
                if (existingTask != null)
                {
                    return existingTask.Run();
                }
                var td = taskService.NewTask();
                td.RegistrationInfo.Description =
                    "Fetches an image from wallbase.cc and sets it as the desktop background at fixed intervals";
                td.RegistrationInfo.Author = "Eddie Wang";
                td.Settings.StartWhenAvailable = true;
                var biHourly = new TimeTrigger { Repetition = { Interval = TimeSpan.FromMinutes(30) } };
                td.Triggers.Add(biHourly);
                td.Actions.Add(new ExecAction(WindowsOps.ExecutableDirectory + @"\WallChanger.exe"));
                return taskService.RootFolder.RegisterTaskDefinition("WallChanger", td).Run();
            }
        }
    }
}
