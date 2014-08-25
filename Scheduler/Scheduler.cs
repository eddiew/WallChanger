﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using WallChanger;

namespace Scheduler
{
    static class Scheduler
    {
        private static readonly Dictionary<string, string> defaultTaskSettings = new Dictionary<string, string> {
            {"Interval","30"},
            {"BatteryOnly","1"},
            //{"DisallowStartIfOnBatteries","false"},
            //{"StopIfGoingOnBatteries","false"},
        };
        private static readonly UTF8Encoding Utf8 = new UTF8Encoding();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Load task settings
            Dictionary<string, string> taskSettings = LoadSettings();
            using (var taskService = new TaskService())
            {
                var wallChangerTask = CreateWallChangerTask(taskService, taskSettings);
                Application.Run(new SysTrayIcon(wallChangerTask));
            }
        }

        public static Task CreateWallChangerTask(TaskService ts, Dictionary<string, string> taskSettings)
        {
            var td = ts.NewTask();
            td.RegistrationInfo.Description =
                "Fetches an image from wallbase.cc and sets it as the desktop background at fixed intervals";
            td.RegistrationInfo.Author = "Eddie Wang";
            td.Settings.StartWhenAvailable = true;
            td.Settings.DisallowStartIfOnBatteries = false;
            td.Settings.StopIfGoingOnBatteries = false;
            int interval = Int32.Parse(taskSettings["Interval"] ?? defaultTaskSettings["Interval"]);
            var biHourly = new TimeTrigger { Repetition = { Interval = TimeSpan.FromMinutes(interval) } };
            td.Triggers.Add(biHourly);
            // Set WallChanger.exe arguments
            List<string> args = new List<string>();
            string batteryOnly = taskSettings["BatteryOnly"] ?? defaultTaskSettings["BatteryOnly"];
            args.Add("BatteryOnly=" + batteryOnly);
            var wallChangeAction = new ExecAction(WindowsOps.ExecutableDirectory + @"\WallChanger.exe") {
                Arguments = string.Join(" ", args)
            };
            td.Actions.Add(wallChangeAction);
            return ts.RootFolder.RegisterTaskDefinition("WallChanger", td);
        }

        public static Dictionary<string, string> LoadSettings()
        {
            string DocumentsDirectory = WindowsOps.DocumentsDirectory;
            Directory.CreateDirectory(DocumentsDirectory);
            string settingsFilePath = DocumentsDirectory + "taskSettings.txt";
            // Create settings file if it doesn't exist
            if (!File.Exists(settingsFilePath))
            {
                FileStream fs = File.Create(settingsFilePath);
                string json = JsonConvert.SerializeObject(defaultTaskSettings, Formatting.Indented);
                byte[] jsonBytes = Utf8.GetBytes(json);
                fs.Write(jsonBytes, 0, jsonBytes.Length);
                fs.Flush();
                fs.Close();
            }
            // Read settings file
            string jsonSettings = File.ReadAllText(settingsFilePath);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonSettings);
        }
    }
}
