using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using WallChanger;

namespace Scheduler
{
    class Scheduler
    {
        static void Main(string[] args)
        {
            using (var taskService = new TaskService())
            {
                var td = taskService.NewTask();
                td.RegistrationInfo.Description =
                    "Fetches an image from wallbase.cc and sets it as the desktop background at fixed intervals";
                td.RegistrationInfo.Author = "Eddie Wang";
                td.Settings.StartWhenAvailable = true;
                var biHourly = new RegistrationTrigger{Repetition = {Interval = TimeSpan.FromMinutes(30)}};
                td.Triggers.Add(biHourly);
                td.Actions.Add(new ExecAction(WindowsOps.ExecutableDirectory + @"\WallChanger.exe"));
                taskService.RootFolder.RegisterTaskDefinition("WallChanger", td);
            }
        }
    }
}
