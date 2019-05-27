﻿using Microsoft.ConfigurationManagement.AdminConsole;
using Microsoft.ConfigurationManagement.AdminConsole.OsdCommon;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ConfigMgr.QuickTools.DriverManager
{
    public partial class OptionsControl : SmsPageControl
    {
        private ControlsValidator controlsValidator;
        private readonly ModifyRegistry registry = new ModifyRegistry();

        public OptionsControl(SmsPageData pageData)
          : base(pageData)
        {
            InitializeComponent();
            Title = "Driver Manager";
        }

        public override void InitializePageControl()
        {
            base.InitializePageControl();

            browseFolderControlSource.Controls.OfType<SmsOsdTextBox>().First().Text = registry.ReadString("DriverSourceFolder");
            browseFolderControlPackage.Controls.OfType<SmsOsdTextBox>().First().Text = registry.ReadString("DriverPackageFolder");

            checkBoxLegacyFolder.Checked = registry.ReadBool("LegacyFolderStructure");

            browseFolderControlLegacyPackage.Controls.OfType<SmsOsdTextBox>().First().Text = registry.ReadString("LegacyPackageFolder");
            checkBoxZipContent.Checked = registry.ReadBool("LegacyPackageZipContent");
            textBoxConsoleFolder.Text = registry.ReadString("LegacyConsoleFolder");

            ControlsInspector = new ControlsInspector();
            controlsValidator = new ControlsValidator(ControlsInspector);

            browseFolderControlSource.SetErrorMessageFolderPath("Specify a valid UNC path");
            browseFolderControlSource.SetCustomValidateFilePath(new ControlDataStateEvaluator(ValidateSourceDirectory));
            browseFolderControlSource.SetValidator(controlsValidator);

            browseFolderControlPackage.SetErrorMessageFolderPath("Specify a valid UNC path");
            browseFolderControlPackage.SetCustomValidateFilePath(new ControlDataStateEvaluator(ValidatePackageDirectory));
            browseFolderControlPackage.SetValidator(controlsValidator);

            ControlsInspector.InspectAll();

            Dirty = false;

            Initialized = true;
        }

        protected override bool ApplyChanges(out Control errorControl, out bool showError)
        {
            registry.Write("DriverSourceFolder", browseFolderControlSource.FolderPath);
            registry.Write("DriverPackageFolder", browseFolderControlPackage.FolderPath);
            registry.Write("LegacyFolderStructure", checkBoxLegacyFolder.Checked);

            registry.Write("LegacyPackageFolder", browseFolderControlLegacyPackage.FolderPath);
            registry.Write("LegacyPackageZipContent", checkBoxZipContent.Checked);
            registry.Write("LegacyConsoleFolder", textBoxConsoleFolder.Text);

            Dirty = false;

            return base.ApplyChanges(out errorControl, out showError);
        }

        private ControlDataState ValidateSourceDirectory()
        {
            return !OsdUtilities.CheckNetFolderPath(browseFolderControlSource.FolderPath) ? ControlDataState.Invalid : ControlDataState.Valid;
        }

        private ControlDataState ValidatePackageDirectory()
        {
            return !OsdUtilities.CheckNetFolderPath(browseFolderControlPackage.FolderPath) ? ControlDataState.Invalid : ControlDataState.Valid;
        }

        private void Control_Changed(object sender, EventArgs e)
        {
            Dirty = true;
        }
    }
}
