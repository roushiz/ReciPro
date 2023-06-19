﻿namespace ReciPro
{
    partial class FormDiffractionSimulator
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            //if (context != null)
            //     context.Dispose();
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDiffractionSimulator));
            toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            toolStrip3 = new System.Windows.Forms.ToolStrip();
            toolStripButtonDiffractionSpots = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripButtonKikuchiLines = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripButtonDebyeRing = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            toolStripButtonScale = new System.Windows.Forms.ToolStripButton();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripButtonIndexLabels = new System.Windows.Forms.ToolStripButton();
            toolStripButtonDspacing = new System.Windows.Forms.ToolStripButton();
            toolStripButtonDistance = new System.Windows.Forms.ToolStripButton();
            toolStripButtonExcitationError = new System.Windows.Forms.ToolStripButton();
            toolStripButtonFg = new System.Windows.Forms.ToolStripButton();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabelTimeForSearchingG = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelTimeForDrawing = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelTimeForBethe = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            panelMain = new System.Windows.Forms.Panel();
            tabControl = new System.Windows.Forms.TabControl();
            tabPageGeneral = new System.Windows.Forms.TabPage();
            groupBox4 = new System.Windows.Forms.GroupBox();
            trackBarStrSize = new System.Windows.Forms.TrackBar();
            groupBox3 = new System.Windows.Forms.GroupBox();
            colorControlString = new ColorControl();
            label14 = new System.Windows.Forms.Label();
            colorControlFoot = new ColorControl();
            colorControlBackGround = new ColorControl();
            tabPageKikuchi = new System.Windows.Forms.TabPage();
            checkBoxKikuchiLine_Kinematical = new System.Windows.Forms.CheckBox();
            numericBoxKikuchiLineThreshold = new NumericBox();
            colorControlDefectLine = new ColorControl();
            colorControlExcessLine = new ColorControl();
            trackBarLineWidth = new System.Windows.Forms.TrackBar();
            label11 = new System.Windows.Forms.Label();
            tabPageDebye = new System.Windows.Forms.TabPage();
            colorControlDebyeRing = new ColorControl();
            checkBoxDebyeRingLabel = new System.Windows.Forms.CheckBox();
            checkBoxDebyeRingIgnoreIntensity = new System.Windows.Forms.CheckBox();
            label6 = new System.Windows.Forms.Label();
            trackBarDebyeRingWidth = new System.Windows.Forms.TrackBar();
            tabPageScale = new System.Windows.Forms.TabPage();
            checkBoxScaleLabel = new System.Windows.Forms.CheckBox();
            label12 = new System.Windows.Forms.Label();
            trackBarScaleLineWidth = new System.Windows.Forms.TrackBar();
            label16 = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonScaleDivisionFine = new System.Windows.Forms.RadioButton();
            radioButtonScaleDivisionMedium = new System.Windows.Forms.RadioButton();
            radioButtonScaleDivisionCoarse = new System.Windows.Forms.RadioButton();
            colorControlScaleAzimuth = new ColorControl();
            colorControlScale2Theta = new ColorControl();
            tabPageMisc = new System.Windows.Forms.TabPage();
            numericBoxDev = new NumericBox();
            numericBoxAcc = new NumericBox();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            groupBox5 = new System.Windows.Forms.GroupBox();
            trackBarRotationSpeed = new System.Windows.Forms.TrackBar();
            graphicsBox = new ImagingSolution.Control.GraphicsBox(components);
            labelDummy = new System.Windows.Forms.Label();
            panelMousePosition = new System.Windows.Forms.Panel();
            label24 = new System.Windows.Forms.Label();
            labelMousePositionDetector = new System.Windows.Forms.Label();
            labelMousePositionReal = new System.Windows.Forms.Label();
            labelDinv = new System.Windows.Forms.Label();
            checkBoxMousePositionDetailes = new System.Windows.Forms.CheckBox();
            labelMousePositionReciprocal = new System.Windows.Forms.Label();
            labelTwoThetaRad = new System.Windows.Forms.Label();
            labelTwoThetaDeg = new System.Windows.Forms.Label();
            labelD = new System.Windows.Forms.Label();
            flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            groupBox6 = new System.Windows.Forms.GroupBox();
            numericBoxClientHeight = new NumericBox();
            numericBoxClientWidth = new NumericBox();
            numericBoxResolution = new NumericBox();
            label4 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            numericUpDownCamaraLength2 = new System.Windows.Forms.NumericUpDown();
            buttonDetailedGeometry = new System.Windows.Forms.Button();
            label18 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            comboBoxCenter = new System.Windows.Forms.ComboBox();
            buttonResetCenter = new System.Windows.Forms.Button();
            checkBoxFixCenter = new System.Windows.Forms.CheckBox();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsMetafileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveDetectorAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveDetectorAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveDetectorAsMetafileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveCBEDPatternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveCBEDasPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveCBEDasTiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asPixelByPixelImagePNGFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asCollectiveImageTiffFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyImageToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyAsMetafileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyDetectorAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyDetectorAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyDetectorAsMetafileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyCBEDPatternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyCBEDasImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemBackLaue = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            dynamicCompressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            presetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            electron300KVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            electron200KVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            electron120KeVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            xray30KeVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            xray20KeVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            xrayMoKαToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            xrayCuKαToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            basicConceptOfBethesMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            waveLengthControl = new WaveLengthControl();
            radioButtonIntensityDynamical = new System.Windows.Forms.RadioButton();
            checkBoxUseCrystalColor = new System.Windows.Forms.CheckBox();
            checkBoxExtinctionAll = new System.Windows.Forms.CheckBox();
            checkBoxExtinctionLattice = new System.Windows.Forms.CheckBox();
            groupBoxSpotProperty = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            flowLayoutPanelPED = new System.Windows.Forms.FlowLayoutPanel();
            label5 = new System.Windows.Forms.Label();
            numericBoxPED_Semiangle = new NumericBox();
            numericBoxPED_Step = new NumericBox();
            flowLayoutPanelBethe = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            numericBoxNumOfBlochWave = new NumericBox();
            numericBoxThickness = new NumericBox();
            flowLayoutPanelAppearance = new System.Windows.Forms.FlowLayoutPanel();
            label19 = new System.Windows.Forms.Label();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonCircleArea = new System.Windows.Forms.RadioButton();
            radioButtonPointSpread = new System.Windows.Forms.RadioButton();
            flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            label8 = new System.Windows.Forms.Label();
            trackBarSpotOpacity = new System.Windows.Forms.TrackBar();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxSpotRadius = new NumericBox();
            flowLayoutPanelGaussianOption = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            label10 = new System.Windows.Forms.Label();
            trackBarIntensityForPointSpread = new System.Windows.Forms.TrackBar();
            flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            label25 = new System.Windows.Forms.Label();
            comboBoxScaleColorScale = new System.Windows.Forms.ComboBox();
            checkBoxLogScale = new System.Windows.Forms.CheckBox();
            flowLayoutPanelColorScale = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanelSpotColor = new System.Windows.Forms.FlowLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            colorControlOrigin = new ColorControl();
            colorControlNoCondition = new ColorControl();
            colorControlScrewGlide = new ColorControl();
            colorControlForbiddenLattice = new ColorControl();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            label7 = new System.Windows.Forms.Label();
            radioButtonIntensityExcitation = new System.Windows.Forms.RadioButton();
            flowLayoutPanelExtinctionOption = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonIntensityKinematical = new System.Windows.Forms.RadioButton();
            buttonDetailsOfSpots = new System.Windows.Forms.Button();
            flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            label13 = new System.Windows.Forms.Label();
            flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonBeamParallel = new System.Windows.Forms.RadioButton();
            radioButtonBeamPrecessionElectron = new System.Windows.Forms.RadioButton();
            radioButtonBeamPrecessionXray = new System.Windows.Forms.RadioButton();
            radioButtonBeamConvergence = new System.Windows.Forms.RadioButton();
            flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            label3 = new System.Windows.Forms.Label();
            toolTip = new System.Windows.Forms.ToolTip(components);
            printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            panel1 = new System.Windows.Forms.Panel();
            pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            printDialog1 = new System.Windows.Forms.PrintDialog();
            timerBlinkSpot = new System.Windows.Forms.Timer(components);
            timerBlinkKikuchiLine = new System.Windows.Forms.Timer(components);
            timerBlinkDebyeRing = new System.Windows.Forms.Timer(components);
            timerBlinkScale = new System.Windows.Forms.Timer(components);
            toolStripButtonDspacingInv = new System.Windows.Forms.ToolStripButton();
            toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            toolStrip3.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panelMain.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageGeneral.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarStrSize).BeginInit();
            groupBox3.SuspendLayout();
            tabPageKikuchi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarLineWidth).BeginInit();
            tabPageDebye.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarDebyeRingWidth).BeginInit();
            tabPageScale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarScaleLineWidth).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            tabPageMisc.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarRotationSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)graphicsBox).BeginInit();
            panelMousePosition.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCamaraLength2).BeginInit();
            groupBox2.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBoxSpotProperty.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanelPED.SuspendLayout();
            flowLayoutPanelBethe.SuspendLayout();
            flowLayoutPanelAppearance.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSpotOpacity).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanelGaussianOption.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarIntensityForPointSpread).BeginInit();
            flowLayoutPanel9.SuspendLayout();
            flowLayoutPanelSpotColor.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanelExtinctionOption.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel10.SuspendLayout();
            flowLayoutPanel11.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            toolStripContainer1.BottomToolStripPanel.Controls.Add(toolStrip3);
            toolStripContainer1.BottomToolStripPanel.Controls.Add(toolStrip1);
            toolStripContainer1.BottomToolStripPanel.Controls.Add(statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(panelMain);
            toolStripContainer1.ContentPanel.Controls.Add(panelMousePosition);
            toolStripContainer1.ContentPanel.Controls.Add(flowLayoutPanel6);
            resources.ApplyResources(toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(toolStripContainer1, "toolStripContainer1");
            toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip1);
            // 
            // toolStrip3
            // 
            resources.ApplyResources(toolStrip3, "toolStrip3");
            toolStrip3.BackColor = System.Drawing.SystemColors.Control;
            toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonDiffractionSpots, toolStripSeparator2, toolStripButtonKikuchiLines, toolStripSeparator3, toolStripButtonDebyeRing, toolStripSeparator6, toolStripButtonScale });
            toolStrip3.Name = "toolStrip3";
            toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolStripButtonDiffractionSpots
            // 
            toolStripButtonDiffractionSpots.BackColor = System.Drawing.SystemColors.Control;
            toolStripButtonDiffractionSpots.Checked = true;
            toolStripButtonDiffractionSpots.CheckOnClick = true;
            toolStripButtonDiffractionSpots.CheckState = System.Windows.Forms.CheckState.Checked;
            toolStripButtonDiffractionSpots.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonDiffractionSpots.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(toolStripButtonDiffractionSpots, "toolStripButtonDiffractionSpots");
            toolStripButtonDiffractionSpots.Name = "toolStripButtonDiffractionSpots";
            toolStripButtonDiffractionSpots.CheckedChanged += toolStripButtonDiffractionSpots_CheckedChanged;
            toolStripButtonDiffractionSpots.MouseDown += toolStripButtonDiffractionSpots_MouseDown;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripButtonKikuchiLines
            // 
            toolStripButtonKikuchiLines.CheckOnClick = true;
            toolStripButtonKikuchiLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonKikuchiLines.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(toolStripButtonKikuchiLines, "toolStripButtonKikuchiLines");
            toolStripButtonKikuchiLines.Name = "toolStripButtonKikuchiLines";
            toolStripButtonKikuchiLines.CheckedChanged += toolStripButtonDiffractionSpots_CheckedChanged;
            toolStripButtonKikuchiLines.MouseDown += toolStripButtonDiffractionSpots_MouseDown;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripButtonDebyeRing
            // 
            toolStripButtonDebyeRing.BackColor = System.Drawing.SystemColors.Control;
            toolStripButtonDebyeRing.CheckOnClick = true;
            toolStripButtonDebyeRing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonDebyeRing.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(toolStripButtonDebyeRing, "toolStripButtonDebyeRing");
            toolStripButtonDebyeRing.Name = "toolStripButtonDebyeRing";
            toolStripButtonDebyeRing.CheckedChanged += toolStripButtonDiffractionSpots_CheckedChanged;
            toolStripButtonDebyeRing.MouseDown += toolStripButtonDiffractionSpots_MouseDown;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(toolStripSeparator6, "toolStripSeparator6");
            // 
            // toolStripButtonScale
            // 
            toolStripButtonScale.BackColor = System.Drawing.SystemColors.Control;
            toolStripButtonScale.CheckOnClick = true;
            toolStripButtonScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonScale.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(toolStripButtonScale, "toolStripButtonScale");
            toolStripButtonScale.Name = "toolStripButtonScale";
            toolStripButtonScale.CheckedChanged += toolStripButtonDiffractionSpots_CheckedChanged;
            toolStripButtonScale.MouseDown += toolStripButtonDiffractionSpots_MouseDown;
            // 
            // toolStrip1
            // 
            resources.ApplyResources(toolStrip1, "toolStrip1");
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonIndexLabels, toolStripButtonDspacing, toolStripButtonDspacingInv, toolStripButtonDistance, toolStripButtonExcitationError, toolStripButtonFg });
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolStripButtonIndexLabels
            // 
            toolStripButtonIndexLabels.Checked = true;
            toolStripButtonIndexLabels.CheckOnClick = true;
            toolStripButtonIndexLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            toolStripButtonIndexLabels.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonIndexLabels.ForeColor = System.Drawing.Color.Salmon;
            resources.ApplyResources(toolStripButtonIndexLabels, "toolStripButtonIndexLabels");
            toolStripButtonIndexLabels.Name = "toolStripButtonIndexLabels";
            toolStripButtonIndexLabels.CheckedChanged += toolStripButtonDiffractionSpots_CheckedChanged;
            // 
            // toolStripButtonDspacing
            // 
            toolStripButtonDspacing.CheckOnClick = true;
            toolStripButtonDspacing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonDspacing.ForeColor = System.Drawing.Color.Salmon;
            resources.ApplyResources(toolStripButtonDspacing, "toolStripButtonDspacing");
            toolStripButtonDspacing.Name = "toolStripButtonDspacing";
            toolStripButtonDspacing.CheckedChanged += toolStripButtonDiffractionSpots_CheckedChanged;
            // 
            // toolStripButtonDistance
            // 
            toolStripButtonDistance.CheckOnClick = true;
            toolStripButtonDistance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonDistance.ForeColor = System.Drawing.Color.Salmon;
            resources.ApplyResources(toolStripButtonDistance, "toolStripButtonDistance");
            toolStripButtonDistance.Name = "toolStripButtonDistance";
            toolStripButtonDistance.CheckedChanged += toolStripButtonDiffractionSpots_CheckedChanged;
            // 
            // toolStripButtonExcitationError
            // 
            toolStripButtonExcitationError.CheckOnClick = true;
            toolStripButtonExcitationError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonExcitationError.ForeColor = System.Drawing.Color.Salmon;
            resources.ApplyResources(toolStripButtonExcitationError, "toolStripButtonExcitationError");
            toolStripButtonExcitationError.Name = "toolStripButtonExcitationError";
            toolStripButtonExcitationError.CheckedChanged += toolStripButtonDiffractionSpots_CheckedChanged;
            // 
            // toolStripButtonFg
            // 
            toolStripButtonFg.CheckOnClick = true;
            toolStripButtonFg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonFg.ForeColor = System.Drawing.Color.Salmon;
            resources.ApplyResources(toolStripButtonFg, "toolStripButtonFg");
            toolStripButtonFg.Name = "toolStripButtonFg";
            toolStripButtonFg.CheckedChanged += toolStripButtonDiffractionSpots_CheckedChanged;
            // 
            // statusStrip1
            // 
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabelTimeForSearchingG, toolStripStatusLabelTimeForDrawing, toolStripStatusLabelTimeForBethe, toolStripStatusLabel3 });
            statusStrip1.Name = "statusStrip1";
            statusStrip1.MouseDown += statusStrip1_MouseDown;
            // 
            // toolStripStatusLabelTimeForSearchingG
            // 
            toolStripStatusLabelTimeForSearchingG.Name = "toolStripStatusLabelTimeForSearchingG";
            resources.ApplyResources(toolStripStatusLabelTimeForSearchingG, "toolStripStatusLabelTimeForSearchingG");
            // 
            // toolStripStatusLabelTimeForDrawing
            // 
            toolStripStatusLabelTimeForDrawing.Name = "toolStripStatusLabelTimeForDrawing";
            resources.ApplyResources(toolStripStatusLabelTimeForDrawing, "toolStripStatusLabelTimeForDrawing");
            // 
            // toolStripStatusLabelTimeForBethe
            // 
            toolStripStatusLabelTimeForBethe.Name = "toolStripStatusLabelTimeForBethe";
            resources.ApplyResources(toolStripStatusLabelTimeForBethe, "toolStripStatusLabelTimeForBethe");
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            resources.ApplyResources(toolStripStatusLabel3, "toolStripStatusLabel3");
            // 
            // panelMain
            // 
            resources.ApplyResources(panelMain, "panelMain");
            panelMain.Controls.Add(tabControl);
            panelMain.Controls.Add(graphicsBox);
            panelMain.Controls.Add(labelDummy);
            panelMain.Name = "panelMain";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Controls.Add(tabPageKikuchi);
            tabControl.Controls.Add(tabPageDebye);
            tabControl.Controls.Add(tabPageScale);
            tabControl.Controls.Add(tabPageMisc);
            tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.HotTrack = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.DrawItem += tabControl_DrawItem;
            tabControl.Selecting += tabControl_Selecting;
            tabControl.Click += tabControl_Click;
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.BackColor = System.Drawing.SystemColors.Control;
            tabPageGeneral.Controls.Add(groupBox4);
            tabPageGeneral.Controls.Add(groupBox3);
            resources.ApplyResources(tabPageGeneral, "tabPageGeneral");
            tabPageGeneral.Name = "tabPageGeneral";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(trackBarStrSize);
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            toolTip.SetToolTip(groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // trackBarStrSize
            // 
            resources.ApplyResources(trackBarStrSize, "trackBarStrSize");
            trackBarStrSize.LargeChange = 50;
            trackBarStrSize.Maximum = 200;
            trackBarStrSize.Minimum = 1;
            trackBarStrSize.Name = "trackBarStrSize";
            trackBarStrSize.SmallChange = 10;
            trackBarStrSize.TickFrequency = 500;
            trackBarStrSize.TickStyle = System.Windows.Forms.TickStyle.None;
            toolTip.SetToolTip(trackBarStrSize, resources.GetString("trackBarStrSize.ToolTip"));
            trackBarStrSize.Value = 80;
            trackBarStrSize.ValueChanged += Draw;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(colorControlString);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(colorControlFoot);
            groupBox3.Controls.Add(colorControlBackGround);
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            // 
            // colorControlString
            // 
            colorControlString.Argb = -1;
            resources.ApplyResources(colorControlString, "colorControlString");
            colorControlString.Blue = 255;
            colorControlString.BlueF = 1F;
            colorControlString.BoxSize = new System.Drawing.Size(20, 20);
            colorControlString.Color = System.Drawing.Color.FromArgb(255, 255, 255);
            colorControlString.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlString.Green = 255;
            colorControlString.GreenF = 1F;
            colorControlString.Name = "colorControlString";
            colorControlString.Red = 255;
            colorControlString.RedF = 1F;
            toolTip.SetToolTip(colorControlString, resources.GetString("colorControlString.ToolTip"));
            colorControlString.ColorChanged += Draw;
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            toolTip.SetToolTip(label14, resources.GetString("label14.ToolTip"));
            // 
            // colorControlFoot
            // 
            colorControlFoot.Argb = -16728064;
            resources.ApplyResources(colorControlFoot, "colorControlFoot");
            colorControlFoot.Blue = 0;
            colorControlFoot.BlueF = 0F;
            colorControlFoot.BoxSize = new System.Drawing.Size(20, 20);
            colorControlFoot.Color = System.Drawing.Color.FromArgb(0, 192, 0);
            colorControlFoot.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlFoot.Green = 192;
            colorControlFoot.GreenF = 0.7529412F;
            colorControlFoot.Name = "colorControlFoot";
            colorControlFoot.Red = 0;
            colorControlFoot.RedF = 0F;
            colorControlFoot.ColorChanged += Draw;
            // 
            // colorControlBackGround
            // 
            colorControlBackGround.Argb = -14671840;
            resources.ApplyResources(colorControlBackGround, "colorControlBackGround");
            colorControlBackGround.Blue = 32;
            colorControlBackGround.BlueF = 0.1254902F;
            colorControlBackGround.BoxSize = new System.Drawing.Size(20, 20);
            colorControlBackGround.Color = System.Drawing.Color.FromArgb(32, 32, 32);
            colorControlBackGround.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlBackGround.Green = 32;
            colorControlBackGround.GreenF = 0.1254902F;
            colorControlBackGround.Name = "colorControlBackGround";
            colorControlBackGround.Red = 32;
            colorControlBackGround.RedF = 0.1254902F;
            toolTip.SetToolTip(colorControlBackGround, resources.GetString("colorControlBackGround.ToolTip"));
            colorControlBackGround.ColorChanged += Draw;
            // 
            // tabPageKikuchi
            // 
            tabPageKikuchi.BackColor = System.Drawing.SystemColors.Control;
            tabPageKikuchi.Controls.Add(checkBoxKikuchiLine_Kinematical);
            tabPageKikuchi.Controls.Add(numericBoxKikuchiLineThreshold);
            tabPageKikuchi.Controls.Add(colorControlDefectLine);
            tabPageKikuchi.Controls.Add(colorControlExcessLine);
            tabPageKikuchi.Controls.Add(trackBarLineWidth);
            tabPageKikuchi.Controls.Add(label11);
            resources.ApplyResources(tabPageKikuchi, "tabPageKikuchi");
            tabPageKikuchi.Name = "tabPageKikuchi";
            // 
            // checkBoxKikuchiLine_Kinematical
            // 
            resources.ApplyResources(checkBoxKikuchiLine_Kinematical, "checkBoxKikuchiLine_Kinematical");
            checkBoxKikuchiLine_Kinematical.Checked = true;
            checkBoxKikuchiLine_Kinematical.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxKikuchiLine_Kinematical.Name = "checkBoxKikuchiLine_Kinematical";
            checkBoxKikuchiLine_Kinematical.UseVisualStyleBackColor = true;
            checkBoxKikuchiLine_Kinematical.CheckedChanged += checkBoxKikuchiLine_Kinematical_CheckedChanged;
            // 
            // numericBoxKikuchiLineThreshold
            // 
            numericBoxKikuchiLineThreshold.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(numericBoxKikuchiLineThreshold, "numericBoxKikuchiLineThreshold");
            numericBoxKikuchiLineThreshold.Maximum = 10D;
            numericBoxKikuchiLineThreshold.Minimum = 0D;
            numericBoxKikuchiLineThreshold.Name = "numericBoxKikuchiLineThreshold";
            numericBoxKikuchiLineThreshold.RadianValue = 0.0034906585039886592D;
            numericBoxKikuchiLineThreshold.RoundErrorAccuracy = -1;
            numericBoxKikuchiLineThreshold.ShowUpDown = true;
            numericBoxKikuchiLineThreshold.SmartIncrement = true;
            toolTip.SetToolTip(numericBoxKikuchiLineThreshold, resources.GetString("numericBoxKikuchiLineThreshold.ToolTip"));
            numericBoxKikuchiLineThreshold.Value = 0.2D;
            numericBoxKikuchiLineThreshold.ValueChanged += numericBoxKikuchiLineThreshold_ValueChanged;
            // 
            // colorControlDefectLine
            // 
            colorControlDefectLine.Argb = -16777216;
            resources.ApplyResources(colorControlDefectLine, "colorControlDefectLine");
            colorControlDefectLine.Blue = 0;
            colorControlDefectLine.BlueF = 0F;
            colorControlDefectLine.BoxSize = new System.Drawing.Size(20, 20);
            colorControlDefectLine.Color = System.Drawing.Color.FromArgb(0, 0, 0);
            colorControlDefectLine.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlDefectLine.Green = 0;
            colorControlDefectLine.GreenF = 0F;
            colorControlDefectLine.Name = "colorControlDefectLine";
            colorControlDefectLine.Red = 0;
            colorControlDefectLine.RedF = 0F;
            colorControlDefectLine.ColorChanged += Draw;
            // 
            // colorControlExcessLine
            // 
            colorControlExcessLine.Argb = -2039584;
            resources.ApplyResources(colorControlExcessLine, "colorControlExcessLine");
            colorControlExcessLine.Blue = 224;
            colorControlExcessLine.BlueF = 0.8784314F;
            colorControlExcessLine.BoxSize = new System.Drawing.Size(20, 20);
            colorControlExcessLine.Color = System.Drawing.Color.FromArgb(224, 224, 224);
            colorControlExcessLine.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlExcessLine.Green = 224;
            colorControlExcessLine.GreenF = 0.8784314F;
            colorControlExcessLine.Name = "colorControlExcessLine";
            colorControlExcessLine.Red = 224;
            colorControlExcessLine.RedF = 0.8784314F;
            colorControlExcessLine.ColorChanged += Draw;
            // 
            // trackBarLineWidth
            // 
            resources.ApplyResources(trackBarLineWidth, "trackBarLineWidth");
            trackBarLineWidth.Maximum = 10000;
            trackBarLineWidth.Minimum = 1;
            trackBarLineWidth.Name = "trackBarLineWidth";
            trackBarLineWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            toolTip.SetToolTip(trackBarLineWidth, resources.GetString("trackBarLineWidth.ToolTip"));
            trackBarLineWidth.Value = 4000;
            trackBarLineWidth.ValueChanged += numericUpDownResolution_ValueChanged;
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            toolTip.SetToolTip(label11, resources.GetString("label11.ToolTip"));
            // 
            // tabPageDebye
            // 
            tabPageDebye.BackColor = System.Drawing.SystemColors.Control;
            tabPageDebye.Controls.Add(colorControlDebyeRing);
            tabPageDebye.Controls.Add(checkBoxDebyeRingLabel);
            tabPageDebye.Controls.Add(checkBoxDebyeRingIgnoreIntensity);
            tabPageDebye.Controls.Add(label6);
            tabPageDebye.Controls.Add(trackBarDebyeRingWidth);
            resources.ApplyResources(tabPageDebye, "tabPageDebye");
            tabPageDebye.Name = "tabPageDebye";
            // 
            // colorControlDebyeRing
            // 
            colorControlDebyeRing.Argb = -256;
            resources.ApplyResources(colorControlDebyeRing, "colorControlDebyeRing");
            colorControlDebyeRing.Blue = 0;
            colorControlDebyeRing.BlueF = 0F;
            colorControlDebyeRing.BoxSize = new System.Drawing.Size(20, 20);
            colorControlDebyeRing.Color = System.Drawing.Color.FromArgb(255, 255, 0);
            colorControlDebyeRing.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlDebyeRing.Green = 255;
            colorControlDebyeRing.GreenF = 1F;
            colorControlDebyeRing.Name = "colorControlDebyeRing";
            colorControlDebyeRing.Red = 255;
            colorControlDebyeRing.RedF = 1F;
            toolTip.SetToolTip(colorControlDebyeRing, resources.GetString("colorControlDebyeRing.ToolTip"));
            colorControlDebyeRing.ColorChanged += Draw;
            // 
            // checkBoxDebyeRingLabel
            // 
            resources.ApplyResources(checkBoxDebyeRingLabel, "checkBoxDebyeRingLabel");
            checkBoxDebyeRingLabel.Name = "checkBoxDebyeRingLabel";
            toolTip.SetToolTip(checkBoxDebyeRingLabel, resources.GetString("checkBoxDebyeRingLabel.ToolTip"));
            checkBoxDebyeRingLabel.UseVisualStyleBackColor = true;
            checkBoxDebyeRingLabel.CheckedChanged += Draw;
            // 
            // checkBoxDebyeRingIgnoreIntensity
            // 
            resources.ApplyResources(checkBoxDebyeRingIgnoreIntensity, "checkBoxDebyeRingIgnoreIntensity");
            checkBoxDebyeRingIgnoreIntensity.Name = "checkBoxDebyeRingIgnoreIntensity";
            toolTip.SetToolTip(checkBoxDebyeRingIgnoreIntensity, resources.GetString("checkBoxDebyeRingIgnoreIntensity.ToolTip"));
            checkBoxDebyeRingIgnoreIntensity.UseVisualStyleBackColor = true;
            checkBoxDebyeRingIgnoreIntensity.CheckedChanged += Draw;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            toolTip.SetToolTip(label6, resources.GetString("label6.ToolTip"));
            // 
            // trackBarDebyeRingWidth
            // 
            resources.ApplyResources(trackBarDebyeRingWidth, "trackBarDebyeRingWidth");
            trackBarDebyeRingWidth.LargeChange = 1;
            trackBarDebyeRingWidth.Minimum = 1;
            trackBarDebyeRingWidth.Name = "trackBarDebyeRingWidth";
            trackBarDebyeRingWidth.TickFrequency = 500;
            trackBarDebyeRingWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            toolTip.SetToolTip(trackBarDebyeRingWidth, resources.GetString("trackBarDebyeRingWidth.ToolTip"));
            trackBarDebyeRingWidth.Value = 5;
            trackBarDebyeRingWidth.ValueChanged += Draw;
            // 
            // tabPageScale
            // 
            tabPageScale.BackColor = System.Drawing.SystemColors.Control;
            tabPageScale.Controls.Add(checkBoxScaleLabel);
            tabPageScale.Controls.Add(label12);
            tabPageScale.Controls.Add(trackBarScaleLineWidth);
            tabPageScale.Controls.Add(label16);
            tabPageScale.Controls.Add(flowLayoutPanel1);
            tabPageScale.Controls.Add(colorControlScaleAzimuth);
            tabPageScale.Controls.Add(colorControlScale2Theta);
            resources.ApplyResources(tabPageScale, "tabPageScale");
            tabPageScale.Name = "tabPageScale";
            // 
            // checkBoxScaleLabel
            // 
            resources.ApplyResources(checkBoxScaleLabel, "checkBoxScaleLabel");
            checkBoxScaleLabel.Checked = true;
            checkBoxScaleLabel.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxScaleLabel.Name = "checkBoxScaleLabel";
            toolTip.SetToolTip(checkBoxScaleLabel, resources.GetString("checkBoxScaleLabel.ToolTip"));
            checkBoxScaleLabel.UseVisualStyleBackColor = true;
            checkBoxScaleLabel.CheckedChanged += Draw;
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            // 
            // trackBarScaleLineWidth
            // 
            resources.ApplyResources(trackBarScaleLineWidth, "trackBarScaleLineWidth");
            trackBarScaleLineWidth.Minimum = 1;
            trackBarScaleLineWidth.Name = "trackBarScaleLineWidth";
            trackBarScaleLineWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            toolTip.SetToolTip(trackBarScaleLineWidth, resources.GetString("trackBarScaleLineWidth.ToolTip"));
            trackBarScaleLineWidth.Value = 3;
            trackBarScaleLineWidth.Scroll += Draw;
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            toolTip.SetToolTip(label16, resources.GetString("label16.ToolTip"));
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Controls.Add(radioButtonScaleDivisionFine);
            flowLayoutPanel1.Controls.Add(radioButtonScaleDivisionMedium);
            flowLayoutPanel1.Controls.Add(radioButtonScaleDivisionCoarse);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // radioButtonScaleDivisionFine
            // 
            resources.ApplyResources(radioButtonScaleDivisionFine, "radioButtonScaleDivisionFine");
            radioButtonScaleDivisionFine.Name = "radioButtonScaleDivisionFine";
            toolTip.SetToolTip(radioButtonScaleDivisionFine, resources.GetString("radioButtonScaleDivisionFine.ToolTip"));
            radioButtonScaleDivisionFine.UseVisualStyleBackColor = true;
            radioButtonScaleDivisionFine.CheckedChanged += Draw;
            // 
            // radioButtonScaleDivisionMedium
            // 
            resources.ApplyResources(radioButtonScaleDivisionMedium, "radioButtonScaleDivisionMedium");
            radioButtonScaleDivisionMedium.Checked = true;
            radioButtonScaleDivisionMedium.Name = "radioButtonScaleDivisionMedium";
            radioButtonScaleDivisionMedium.TabStop = true;
            toolTip.SetToolTip(radioButtonScaleDivisionMedium, resources.GetString("radioButtonScaleDivisionMedium.ToolTip"));
            radioButtonScaleDivisionMedium.UseVisualStyleBackColor = true;
            radioButtonScaleDivisionMedium.CheckedChanged += Draw;
            // 
            // radioButtonScaleDivisionCoarse
            // 
            resources.ApplyResources(radioButtonScaleDivisionCoarse, "radioButtonScaleDivisionCoarse");
            radioButtonScaleDivisionCoarse.Name = "radioButtonScaleDivisionCoarse";
            toolTip.SetToolTip(radioButtonScaleDivisionCoarse, resources.GetString("radioButtonScaleDivisionCoarse.ToolTip"));
            radioButtonScaleDivisionCoarse.UseVisualStyleBackColor = true;
            // 
            // colorControlScaleAzimuth
            // 
            colorControlScaleAzimuth.Argb = -8960954;
            resources.ApplyResources(colorControlScaleAzimuth, "colorControlScaleAzimuth");
            colorControlScaleAzimuth.Blue = 70;
            colorControlScaleAzimuth.BlueF = 0.274509817F;
            colorControlScaleAzimuth.BoxSize = new System.Drawing.Size(20, 20);
            colorControlScaleAzimuth.Color = System.Drawing.Color.FromArgb(119, 68, 70);
            colorControlScaleAzimuth.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlScaleAzimuth.Green = 68;
            colorControlScaleAzimuth.GreenF = 0.266666681F;
            colorControlScaleAzimuth.Name = "colorControlScaleAzimuth";
            colorControlScaleAzimuth.Red = 119;
            colorControlScaleAzimuth.RedF = 0.466666669F;
            toolTip.SetToolTip(colorControlScaleAzimuth, resources.GetString("colorControlScaleAzimuth.ToolTip"));
            colorControlScaleAzimuth.ColorChanged += Draw;
            // 
            // colorControlScale2Theta
            // 
            colorControlScale2Theta.Argb = -12303240;
            resources.ApplyResources(colorControlScale2Theta, "colorControlScale2Theta");
            colorControlScale2Theta.Blue = 120;
            colorControlScale2Theta.BlueF = 0.470588237F;
            colorControlScale2Theta.BoxSize = new System.Drawing.Size(20, 20);
            colorControlScale2Theta.Color = System.Drawing.Color.FromArgb(68, 68, 120);
            colorControlScale2Theta.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlScale2Theta.Green = 68;
            colorControlScale2Theta.GreenF = 0.266666681F;
            colorControlScale2Theta.Name = "colorControlScale2Theta";
            colorControlScale2Theta.Red = 68;
            colorControlScale2Theta.RedF = 0.266666681F;
            toolTip.SetToolTip(colorControlScale2Theta, resources.GetString("colorControlScale2Theta.ToolTip"));
            colorControlScale2Theta.ColorChanged += Draw;
            // 
            // tabPageMisc
            // 
            tabPageMisc.BackColor = System.Drawing.SystemColors.Control;
            tabPageMisc.Controls.Add(numericBoxDev);
            tabPageMisc.Controls.Add(numericBoxAcc);
            tabPageMisc.Controls.Add(button2);
            tabPageMisc.Controls.Add(button1);
            tabPageMisc.Controls.Add(groupBox5);
            resources.ApplyResources(tabPageMisc, "tabPageMisc");
            tabPageMisc.Name = "tabPageMisc";
            // 
            // numericBoxDev
            // 
            resources.ApplyResources(numericBoxDev, "numericBoxDev");
            numericBoxDev.BackColor = System.Drawing.SystemColors.Control;
            numericBoxDev.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxDev.Name = "numericBoxDev";
            numericBoxDev.RadianValue = 0.023911010752322315D;
            numericBoxDev.RoundErrorAccuracy = -1;
            numericBoxDev.SkipEventDuringInput = false;
            numericBoxDev.SmartIncrement = true;
            numericBoxDev.ThonsandsSeparator = true;
            numericBoxDev.Value = 1.37D;
            // 
            // numericBoxAcc
            // 
            resources.ApplyResources(numericBoxAcc, "numericBoxAcc");
            numericBoxAcc.BackColor = System.Drawing.SystemColors.Control;
            numericBoxAcc.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxAcc.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxAcc.Name = "numericBoxAcc";
            numericBoxAcc.RadianValue = 216.42082724729684D;
            numericBoxAcc.RoundErrorAccuracy = -1;
            numericBoxAcc.SkipEventDuringInput = false;
            numericBoxAcc.SmartIncrement = true;
            numericBoxAcc.ThonsandsSeparator = true;
            numericBoxAcc.Value = 12400D;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // groupBox5
            // 
            resources.ApplyResources(groupBox5, "groupBox5");
            groupBox5.Controls.Add(trackBarRotationSpeed);
            groupBox5.Name = "groupBox5";
            groupBox5.TabStop = false;
            toolTip.SetToolTip(groupBox5, resources.GetString("groupBox5.ToolTip"));
            // 
            // trackBarRotationSpeed
            // 
            resources.ApplyResources(trackBarRotationSpeed, "trackBarRotationSpeed");
            trackBarRotationSpeed.Maximum = 600;
            trackBarRotationSpeed.Minimum = 1;
            trackBarRotationSpeed.Name = "trackBarRotationSpeed";
            trackBarRotationSpeed.TickFrequency = 10000;
            trackBarRotationSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            toolTip.SetToolTip(trackBarRotationSpeed, resources.GetString("trackBarRotationSpeed.ToolTip"));
            trackBarRotationSpeed.Value = 150;
            // 
            // graphicsBox
            // 
            graphicsBox.BackColor = System.Drawing.Color.Transparent;
            graphicsBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(graphicsBox, "graphicsBox");
            graphicsBox.Name = "graphicsBox";
            graphicsBox.TabStop = false;
            toolTip.SetToolTip(graphicsBox, resources.GetString("graphicsBox.ToolTip"));
            graphicsBox.MouseDown += graphicsBox_MouseDown;
            graphicsBox.MouseMove += graphicsBox_MouseMove;
            graphicsBox.MouseUp += graphicsBox_MouseUp;
            graphicsBox.Move += Draw;
            graphicsBox.Resize += graphicsBox_Resize;
            // 
            // labelDummy
            // 
            resources.ApplyResources(labelDummy, "labelDummy");
            labelDummy.Name = "labelDummy";
            // 
            // panelMousePosition
            // 
            resources.ApplyResources(panelMousePosition, "panelMousePosition");
            panelMousePosition.Controls.Add(label24);
            panelMousePosition.Controls.Add(labelMousePositionDetector);
            panelMousePosition.Controls.Add(labelMousePositionReal);
            panelMousePosition.Controls.Add(labelDinv);
            panelMousePosition.Controls.Add(checkBoxMousePositionDetailes);
            panelMousePosition.Controls.Add(labelMousePositionReciprocal);
            panelMousePosition.Controls.Add(labelTwoThetaRad);
            panelMousePosition.Controls.Add(labelTwoThetaDeg);
            panelMousePosition.Controls.Add(labelD);
            panelMousePosition.Name = "panelMousePosition";
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.Name = "label24";
            // 
            // labelMousePositionDetector
            // 
            resources.ApplyResources(labelMousePositionDetector, "labelMousePositionDetector");
            labelMousePositionDetector.Name = "labelMousePositionDetector";
            // 
            // labelMousePositionReal
            // 
            resources.ApplyResources(labelMousePositionReal, "labelMousePositionReal");
            labelMousePositionReal.Name = "labelMousePositionReal";
            // 
            // labelDinv
            // 
            resources.ApplyResources(labelDinv, "labelDinv");
            labelDinv.Name = "labelDinv";
            // 
            // checkBoxMousePositionDetailes
            // 
            resources.ApplyResources(checkBoxMousePositionDetailes, "checkBoxMousePositionDetailes");
            checkBoxMousePositionDetailes.Name = "checkBoxMousePositionDetailes";
            toolTip.SetToolTip(checkBoxMousePositionDetailes, resources.GetString("checkBoxMousePositionDetailes.ToolTip"));
            checkBoxMousePositionDetailes.UseVisualStyleBackColor = true;
            checkBoxMousePositionDetailes.CheckedChanged += checkBoxMousePositionDetailes_CheckedChanged;
            // 
            // labelMousePositionReciprocal
            // 
            resources.ApplyResources(labelMousePositionReciprocal, "labelMousePositionReciprocal");
            labelMousePositionReciprocal.Name = "labelMousePositionReciprocal";
            // 
            // labelTwoThetaRad
            // 
            resources.ApplyResources(labelTwoThetaRad, "labelTwoThetaRad");
            labelTwoThetaRad.Name = "labelTwoThetaRad";
            // 
            // labelTwoThetaDeg
            // 
            resources.ApplyResources(labelTwoThetaDeg, "labelTwoThetaDeg");
            labelTwoThetaDeg.Name = "labelTwoThetaDeg";
            // 
            // labelD
            // 
            resources.ApplyResources(labelD, "labelD");
            labelD.Name = "labelD";
            // 
            // flowLayoutPanel6
            // 
            resources.ApplyResources(flowLayoutPanel6, "flowLayoutPanel6");
            flowLayoutPanel6.Controls.Add(groupBox6);
            flowLayoutPanel6.Controls.Add(groupBox1);
            flowLayoutPanel6.Controls.Add(groupBox2);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            // 
            // groupBox6
            // 
            resources.ApplyResources(groupBox6, "groupBox6");
            groupBox6.Controls.Add(numericBoxClientHeight);
            groupBox6.Controls.Add(numericBoxClientWidth);
            groupBox6.Controls.Add(numericBoxResolution);
            groupBox6.Controls.Add(label4);
            groupBox6.Name = "groupBox6";
            groupBox6.TabStop = false;
            toolTip.SetToolTip(groupBox6, resources.GetString("groupBox6.ToolTip"));
            // 
            // numericBoxClientHeight
            // 
            resources.ApplyResources(numericBoxClientHeight, "numericBoxClientHeight");
            numericBoxClientHeight.BackColor = System.Drawing.SystemColors.Control;
            numericBoxClientHeight.DecimalPlaces = 0;
            numericBoxClientHeight.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxClientHeight.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxClientHeight.Maximum = 2000D;
            numericBoxClientHeight.Minimum = 1D;
            numericBoxClientHeight.Name = "numericBoxClientHeight";
            numericBoxClientHeight.RadianValue = 17.453292519943293D;
            numericBoxClientHeight.RoundErrorAccuracy = -1;
            numericBoxClientHeight.ShowUpDown = true;
            numericBoxClientHeight.SmartIncrement = true;
            numericBoxClientHeight.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxClientHeight, resources.GetString("numericBoxClientHeight.ToolTip"));
            numericBoxClientHeight.Value = 1000D;
            numericBoxClientHeight.ValueChanged += NumericBoxClientSize_ValueChanged;
            // 
            // numericBoxClientWidth
            // 
            resources.ApplyResources(numericBoxClientWidth, "numericBoxClientWidth");
            numericBoxClientWidth.BackColor = System.Drawing.SystemColors.Control;
            numericBoxClientWidth.DecimalPlaces = 0;
            numericBoxClientWidth.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxClientWidth.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxClientWidth.Maximum = 2000D;
            numericBoxClientWidth.Minimum = 1D;
            numericBoxClientWidth.Name = "numericBoxClientWidth";
            numericBoxClientWidth.RadianValue = 17.453292519943293D;
            numericBoxClientWidth.RoundErrorAccuracy = -1;
            numericBoxClientWidth.ShowUpDown = true;
            numericBoxClientWidth.SmartIncrement = true;
            numericBoxClientWidth.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxClientWidth, resources.GetString("numericBoxClientWidth.ToolTip"));
            numericBoxClientWidth.Value = 1000D;
            numericBoxClientWidth.ValueChanged += NumericBoxClientSize_ValueChanged;
            // 
            // numericBoxResolution
            // 
            resources.ApplyResources(numericBoxResolution, "numericBoxResolution");
            numericBoxResolution.BackColor = System.Drawing.SystemColors.Control;
            numericBoxResolution.DecimalPlaces = 5;
            numericBoxResolution.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxResolution.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxResolution.Maximum = 10D;
            numericBoxResolution.Minimum = 1E-05D;
            numericBoxResolution.Name = "numericBoxResolution";
            numericBoxResolution.RadianValue = 0.0013962634015954637D;
            numericBoxResolution.RoundErrorAccuracy = -1;
            numericBoxResolution.ShowUpDown = true;
            numericBoxResolution.SmartIncrement = true;
            numericBoxResolution.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxResolution, resources.GetString("numericBoxResolution.ToolTip"));
            numericBoxResolution.Value = 0.08D;
            numericBoxResolution.ValueChanged += numericUpDownResolution_ValueChanged;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDownCamaraLength2);
            groupBox1.Controls.Add(buttonDetailedGeometry);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(label15);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // numericUpDownCamaraLength2
            // 
            numericUpDownCamaraLength2.DecimalPlaces = 3;
            resources.ApplyResources(numericUpDownCamaraLength2, "numericUpDownCamaraLength2");
            numericUpDownCamaraLength2.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownCamaraLength2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownCamaraLength2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCamaraLength2.Name = "numericUpDownCamaraLength2";
            toolTip.SetToolTip(numericUpDownCamaraLength2, resources.GetString("numericUpDownCamaraLength2.ToolTip"));
            numericUpDownCamaraLength2.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownCamaraLength2.ValueChanged += numericUpDownCamaraLength2_ValueChanged;
            // 
            // buttonDetailedGeometry
            // 
            resources.ApplyResources(buttonDetailedGeometry, "buttonDetailedGeometry");
            buttonDetailedGeometry.Name = "buttonDetailedGeometry";
            toolTip.SetToolTip(buttonDetailedGeometry, resources.GetString("buttonDetailedGeometry.ToolTip"));
            buttonDetailedGeometry.UseVisualStyleBackColor = true;
            buttonDetailedGeometry.Click += buttonDetailedGeometry_Click;
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            toolTip.SetToolTip(label18, resources.GetString("label18.ToolTip"));
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.Name = "label15";
            toolTip.SetToolTip(label15, resources.GetString("label15.ToolTip"));
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBoxCenter);
            groupBox2.Controls.Add(buttonResetCenter);
            groupBox2.Controls.Add(checkBoxFixCenter);
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // comboBoxCenter
            // 
            comboBoxCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBoxCenter, "comboBoxCenter");
            comboBoxCenter.FormattingEnabled = true;
            comboBoxCenter.Items.AddRange(new object[] { resources.GetString("comboBoxCenter.Items"), resources.GetString("comboBoxCenter.Items1"), resources.GetString("comboBoxCenter.Items2") });
            comboBoxCenter.Name = "comboBoxCenter";
            // 
            // buttonResetCenter
            // 
            resources.ApplyResources(buttonResetCenter, "buttonResetCenter");
            buttonResetCenter.Name = "buttonResetCenter";
            toolTip.SetToolTip(buttonResetCenter, resources.GetString("buttonResetCenter.ToolTip"));
            buttonResetCenter.UseVisualStyleBackColor = true;
            buttonResetCenter.Click += buttonResetCenter_Click_1;
            // 
            // checkBoxFixCenter
            // 
            resources.ApplyResources(checkBoxFixCenter, "checkBoxFixCenter");
            checkBoxFixCenter.Name = "checkBoxFixCenter";
            toolTip.SetToolTip(checkBoxFixCenter, resources.GetString("checkBoxFixCenter.ToolTip"));
            checkBoxFixCenter.UseVisualStyleBackColor = true;
            checkBoxFixCenter.CheckedChanged += checkBoxFixCenter_CheckedChanged;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, optionToolStripMenuItem, presetToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveImageToolStripMenuItem, saveDetectorAreaToolStripMenuItem, saveCBEDPatternToolStripMenuItem, copyImageToClipboardToolStripMenuItem, copyDetectorAreaToolStripMenuItem, copyCBEDPatternToolStripMenuItem, toolStripSeparator1, pageSetupToolStripMenuItem, printPreviewToolStripMenuItem, printToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.AutoToolTip = true;
            saveImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveAsImageToolStripMenuItem, saveAsMetafileToolStripMenuItem });
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            resources.ApplyResources(saveImageToolStripMenuItem, "saveImageToolStripMenuItem");
            // 
            // saveAsImageToolStripMenuItem
            // 
            saveAsImageToolStripMenuItem.Name = "saveAsImageToolStripMenuItem";
            resources.ApplyResources(saveAsImageToolStripMenuItem, "saveAsImageToolStripMenuItem");
            saveAsImageToolStripMenuItem.Click += saveAsImageToolStripMenuItem_Click;
            // 
            // saveAsMetafileToolStripMenuItem
            // 
            saveAsMetafileToolStripMenuItem.Name = "saveAsMetafileToolStripMenuItem";
            resources.ApplyResources(saveAsMetafileToolStripMenuItem, "saveAsMetafileToolStripMenuItem");
            saveAsMetafileToolStripMenuItem.Click += saveAsMetafileToolStripMenuItem_Click;
            // 
            // saveDetectorAreaToolStripMenuItem
            // 
            saveDetectorAreaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveDetectorAsImageToolStripMenuItem, saveDetectorAsMetafileToolStripMenuItem });
            saveDetectorAreaToolStripMenuItem.Name = "saveDetectorAreaToolStripMenuItem";
            resources.ApplyResources(saveDetectorAreaToolStripMenuItem, "saveDetectorAreaToolStripMenuItem");
            // 
            // saveDetectorAsImageToolStripMenuItem
            // 
            saveDetectorAsImageToolStripMenuItem.Name = "saveDetectorAsImageToolStripMenuItem";
            resources.ApplyResources(saveDetectorAsImageToolStripMenuItem, "saveDetectorAsImageToolStripMenuItem");
            saveDetectorAsImageToolStripMenuItem.Click += saveDetectorAsImageToolStripMenuItem_Click;
            // 
            // saveDetectorAsMetafileToolStripMenuItem
            // 
            saveDetectorAsMetafileToolStripMenuItem.Name = "saveDetectorAsMetafileToolStripMenuItem";
            resources.ApplyResources(saveDetectorAsMetafileToolStripMenuItem, "saveDetectorAsMetafileToolStripMenuItem");
            saveDetectorAsMetafileToolStripMenuItem.Click += saveDetectorAsMetafileToolStripMenuItem_Click;
            // 
            // saveCBEDPatternToolStripMenuItem
            // 
            saveCBEDPatternToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveCBEDasPngToolStripMenuItem, saveCBEDasTiffToolStripMenuItem, asPixelByPixelImagePNGFormatToolStripMenuItem, asCollectiveImageTiffFormatToolStripMenuItem });
            saveCBEDPatternToolStripMenuItem.Name = "saveCBEDPatternToolStripMenuItem";
            resources.ApplyResources(saveCBEDPatternToolStripMenuItem, "saveCBEDPatternToolStripMenuItem");
            // 
            // saveCBEDasPngToolStripMenuItem
            // 
            saveCBEDasPngToolStripMenuItem.Name = "saveCBEDasPngToolStripMenuItem";
            resources.ApplyResources(saveCBEDasPngToolStripMenuItem, "saveCBEDasPngToolStripMenuItem");
            saveCBEDasPngToolStripMenuItem.Click += saveCBEDasPngToolStripMenuItem_Click;
            // 
            // saveCBEDasTiffToolStripMenuItem
            // 
            saveCBEDasTiffToolStripMenuItem.Name = "saveCBEDasTiffToolStripMenuItem";
            resources.ApplyResources(saveCBEDasTiffToolStripMenuItem, "saveCBEDasTiffToolStripMenuItem");
            saveCBEDasTiffToolStripMenuItem.Click += saveCBEDasTiffToolStripMenuItem_Click;
            // 
            // asPixelByPixelImagePNGFormatToolStripMenuItem
            // 
            asPixelByPixelImagePNGFormatToolStripMenuItem.Name = "asPixelByPixelImagePNGFormatToolStripMenuItem";
            resources.ApplyResources(asPixelByPixelImagePNGFormatToolStripMenuItem, "asPixelByPixelImagePNGFormatToolStripMenuItem");
            asPixelByPixelImagePNGFormatToolStripMenuItem.Click += saveCBEDasCollectiveImageToolStripMenuItem_Click;
            // 
            // asCollectiveImageTiffFormatToolStripMenuItem
            // 
            asCollectiveImageTiffFormatToolStripMenuItem.Name = "asCollectiveImageTiffFormatToolStripMenuItem";
            resources.ApplyResources(asCollectiveImageTiffFormatToolStripMenuItem, "asCollectiveImageTiffFormatToolStripMenuItem");
            asCollectiveImageTiffFormatToolStripMenuItem.Click += asCollectiveImageTiffFormatToolStripMenuItem_Click;
            // 
            // copyImageToClipboardToolStripMenuItem
            // 
            copyImageToClipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { copyAsImageToolStripMenuItem, copyAsMetafileToolStripMenuItem });
            copyImageToClipboardToolStripMenuItem.Name = "copyImageToClipboardToolStripMenuItem";
            resources.ApplyResources(copyImageToClipboardToolStripMenuItem, "copyImageToClipboardToolStripMenuItem");
            // 
            // copyAsImageToolStripMenuItem
            // 
            copyAsImageToolStripMenuItem.Name = "copyAsImageToolStripMenuItem";
            resources.ApplyResources(copyAsImageToolStripMenuItem, "copyAsImageToolStripMenuItem");
            copyAsImageToolStripMenuItem.Click += copyAsImageToolStripMenuItem1_Click;
            // 
            // copyAsMetafileToolStripMenuItem
            // 
            copyAsMetafileToolStripMenuItem.Name = "copyAsMetafileToolStripMenuItem";
            resources.ApplyResources(copyAsMetafileToolStripMenuItem, "copyAsMetafileToolStripMenuItem");
            copyAsMetafileToolStripMenuItem.Click += copyAsMetafileToolStripMenuItem1_Click;
            // 
            // copyDetectorAreaToolStripMenuItem
            // 
            copyDetectorAreaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { copyDetectorAsImageToolStripMenuItem, copyDetectorAsMetafileToolStripMenuItem });
            copyDetectorAreaToolStripMenuItem.Name = "copyDetectorAreaToolStripMenuItem";
            resources.ApplyResources(copyDetectorAreaToolStripMenuItem, "copyDetectorAreaToolStripMenuItem");
            // 
            // copyDetectorAsImageToolStripMenuItem
            // 
            copyDetectorAsImageToolStripMenuItem.Name = "copyDetectorAsImageToolStripMenuItem";
            resources.ApplyResources(copyDetectorAsImageToolStripMenuItem, "copyDetectorAsImageToolStripMenuItem");
            copyDetectorAsImageToolStripMenuItem.Click += copyDetectorAsImageWithOverlappeImageToolStripMenuItem_Click;
            // 
            // copyDetectorAsMetafileToolStripMenuItem
            // 
            copyDetectorAsMetafileToolStripMenuItem.Name = "copyDetectorAsMetafileToolStripMenuItem";
            resources.ApplyResources(copyDetectorAsMetafileToolStripMenuItem, "copyDetectorAsMetafileToolStripMenuItem");
            copyDetectorAsMetafileToolStripMenuItem.Click += copyDetectorAsMetafileWithOverlappedImageToolStripMenuItem_Click;
            // 
            // copyCBEDPatternToolStripMenuItem
            // 
            copyCBEDPatternToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { copyCBEDasImageToolStripMenuItem });
            copyCBEDPatternToolStripMenuItem.Name = "copyCBEDPatternToolStripMenuItem";
            resources.ApplyResources(copyCBEDPatternToolStripMenuItem, "copyCBEDPatternToolStripMenuItem");
            // 
            // copyCBEDasImageToolStripMenuItem
            // 
            copyCBEDasImageToolStripMenuItem.Name = "copyCBEDasImageToolStripMenuItem";
            resources.ApplyResources(copyCBEDasImageToolStripMenuItem, "copyCBEDasImageToolStripMenuItem");
            copyCBEDasImageToolStripMenuItem.Click += copyCBEDasImageToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // pageSetupToolStripMenuItem
            // 
            pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            resources.ApplyResources(pageSetupToolStripMenuItem, "pageSetupToolStripMenuItem");
            pageSetupToolStripMenuItem.Click += pageSetupToolStripMenuItem_Click;
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            resources.ApplyResources(printPreviewToolStripMenuItem, "printPreviewToolStripMenuItem");
            printPreviewToolStripMenuItem.Click += printPreviewToolStripMenuItem_Click;
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(printToolStripMenuItem, "printToolStripMenuItem");
            printToolStripMenuItem.Click += printToolStripMenuItem_Click;
            // 
            // optionToolStripMenuItem
            // 
            optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemBackLaue, toolStripSeparator4, dynamicCompressionToolStripMenuItem, toolStripSeparator5 });
            optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            resources.ApplyResources(optionToolStripMenuItem, "optionToolStripMenuItem");
            // 
            // toolStripMenuItemBackLaue
            // 
            toolStripMenuItemBackLaue.CheckOnClick = true;
            toolStripMenuItemBackLaue.Name = "toolStripMenuItemBackLaue";
            resources.ApplyResources(toolStripMenuItemBackLaue, "toolStripMenuItemBackLaue");
            toolStripMenuItemBackLaue.CheckedChanged += Draw;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
            // 
            // dynamicCompressionToolStripMenuItem
            // 
            dynamicCompressionToolStripMenuItem.Name = "dynamicCompressionToolStripMenuItem";
            resources.ApplyResources(dynamicCompressionToolStripMenuItem, "dynamicCompressionToolStripMenuItem");
            dynamicCompressionToolStripMenuItem.Click += dynamicCompressionToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(toolStripSeparator5, "toolStripSeparator5");
            // 
            // presetToolStripMenuItem
            // 
            presetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { electron300KVToolStripMenuItem, electron200KVToolStripMenuItem, electron120KeVToolStripMenuItem, toolStripSeparator7, xray30KeVToolStripMenuItem, xray20KeVToolStripMenuItem, xrayMoKαToolStripMenuItem, xrayCuKαToolStripMenuItem });
            presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            resources.ApplyResources(presetToolStripMenuItem, "presetToolStripMenuItem");
            // 
            // electron300KVToolStripMenuItem
            // 
            electron300KVToolStripMenuItem.Name = "electron300KVToolStripMenuItem";
            resources.ApplyResources(electron300KVToolStripMenuItem, "electron300KVToolStripMenuItem");
            electron300KVToolStripMenuItem.Click += presetToolStripMenuItem_Click;
            // 
            // electron200KVToolStripMenuItem
            // 
            electron200KVToolStripMenuItem.Name = "electron200KVToolStripMenuItem";
            resources.ApplyResources(electron200KVToolStripMenuItem, "electron200KVToolStripMenuItem");
            electron200KVToolStripMenuItem.Click += presetToolStripMenuItem_Click;
            // 
            // electron120KeVToolStripMenuItem
            // 
            electron120KeVToolStripMenuItem.Name = "electron120KeVToolStripMenuItem";
            resources.ApplyResources(electron120KeVToolStripMenuItem, "electron120KeVToolStripMenuItem");
            electron120KeVToolStripMenuItem.Click += presetToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(toolStripSeparator7, "toolStripSeparator7");
            // 
            // xray30KeVToolStripMenuItem
            // 
            xray30KeVToolStripMenuItem.Name = "xray30KeVToolStripMenuItem";
            resources.ApplyResources(xray30KeVToolStripMenuItem, "xray30KeVToolStripMenuItem");
            xray30KeVToolStripMenuItem.Click += presetToolStripMenuItem_Click;
            // 
            // xray20KeVToolStripMenuItem
            // 
            xray20KeVToolStripMenuItem.Name = "xray20KeVToolStripMenuItem";
            resources.ApplyResources(xray20KeVToolStripMenuItem, "xray20KeVToolStripMenuItem");
            xray20KeVToolStripMenuItem.Click += presetToolStripMenuItem_Click;
            // 
            // xrayMoKαToolStripMenuItem
            // 
            xrayMoKαToolStripMenuItem.Name = "xrayMoKαToolStripMenuItem";
            resources.ApplyResources(xrayMoKαToolStripMenuItem, "xrayMoKαToolStripMenuItem");
            xrayMoKαToolStripMenuItem.Click += presetToolStripMenuItem_Click;
            // 
            // xrayCuKαToolStripMenuItem
            // 
            xrayCuKαToolStripMenuItem.Name = "xrayCuKαToolStripMenuItem";
            resources.ApplyResources(xrayCuKαToolStripMenuItem, "xrayCuKαToolStripMenuItem");
            xrayCuKαToolStripMenuItem.Click += presetToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { basicConceptOfBethesMethodToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // basicConceptOfBethesMethodToolStripMenuItem
            // 
            basicConceptOfBethesMethodToolStripMenuItem.Name = "basicConceptOfBethesMethodToolStripMenuItem";
            resources.ApplyResources(basicConceptOfBethesMethodToolStripMenuItem, "basicConceptOfBethesMethodToolStripMenuItem");
            basicConceptOfBethesMethodToolStripMenuItem.Click += basicConceptOfBethesMethodToolStripMenuItem_Click;
            // 
            // waveLengthControl
            // 
            waveLengthControl.Direction = System.Windows.Forms.FlowDirection.TopDown;
            waveLengthControl.Energy = 200D;
            resources.ApplyResources(waveLengthControl, "waveLengthControl");
            waveLengthControl.Name = "waveLengthControl";
            waveLengthControl.ShowWaveSource = true;
            waveLengthControl.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            waveLengthControl.WaveLength = 0.0025079347455D;
            waveLengthControl.WaveSource = WaveSource.Electron;
            waveLengthControl.XrayWaveSourceElementNumber = 0;
            waveLengthControl.XrayWaveSourceLine = XrayLine.Ka1;
            waveLengthControl.WavelengthChanged += waveLengthControl_WavelengthChanged;
            waveLengthControl.WaveSourceChanged += WaveLengthControl_WaveSourceChanged;
            // 
            // radioButtonIntensityDynamical
            // 
            resources.ApplyResources(radioButtonIntensityDynamical, "radioButtonIntensityDynamical");
            radioButtonIntensityDynamical.Name = "radioButtonIntensityDynamical";
            toolTip.SetToolTip(radioButtonIntensityDynamical, resources.GetString("radioButtonIntensityDynamical.ToolTip"));
            radioButtonIntensityDynamical.UseVisualStyleBackColor = true;
            radioButtonIntensityDynamical.CheckedChanged += radioButtonIntensityCalculationMethod_CheckedChanged;
            // 
            // checkBoxUseCrystalColor
            // 
            resources.ApplyResources(checkBoxUseCrystalColor, "checkBoxUseCrystalColor");
            checkBoxUseCrystalColor.Name = "checkBoxUseCrystalColor";
            toolTip.SetToolTip(checkBoxUseCrystalColor, resources.GetString("checkBoxUseCrystalColor.ToolTip"));
            checkBoxUseCrystalColor.CheckedChanged += checkBoxUseCrystalColor_CheckedChanged;
            // 
            // checkBoxExtinctionAll
            // 
            resources.ApplyResources(checkBoxExtinctionAll, "checkBoxExtinctionAll");
            checkBoxExtinctionAll.Name = "checkBoxExtinctionAll";
            toolTip.SetToolTip(checkBoxExtinctionAll, resources.GetString("checkBoxExtinctionAll.ToolTip"));
            checkBoxExtinctionAll.CheckedChanged += checkBoxExtinctionAll_CheckedChanged;
            // 
            // checkBoxExtinctionLattice
            // 
            resources.ApplyResources(checkBoxExtinctionLattice, "checkBoxExtinctionLattice");
            checkBoxExtinctionLattice.Checked = true;
            checkBoxExtinctionLattice.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxExtinctionLattice.Name = "checkBoxExtinctionLattice";
            toolTip.SetToolTip(checkBoxExtinctionLattice, resources.GetString("checkBoxExtinctionLattice.ToolTip"));
            checkBoxExtinctionLattice.CheckedChanged += checkBoxExtinctionAll_CheckedChanged;
            // 
            // groupBoxSpotProperty
            // 
            groupBoxSpotProperty.Controls.Add(panel2);
            resources.ApplyResources(groupBoxSpotProperty, "groupBoxSpotProperty");
            groupBoxSpotProperty.Name = "groupBoxSpotProperty";
            groupBoxSpotProperty.TabStop = false;
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(flowLayoutPanelPED);
            panel2.Controls.Add(flowLayoutPanelBethe);
            panel2.Controls.Add(flowLayoutPanelAppearance);
            panel2.Controls.Add(flowLayoutPanel3);
            panel2.Controls.Add(flowLayoutPanel5);
            panel2.Controls.Add(flowLayoutPanel11);
            panel2.Name = "panel2";
            // 
            // flowLayoutPanelPED
            // 
            resources.ApplyResources(flowLayoutPanelPED, "flowLayoutPanelPED");
            flowLayoutPanelPED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanelPED.Controls.Add(label5);
            flowLayoutPanelPED.Controls.Add(numericBoxPED_Semiangle);
            flowLayoutPanelPED.Controls.Add(numericBoxPED_Step);
            flowLayoutPanelPED.Name = "flowLayoutPanelPED";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // numericBoxPED_Semiangle
            // 
            resources.ApplyResources(numericBoxPED_Semiangle, "numericBoxPED_Semiangle");
            numericBoxPED_Semiangle.BackColor = System.Drawing.SystemColors.Control;
            numericBoxPED_Semiangle.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxPED_Semiangle.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxPED_Semiangle.Maximum = 500D;
            numericBoxPED_Semiangle.Minimum = 0.1D;
            numericBoxPED_Semiangle.Name = "numericBoxPED_Semiangle";
            numericBoxPED_Semiangle.RadianValue = 0.87266462599716477D;
            numericBoxPED_Semiangle.RoundErrorAccuracy = -1;
            numericBoxPED_Semiangle.ShowUpDown = true;
            numericBoxPED_Semiangle.SmartIncrement = true;
            numericBoxPED_Semiangle.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxPED_Semiangle, resources.GetString("numericBoxPED_Semiangle.ToolTip"));
            numericBoxPED_Semiangle.Value = 50D;
            numericBoxPED_Semiangle.ValueChanged += Draw;
            // 
            // numericBoxPED_Step
            // 
            resources.ApplyResources(numericBoxPED_Step, "numericBoxPED_Step");
            numericBoxPED_Step.BackColor = System.Drawing.SystemColors.Control;
            numericBoxPED_Step.DecimalPlaces = 0;
            numericBoxPED_Step.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxPED_Step.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxPED_Step.Maximum = 1080D;
            numericBoxPED_Step.Minimum = 2D;
            numericBoxPED_Step.Name = "numericBoxPED_Step";
            numericBoxPED_Step.RadianValue = 0.62831853071795862D;
            numericBoxPED_Step.RoundErrorAccuracy = -1;
            numericBoxPED_Step.ShowUpDown = true;
            numericBoxPED_Step.SmartIncrement = true;
            numericBoxPED_Step.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxPED_Step, resources.GetString("numericBoxPED_Step.ToolTip"));
            numericBoxPED_Step.Value = 36D;
            numericBoxPED_Step.ValueChanged += Draw;
            // 
            // flowLayoutPanelBethe
            // 
            resources.ApplyResources(flowLayoutPanelBethe, "flowLayoutPanelBethe");
            flowLayoutPanelBethe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanelBethe.Controls.Add(label1);
            flowLayoutPanelBethe.Controls.Add(numericBoxNumOfBlochWave);
            flowLayoutPanelBethe.Controls.Add(numericBoxThickness);
            flowLayoutPanelBethe.Name = "flowLayoutPanelBethe";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // numericBoxNumOfBlochWave
            // 
            resources.ApplyResources(numericBoxNumOfBlochWave, "numericBoxNumOfBlochWave");
            numericBoxNumOfBlochWave.BackColor = System.Drawing.SystemColors.Control;
            numericBoxNumOfBlochWave.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxNumOfBlochWave.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxNumOfBlochWave.Maximum = 1000D;
            numericBoxNumOfBlochWave.Minimum = 8D;
            numericBoxNumOfBlochWave.Name = "numericBoxNumOfBlochWave";
            numericBoxNumOfBlochWave.RadianValue = 4.1887902047863905D;
            numericBoxNumOfBlochWave.RoundErrorAccuracy = -1;
            numericBoxNumOfBlochWave.ShowUpDown = true;
            numericBoxNumOfBlochWave.SmartIncrement = true;
            numericBoxNumOfBlochWave.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxNumOfBlochWave, resources.GetString("numericBoxNumOfBlochWave.ToolTip"));
            numericBoxNumOfBlochWave.Value = 240D;
            numericBoxNumOfBlochWave.ValueChanged += Draw;
            // 
            // numericBoxThickness
            // 
            resources.ApplyResources(numericBoxThickness, "numericBoxThickness");
            numericBoxThickness.BackColor = System.Drawing.SystemColors.Control;
            numericBoxThickness.DecimalPlaces = 2;
            numericBoxThickness.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxThickness.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxThickness.Maximum = 10000D;
            numericBoxThickness.Minimum = 0.01D;
            numericBoxThickness.Name = "numericBoxThickness";
            numericBoxThickness.RadianValue = 0.87266462599716477D;
            numericBoxThickness.RoundErrorAccuracy = -1;
            numericBoxThickness.ShowUpDown = true;
            numericBoxThickness.SkipEventDuringInput = false;
            numericBoxThickness.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxThickness, resources.GetString("numericBoxThickness.ToolTip"));
            numericBoxThickness.UpDown_Increment = 10D;
            numericBoxThickness.Value = 50D;
            numericBoxThickness.ValueChanged += Draw;
            // 
            // flowLayoutPanelAppearance
            // 
            resources.ApplyResources(flowLayoutPanelAppearance, "flowLayoutPanelAppearance");
            flowLayoutPanelAppearance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanelAppearance.Controls.Add(label19);
            flowLayoutPanelAppearance.Controls.Add(flowLayoutPanel4);
            flowLayoutPanelAppearance.Controls.Add(flowLayoutPanel7);
            flowLayoutPanelAppearance.Controls.Add(flowLayoutPanel2);
            flowLayoutPanelAppearance.Controls.Add(flowLayoutPanelGaussianOption);
            flowLayoutPanelAppearance.Controls.Add(flowLayoutPanelSpotColor);
            flowLayoutPanelAppearance.Name = "flowLayoutPanelAppearance";
            flowLayoutPanelAppearance.Paint += flowLayoutPanelAppearance_Paint;
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            toolTip.SetToolTip(label19, resources.GetString("label19.ToolTip"));
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(flowLayoutPanel4, "flowLayoutPanel4");
            flowLayoutPanel4.Controls.Add(radioButtonCircleArea);
            flowLayoutPanel4.Controls.Add(radioButtonPointSpread);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // radioButtonCircleArea
            // 
            resources.ApplyResources(radioButtonCircleArea, "radioButtonCircleArea");
            radioButtonCircleArea.Checked = true;
            radioButtonCircleArea.Name = "radioButtonCircleArea";
            radioButtonCircleArea.TabStop = true;
            toolTip.SetToolTip(radioButtonCircleArea, resources.GetString("radioButtonCircleArea.ToolTip"));
            radioButtonCircleArea.UseVisualStyleBackColor = true;
            radioButtonCircleArea.CheckedChanged += radioButtonPointSpread_CheckedChanged;
            // 
            // radioButtonPointSpread
            // 
            resources.ApplyResources(radioButtonPointSpread, "radioButtonPointSpread");
            radioButtonPointSpread.Name = "radioButtonPointSpread";
            toolTip.SetToolTip(radioButtonPointSpread, resources.GetString("radioButtonPointSpread.ToolTip"));
            radioButtonPointSpread.UseVisualStyleBackColor = true;
            radioButtonPointSpread.CheckedChanged += radioButtonPointSpread_CheckedChanged;
            // 
            // flowLayoutPanel7
            // 
            resources.ApplyResources(flowLayoutPanel7, "flowLayoutPanel7");
            flowLayoutPanel7.Controls.Add(label8);
            flowLayoutPanel7.Controls.Add(trackBarSpotOpacity);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            toolTip.SetToolTip(flowLayoutPanel7, resources.GetString("flowLayoutPanel7.ToolTip"));
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            toolTip.SetToolTip(label8, resources.GetString("label8.ToolTip"));
            // 
            // trackBarSpotOpacity
            // 
            resources.ApplyResources(trackBarSpotOpacity, "trackBarSpotOpacity");
            trackBarSpotOpacity.LargeChange = 20;
            trackBarSpotOpacity.Maximum = 100;
            trackBarSpotOpacity.Name = "trackBarSpotOpacity";
            trackBarSpotOpacity.SmallChange = 10;
            trackBarSpotOpacity.TickFrequency = 500;
            trackBarSpotOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            toolTip.SetToolTip(trackBarSpotOpacity, resources.GetString("trackBarSpotOpacity.ToolTip"));
            trackBarSpotOpacity.Value = 100;
            trackBarSpotOpacity.ValueChanged += Draw;
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
            flowLayoutPanel2.Controls.Add(numericBoxSpotRadius);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // numericBoxSpotRadius
            // 
            resources.ApplyResources(numericBoxSpotRadius, "numericBoxSpotRadius");
            numericBoxSpotRadius.BackColor = System.Drawing.SystemColors.Control;
            numericBoxSpotRadius.DecimalPlaces = 4;
            numericBoxSpotRadius.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxSpotRadius.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxSpotRadius.Maximum = 1D;
            numericBoxSpotRadius.Minimum = 0.01D;
            numericBoxSpotRadius.Name = "numericBoxSpotRadius";
            numericBoxSpotRadius.RadianValue = 0.0034906585039886592D;
            numericBoxSpotRadius.RoundErrorAccuracy = -1;
            numericBoxSpotRadius.ShowUpDown = true;
            numericBoxSpotRadius.SkipEventDuringInput = false;
            numericBoxSpotRadius.SmartIncrement = true;
            numericBoxSpotRadius.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxSpotRadius, resources.GetString("numericBoxSpotRadius.ToolTip"));
            numericBoxSpotRadius.UpDown_Increment = 0.01D;
            numericBoxSpotRadius.Value = 0.2D;
            numericBoxSpotRadius.ValueChanged += Draw;
            // 
            // flowLayoutPanelGaussianOption
            // 
            resources.ApplyResources(flowLayoutPanelGaussianOption, "flowLayoutPanelGaussianOption");
            flowLayoutPanelGaussianOption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanelGaussianOption.Controls.Add(flowLayoutPanel8);
            flowLayoutPanelGaussianOption.Controls.Add(flowLayoutPanel9);
            flowLayoutPanelGaussianOption.Controls.Add(checkBoxLogScale);
            flowLayoutPanelGaussianOption.Controls.Add(flowLayoutPanelColorScale);
            flowLayoutPanelGaussianOption.Name = "flowLayoutPanelGaussianOption";
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(label10);
            flowLayoutPanel8.Controls.Add(trackBarIntensityForPointSpread);
            resources.ApplyResources(flowLayoutPanel8, "flowLayoutPanel8");
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            toolTip.SetToolTip(label10, resources.GetString("label10.ToolTip"));
            // 
            // trackBarIntensityForPointSpread
            // 
            resources.ApplyResources(trackBarIntensityForPointSpread, "trackBarIntensityForPointSpread");
            trackBarIntensityForPointSpread.LargeChange = 50;
            trackBarIntensityForPointSpread.Maximum = 800;
            trackBarIntensityForPointSpread.Minimum = 1;
            trackBarIntensityForPointSpread.Name = "trackBarIntensityForPointSpread";
            trackBarIntensityForPointSpread.SmallChange = 10;
            trackBarIntensityForPointSpread.TickFrequency = 500;
            trackBarIntensityForPointSpread.TickStyle = System.Windows.Forms.TickStyle.None;
            toolTip.SetToolTip(trackBarIntensityForPointSpread, resources.GetString("trackBarIntensityForPointSpread.ToolTip"));
            trackBarIntensityForPointSpread.Value = 400;
            trackBarIntensityForPointSpread.ValueChanged += Draw;
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.Controls.Add(label25);
            flowLayoutPanel9.Controls.Add(comboBoxScaleColorScale);
            resources.ApplyResources(flowLayoutPanel9, "flowLayoutPanel9");
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            // 
            // comboBoxScaleColorScale
            // 
            comboBoxScaleColorScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBoxScaleColorScale, "comboBoxScaleColorScale");
            comboBoxScaleColorScale.FormattingEnabled = true;
            comboBoxScaleColorScale.Items.AddRange(new object[] { resources.GetString("comboBoxScaleColorScale.Items"), resources.GetString("comboBoxScaleColorScale.Items1"), resources.GetString("comboBoxScaleColorScale.Items2"), resources.GetString("comboBoxScaleColorScale.Items3") });
            comboBoxScaleColorScale.Name = "comboBoxScaleColorScale";
            toolTip.SetToolTip(comboBoxScaleColorScale, resources.GetString("comboBoxScaleColorScale.ToolTip"));
            comboBoxScaleColorScale.SelectedIndexChanged += comboBoxScaleColorScale_SelectedIndexChanged;
            // 
            // checkBoxLogScale
            // 
            resources.ApplyResources(checkBoxLogScale, "checkBoxLogScale");
            checkBoxLogScale.Name = "checkBoxLogScale";
            toolTip.SetToolTip(checkBoxLogScale, resources.GetString("checkBoxLogScale.ToolTip"));
            checkBoxLogScale.UseVisualStyleBackColor = true;
            checkBoxLogScale.CheckedChanged += Draw;
            // 
            // flowLayoutPanelColorScale
            // 
            resources.ApplyResources(flowLayoutPanelColorScale, "flowLayoutPanelColorScale");
            flowLayoutPanelColorScale.Name = "flowLayoutPanelColorScale";
            // 
            // flowLayoutPanelSpotColor
            // 
            resources.ApplyResources(flowLayoutPanelSpotColor, "flowLayoutPanelSpotColor");
            flowLayoutPanelSpotColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanelSpotColor.Controls.Add(label2);
            flowLayoutPanelSpotColor.Controls.Add(checkBoxUseCrystalColor);
            flowLayoutPanelSpotColor.Controls.Add(colorControlOrigin);
            flowLayoutPanelSpotColor.Controls.Add(colorControlNoCondition);
            flowLayoutPanelSpotColor.Controls.Add(colorControlScrewGlide);
            flowLayoutPanelSpotColor.Controls.Add(colorControlForbiddenLattice);
            flowLayoutPanelSpotColor.Name = "flowLayoutPanelSpotColor";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // colorControlOrigin
            // 
            colorControlOrigin.Argb = -65536;
            resources.ApplyResources(colorControlOrigin, "colorControlOrigin");
            colorControlOrigin.BackColor = System.Drawing.Color.Transparent;
            colorControlOrigin.Blue = 0;
            colorControlOrigin.BlueF = 0F;
            colorControlOrigin.BoxSize = new System.Drawing.Size(20, 20);
            colorControlOrigin.Color = System.Drawing.Color.FromArgb(255, 0, 0);
            colorControlOrigin.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlOrigin.Green = 0;
            colorControlOrigin.GreenF = 0F;
            colorControlOrigin.Name = "colorControlOrigin";
            colorControlOrigin.Red = 255;
            colorControlOrigin.RedF = 1F;
            toolTip.SetToolTip(colorControlOrigin, resources.GetString("colorControlOrigin.ToolTip1"));
            colorControlOrigin.ColorChanged += Draw;
            // 
            // colorControlNoCondition
            // 
            colorControlNoCondition.Argb = -1;
            resources.ApplyResources(colorControlNoCondition, "colorControlNoCondition");
            colorControlNoCondition.Blue = 255;
            colorControlNoCondition.BlueF = 1F;
            colorControlNoCondition.BoxSize = new System.Drawing.Size(20, 20);
            colorControlNoCondition.Color = System.Drawing.Color.FromArgb(255, 255, 255);
            colorControlNoCondition.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlNoCondition.Green = 255;
            colorControlNoCondition.GreenF = 1F;
            colorControlNoCondition.Name = "colorControlNoCondition";
            colorControlNoCondition.Red = 255;
            colorControlNoCondition.RedF = 1F;
            toolTip.SetToolTip(colorControlNoCondition, resources.GetString("colorControlNoCondition.ToolTip1"));
            colorControlNoCondition.ColorChanged += Draw;
            // 
            // colorControlScrewGlide
            // 
            colorControlScrewGlide.Argb = -16192;
            resources.ApplyResources(colorControlScrewGlide, "colorControlScrewGlide");
            colorControlScrewGlide.Blue = 192;
            colorControlScrewGlide.BlueF = 0.7529412F;
            colorControlScrewGlide.BoxSize = new System.Drawing.Size(20, 20);
            colorControlScrewGlide.Color = System.Drawing.Color.FromArgb(255, 192, 192);
            colorControlScrewGlide.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlScrewGlide.Green = 192;
            colorControlScrewGlide.GreenF = 0.7529412F;
            colorControlScrewGlide.Name = "colorControlScrewGlide";
            colorControlScrewGlide.Red = 255;
            colorControlScrewGlide.RedF = 1F;
            toolTip.SetToolTip(colorControlScrewGlide, resources.GetString("colorControlScrewGlide.ToolTip1"));
            colorControlScrewGlide.ColorChanged += Draw;
            // 
            // colorControlForbiddenLattice
            // 
            colorControlForbiddenLattice.Argb = -4144897;
            resources.ApplyResources(colorControlForbiddenLattice, "colorControlForbiddenLattice");
            colorControlForbiddenLattice.Blue = 255;
            colorControlForbiddenLattice.BlueF = 1F;
            colorControlForbiddenLattice.BoxSize = new System.Drawing.Size(20, 20);
            colorControlForbiddenLattice.Color = System.Drawing.Color.FromArgb(192, 192, 255);
            colorControlForbiddenLattice.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlForbiddenLattice.Green = 192;
            colorControlForbiddenLattice.GreenF = 0.7529412F;
            colorControlForbiddenLattice.Name = "colorControlForbiddenLattice";
            colorControlForbiddenLattice.Red = 192;
            colorControlForbiddenLattice.RedF = 0.7529412F;
            toolTip.SetToolTip(colorControlForbiddenLattice, resources.GetString("colorControlForbiddenLattice.ToolTip1"));
            colorControlForbiddenLattice.ColorChanged += Draw;
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(flowLayoutPanel3, "flowLayoutPanel3");
            flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanel3.Controls.Add(label7);
            flowLayoutPanel3.Controls.Add(radioButtonIntensityExcitation);
            flowLayoutPanel3.Controls.Add(flowLayoutPanelExtinctionOption);
            flowLayoutPanel3.Controls.Add(radioButtonIntensityKinematical);
            flowLayoutPanel3.Controls.Add(radioButtonIntensityDynamical);
            flowLayoutPanel3.Controls.Add(buttonDetailsOfSpots);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // radioButtonIntensityExcitation
            // 
            resources.ApplyResources(radioButtonIntensityExcitation, "radioButtonIntensityExcitation");
            radioButtonIntensityExcitation.Name = "radioButtonIntensityExcitation";
            toolTip.SetToolTip(radioButtonIntensityExcitation, resources.GetString("radioButtonIntensityExcitation.ToolTip"));
            radioButtonIntensityExcitation.UseVisualStyleBackColor = true;
            radioButtonIntensityExcitation.CheckedChanged += radioButtonIntensityCalculationMethod_CheckedChanged;
            // 
            // flowLayoutPanelExtinctionOption
            // 
            resources.ApplyResources(flowLayoutPanelExtinctionOption, "flowLayoutPanelExtinctionOption");
            flowLayoutPanelExtinctionOption.Controls.Add(checkBoxExtinctionAll);
            flowLayoutPanelExtinctionOption.Controls.Add(checkBoxExtinctionLattice);
            flowLayoutPanelExtinctionOption.Name = "flowLayoutPanelExtinctionOption";
            // 
            // radioButtonIntensityKinematical
            // 
            resources.ApplyResources(radioButtonIntensityKinematical, "radioButtonIntensityKinematical");
            radioButtonIntensityKinematical.Checked = true;
            radioButtonIntensityKinematical.Name = "radioButtonIntensityKinematical";
            radioButtonIntensityKinematical.TabStop = true;
            toolTip.SetToolTip(radioButtonIntensityKinematical, resources.GetString("radioButtonIntensityKinematical.ToolTip"));
            radioButtonIntensityKinematical.UseVisualStyleBackColor = true;
            radioButtonIntensityKinematical.CheckedChanged += radioButtonIntensityCalculationMethod_CheckedChanged;
            // 
            // buttonDetailsOfSpots
            // 
            resources.ApplyResources(buttonDetailsOfSpots, "buttonDetailsOfSpots");
            buttonDetailsOfSpots.Name = "buttonDetailsOfSpots";
            toolTip.SetToolTip(buttonDetailsOfSpots, resources.GetString("buttonDetailsOfSpots.ToolTip"));
            buttonDetailsOfSpots.UseVisualStyleBackColor = true;
            buttonDetailsOfSpots.Click += ButtonDetailsOfSpots_Click;
            // 
            // flowLayoutPanel5
            // 
            resources.ApplyResources(flowLayoutPanel5, "flowLayoutPanel5");
            flowLayoutPanel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanel5.Controls.Add(label13);
            flowLayoutPanel5.Controls.Add(flowLayoutPanel10);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            // 
            // flowLayoutPanel10
            // 
            resources.ApplyResources(flowLayoutPanel10, "flowLayoutPanel10");
            flowLayoutPanel10.Controls.Add(radioButtonBeamParallel);
            flowLayoutPanel10.Controls.Add(radioButtonBeamPrecessionElectron);
            flowLayoutPanel10.Controls.Add(radioButtonBeamPrecessionXray);
            flowLayoutPanel10.Controls.Add(radioButtonBeamConvergence);
            flowLayoutPanel10.Name = "flowLayoutPanel10";
            // 
            // radioButtonBeamParallel
            // 
            resources.ApplyResources(radioButtonBeamParallel, "radioButtonBeamParallel");
            radioButtonBeamParallel.Checked = true;
            radioButtonBeamParallel.Name = "radioButtonBeamParallel";
            radioButtonBeamParallel.TabStop = true;
            toolTip.SetToolTip(radioButtonBeamParallel, resources.GetString("radioButtonBeamParallel.ToolTip"));
            radioButtonBeamParallel.UseVisualStyleBackColor = true;
            radioButtonBeamParallel.CheckedChanged += radioButtonBeamParallel_CheckedChanged;
            // 
            // radioButtonBeamPrecessionElectron
            // 
            resources.ApplyResources(radioButtonBeamPrecessionElectron, "radioButtonBeamPrecessionElectron");
            radioButtonBeamPrecessionElectron.Name = "radioButtonBeamPrecessionElectron";
            toolTip.SetToolTip(radioButtonBeamPrecessionElectron, resources.GetString("radioButtonBeamPrecessionElectron.ToolTip"));
            radioButtonBeamPrecessionElectron.UseVisualStyleBackColor = true;
            radioButtonBeamPrecessionElectron.CheckedChanged += radioButtonBeamParallel_CheckedChanged;
            // 
            // radioButtonBeamPrecessionXray
            // 
            resources.ApplyResources(radioButtonBeamPrecessionXray, "radioButtonBeamPrecessionXray");
            radioButtonBeamPrecessionXray.Name = "radioButtonBeamPrecessionXray";
            toolTip.SetToolTip(radioButtonBeamPrecessionXray, resources.GetString("radioButtonBeamPrecessionXray.ToolTip"));
            radioButtonBeamPrecessionXray.UseVisualStyleBackColor = true;
            radioButtonBeamPrecessionXray.CheckedChanged += radioButtonBeamParallel_CheckedChanged;
            // 
            // radioButtonBeamConvergence
            // 
            resources.ApplyResources(radioButtonBeamConvergence, "radioButtonBeamConvergence");
            radioButtonBeamConvergence.Name = "radioButtonBeamConvergence";
            toolTip.SetToolTip(radioButtonBeamConvergence, resources.GetString("radioButtonBeamConvergence.ToolTip"));
            radioButtonBeamConvergence.UseVisualStyleBackColor = true;
            radioButtonBeamConvergence.CheckedChanged += radioButtonBeamParallel_CheckedChanged;
            // 
            // flowLayoutPanel11
            // 
            resources.ApplyResources(flowLayoutPanel11, "flowLayoutPanel11");
            flowLayoutPanel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanel11.Controls.Add(label3);
            flowLayoutPanel11.Controls.Add(waveLengthControl);
            flowLayoutPanel11.Name = "flowLayoutPanel11";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 10000;
            toolTip.InitialDelay = 500;
            toolTip.IsBalloon = true;
            toolTip.ReshowDelay = 100;
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(printPreviewDialog1, "printPreviewDialog1");
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // pageSetupDialog1
            // 
            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.ShowHelp = true;
            // 
            // printDialog1
            // 
            printDialog1.AllowCurrentPage = true;
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;
            printDialog1.Document = printDocument1;
            printDialog1.PrintToFile = true;
            printDialog1.UseEXDialog = true;
            // 
            // timerBlinkSpot
            // 
            timerBlinkSpot.Interval = 400;
            timerBlinkSpot.Tag = "true";
            timerBlinkSpot.Tick += timerBlinkSpot_Tick;
            // 
            // timerBlinkKikuchiLine
            // 
            timerBlinkKikuchiLine.Interval = 400;
            timerBlinkKikuchiLine.Tick += timerBlinkKikuchiLine_Tick;
            // 
            // timerBlinkDebyeRing
            // 
            timerBlinkDebyeRing.Interval = 400;
            timerBlinkDebyeRing.Tick += timerBlinkDebyering_Tick;
            // 
            // timerBlinkScale
            // 
            timerBlinkScale.Interval = 400;
            timerBlinkScale.Tag = "";
            timerBlinkScale.Tick += timerBlinkScale_Tick;
            // 
            // toolStripButtonDspacingInv
            // 
            toolStripButtonDspacingInv.CheckOnClick = true;
            toolStripButtonDspacingInv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripButtonDspacingInv.ForeColor = System.Drawing.Color.Salmon;
            resources.ApplyResources(toolStripButtonDspacingInv, "toolStripButtonDspacingInv");
            toolStripButtonDspacingInv.Name = "toolStripButtonDspacingInv";
            // 
            // FormDiffractionSimulator
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(toolStripContainer1);
            Controls.Add(panel1);
            Controls.Add(groupBoxSpotProperty);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "FormDiffractionSimulator";
            FormClosing += FormElectronDiffraction_FormClosing;
            Load += FormElectronDiffraction_Load;
            ResizeBegin += FormDiffractionSimulator_ResizeBegin;
            ResizeEnd += FormElectronDiffraction_ResizeEnd;
            VisibleChanged += FormElectronDiffraction_VisibleChanged;
            DragDrop += FormDiffractionSimulator_DragDrop;
            DragEnter += FormDiffractionSimulator_DragEnter;
            Paint += FormDiffractionSimulator_Paint;
            toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer1.BottomToolStripPanel.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.ContentPanel.PerformLayout();
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelMain.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPageGeneral.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBarStrSize).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabPageKikuchi.ResumeLayout(false);
            tabPageKikuchi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarLineWidth).EndInit();
            tabPageDebye.ResumeLayout(false);
            tabPageDebye.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarDebyeRingWidth).EndInit();
            tabPageScale.ResumeLayout(false);
            tabPageScale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarScaleLineWidth).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tabPageMisc.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBarRotationSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)graphicsBox).EndInit();
            panelMousePosition.ResumeLayout(false);
            panelMousePosition.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCamaraLength2).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBoxSpotProperty.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanelPED.ResumeLayout(false);
            flowLayoutPanelPED.PerformLayout();
            flowLayoutPanelBethe.ResumeLayout(false);
            flowLayoutPanelBethe.PerformLayout();
            flowLayoutPanelAppearance.ResumeLayout(false);
            flowLayoutPanelAppearance.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSpotOpacity).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanelGaussianOption.ResumeLayout(false);
            flowLayoutPanelGaussianOption.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarIntensityForPointSpread).EndInit();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            flowLayoutPanelSpotColor.ResumeLayout(false);
            flowLayoutPanelSpotColor.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanelExtinctionOption.ResumeLayout(false);
            flowLayoutPanelExtinctionOption.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel10.ResumeLayout(false);
            flowLayoutPanel10.PerformLayout();
            flowLayoutPanel11.ResumeLayout(false);
            flowLayoutPanel11.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxExtinctionAll;
        private System.Windows.Forms.CheckBox checkBoxExtinctionLattice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackBarLineWidth;
        private System.Windows.Forms.TrackBar trackBarStrSize;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.NumericUpDown numericUpDownCamaraLength2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageKikuchi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyImageToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pageSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonIndexLabels;
        private System.Windows.Forms.ToolStripButton toolStripButtonDspacing;
        private System.Windows.Forms.ToolStripButton toolStripButtonDistance;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButtonKikuchiLines;
        private System.Windows.Forms.ToolStripButton toolStripButtonExcitationError;
        private System.Windows.Forms.ToolStripButton toolStripButtonFg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimeForSearchingG;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBackLaue;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TrackBar trackBarRotationSpeed;
        public WaveLengthControl waveLengthControl;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label labelMousePositionDetector;
        private System.Windows.Forms.Label labelMousePositionReciprocal;
        private System.Windows.Forms.TrackBar trackBarIntensityForPointSpread;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonDetailedGeometry;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageDebye;
        private System.Windows.Forms.GroupBox groupBoxSpotProperty;
        private System.Windows.Forms.RadioButton radioButtonCircleArea;
        private System.Windows.Forms.RadioButton radioButtonPointSpread;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonResetCenter;
        public NumericBox numericBoxResolution;
        public ImagingSolution.Control.GraphicsBox graphicsBox;
        private System.Windows.Forms.ToolStripMenuItem saveAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMetafileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAsMetafileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDiffractionSpots;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonDebyeRing;
        private System.Windows.Forms.CheckBox checkBoxDebyeRingIgnoreIntensity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBarDebyeRingWidth;
        private System.Windows.Forms.RadioButton radioButtonIntensityExcitation;
        private System.Windows.Forms.Label labelTwoThetaDeg;
        private System.Windows.Forms.Timer timerBlinkSpot;
        private System.Windows.Forms.Timer timerBlinkKikuchiLine;
        private System.Windows.Forms.Timer timerBlinkDebyeRing;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAppearance;
        private System.Windows.Forms.CheckBox checkBoxDebyeRingLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBarSpotOpacity;
        private System.Windows.Forms.ToolStripMenuItem copyAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyDetectorAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyDetectorAsMetafileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem copyDetectorAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDetectorAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDetectorAsMetafileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveDetectorAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimeForDrawing;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.CheckBox checkBoxUseCrystalColor;
        private System.Windows.Forms.CheckBox checkBoxLogScale;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBethe;
        private System.Windows.Forms.ToolStripMenuItem dynamicCompressionToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonIntensityKinematical;
        public System.Windows.Forms.RadioButton radioButtonIntensityDynamical;
        private System.Windows.Forms.ToolStripMenuItem saveCBEDasPngToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxFixCenter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem saveCBEDasTiffToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimeForBethe;
        private System.Windows.Forms.TabPage tabPageMisc;
        public NumericBox numericBoxClientHeight;
        public NumericBox numericBoxClientWidth;
        private System.Windows.Forms.Button button1;
        private NumericBox numericBoxDev;
        private NumericBox numericBoxAcc;
        private NumericBox numericBoxPED_Semiangle;
        private NumericBox numericBoxPED_Step;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPED;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton radioButtonBeamParallel;
        private System.Windows.Forms.RadioButton radioButtonBeamPrecessionElectron;
        public System.Windows.Forms.RadioButton radioButtonBeamConvergence;
        private System.Windows.Forms.Label labelDinv;
        private System.Windows.Forms.Button buttonDetailsOfSpots;
        public NumericBox numericBoxNumOfBlochWave;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.ComboBox comboBoxScaleColorScale;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelColorScale;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basicConceptOfBethesMethodToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGaussianOption;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private NumericBox numericBoxSpotRadius;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelExtinctionOption;
        private System.Windows.Forms.GroupBox groupBox4;
        public ColorControl colorControlOrigin;
        public ColorControl colorControlNoCondition;
        public ColorControl colorControlForbiddenLattice;
        public ColorControl colorControlScrewGlide;
        private System.Windows.Forms.Label label14;
        public ColorControl colorControlString;
        public ColorControl colorControlFoot;
        public ColorControl colorControlBackGround;
        public ColorControl colorControlDefectLine;
        public ColorControl colorControlExcessLine;
        public ColorControl colorControlDebyeRing;
        public NumericBox numericBoxThickness;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSpotColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageScale;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButtonScale;
        private System.Windows.Forms.CheckBox checkBoxScaleLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar trackBarScaleLineWidth;
        private System.Windows.Forms.Label label16;
        private ColorControl colorControlScale2Theta;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonScaleDivisionFine;
        private System.Windows.Forms.RadioButton radioButtonScaleDivisionMedium;
        private System.Windows.Forms.RadioButton radioButtonScaleDivisionCoarse;
        private System.Windows.Forms.Timer timerBlinkScale;
        private ColorControl colorControlScaleAzimuth;
        private System.Windows.Forms.Label labelMousePositionReal;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBoxMousePositionDetailes;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelMousePosition;
        private System.Windows.Forms.ToolStripMenuItem presetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem electron200KVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem electron120KeVToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem xray30KeVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xray20KeVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xrayMoKαToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xrayCuKαToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem electron300KVToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDummy;
        private NumericBox numericBoxKikuchiLineThreshold;
        private System.Windows.Forms.ToolStripMenuItem copyCBEDasImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asPixelByPixelImagePNGFormatToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTwoThetaRad;
        private System.Windows.Forms.CheckBox checkBoxKikuchiLine_Kinematical;
        private System.Windows.Forms.ToolStripMenuItem asCollectiveImageTiffFormatToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonBeamPrecessionXray;
        private System.Windows.Forms.ComboBox comboBoxCenter;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ToolStripMenuItem saveCBEDPatternToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem copyCBEDPatternToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDspacingInv;
    }
}