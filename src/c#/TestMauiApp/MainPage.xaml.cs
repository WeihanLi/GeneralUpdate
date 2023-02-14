﻿using GeneralUpdate.Core.OSS;
using GeneralUpdate.OSS.Domain.Entity;
using GeneralUpdate.OSS.OSSStrategys;

namespace TestMauiApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            string url = "http://192.168.50.203/";
            string appName = "MainApplication.exe";
            string currentVersion = "1.1.1.1";
            string versionFileName = "version_config.json";
            GeneralUpdateOSS.Download += OnOSSDownload;
            GeneralUpdateOSS.UnZipCompleted += OnOSSUnZipCompleted;
            GeneralUpdateOSS.UnZipProgress += OnOSSUnZipProgress;
            await GeneralUpdateOSS.Start<OSSStrategy>(new ParamsOSS(url, appName, currentVersion, versionFileName));
        }

        private void OnOSSUnZipProgress(object sender, GeneralUpdate.Zip.Events.BaseUnZipProgressEventArgs e)
        {

        }

        private void OnOSSUnZipCompleted(object sender, GeneralUpdate.Zip.Events.BaseCompleteEventArgs e)
        {

        }

        private void OnOSSDownload(object sender, GeneralUpdate.OSS.Events.OSSDownloadArgs e)
        {
            Console.WriteLine($"{e.CurrentByte},{e.TotalByte}");
        }
    }
}