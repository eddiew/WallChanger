using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace Scheduler
{
    class Scheduler
    {
        static void Main(string[] args)
        {
            #if DEBUG
                const string mode = "Debug";
            #else
                const string mode = "Release";
            #endif
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            path = path.Remove(path.Length - (@"Scheduler\bin\" + mode).Length) + @"WallChanger\bin\"+mode+@"\WallChanger.exe";
            using (var taskService = new TaskService())
            {
                var td = taskService.NewTask();
                td.RegistrationInfo.Description =
                    "Fetches an image from wallbase.cc and sets it as the desktop background at fixed intervals";
                td.RegistrationInfo.Author = "Eddie Wang";
                td.Settings.StartWhenAvailable = true;
                var biHourly = new RegistrationTrigger{Repetition = {Interval = TimeSpan.FromMinutes(30)}};
                td.Triggers.Add(biHourly);
                td.Actions.Add(new ExecAction(path));
                taskService.RootFolder.RegisterTaskDefinition("WallChanger", td);
            }
        }
    }
}
