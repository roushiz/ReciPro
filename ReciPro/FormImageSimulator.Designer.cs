﻿using System;

namespace ReciPro
{
    partial class FormImageSimulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                scaleImage.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImageSimulator));
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            labelMousePositionValue = new System.Windows.Forms.Label();
            labelMousePositionY = new System.Windows.Forms.Label();
            labelMousePositionX = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            checkBoxShowUnitcell = new System.Windows.Forms.CheckBox();
            pictureBoxScaleOfIntensity = new System.Windows.Forms.PictureBox();
            flowLayoutPanelScale = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxScaleLength = new NumericBox();
            colorControlScale = new ColorControl();
            flowLayoutPanelLabel = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxLabelFontSize = new NumericBox();
            colorControlLabel = new ColorControl();
            checkBoxShowScale = new System.Windows.Forms.CheckBox();
            flowLayoutPanelGaussianBlur2 = new System.Windows.Forms.FlowLayoutPanel();
            checkBoxGaussianBlur = new System.Windows.Forms.CheckBox();
            numericBoxGaussianBlurRadius = new NumericBox();
            checkBoxShowLabel = new System.Windows.Forms.CheckBox();
            label25 = new System.Windows.Forms.Label();
            trackBarAdvancedMax = new TrackBarAdvanced();
            comboBoxScaleColorScale = new System.Windows.Forms.ComboBox();
            trackBarAdvancedMin = new TrackBarAdvanced();
            label27 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label33 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel3 = new System.Windows.Forms.Panel();
            groupBoxSerialImage = new System.Windows.Forms.GroupBox();
            panelSerial = new System.Windows.Forms.Panel();
            panelSerialThickness = new System.Windows.Forms.Panel();
            numericBoxThicknessNum = new NumericBox();
            numericBoxThicknessStep = new NumericBox();
            textBoxThicknessList = new System.Windows.Forms.TextBox();
            numericBoxThicknessStart = new NumericBox();
            panelSerialDefocus = new System.Windows.Forms.Panel();
            textBoxDefocusList = new System.Windows.Forms.TextBox();
            numericBoxDefocusNum = new NumericBox();
            numericBoxDefocusStep = new NumericBox();
            numericBoxDefocusStart = new NumericBox();
            flowLayoutPanelHorizontalDirection = new System.Windows.Forms.FlowLayoutPanel();
            label6 = new System.Windows.Forms.Label();
            radioButtonHorizontalDefocus = new System.Windows.Forms.RadioButton();
            radioButtonHorizontalThickness = new System.Windows.Forms.RadioButton();
            checkBoxSerialThickness = new System.Windows.Forms.CheckBox();
            checkBoxSerialDefocus = new System.Windows.Forms.CheckBox();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonSingleMode = new System.Windows.Forms.RadioButton();
            radioButtonSerialMode = new System.Windows.Forms.RadioButton();
            groupBoxPotentialOption = new System.Windows.Forms.GroupBox();
            flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonPotentialModeMagAndPhase = new System.Windows.Forms.RadioButton();
            flowLayoutPanelMagAndPhase = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonPotentialShowMagAndPhase = new System.Windows.Forms.RadioButton();
            radioButtonPotentialShowMag = new System.Windows.Forms.RadioButton();
            radioButtonPotentialShowPhase = new System.Windows.Forms.RadioButton();
            panelPhaseScale = new System.Windows.Forms.Panel();
            label24 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            pictureBoxPhaseScale = new System.Windows.Forms.PictureBox();
            label17 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            radioButtonPotentialModeRealAndImag = new System.Windows.Forms.RadioButton();
            flowLayoutPanelRealAndImaiginary = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonPotentialShowRealAndImag = new System.Windows.Forms.RadioButton();
            radioButtonPotentialShowReal = new System.Windows.Forms.RadioButton();
            radioButtonPotentialShowImag = new System.Windows.Forms.RadioButton();
            checkBoxPotentialUgPrime = new System.Windows.Forms.CheckBox();
            checkBoxPotentialUg = new System.Windows.Forms.CheckBox();
            groupBoxSTEMoption2 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonSTEM_target_Both = new System.Windows.Forms.RadioButton();
            radioButtonSTEM_target_Elas = new System.Windows.Forms.RadioButton();
            radioButtonSTEM_target_Inel = new System.Windows.Forms.RadioButton();
            numericBoxDivisionOfIncidentElectron = new NumericBox();
            numericBoxSliceThicknessForInelasticSTEM = new NumericBox();
            flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            groupBoxHREMoption2 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonModeQuasiCoherent = new System.Windows.Forms.RadioButton();
            radioButtonModeTransmissionCrossCoefficient = new System.Windows.Forms.RadioButton();
            label32 = new System.Windows.Forms.Label();
            panel6 = new System.Windows.Forms.Panel();
            groupBoxNormalization = new System.Windows.Forms.GroupBox();
            checkBoxNormarizeIndividually = new System.Windows.Forms.CheckBox();
            flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            checkBoxIntensityMin = new System.Windows.Forms.CheckBox();
            numericBoxIntensityMin = new NumericBox();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxIntensityMax = new NumericBox();
            groupBox8 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxWidth = new NumericBox();
            numericBoxHeight = new NumericBox();
            label2 = new System.Windows.Forms.Label();
            numericBoxResolution = new NumericBox();
            groupBox7 = new System.Windows.Forms.GroupBox();
            numericBoxNumOfBlochWave = new NumericBox();
            groupBoxOpticalProperty = new System.Windows.Forms.GroupBox();
            groupBoxSTEMoption1 = new System.Windows.Forms.GroupBox();
            contextMenuStripSTEM = new System.Windows.Forms.ContextMenuStrip(components);
            typicalBF02MradToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            typicalABF1224MradToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            typicalLAADF2560MradToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            typicalHAADF80250MradToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            numericBoxSTEM_DetectorOuterAngle = new NumericBox();
            numericBoxSourceSize = new NumericBox();
            numericBoxSTEM_ConvergenceAngle = new NumericBox();
            numericBoxSTEM_DetectorInnerAngle = new NumericBox();
            groupBoxHREMoption1 = new System.Windows.Forms.GroupBox();
            numericBoxObjAperX = new NumericBox();
            numericBoxObjAperRadius = new NumericBox();
            numericBoxObjAperY = new NumericBox();
            checkBoxOpenAperture = new System.Windows.Forms.CheckBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            textBoxNumOfSpots = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            textBoxApertureRadius = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            buttonDetailsOfSpots = new System.Windows.Forms.Button();
            label8 = new System.Windows.Forms.Label();
            panelLenz = new System.Windows.Forms.Panel();
            checkBoxShowLensFunctionGraph = new System.Windows.Forms.CheckBox();
            groupBoxLensFunction = new System.Windows.Forms.GroupBox();
            graphControl = new GraphControl();
            panelGraphOption = new System.Windows.Forms.Panel();
            buttonCopyGraph = new System.Windows.Forms.Button();
            numericBoxMaxU1 = new NumericBox();
            checkBoxGraphAll = new System.Windows.Forms.CheckBox();
            checkBoxGraphEc = new System.Windows.Forms.CheckBox();
            checkBoxGraphPCTF = new System.Windows.Forms.CheckBox();
            checkBoxGraphEs = new System.Windows.Forms.CheckBox();
            buttonPanel = new System.Windows.Forms.Button();
            groupBox4 = new System.Windows.Forms.GroupBox();
            contextMenuStripTEMcondition = new System.Windows.Forms.ContextMenuStrip(components);
            setoZeroDefocusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            setoScherzerDefocusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            setAllAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            numericBoxCs = new NumericBox();
            numericBoxCc = new NumericBox();
            numericBoxAccVol = new NumericBox();
            numericBoxDeltaV = new NumericBox();
            numericBoxDefocus = new NumericBox();
            numericBoxBetaAgnle = new NumericBox();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            label3 = new System.Windows.Forms.Label();
            textBoxScherzer = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            panel4 = new System.Windows.Forms.Panel();
            buttonSimulate = new System.Windows.Forms.Button();
            checkBoxRealTimeSimulation = new System.Windows.Forms.CheckBox();
            flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
            groupBox6 = new System.Windows.Forms.GroupBox();
            radioButtonProjectedPotential = new System.Windows.Forms.RadioButton();
            radioButtonSTEM = new System.Windows.Forms.RadioButton();
            radioButtonHRTEM = new System.Windows.Forms.RadioButton();
            groupBoxSampleProperty = new System.Windows.Forms.GroupBox();
            numericBoxThickness = new NumericBox();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemSavePNG = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemSaveTIFF = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemSaveMetafile = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemSaveIndividually = new System.Windows.Forms.ToolStripMenuItem();
            copyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemCopyMetafile = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemOverprintSymbols = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            readTEMParameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveTEMParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            detailsOfHRTEMSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            calculationLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripComboBoxCaclulationLibrary = new System.Windows.Forms.ToolStripComboBox();
            toolTip = new System.Windows.Forms.ToolTip(components);
            buttonStop = new System.Windows.Forms.Button();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxScaleOfIntensity).BeginInit();
            flowLayoutPanelScale.SuspendLayout();
            flowLayoutPanelLabel.SuspendLayout();
            flowLayoutPanelGaussianBlur2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            groupBoxSerialImage.SuspendLayout();
            panelSerial.SuspendLayout();
            panelSerialThickness.SuspendLayout();
            panelSerialDefocus.SuspendLayout();
            flowLayoutPanelHorizontalDirection.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            groupBoxPotentialOption.SuspendLayout();
            flowLayoutPanel11.SuspendLayout();
            flowLayoutPanelMagAndPhase.SuspendLayout();
            panelPhaseScale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhaseScale).BeginInit();
            flowLayoutPanelRealAndImaiginary.SuspendLayout();
            groupBoxSTEMoption2.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            groupBoxHREMoption2.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            panel6.SuspendLayout();
            groupBoxNormalization.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox8.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBoxOpticalProperty.SuspendLayout();
            groupBoxSTEMoption1.SuspendLayout();
            contextMenuStripSTEM.SuspendLayout();
            groupBoxHREMoption1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            panelLenz.SuspendLayout();
            groupBoxLensFunction.SuspendLayout();
            panelGraphOption.SuspendLayout();
            groupBox4.SuspendLayout();
            contextMenuStripTEMcondition.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            panel4.SuspendLayout();
            flowLayoutPanel14.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBoxSampleProperty.SuspendLayout();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Panel2.Controls.Add(groupBoxOpticalProperty);
            splitContainer1.Panel2.Controls.Add(panel4);
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel14);
            splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(splitContainer1.Panel2, "splitContainer1.Panel2");
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(tableLayoutPanel, "tableLayoutPanel");
            tableLayoutPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            tableLayoutPanel.CausesValidation = false;
            tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Enter += tableLayoutPanel_Enter;
            tableLayoutPanel.Leave += tableLayoutPanel_Leave;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelMousePositionValue);
            panel1.Controls.Add(labelMousePositionY);
            panel1.Controls.Add(labelMousePositionX);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // labelMousePositionValue
            // 
            resources.ApplyResources(labelMousePositionValue, "labelMousePositionValue");
            labelMousePositionValue.Name = "labelMousePositionValue";
            // 
            // labelMousePositionY
            // 
            resources.ApplyResources(labelMousePositionY, "labelMousePositionY");
            labelMousePositionY.Name = "labelMousePositionY";
            // 
            // labelMousePositionX
            // 
            resources.ApplyResources(labelMousePositionX, "labelMousePositionX");
            labelMousePositionX.Name = "labelMousePositionX";
            // 
            // panel2
            // 
            panel2.Controls.Add(checkBoxShowUnitcell);
            panel2.Controls.Add(pictureBoxScaleOfIntensity);
            panel2.Controls.Add(flowLayoutPanelScale);
            panel2.Controls.Add(flowLayoutPanelLabel);
            panel2.Controls.Add(checkBoxShowScale);
            panel2.Controls.Add(flowLayoutPanelGaussianBlur2);
            panel2.Controls.Add(checkBoxShowLabel);
            panel2.Controls.Add(label25);
            panel2.Controls.Add(trackBarAdvancedMax);
            panel2.Controls.Add(comboBoxScaleColorScale);
            panel2.Controls.Add(trackBarAdvancedMin);
            panel2.Controls.Add(label27);
            panel2.Controls.Add(label30);
            panel2.Controls.Add(label26);
            panel2.Controls.Add(label28);
            panel2.Controls.Add(label29);
            panel2.Controls.Add(label31);
            panel2.Controls.Add(label33);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // checkBoxShowUnitcell
            // 
            resources.ApplyResources(checkBoxShowUnitcell, "checkBoxShowUnitcell");
            checkBoxShowUnitcell.Checked = true;
            checkBoxShowUnitcell.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxShowUnitcell.Name = "checkBoxShowUnitcell";
            checkBoxShowUnitcell.UseVisualStyleBackColor = true;
            checkBoxShowUnitcell.CheckedChanged += CheckBoxShowLabel_CheckedChanged;
            // 
            // pictureBoxScaleOfIntensity
            // 
            resources.ApplyResources(pictureBoxScaleOfIntensity, "pictureBoxScaleOfIntensity");
            pictureBoxScaleOfIntensity.Name = "pictureBoxScaleOfIntensity";
            pictureBoxScaleOfIntensity.TabStop = false;
            // 
            // flowLayoutPanelScale
            // 
            resources.ApplyResources(flowLayoutPanelScale, "flowLayoutPanelScale");
            flowLayoutPanelScale.Controls.Add(numericBoxScaleLength);
            flowLayoutPanelScale.Controls.Add(colorControlScale);
            flowLayoutPanelScale.Name = "flowLayoutPanelScale";
            // 
            // numericBoxScaleLength
            // 
            resources.ApplyResources(numericBoxScaleLength, "numericBoxScaleLength");
            numericBoxScaleLength.BackColor = System.Drawing.SystemColors.Control;
            numericBoxScaleLength.DecimalPlaces = 1;
            numericBoxScaleLength.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxScaleLength.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxScaleLength.Maximum = 100D;
            numericBoxScaleLength.Minimum = 0.2D;
            numericBoxScaleLength.Name = "numericBoxScaleLength";
            numericBoxScaleLength.RadianValue = 0.0087266462599716477D;
            numericBoxScaleLength.RoundErrorAccuracy = -1;
            numericBoxScaleLength.ShowUpDown = true;
            numericBoxScaleLength.SkipEventDuringInput = false;
            numericBoxScaleLength.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxScaleLength.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxScaleLength, resources.GetString("numericBoxScaleLength.ToolTip"));
            numericBoxScaleLength.UpDown_Increment = 0.2D;
            numericBoxScaleLength.Value = 0.5D;
            numericBoxScaleLength.ValueChanged += CheckBoxShowLabel_CheckedChanged;
            // 
            // colorControlScale
            // 
            colorControlScale.Argb = -7877126;
            resources.ApplyResources(colorControlScale, "colorControlScale");
            colorControlScale.Blue = 250;
            colorControlScale.BlueF = 0.980392158F;
            colorControlScale.BoxSize = new System.Drawing.Size(20, 20);
            colorControlScale.Color = System.Drawing.Color.FromArgb(135, 205, 250);
            colorControlScale.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlScale.Green = 205;
            colorControlScale.GreenF = 0.8039216F;
            colorControlScale.Name = "colorControlScale";
            colorControlScale.Red = 135;
            colorControlScale.RedF = 0.5294118F;
            toolTip.SetToolTip(colorControlScale, resources.GetString("colorControlScale.ToolTip1"));
            colorControlScale.ColorChanged += CheckBoxShowLabel_CheckedChanged;
            // 
            // flowLayoutPanelLabel
            // 
            resources.ApplyResources(flowLayoutPanelLabel, "flowLayoutPanelLabel");
            flowLayoutPanelLabel.Controls.Add(numericBoxLabelFontSize);
            flowLayoutPanelLabel.Controls.Add(colorControlLabel);
            flowLayoutPanelLabel.Name = "flowLayoutPanelLabel";
            // 
            // numericBoxLabelFontSize
            // 
            resources.ApplyResources(numericBoxLabelFontSize, "numericBoxLabelFontSize");
            numericBoxLabelFontSize.BackColor = System.Drawing.SystemColors.Control;
            numericBoxLabelFontSize.DecimalPlaces = 0;
            numericBoxLabelFontSize.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxLabelFontSize.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxLabelFontSize.Maximum = 20D;
            numericBoxLabelFontSize.Minimum = 1D;
            numericBoxLabelFontSize.Name = "numericBoxLabelFontSize";
            numericBoxLabelFontSize.RadianValue = 0.15707963267948966D;
            numericBoxLabelFontSize.RoundErrorAccuracy = -1;
            numericBoxLabelFontSize.ShowUpDown = true;
            numericBoxLabelFontSize.SkipEventDuringInput = false;
            numericBoxLabelFontSize.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxLabelFontSize.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxLabelFontSize, resources.GetString("numericBoxLabelFontSize.ToolTip"));
            numericBoxLabelFontSize.Value = 9D;
            numericBoxLabelFontSize.ValueChanged += CheckBoxShowLabel_CheckedChanged;
            // 
            // colorControlLabel
            // 
            colorControlLabel.Argb = -5374161;
            resources.ApplyResources(colorControlLabel, "colorControlLabel");
            colorControlLabel.Blue = 47;
            colorControlLabel.BlueF = 0.184313729F;
            colorControlLabel.BoxSize = new System.Drawing.Size(20, 20);
            colorControlLabel.Color = System.Drawing.Color.FromArgb(173, 255, 47);
            colorControlLabel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlLabel.Green = 255;
            colorControlLabel.GreenF = 1F;
            colorControlLabel.Name = "colorControlLabel";
            colorControlLabel.Red = 173;
            colorControlLabel.RedF = 0.6784314F;
            toolTip.SetToolTip(colorControlLabel, resources.GetString("colorControlLabel.ToolTip1"));
            colorControlLabel.ColorChanged += CheckBoxShowLabel_CheckedChanged;
            // 
            // checkBoxShowScale
            // 
            resources.ApplyResources(checkBoxShowScale, "checkBoxShowScale");
            checkBoxShowScale.Checked = true;
            checkBoxShowScale.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxShowScale.Name = "checkBoxShowScale";
            toolTip.SetToolTip(checkBoxShowScale, resources.GetString("checkBoxShowScale.ToolTip"));
            checkBoxShowScale.UseVisualStyleBackColor = true;
            checkBoxShowScale.CheckedChanged += CheckBoxShowLabel_CheckedChanged;
            // 
            // flowLayoutPanelGaussianBlur2
            // 
            resources.ApplyResources(flowLayoutPanelGaussianBlur2, "flowLayoutPanelGaussianBlur2");
            flowLayoutPanelGaussianBlur2.Controls.Add(checkBoxGaussianBlur);
            flowLayoutPanelGaussianBlur2.Controls.Add(numericBoxGaussianBlurRadius);
            flowLayoutPanelGaussianBlur2.Name = "flowLayoutPanelGaussianBlur2";
            // 
            // checkBoxGaussianBlur
            // 
            resources.ApplyResources(checkBoxGaussianBlur, "checkBoxGaussianBlur");
            checkBoxGaussianBlur.Name = "checkBoxGaussianBlur";
            checkBoxGaussianBlur.UseVisualStyleBackColor = true;
            checkBoxGaussianBlur.CheckedChanged += CheckBoxGaussianBlur_CheckedChanged;
            // 
            // numericBoxGaussianBlurRadius
            // 
            resources.ApplyResources(numericBoxGaussianBlurRadius, "numericBoxGaussianBlurRadius");
            numericBoxGaussianBlurRadius.BackColor = System.Drawing.SystemColors.Control;
            numericBoxGaussianBlurRadius.DecimalPlaces = 1;
            numericBoxGaussianBlurRadius.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxGaussianBlurRadius.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxGaussianBlurRadius.Maximum = 100D;
            numericBoxGaussianBlurRadius.Minimum = 0D;
            numericBoxGaussianBlurRadius.Name = "numericBoxGaussianBlurRadius";
            numericBoxGaussianBlurRadius.RadianValue = 0.034906585039886591D;
            numericBoxGaussianBlurRadius.RoundErrorAccuracy = -1;
            numericBoxGaussianBlurRadius.ShowUpDown = true;
            numericBoxGaussianBlurRadius.SkipEventDuringInput = false;
            numericBoxGaussianBlurRadius.SmartIncrement = true;
            numericBoxGaussianBlurRadius.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxGaussianBlurRadius.ThonsandsSeparator = true;
            numericBoxGaussianBlurRadius.Value = 2D;
            numericBoxGaussianBlurRadius.ValueChanged += CheckBoxGaussianBlur_CheckedChanged;
            // 
            // checkBoxShowLabel
            // 
            resources.ApplyResources(checkBoxShowLabel, "checkBoxShowLabel");
            checkBoxShowLabel.Checked = true;
            checkBoxShowLabel.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxShowLabel.Name = "checkBoxShowLabel";
            toolTip.SetToolTip(checkBoxShowLabel, resources.GetString("checkBoxShowLabel.ToolTip"));
            checkBoxShowLabel.UseVisualStyleBackColor = true;
            checkBoxShowLabel.CheckedChanged += CheckBoxShowLabel_CheckedChanged;
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            // 
            // trackBarAdvancedMax
            // 
            resources.ApplyResources(trackBarAdvancedMax, "trackBarAdvancedMax");
            trackBarAdvancedMax.ControlHeight = 27;
            trackBarAdvancedMax.DecimalPlaces = -1;
            trackBarAdvancedMax.LogScrollBar = false;
            trackBarAdvancedMax.Maximum = 1D;
            trackBarAdvancedMax.Minimum = 0D;
            trackBarAdvancedMax.Name = "trackBarAdvancedMax";
            trackBarAdvancedMax.NumericBoxSize = 100;
            trackBarAdvancedMax.Orientation = System.Windows.Forms.Orientation.Vertical;
            trackBarAdvancedMax.Smart_Increment = true;
            trackBarAdvancedMax.TickStyle = System.Windows.Forms.TickStyle.BottomRight;
            trackBarAdvancedMax.UpDown_Increment = 0.01D;
            trackBarAdvancedMax.Value = 1D;
            trackBarAdvancedMax.ValueChanged += TrackBarAdvancedMin_ValueChanged;
            // 
            // comboBoxScaleColorScale
            // 
            comboBoxScaleColorScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxScaleColorScale.FormattingEnabled = true;
            comboBoxScaleColorScale.Items.AddRange(new object[] { resources.GetString("comboBoxScaleColorScale.Items"), resources.GetString("comboBoxScaleColorScale.Items1") });
            resources.ApplyResources(comboBoxScaleColorScale, "comboBoxScaleColorScale");
            comboBoxScaleColorScale.Name = "comboBoxScaleColorScale";
            comboBoxScaleColorScale.SelectedIndexChanged += ComboBoxScaleColorScale_SelectedIndexChanged;
            // 
            // trackBarAdvancedMin
            // 
            resources.ApplyResources(trackBarAdvancedMin, "trackBarAdvancedMin");
            trackBarAdvancedMin.ControlHeight = 27;
            trackBarAdvancedMin.DecimalPlaces = -1;
            trackBarAdvancedMin.LogScrollBar = false;
            trackBarAdvancedMin.Maximum = 65535D;
            trackBarAdvancedMin.Minimum = 0D;
            trackBarAdvancedMin.Name = "trackBarAdvancedMin";
            trackBarAdvancedMin.NumericBoxSize = 97;
            trackBarAdvancedMin.Orientation = System.Windows.Forms.Orientation.Vertical;
            trackBarAdvancedMin.Smart_Increment = true;
            trackBarAdvancedMin.TickStyle = System.Windows.Forms.TickStyle.BottomRight;
            trackBarAdvancedMin.UpDown_Increment = 1D;
            trackBarAdvancedMin.Value = 0D;
            trackBarAdvancedMin.ValueChanged += TrackBarAdvancedMin_ValueChanged;
            // 
            // label27
            // 
            resources.ApplyResources(label27, "label27");
            label27.Name = "label27";
            // 
            // label30
            // 
            resources.ApplyResources(label30, "label30");
            label30.Name = "label30";
            // 
            // label26
            // 
            resources.ApplyResources(label26, "label26");
            label26.Name = "label26";
            // 
            // label28
            // 
            resources.ApplyResources(label28, "label28");
            label28.Name = "label28";
            // 
            // label29
            // 
            resources.ApplyResources(label29, "label29");
            label29.Name = "label29";
            // 
            // label31
            // 
            resources.ApplyResources(label31, "label31");
            label31.Name = "label31";
            // 
            // label33
            // 
            resources.ApplyResources(label33, "label33");
            label33.Name = "label33";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(panel6);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.Controls.Add(groupBoxSerialImage);
            panel3.Controls.Add(groupBoxPotentialOption);
            panel3.Controls.Add(groupBoxSTEMoption2);
            panel3.Controls.Add(groupBoxHREMoption2);
            panel3.Name = "panel3";
            // 
            // groupBoxSerialImage
            // 
            resources.ApplyResources(groupBoxSerialImage, "groupBoxSerialImage");
            groupBoxSerialImage.Controls.Add(panelSerial);
            groupBoxSerialImage.Controls.Add(flowLayoutPanel4);
            groupBoxSerialImage.Name = "groupBoxSerialImage";
            groupBoxSerialImage.TabStop = false;
            // 
            // panelSerial
            // 
            panelSerial.Controls.Add(panelSerialThickness);
            panelSerial.Controls.Add(panelSerialDefocus);
            panelSerial.Controls.Add(flowLayoutPanelHorizontalDirection);
            panelSerial.Controls.Add(checkBoxSerialThickness);
            panelSerial.Controls.Add(checkBoxSerialDefocus);
            resources.ApplyResources(panelSerial, "panelSerial");
            panelSerial.Name = "panelSerial";
            // 
            // panelSerialThickness
            // 
            resources.ApplyResources(panelSerialThickness, "panelSerialThickness");
            panelSerialThickness.Controls.Add(numericBoxThicknessNum);
            panelSerialThickness.Controls.Add(numericBoxThicknessStep);
            panelSerialThickness.Controls.Add(textBoxThicknessList);
            panelSerialThickness.Controls.Add(numericBoxThicknessStart);
            panelSerialThickness.Name = "panelSerialThickness";
            // 
            // numericBoxThicknessNum
            // 
            resources.ApplyResources(numericBoxThicknessNum, "numericBoxThicknessNum");
            numericBoxThicknessNum.BackColor = System.Drawing.SystemColors.Control;
            numericBoxThicknessNum.DecimalPlaces = 0;
            numericBoxThicknessNum.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxThicknessNum.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxThicknessNum.Maximum = 20D;
            numericBoxThicknessNum.Minimum = 0.1D;
            numericBoxThicknessNum.Name = "numericBoxThicknessNum";
            numericBoxThicknessNum.RadianValue = 0.069813170079773182D;
            numericBoxThicknessNum.RoundErrorAccuracy = -1;
            numericBoxThicknessNum.ShowUpDown = true;
            numericBoxThicknessNum.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxThicknessNum.ThonsandsSeparator = true;
            numericBoxThicknessNum.Value = 4D;
            numericBoxThicknessNum.ValueChanged += NumericBoxThicknessSerial_ValueChanged;
            // 
            // numericBoxThicknessStep
            // 
            resources.ApplyResources(numericBoxThicknessStep, "numericBoxThicknessStep");
            numericBoxThicknessStep.BackColor = System.Drawing.SystemColors.Control;
            numericBoxThicknessStep.DecimalPlaces = 2;
            numericBoxThicknessStep.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxThicknessStep.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxThicknessStep.Maximum = 1000D;
            numericBoxThicknessStep.Minimum = 1D;
            numericBoxThicknessStep.Name = "numericBoxThicknessStep";
            numericBoxThicknessStep.RadianValue = 0.3490658503988659D;
            numericBoxThicknessStep.RoundErrorAccuracy = -1;
            numericBoxThicknessStep.ShowUpDown = true;
            numericBoxThicknessStep.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxThicknessStep.ThonsandsSeparator = true;
            numericBoxThicknessStep.UpDown_Increment = 10D;
            numericBoxThicknessStep.Value = 20D;
            numericBoxThicknessStep.ValueChanged += NumericBoxThicknessSerial_ValueChanged;
            // 
            // textBoxThicknessList
            // 
            resources.ApplyResources(textBoxThicknessList, "textBoxThicknessList");
            textBoxThicknessList.Name = "textBoxThicknessList";
            // 
            // numericBoxThicknessStart
            // 
            resources.ApplyResources(numericBoxThicknessStart, "numericBoxThicknessStart");
            numericBoxThicknessStart.BackColor = System.Drawing.SystemColors.Control;
            numericBoxThicknessStart.DecimalPlaces = 2;
            numericBoxThicknessStart.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxThicknessStart.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxThicknessStart.Maximum = 1000D;
            numericBoxThicknessStart.Minimum = 0.1D;
            numericBoxThicknessStart.Name = "numericBoxThicknessStart";
            numericBoxThicknessStart.RadianValue = 0.3490658503988659D;
            numericBoxThicknessStart.RoundErrorAccuracy = -1;
            numericBoxThicknessStart.ShowUpDown = true;
            numericBoxThicknessStart.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxThicknessStart.ThonsandsSeparator = true;
            numericBoxThicknessStart.UpDown_Increment = 10D;
            numericBoxThicknessStart.Value = 20D;
            numericBoxThicknessStart.ValueChanged += NumericBoxThicknessSerial_ValueChanged;
            // 
            // panelSerialDefocus
            // 
            resources.ApplyResources(panelSerialDefocus, "panelSerialDefocus");
            panelSerialDefocus.Controls.Add(textBoxDefocusList);
            panelSerialDefocus.Controls.Add(numericBoxDefocusNum);
            panelSerialDefocus.Controls.Add(numericBoxDefocusStep);
            panelSerialDefocus.Controls.Add(numericBoxDefocusStart);
            panelSerialDefocus.Name = "panelSerialDefocus";
            // 
            // textBoxDefocusList
            // 
            resources.ApplyResources(textBoxDefocusList, "textBoxDefocusList");
            textBoxDefocusList.Name = "textBoxDefocusList";
            // 
            // numericBoxDefocusNum
            // 
            resources.ApplyResources(numericBoxDefocusNum, "numericBoxDefocusNum");
            numericBoxDefocusNum.BackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocusNum.DecimalPlaces = 0;
            numericBoxDefocusNum.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocusNum.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocusNum.Maximum = 20D;
            numericBoxDefocusNum.Minimum = 1D;
            numericBoxDefocusNum.Name = "numericBoxDefocusNum";
            numericBoxDefocusNum.RadianValue = 0.069813170079773182D;
            numericBoxDefocusNum.RoundErrorAccuracy = -1;
            numericBoxDefocusNum.ShowUpDown = true;
            numericBoxDefocusNum.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxDefocusNum.ThonsandsSeparator = true;
            numericBoxDefocusNum.Value = 4D;
            numericBoxDefocusNum.ValueChanged += NumericBoxDefocusSerial_ValueChanged;
            // 
            // numericBoxDefocusStep
            // 
            resources.ApplyResources(numericBoxDefocusStep, "numericBoxDefocusStep");
            numericBoxDefocusStep.BackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocusStep.DecimalPlaces = 2;
            numericBoxDefocusStep.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocusStep.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocusStep.Maximum = 100D;
            numericBoxDefocusStep.Minimum = -100D;
            numericBoxDefocusStep.Name = "numericBoxDefocusStep";
            numericBoxDefocusStep.RadianValue = -0.3490658503988659D;
            numericBoxDefocusStep.RoundErrorAccuracy = -1;
            numericBoxDefocusStep.ShowUpDown = true;
            numericBoxDefocusStep.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxDefocusStep.ThonsandsSeparator = true;
            numericBoxDefocusStep.UpDown_Increment = 10D;
            numericBoxDefocusStep.Value = -20D;
            numericBoxDefocusStep.ValueChanged += NumericBoxDefocusSerial_ValueChanged;
            // 
            // numericBoxDefocusStart
            // 
            resources.ApplyResources(numericBoxDefocusStart, "numericBoxDefocusStart");
            numericBoxDefocusStart.BackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocusStart.DecimalPlaces = 2;
            numericBoxDefocusStart.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocusStart.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocusStart.Maximum = 1000D;
            numericBoxDefocusStart.Minimum = -1000D;
            numericBoxDefocusStart.Name = "numericBoxDefocusStart";
            numericBoxDefocusStart.RadianValue = -1.2217304763960306D;
            numericBoxDefocusStart.RoundErrorAccuracy = -1;
            numericBoxDefocusStart.ShowUpDown = true;
            numericBoxDefocusStart.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxDefocusStart.ThonsandsSeparator = true;
            numericBoxDefocusStart.UpDown_Increment = 10D;
            numericBoxDefocusStart.Value = -70D;
            numericBoxDefocusStart.ValueChanged += NumericBoxDefocusSerial_ValueChanged;
            // 
            // flowLayoutPanelHorizontalDirection
            // 
            resources.ApplyResources(flowLayoutPanelHorizontalDirection, "flowLayoutPanelHorizontalDirection");
            flowLayoutPanelHorizontalDirection.Controls.Add(label6);
            flowLayoutPanelHorizontalDirection.Controls.Add(radioButtonHorizontalDefocus);
            flowLayoutPanelHorizontalDirection.Controls.Add(radioButtonHorizontalThickness);
            flowLayoutPanelHorizontalDirection.Name = "flowLayoutPanelHorizontalDirection";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.ForeColor = System.Drawing.Color.Black;
            label6.Name = "label6";
            // 
            // radioButtonHorizontalDefocus
            // 
            resources.ApplyResources(radioButtonHorizontalDefocus, "radioButtonHorizontalDefocus");
            radioButtonHorizontalDefocus.Checked = true;
            radioButtonHorizontalDefocus.Name = "radioButtonHorizontalDefocus";
            radioButtonHorizontalDefocus.TabStop = true;
            radioButtonHorizontalDefocus.UseVisualStyleBackColor = true;
            // 
            // radioButtonHorizontalThickness
            // 
            resources.ApplyResources(radioButtonHorizontalThickness, "radioButtonHorizontalThickness");
            radioButtonHorizontalThickness.Name = "radioButtonHorizontalThickness";
            radioButtonHorizontalThickness.UseVisualStyleBackColor = true;
            // 
            // checkBoxSerialThickness
            // 
            resources.ApplyResources(checkBoxSerialThickness, "checkBoxSerialThickness");
            checkBoxSerialThickness.Checked = true;
            checkBoxSerialThickness.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxSerialThickness.Name = "checkBoxSerialThickness";
            checkBoxSerialThickness.UseVisualStyleBackColor = true;
            checkBoxSerialThickness.CheckedChanged += CheckBoxSerialDefocus_CheckedChanged;
            // 
            // checkBoxSerialDefocus
            // 
            resources.ApplyResources(checkBoxSerialDefocus, "checkBoxSerialDefocus");
            checkBoxSerialDefocus.Checked = true;
            checkBoxSerialDefocus.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxSerialDefocus.Name = "checkBoxSerialDefocus";
            checkBoxSerialDefocus.UseVisualStyleBackColor = true;
            checkBoxSerialDefocus.CheckedChanged += CheckBoxSerialDefocus_CheckedChanged;
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(flowLayoutPanel4, "flowLayoutPanel4");
            flowLayoutPanel4.Controls.Add(radioButtonSingleMode);
            flowLayoutPanel4.Controls.Add(radioButtonSerialMode);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // radioButtonSingleMode
            // 
            resources.ApplyResources(radioButtonSingleMode, "radioButtonSingleMode");
            radioButtonSingleMode.Checked = true;
            radioButtonSingleMode.Name = "radioButtonSingleMode";
            radioButtonSingleMode.TabStop = true;
            radioButtonSingleMode.UseVisualStyleBackColor = true;
            radioButtonSingleMode.CheckedChanged += CheckBoxSerialDefocus_CheckedChanged;
            // 
            // radioButtonSerialMode
            // 
            resources.ApplyResources(radioButtonSerialMode, "radioButtonSerialMode");
            radioButtonSerialMode.Name = "radioButtonSerialMode";
            radioButtonSerialMode.UseVisualStyleBackColor = true;
            // 
            // groupBoxPotentialOption
            // 
            resources.ApplyResources(groupBoxPotentialOption, "groupBoxPotentialOption");
            groupBoxPotentialOption.Controls.Add(flowLayoutPanel11);
            groupBoxPotentialOption.Controls.Add(checkBoxPotentialUgPrime);
            groupBoxPotentialOption.Controls.Add(checkBoxPotentialUg);
            groupBoxPotentialOption.Name = "groupBoxPotentialOption";
            groupBoxPotentialOption.TabStop = false;
            // 
            // flowLayoutPanel11
            // 
            resources.ApplyResources(flowLayoutPanel11, "flowLayoutPanel11");
            flowLayoutPanel11.Controls.Add(radioButtonPotentialModeMagAndPhase);
            flowLayoutPanel11.Controls.Add(flowLayoutPanelMagAndPhase);
            flowLayoutPanel11.Controls.Add(panelPhaseScale);
            flowLayoutPanel11.Controls.Add(radioButtonPotentialModeRealAndImag);
            flowLayoutPanel11.Controls.Add(flowLayoutPanelRealAndImaiginary);
            flowLayoutPanel11.Name = "flowLayoutPanel11";
            // 
            // radioButtonPotentialModeMagAndPhase
            // 
            resources.ApplyResources(radioButtonPotentialModeMagAndPhase, "radioButtonPotentialModeMagAndPhase");
            radioButtonPotentialModeMagAndPhase.Checked = true;
            radioButtonPotentialModeMagAndPhase.Name = "radioButtonPotentialModeMagAndPhase";
            radioButtonPotentialModeMagAndPhase.TabStop = true;
            radioButtonPotentialModeMagAndPhase.UseVisualStyleBackColor = true;
            radioButtonPotentialModeMagAndPhase.CheckedChanged += RadioButtonPotentialAsMagnitudeAndPhase_CheckedChanged;
            // 
            // flowLayoutPanelMagAndPhase
            // 
            resources.ApplyResources(flowLayoutPanelMagAndPhase, "flowLayoutPanelMagAndPhase");
            flowLayoutPanelMagAndPhase.Controls.Add(radioButtonPotentialShowMagAndPhase);
            flowLayoutPanelMagAndPhase.Controls.Add(radioButtonPotentialShowMag);
            flowLayoutPanelMagAndPhase.Controls.Add(radioButtonPotentialShowPhase);
            flowLayoutPanelMagAndPhase.Name = "flowLayoutPanelMagAndPhase";
            // 
            // radioButtonPotentialShowMagAndPhase
            // 
            resources.ApplyResources(radioButtonPotentialShowMagAndPhase, "radioButtonPotentialShowMagAndPhase");
            radioButtonPotentialShowMagAndPhase.Checked = true;
            radioButtonPotentialShowMagAndPhase.Name = "radioButtonPotentialShowMagAndPhase";
            radioButtonPotentialShowMagAndPhase.TabStop = true;
            radioButtonPotentialShowMagAndPhase.UseVisualStyleBackColor = true;
            // 
            // radioButtonPotentialShowMag
            // 
            resources.ApplyResources(radioButtonPotentialShowMag, "radioButtonPotentialShowMag");
            radioButtonPotentialShowMag.Name = "radioButtonPotentialShowMag";
            radioButtonPotentialShowMag.UseVisualStyleBackColor = true;
            // 
            // radioButtonPotentialShowPhase
            // 
            resources.ApplyResources(radioButtonPotentialShowPhase, "radioButtonPotentialShowPhase");
            radioButtonPotentialShowPhase.ForeColor = System.Drawing.SystemColors.ControlText;
            radioButtonPotentialShowPhase.Name = "radioButtonPotentialShowPhase";
            radioButtonPotentialShowPhase.UseVisualStyleBackColor = true;
            // 
            // panelPhaseScale
            // 
            resources.ApplyResources(panelPhaseScale, "panelPhaseScale");
            panelPhaseScale.Controls.Add(label24);
            panelPhaseScale.Controls.Add(label23);
            panelPhaseScale.Controls.Add(label22);
            panelPhaseScale.Controls.Add(label21);
            panelPhaseScale.Controls.Add(label20);
            panelPhaseScale.Controls.Add(label19);
            panelPhaseScale.Controls.Add(label18);
            panelPhaseScale.Controls.Add(pictureBoxPhaseScale);
            panelPhaseScale.Controls.Add(label17);
            panelPhaseScale.Controls.Add(label16);
            panelPhaseScale.Controls.Add(label15);
            panelPhaseScale.Controls.Add(label14);
            panelPhaseScale.Controls.Add(label11);
            panelPhaseScale.Controls.Add(label12);
            panelPhaseScale.Controls.Add(label13);
            panelPhaseScale.Controls.Add(label10);
            panelPhaseScale.Name = "panelPhaseScale";
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.Name = "label24";
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.Name = "label23";
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            // 
            // label20
            // 
            resources.ApplyResources(label20, "label20");
            label20.Name = "label20";
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            // 
            // pictureBoxPhaseScale
            // 
            resources.ApplyResources(pictureBoxPhaseScale, "pictureBoxPhaseScale");
            pictureBoxPhaseScale.Name = "pictureBoxPhaseScale";
            pictureBoxPhaseScale.TabStop = false;
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // radioButtonPotentialModeRealAndImag
            // 
            resources.ApplyResources(radioButtonPotentialModeRealAndImag, "radioButtonPotentialModeRealAndImag");
            radioButtonPotentialModeRealAndImag.Name = "radioButtonPotentialModeRealAndImag";
            radioButtonPotentialModeRealAndImag.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelRealAndImaiginary
            // 
            resources.ApplyResources(flowLayoutPanelRealAndImaiginary, "flowLayoutPanelRealAndImaiginary");
            flowLayoutPanelRealAndImaiginary.Controls.Add(radioButtonPotentialShowRealAndImag);
            flowLayoutPanelRealAndImaiginary.Controls.Add(radioButtonPotentialShowReal);
            flowLayoutPanelRealAndImaiginary.Controls.Add(radioButtonPotentialShowImag);
            flowLayoutPanelRealAndImaiginary.Name = "flowLayoutPanelRealAndImaiginary";
            // 
            // radioButtonPotentialShowRealAndImag
            // 
            resources.ApplyResources(radioButtonPotentialShowRealAndImag, "radioButtonPotentialShowRealAndImag");
            radioButtonPotentialShowRealAndImag.Checked = true;
            radioButtonPotentialShowRealAndImag.Name = "radioButtonPotentialShowRealAndImag";
            radioButtonPotentialShowRealAndImag.TabStop = true;
            radioButtonPotentialShowRealAndImag.UseVisualStyleBackColor = true;
            // 
            // radioButtonPotentialShowReal
            // 
            resources.ApplyResources(radioButtonPotentialShowReal, "radioButtonPotentialShowReal");
            radioButtonPotentialShowReal.Name = "radioButtonPotentialShowReal";
            radioButtonPotentialShowReal.UseVisualStyleBackColor = true;
            // 
            // radioButtonPotentialShowImag
            // 
            resources.ApplyResources(radioButtonPotentialShowImag, "radioButtonPotentialShowImag");
            radioButtonPotentialShowImag.Name = "radioButtonPotentialShowImag";
            radioButtonPotentialShowImag.UseVisualStyleBackColor = true;
            // 
            // checkBoxPotentialUgPrime
            // 
            resources.ApplyResources(checkBoxPotentialUgPrime, "checkBoxPotentialUgPrime");
            checkBoxPotentialUgPrime.Checked = true;
            checkBoxPotentialUgPrime.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxPotentialUgPrime.Name = "checkBoxPotentialUgPrime";
            checkBoxPotentialUgPrime.UseVisualStyleBackColor = true;
            // 
            // checkBoxPotentialUg
            // 
            resources.ApplyResources(checkBoxPotentialUg, "checkBoxPotentialUg");
            checkBoxPotentialUg.Checked = true;
            checkBoxPotentialUg.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxPotentialUg.Name = "checkBoxPotentialUg";
            checkBoxPotentialUg.UseVisualStyleBackColor = true;
            // 
            // groupBoxSTEMoption2
            // 
            groupBoxSTEMoption2.Controls.Add(flowLayoutPanel7);
            groupBoxSTEMoption2.Controls.Add(numericBoxDivisionOfIncidentElectron);
            groupBoxSTEMoption2.Controls.Add(numericBoxSliceThicknessForInelasticSTEM);
            groupBoxSTEMoption2.Controls.Add(flowLayoutPanel10);
            resources.ApplyResources(groupBoxSTEMoption2, "groupBoxSTEMoption2");
            groupBoxSTEMoption2.Name = "groupBoxSTEMoption2";
            groupBoxSTEMoption2.TabStop = false;
            // 
            // flowLayoutPanel7
            // 
            resources.ApplyResources(flowLayoutPanel7, "flowLayoutPanel7");
            flowLayoutPanel7.Controls.Add(radioButtonSTEM_target_Both);
            flowLayoutPanel7.Controls.Add(radioButtonSTEM_target_Elas);
            flowLayoutPanel7.Controls.Add(radioButtonSTEM_target_Inel);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            // 
            // radioButtonSTEM_target_Both
            // 
            resources.ApplyResources(radioButtonSTEM_target_Both, "radioButtonSTEM_target_Both");
            radioButtonSTEM_target_Both.Checked = true;
            radioButtonSTEM_target_Both.Name = "radioButtonSTEM_target_Both";
            radioButtonSTEM_target_Both.TabStop = true;
            radioButtonSTEM_target_Both.UseVisualStyleBackColor = true;
            // 
            // radioButtonSTEM_target_Elas
            // 
            resources.ApplyResources(radioButtonSTEM_target_Elas, "radioButtonSTEM_target_Elas");
            radioButtonSTEM_target_Elas.Name = "radioButtonSTEM_target_Elas";
            radioButtonSTEM_target_Elas.UseVisualStyleBackColor = true;
            // 
            // radioButtonSTEM_target_Inel
            // 
            resources.ApplyResources(radioButtonSTEM_target_Inel, "radioButtonSTEM_target_Inel");
            radioButtonSTEM_target_Inel.Name = "radioButtonSTEM_target_Inel";
            radioButtonSTEM_target_Inel.UseVisualStyleBackColor = true;
            // 
            // numericBoxDivisionOfIncidentElectron
            // 
            resources.ApplyResources(numericBoxDivisionOfIncidentElectron, "numericBoxDivisionOfIncidentElectron");
            numericBoxDivisionOfIncidentElectron.BackColor = System.Drawing.SystemColors.Control;
            numericBoxDivisionOfIncidentElectron.DecimalPlaces = 0;
            numericBoxDivisionOfIncidentElectron.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxDivisionOfIncidentElectron.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxDivisionOfIncidentElectron.Maximum = 1024D;
            numericBoxDivisionOfIncidentElectron.Minimum = 16D;
            numericBoxDivisionOfIncidentElectron.Name = "numericBoxDivisionOfIncidentElectron";
            numericBoxDivisionOfIncidentElectron.RadianValue = 2.2340214425527418D;
            numericBoxDivisionOfIncidentElectron.RoundErrorAccuracy = -1;
            numericBoxDivisionOfIncidentElectron.ShowUpDown = true;
            numericBoxDivisionOfIncidentElectron.SmartIncrement = true;
            numericBoxDivisionOfIncidentElectron.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxDivisionOfIncidentElectron.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxDivisionOfIncidentElectron, resources.GetString("numericBoxDivisionOfIncidentElectron.ToolTip"));
            numericBoxDivisionOfIncidentElectron.Value = 128D;
            // 
            // numericBoxSliceThicknessForInelasticSTEM
            // 
            resources.ApplyResources(numericBoxSliceThicknessForInelasticSTEM, "numericBoxSliceThicknessForInelasticSTEM");
            numericBoxSliceThicknessForInelasticSTEM.BackColor = System.Drawing.SystemColors.Control;
            numericBoxSliceThicknessForInelasticSTEM.DecimalPlaces = 1;
            numericBoxSliceThicknessForInelasticSTEM.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxSliceThicknessForInelasticSTEM.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxSliceThicknessForInelasticSTEM.Maximum = 10D;
            numericBoxSliceThicknessForInelasticSTEM.Minimum = 0.1D;
            numericBoxSliceThicknessForInelasticSTEM.Name = "numericBoxSliceThicknessForInelasticSTEM";
            numericBoxSliceThicknessForInelasticSTEM.RadianValue = 0.017453292519943295D;
            numericBoxSliceThicknessForInelasticSTEM.RoundErrorAccuracy = -1;
            numericBoxSliceThicknessForInelasticSTEM.ShowUpDown = true;
            numericBoxSliceThicknessForInelasticSTEM.SmartIncrement = true;
            numericBoxSliceThicknessForInelasticSTEM.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxSliceThicknessForInelasticSTEM.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxSliceThicknessForInelasticSTEM, resources.GetString("numericBoxSliceThicknessForInelasticSTEM.ToolTip"));
            numericBoxSliceThicknessForInelasticSTEM.Value = 1D;
            // 
            // flowLayoutPanel10
            // 
            resources.ApplyResources(flowLayoutPanel10, "flowLayoutPanel10");
            flowLayoutPanel10.Name = "flowLayoutPanel10";
            // 
            // groupBoxHREMoption2
            // 
            resources.ApplyResources(groupBoxHREMoption2, "groupBoxHREMoption2");
            groupBoxHREMoption2.Controls.Add(flowLayoutPanel8);
            groupBoxHREMoption2.Controls.Add(label32);
            groupBoxHREMoption2.Name = "groupBoxHREMoption2";
            groupBoxHREMoption2.TabStop = false;
            // 
            // flowLayoutPanel8
            // 
            resources.ApplyResources(flowLayoutPanel8, "flowLayoutPanel8");
            flowLayoutPanel8.Controls.Add(radioButtonModeQuasiCoherent);
            flowLayoutPanel8.Controls.Add(radioButtonModeTransmissionCrossCoefficient);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            // 
            // radioButtonModeQuasiCoherent
            // 
            resources.ApplyResources(radioButtonModeQuasiCoherent, "radioButtonModeQuasiCoherent");
            radioButtonModeQuasiCoherent.Checked = true;
            radioButtonModeQuasiCoherent.Name = "radioButtonModeQuasiCoherent";
            radioButtonModeQuasiCoherent.TabStop = true;
            toolTip.SetToolTip(radioButtonModeQuasiCoherent, resources.GetString("radioButtonModeQuasiCoherent.ToolTip"));
            radioButtonModeQuasiCoherent.UseVisualStyleBackColor = true;
            // 
            // radioButtonModeTransmissionCrossCoefficient
            // 
            resources.ApplyResources(radioButtonModeTransmissionCrossCoefficient, "radioButtonModeTransmissionCrossCoefficient");
            radioButtonModeTransmissionCrossCoefficient.Name = "radioButtonModeTransmissionCrossCoefficient";
            toolTip.SetToolTip(radioButtonModeTransmissionCrossCoefficient, resources.GetString("radioButtonModeTransmissionCrossCoefficient.ToolTip"));
            radioButtonModeTransmissionCrossCoefficient.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            resources.ApplyResources(label32, "label32");
            label32.ForeColor = System.Drawing.Color.Black;
            label32.Name = "label32";
            // 
            // panel6
            // 
            panel6.Controls.Add(groupBoxNormalization);
            panel6.Controls.Add(groupBox8);
            panel6.Controls.Add(groupBox7);
            resources.ApplyResources(panel6, "panel6");
            panel6.Name = "panel6";
            // 
            // groupBoxNormalization
            // 
            resources.ApplyResources(groupBoxNormalization, "groupBoxNormalization");
            groupBoxNormalization.Controls.Add(checkBoxNormarizeIndividually);
            groupBoxNormalization.Controls.Add(flowLayoutPanel6);
            groupBoxNormalization.Controls.Add(flowLayoutPanel2);
            groupBoxNormalization.Name = "groupBoxNormalization";
            groupBoxNormalization.TabStop = false;
            // 
            // checkBoxNormarizeIndividually
            // 
            resources.ApplyResources(checkBoxNormarizeIndividually, "checkBoxNormarizeIndividually");
            checkBoxNormarizeIndividually.Name = "checkBoxNormarizeIndividually";
            checkBoxNormarizeIndividually.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel6
            // 
            resources.ApplyResources(flowLayoutPanel6, "flowLayoutPanel6");
            flowLayoutPanel6.Controls.Add(checkBoxIntensityMin);
            flowLayoutPanel6.Controls.Add(numericBoxIntensityMin);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            // 
            // checkBoxIntensityMin
            // 
            resources.ApplyResources(checkBoxIntensityMin, "checkBoxIntensityMin");
            checkBoxIntensityMin.Checked = true;
            checkBoxIntensityMin.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxIntensityMin.Name = "checkBoxIntensityMin";
            checkBoxIntensityMin.UseVisualStyleBackColor = true;
            checkBoxIntensityMin.CheckedChanged += checkBoxIntensityMin_CheckedChanged;
            // 
            // numericBoxIntensityMin
            // 
            resources.ApplyResources(numericBoxIntensityMin, "numericBoxIntensityMin");
            numericBoxIntensityMin.BackColor = System.Drawing.SystemColors.Control;
            numericBoxIntensityMin.DecimalPlaces = 0;
            numericBoxIntensityMin.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxIntensityMin.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxIntensityMin.Maximum = 65535D;
            numericBoxIntensityMin.Minimum = 0D;
            numericBoxIntensityMin.Name = "numericBoxIntensityMin";
            numericBoxIntensityMin.RoundErrorAccuracy = -1;
            numericBoxIntensityMin.ShowUpDown = true;
            numericBoxIntensityMin.SmartIncrement = true;
            numericBoxIntensityMin.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxIntensityMin.ThonsandsSeparator = true;
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
            flowLayoutPanel2.Controls.Add(numericBoxIntensityMax);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // numericBoxIntensityMax
            // 
            resources.ApplyResources(numericBoxIntensityMax, "numericBoxIntensityMax");
            numericBoxIntensityMax.BackColor = System.Drawing.SystemColors.Control;
            numericBoxIntensityMax.DecimalPlaces = 0;
            numericBoxIntensityMax.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxIntensityMax.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxIntensityMax.Maximum = 65535D;
            numericBoxIntensityMax.Minimum = 1D;
            numericBoxIntensityMax.Name = "numericBoxIntensityMax";
            numericBoxIntensityMax.RadianValue = 0.017453292519943295D;
            numericBoxIntensityMax.RoundErrorAccuracy = -1;
            numericBoxIntensityMax.ShowUpDown = true;
            numericBoxIntensityMax.SmartIncrement = true;
            numericBoxIntensityMax.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxIntensityMax.ThonsandsSeparator = true;
            numericBoxIntensityMax.Value = 1D;
            // 
            // groupBox8
            // 
            resources.ApplyResources(groupBox8, "groupBox8");
            groupBox8.Controls.Add(flowLayoutPanel9);
            groupBox8.Name = "groupBox8";
            groupBox8.TabStop = false;
            // 
            // flowLayoutPanel9
            // 
            resources.ApplyResources(flowLayoutPanel9, "flowLayoutPanel9");
            flowLayoutPanel9.Controls.Add(numericBoxWidth);
            flowLayoutPanel9.Controls.Add(numericBoxHeight);
            flowLayoutPanel9.Controls.Add(label2);
            flowLayoutPanel9.Controls.Add(numericBoxResolution);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            // 
            // numericBoxWidth
            // 
            resources.ApplyResources(numericBoxWidth, "numericBoxWidth");
            numericBoxWidth.BackColor = System.Drawing.SystemColors.Control;
            numericBoxWidth.DecimalPlaces = 0;
            numericBoxWidth.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxWidth.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxWidth.Maximum = 2048D;
            numericBoxWidth.Minimum = 8D;
            numericBoxWidth.Name = "numericBoxWidth";
            numericBoxWidth.RadianValue = 8.9360857702109673D;
            numericBoxWidth.RoundErrorAccuracy = -1;
            numericBoxWidth.ShowUpDown = true;
            numericBoxWidth.SmartIncrement = true;
            numericBoxWidth.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxWidth.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxWidth, resources.GetString("numericBoxWidth.ToolTip"));
            numericBoxWidth.Value = 512D;
            // 
            // numericBoxHeight
            // 
            resources.ApplyResources(numericBoxHeight, "numericBoxHeight");
            numericBoxHeight.BackColor = System.Drawing.SystemColors.Control;
            numericBoxHeight.DecimalPlaces = 0;
            numericBoxHeight.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxHeight.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxHeight.Maximum = 2048D;
            numericBoxHeight.Minimum = 8D;
            numericBoxHeight.Name = "numericBoxHeight";
            numericBoxHeight.RadianValue = 8.9360857702109673D;
            numericBoxHeight.RoundErrorAccuracy = -1;
            numericBoxHeight.ShowUpDown = true;
            numericBoxHeight.SmartIncrement = true;
            numericBoxHeight.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxHeight.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxHeight, resources.GetString("numericBoxHeight.ToolTip"));
            numericBoxHeight.Value = 512D;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Name = "label2";
            // 
            // numericBoxResolution
            // 
            resources.ApplyResources(numericBoxResolution, "numericBoxResolution");
            numericBoxResolution.BackColor = System.Drawing.SystemColors.Control;
            numericBoxResolution.DecimalPlaces = 2;
            numericBoxResolution.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxResolution.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxResolution.Maximum = 100D;
            numericBoxResolution.Minimum = 0.01D;
            numericBoxResolution.Name = "numericBoxResolution";
            numericBoxResolution.RadianValue = 0.034906585039886591D;
            numericBoxResolution.RoundErrorAccuracy = -1;
            numericBoxResolution.ShowUpDown = true;
            numericBoxResolution.SmartIncrement = true;
            numericBoxResolution.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxResolution.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxResolution, resources.GetString("numericBoxResolution.ToolTip"));
            numericBoxResolution.Value = 2D;
            // 
            // groupBox7
            // 
            resources.ApplyResources(groupBox7, "groupBox7");
            groupBox7.Controls.Add(numericBoxNumOfBlochWave);
            groupBox7.Name = "groupBox7";
            groupBox7.TabStop = false;
            // 
            // numericBoxNumOfBlochWave
            // 
            resources.ApplyResources(numericBoxNumOfBlochWave, "numericBoxNumOfBlochWave");
            numericBoxNumOfBlochWave.BackColor = System.Drawing.SystemColors.Control;
            numericBoxNumOfBlochWave.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxNumOfBlochWave.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxNumOfBlochWave.Maximum = 1024D;
            numericBoxNumOfBlochWave.Minimum = 2D;
            numericBoxNumOfBlochWave.Name = "numericBoxNumOfBlochWave";
            numericBoxNumOfBlochWave.RadianValue = 1.3962634015954636D;
            numericBoxNumOfBlochWave.RoundErrorAccuracy = -1;
            numericBoxNumOfBlochWave.ShowUpDown = true;
            numericBoxNumOfBlochWave.SmartIncrement = true;
            numericBoxNumOfBlochWave.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxNumOfBlochWave.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxNumOfBlochWave, resources.GetString("numericBoxNumOfBlochWave.ToolTip"));
            numericBoxNumOfBlochWave.Value = 80D;
            numericBoxNumOfBlochWave.ValueChanged += NumericBoxNumOfBlochWave_ValueChanged;
            // 
            // groupBoxOpticalProperty
            // 
            resources.ApplyResources(groupBoxOpticalProperty, "groupBoxOpticalProperty");
            groupBoxOpticalProperty.Controls.Add(groupBoxSTEMoption1);
            groupBoxOpticalProperty.Controls.Add(groupBoxHREMoption1);
            groupBoxOpticalProperty.Controls.Add(panelLenz);
            groupBoxOpticalProperty.Controls.Add(groupBox4);
            groupBoxOpticalProperty.Name = "groupBoxOpticalProperty";
            groupBoxOpticalProperty.TabStop = false;
            // 
            // groupBoxSTEMoption1
            // 
            groupBoxSTEMoption1.ContextMenuStrip = contextMenuStripSTEM;
            groupBoxSTEMoption1.Controls.Add(numericBoxSTEM_DetectorOuterAngle);
            groupBoxSTEMoption1.Controls.Add(numericBoxSourceSize);
            groupBoxSTEMoption1.Controls.Add(numericBoxSTEM_ConvergenceAngle);
            groupBoxSTEMoption1.Controls.Add(numericBoxSTEM_DetectorInnerAngle);
            resources.ApplyResources(groupBoxSTEMoption1, "groupBoxSTEMoption1");
            groupBoxSTEMoption1.Name = "groupBoxSTEMoption1";
            groupBoxSTEMoption1.TabStop = false;
            // 
            // contextMenuStripSTEM
            // 
            contextMenuStripSTEM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { typicalBF02MradToolStripMenuItem, typicalABF1224MradToolStripMenuItem, typicalLAADF2560MradToolStripMenuItem, typicalHAADF80250MradToolStripMenuItem });
            contextMenuStripSTEM.Name = "contextMenuStripSTEM";
            resources.ApplyResources(contextMenuStripSTEM, "contextMenuStripSTEM");
            // 
            // typicalBF02MradToolStripMenuItem
            // 
            typicalBF02MradToolStripMenuItem.Name = "typicalBF02MradToolStripMenuItem";
            resources.ApplyResources(typicalBF02MradToolStripMenuItem, "typicalBF02MradToolStripMenuItem");
            typicalBF02MradToolStripMenuItem.Click += typicalBF02MradToolStripMenuItem_Click;
            // 
            // typicalABF1224MradToolStripMenuItem
            // 
            typicalABF1224MradToolStripMenuItem.Name = "typicalABF1224MradToolStripMenuItem";
            resources.ApplyResources(typicalABF1224MradToolStripMenuItem, "typicalABF1224MradToolStripMenuItem");
            typicalABF1224MradToolStripMenuItem.Click += typicalABF1224MradToolStripMenuItem_Click;
            // 
            // typicalLAADF2560MradToolStripMenuItem
            // 
            typicalLAADF2560MradToolStripMenuItem.Name = "typicalLAADF2560MradToolStripMenuItem";
            resources.ApplyResources(typicalLAADF2560MradToolStripMenuItem, "typicalLAADF2560MradToolStripMenuItem");
            typicalLAADF2560MradToolStripMenuItem.Click += typicalLAADF2560MradToolStripMenuItem_Click;
            // 
            // typicalHAADF80250MradToolStripMenuItem
            // 
            typicalHAADF80250MradToolStripMenuItem.Name = "typicalHAADF80250MradToolStripMenuItem";
            resources.ApplyResources(typicalHAADF80250MradToolStripMenuItem, "typicalHAADF80250MradToolStripMenuItem");
            typicalHAADF80250MradToolStripMenuItem.Click += typicalHAADF80250MradToolStripMenuItem_Click;
            // 
            // numericBoxSTEM_DetectorOuterAngle
            // 
            resources.ApplyResources(numericBoxSTEM_DetectorOuterAngle, "numericBoxSTEM_DetectorOuterAngle");
            numericBoxSTEM_DetectorOuterAngle.BackColor = System.Drawing.SystemColors.Control;
            numericBoxSTEM_DetectorOuterAngle.DecimalPlaces = 1;
            numericBoxSTEM_DetectorOuterAngle.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxSTEM_DetectorOuterAngle.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxSTEM_DetectorOuterAngle.Maximum = 1570D;
            numericBoxSTEM_DetectorOuterAngle.Minimum = 0.5D;
            numericBoxSTEM_DetectorOuterAngle.Name = "numericBoxSTEM_DetectorOuterAngle";
            numericBoxSTEM_DetectorOuterAngle.RadianValue = 0.3490658503988659D;
            numericBoxSTEM_DetectorOuterAngle.RoundErrorAccuracy = -1;
            numericBoxSTEM_DetectorOuterAngle.ShowUpDown = true;
            numericBoxSTEM_DetectorOuterAngle.SmartIncrement = true;
            numericBoxSTEM_DetectorOuterAngle.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxSTEM_DetectorOuterAngle.ThonsandsSeparator = true;
            numericBoxSTEM_DetectorOuterAngle.UpDown_Increment = 0.5D;
            numericBoxSTEM_DetectorOuterAngle.Value = 20D;
            // 
            // numericBoxSourceSize
            // 
            resources.ApplyResources(numericBoxSourceSize, "numericBoxSourceSize");
            numericBoxSourceSize.BackColor = System.Drawing.SystemColors.Control;
            numericBoxSourceSize.DecimalPlaces = 1;
            numericBoxSourceSize.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxSourceSize.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxSourceSize.Maximum = 1000D;
            numericBoxSourceSize.Minimum = 0D;
            numericBoxSourceSize.Name = "numericBoxSourceSize";
            numericBoxSourceSize.RadianValue = 0.3490658503988659D;
            numericBoxSourceSize.RestrictLimitValue = false;
            numericBoxSourceSize.RoundErrorAccuracy = -1;
            numericBoxSourceSize.ShowUpDown = true;
            numericBoxSourceSize.SmartIncrement = true;
            numericBoxSourceSize.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxSourceSize.ThonsandsSeparator = true;
            numericBoxSourceSize.UpDown_Increment = 0.1D;
            numericBoxSourceSize.Value = 20D;
            numericBoxSourceSize.ValueChanged += NumericBoxTEMproperty_ValueChanged;
            // 
            // numericBoxSTEM_ConvergenceAngle
            // 
            resources.ApplyResources(numericBoxSTEM_ConvergenceAngle, "numericBoxSTEM_ConvergenceAngle");
            numericBoxSTEM_ConvergenceAngle.BackColor = System.Drawing.SystemColors.Control;
            numericBoxSTEM_ConvergenceAngle.DecimalPlaces = 1;
            numericBoxSTEM_ConvergenceAngle.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxSTEM_ConvergenceAngle.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxSTEM_ConvergenceAngle.Maximum = 1570D;
            numericBoxSTEM_ConvergenceAngle.Minimum = 0.1D;
            numericBoxSTEM_ConvergenceAngle.Name = "numericBoxSTEM_ConvergenceAngle";
            numericBoxSTEM_ConvergenceAngle.RadianValue = 0.43633231299858238D;
            numericBoxSTEM_ConvergenceAngle.RoundErrorAccuracy = -1;
            numericBoxSTEM_ConvergenceAngle.ShowUpDown = true;
            numericBoxSTEM_ConvergenceAngle.SmartIncrement = true;
            numericBoxSTEM_ConvergenceAngle.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxSTEM_ConvergenceAngle.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxSTEM_ConvergenceAngle, resources.GetString("numericBoxSTEM_ConvergenceAngle.ToolTip"));
            numericBoxSTEM_ConvergenceAngle.UpDown_Increment = 0.5D;
            numericBoxSTEM_ConvergenceAngle.Value = 25D;
            // 
            // numericBoxSTEM_DetectorInnerAngle
            // 
            resources.ApplyResources(numericBoxSTEM_DetectorInnerAngle, "numericBoxSTEM_DetectorInnerAngle");
            numericBoxSTEM_DetectorInnerAngle.BackColor = System.Drawing.SystemColors.Control;
            numericBoxSTEM_DetectorInnerAngle.DecimalPlaces = 1;
            numericBoxSTEM_DetectorInnerAngle.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxSTEM_DetectorInnerAngle.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxSTEM_DetectorInnerAngle.Maximum = 1570D;
            numericBoxSTEM_DetectorInnerAngle.Minimum = 0D;
            numericBoxSTEM_DetectorInnerAngle.Name = "numericBoxSTEM_DetectorInnerAngle";
            numericBoxSTEM_DetectorInnerAngle.RoundErrorAccuracy = -1;
            numericBoxSTEM_DetectorInnerAngle.ShowUpDown = true;
            numericBoxSTEM_DetectorInnerAngle.SmartIncrement = true;
            numericBoxSTEM_DetectorInnerAngle.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxSTEM_DetectorInnerAngle.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxSTEM_DetectorInnerAngle, resources.GetString("numericBoxSTEM_DetectorInnerAngle.ToolTip"));
            numericBoxSTEM_DetectorInnerAngle.UpDown_Increment = 0.5D;
            // 
            // groupBoxHREMoption1
            // 
            groupBoxHREMoption1.Controls.Add(numericBoxObjAperX);
            groupBoxHREMoption1.Controls.Add(numericBoxObjAperRadius);
            groupBoxHREMoption1.Controls.Add(numericBoxObjAperY);
            groupBoxHREMoption1.Controls.Add(checkBoxOpenAperture);
            groupBoxHREMoption1.Controls.Add(flowLayoutPanel1);
            groupBoxHREMoption1.Controls.Add(flowLayoutPanel5);
            groupBoxHREMoption1.Controls.Add(buttonDetailsOfSpots);
            groupBoxHREMoption1.Controls.Add(label8);
            resources.ApplyResources(groupBoxHREMoption1, "groupBoxHREMoption1");
            groupBoxHREMoption1.Name = "groupBoxHREMoption1";
            groupBoxHREMoption1.TabStop = false;
            // 
            // numericBoxObjAperX
            // 
            resources.ApplyResources(numericBoxObjAperX, "numericBoxObjAperX");
            numericBoxObjAperX.BackColor = System.Drawing.SystemColors.Control;
            numericBoxObjAperX.DecimalPlaces = 1;
            numericBoxObjAperX.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxObjAperX.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxObjAperX.Maximum = 100D;
            numericBoxObjAperX.Minimum = -100D;
            numericBoxObjAperX.Name = "numericBoxObjAperX";
            numericBoxObjAperX.RoundErrorAccuracy = -1;
            numericBoxObjAperX.ShowUpDown = true;
            numericBoxObjAperX.SmartIncrement = true;
            numericBoxObjAperX.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxObjAperX.ThonsandsSeparator = true;
            numericBoxObjAperX.UpDown_Increment = 0.5D;
            numericBoxObjAperX.ValueChanged += NumericBoxObjAperRadius_ValueChanged;
            // 
            // numericBoxObjAperRadius
            // 
            resources.ApplyResources(numericBoxObjAperRadius, "numericBoxObjAperRadius");
            numericBoxObjAperRadius.BackColor = System.Drawing.SystemColors.Control;
            numericBoxObjAperRadius.DecimalPlaces = 1;
            numericBoxObjAperRadius.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxObjAperRadius.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxObjAperRadius.Maximum = 500D;
            numericBoxObjAperRadius.Minimum = 0.5D;
            numericBoxObjAperRadius.Name = "numericBoxObjAperRadius";
            numericBoxObjAperRadius.RadianValue = 0.20943951023931953D;
            numericBoxObjAperRadius.RoundErrorAccuracy = -1;
            numericBoxObjAperRadius.ShowUpDown = true;
            numericBoxObjAperRadius.SmartIncrement = true;
            numericBoxObjAperRadius.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxObjAperRadius.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxObjAperRadius, resources.GetString("numericBoxObjAperRadius.ToolTip"));
            numericBoxObjAperRadius.UpDown_Increment = 0.5D;
            numericBoxObjAperRadius.Value = 12D;
            numericBoxObjAperRadius.ValueChanged += NumericBoxObjAperRadius_ValueChanged;
            // 
            // numericBoxObjAperY
            // 
            resources.ApplyResources(numericBoxObjAperY, "numericBoxObjAperY");
            numericBoxObjAperY.BackColor = System.Drawing.SystemColors.Control;
            numericBoxObjAperY.DecimalPlaces = 1;
            numericBoxObjAperY.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxObjAperY.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxObjAperY.Maximum = 100D;
            numericBoxObjAperY.Minimum = -100D;
            numericBoxObjAperY.Name = "numericBoxObjAperY";
            numericBoxObjAperY.RoundErrorAccuracy = -1;
            numericBoxObjAperY.ShowUpDown = true;
            numericBoxObjAperY.SmartIncrement = true;
            numericBoxObjAperY.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxObjAperY.ThonsandsSeparator = true;
            numericBoxObjAperY.UpDown_Increment = 0.5D;
            numericBoxObjAperY.ValueChanged += NumericBoxObjAperRadius_ValueChanged;
            // 
            // checkBoxOpenAperture
            // 
            resources.ApplyResources(checkBoxOpenAperture, "checkBoxOpenAperture");
            checkBoxOpenAperture.Name = "checkBoxOpenAperture";
            checkBoxOpenAperture.UseVisualStyleBackColor = true;
            checkBoxOpenAperture.CheckedChanged += NumericBoxObjAperRadius_ValueChanged;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Controls.Add(textBoxNumOfSpots);
            flowLayoutPanel1.Controls.Add(label9);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // textBoxNumOfSpots
            // 
            textBoxNumOfSpots.BackColor = System.Drawing.SystemColors.InactiveCaption;
            textBoxNumOfSpots.ForeColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(textBoxNumOfSpots, "textBoxNumOfSpots");
            textBoxNumOfSpots.Name = "textBoxNumOfSpots";
            textBoxNumOfSpots.ReadOnly = true;
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.ForeColor = System.Drawing.Color.Black;
            label9.Name = "label9";
            // 
            // flowLayoutPanel5
            // 
            resources.ApplyResources(flowLayoutPanel5, "flowLayoutPanel5");
            flowLayoutPanel5.Controls.Add(textBoxApertureRadius);
            flowLayoutPanel5.Controls.Add(label7);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            // 
            // textBoxApertureRadius
            // 
            textBoxApertureRadius.BackColor = System.Drawing.SystemColors.InactiveCaption;
            textBoxApertureRadius.ForeColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(textBoxApertureRadius, "textBoxApertureRadius");
            textBoxApertureRadius.Name = "textBoxApertureRadius";
            textBoxApertureRadius.ReadOnly = true;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.ForeColor = System.Drawing.Color.Black;
            label7.Name = "label7";
            // 
            // buttonDetailsOfSpots
            // 
            resources.ApplyResources(buttonDetailsOfSpots, "buttonDetailsOfSpots");
            buttonDetailsOfSpots.Name = "buttonDetailsOfSpots";
            buttonDetailsOfSpots.UseVisualStyleBackColor = true;
            buttonDetailsOfSpots.Click += ButtonDetailsOfSpots_Click;
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.ForeColor = System.Drawing.Color.DimGray;
            label8.Name = "label8";
            // 
            // panelLenz
            // 
            resources.ApplyResources(panelLenz, "panelLenz");
            panelLenz.Controls.Add(checkBoxShowLensFunctionGraph);
            panelLenz.Controls.Add(groupBoxLensFunction);
            panelLenz.Name = "panelLenz";
            // 
            // checkBoxShowLensFunctionGraph
            // 
            resources.ApplyResources(checkBoxShowLensFunctionGraph, "checkBoxShowLensFunctionGraph");
            checkBoxShowLensFunctionGraph.Checked = true;
            checkBoxShowLensFunctionGraph.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxShowLensFunctionGraph.Name = "checkBoxShowLensFunctionGraph";
            checkBoxShowLensFunctionGraph.UseVisualStyleBackColor = true;
            checkBoxShowLensFunctionGraph.CheckedChanged += checkBoxShowLensFunctionGraph_CheckedChanged;
            // 
            // groupBoxLensFunction
            // 
            groupBoxLensFunction.Controls.Add(graphControl);
            groupBoxLensFunction.Controls.Add(panelGraphOption);
            groupBoxLensFunction.Controls.Add(buttonPanel);
            resources.ApplyResources(groupBoxLensFunction, "groupBoxLensFunction");
            groupBoxLensFunction.Name = "groupBoxLensFunction";
            groupBoxLensFunction.TabStop = false;
            // 
            // graphControl
            // 
            graphControl.AllowMouseOperation = true;
            graphControl.BackgroundColor = System.Drawing.Color.White;
            graphControl.BottomMargin = 0D;
            graphControl.DivisionLineColor = System.Drawing.Color.Gray;
            graphControl.DivisionSubLineColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(graphControl, "graphControl");
            graphControl.FixRangeHorizontal = false;
            graphControl.FixRangeVertical = false;
            graphControl.GraphName = "";
            graphControl.HorizontalGradiationTextVisivle = true;
            graphControl.Interpolation = false;
            graphControl.IsIntegerX = false;
            graphControl.IsIntegerY = false;
            graphControl.LabelX = "X:";
            graphControl.LabelY = "Y:";
            graphControl.LeftMargin = 0F;
            graphControl.LineColor = System.Drawing.Color.Red;
            graphControl.LineWidth = 1F;
            graphControl.LowerX = 0D;
            graphControl.LowerY = 0D;
            graphControl.MaximalX = 1D;
            graphControl.MaximalY = 1D;
            graphControl.MinimalX = 0D;
            graphControl.MinimalY = 0D;
            graphControl.Mode = GraphControl.DrawingMode.Line;
            graphControl.MousePositionVisible = false;
            graphControl.Name = "graphControl";
            graphControl.OriginPosition = new System.Drawing.Point(20, 20);
            graphControl.Smoothing = false;
            graphControl.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            graphControl.UnitX = "";
            graphControl.UnitY = "";
            graphControl.UpperText = "";
            graphControl.UpperTextVisible = false;
            graphControl.UpperX = 1D;
            graphControl.UpperY = 1D;
            graphControl.UseLineWidth = true;
            graphControl.VerticalGradiationTextVisivle = true;
            graphControl.XLog = false;
            graphControl.XScaleLineVisible = true;
            graphControl.YLog = false;
            graphControl.YScaleLineVisible = true;
            // 
            // panelGraphOption
            // 
            panelGraphOption.Controls.Add(buttonCopyGraph);
            panelGraphOption.Controls.Add(numericBoxMaxU1);
            panelGraphOption.Controls.Add(checkBoxGraphAll);
            panelGraphOption.Controls.Add(checkBoxGraphEc);
            panelGraphOption.Controls.Add(checkBoxGraphPCTF);
            panelGraphOption.Controls.Add(checkBoxGraphEs);
            resources.ApplyResources(panelGraphOption, "panelGraphOption");
            panelGraphOption.Name = "panelGraphOption";
            // 
            // buttonCopyGraph
            // 
            resources.ApplyResources(buttonCopyGraph, "buttonCopyGraph");
            buttonCopyGraph.Name = "buttonCopyGraph";
            buttonCopyGraph.UseVisualStyleBackColor = true;
            buttonCopyGraph.Click += ButtonCopyGraph_Click;
            // 
            // numericBoxMaxU1
            // 
            resources.ApplyResources(numericBoxMaxU1, "numericBoxMaxU1");
            numericBoxMaxU1.BackColor = System.Drawing.SystemColors.Control;
            numericBoxMaxU1.DecimalPlaces = 1;
            numericBoxMaxU1.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxMaxU1.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxMaxU1.Maximum = 20D;
            numericBoxMaxU1.Minimum = 0D;
            numericBoxMaxU1.Name = "numericBoxMaxU1";
            numericBoxMaxU1.RadianValue = 0.10471975511965977D;
            numericBoxMaxU1.RoundErrorAccuracy = -1;
            numericBoxMaxU1.ShowUpDown = true;
            numericBoxMaxU1.SmartIncrement = true;
            numericBoxMaxU1.TextFont = new System.Drawing.Font("Segoe UI Symbol", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxMaxU1.ThonsandsSeparator = true;
            numericBoxMaxU1.Value = 6D;
            numericBoxMaxU1.ValueChanged += NumericBoxTEMproperty_ValueChanged;
            // 
            // checkBoxGraphAll
            // 
            resources.ApplyResources(checkBoxGraphAll, "checkBoxGraphAll");
            checkBoxGraphAll.Checked = true;
            checkBoxGraphAll.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxGraphAll.Name = "checkBoxGraphAll";
            checkBoxGraphAll.UseVisualStyleBackColor = true;
            checkBoxGraphAll.CheckedChanged += NumericBoxTEMproperty_ValueChanged;
            // 
            // checkBoxGraphEc
            // 
            resources.ApplyResources(checkBoxGraphEc, "checkBoxGraphEc");
            checkBoxGraphEc.Checked = true;
            checkBoxGraphEc.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxGraphEc.Name = "checkBoxGraphEc";
            toolTip.SetToolTip(checkBoxGraphEc, resources.GetString("checkBoxGraphEc.ToolTip"));
            checkBoxGraphEc.UseVisualStyleBackColor = true;
            checkBoxGraphEc.CheckedChanged += NumericBoxTEMproperty_ValueChanged;
            // 
            // checkBoxGraphPCTF
            // 
            resources.ApplyResources(checkBoxGraphPCTF, "checkBoxGraphPCTF");
            checkBoxGraphPCTF.Checked = true;
            checkBoxGraphPCTF.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxGraphPCTF.Name = "checkBoxGraphPCTF";
            toolTip.SetToolTip(checkBoxGraphPCTF, resources.GetString("checkBoxGraphPCTF.ToolTip"));
            checkBoxGraphPCTF.UseVisualStyleBackColor = true;
            checkBoxGraphPCTF.CheckedChanged += NumericBoxTEMproperty_ValueChanged;
            // 
            // checkBoxGraphEs
            // 
            resources.ApplyResources(checkBoxGraphEs, "checkBoxGraphEs");
            checkBoxGraphEs.Checked = true;
            checkBoxGraphEs.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxGraphEs.Name = "checkBoxGraphEs";
            toolTip.SetToolTip(checkBoxGraphEs, resources.GetString("checkBoxGraphEs.ToolTip"));
            checkBoxGraphEs.UseVisualStyleBackColor = true;
            checkBoxGraphEs.CheckedChanged += NumericBoxTEMproperty_ValueChanged;
            // 
            // buttonPanel
            // 
            resources.ApplyResources(buttonPanel, "buttonPanel");
            buttonPanel.Name = "buttonPanel";
            buttonPanel.UseVisualStyleBackColor = true;
            buttonPanel.Click += ButtonPanel_Click;
            // 
            // groupBox4
            // 
            groupBox4.ContextMenuStrip = contextMenuStripTEMcondition;
            groupBox4.Controls.Add(numericBoxCs);
            groupBox4.Controls.Add(numericBoxCc);
            groupBox4.Controls.Add(numericBoxAccVol);
            groupBox4.Controls.Add(numericBoxDeltaV);
            groupBox4.Controls.Add(numericBoxDefocus);
            groupBox4.Controls.Add(numericBoxBetaAgnle);
            groupBox4.Controls.Add(flowLayoutPanel3);
            groupBox4.Controls.Add(label34);
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            // 
            // contextMenuStripTEMcondition
            // 
            contextMenuStripTEMcondition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { setoZeroDefocusToolStripMenuItem, setoScherzerDefocusToolStripMenuItem, toolStripSeparator3, setAllAToolStripMenuItem });
            contextMenuStripTEMcondition.Name = "contextMenuStripInherentProperty";
            resources.ApplyResources(contextMenuStripTEMcondition, "contextMenuStripTEMcondition");
            // 
            // setoZeroDefocusToolStripMenuItem
            // 
            setoZeroDefocusToolStripMenuItem.Name = "setoZeroDefocusToolStripMenuItem";
            resources.ApplyResources(setoZeroDefocusToolStripMenuItem, "setoZeroDefocusToolStripMenuItem");
            setoZeroDefocusToolStripMenuItem.Click += setoZeroDefocusToolStripMenuItem_Click;
            // 
            // setoScherzerDefocusToolStripMenuItem
            // 
            setoScherzerDefocusToolStripMenuItem.Name = "setoScherzerDefocusToolStripMenuItem";
            resources.ApplyResources(setoScherzerDefocusToolStripMenuItem, "setoScherzerDefocusToolStripMenuItem");
            setoScherzerDefocusToolStripMenuItem.Click += setoScherzerDefocusToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // setAllAToolStripMenuItem
            // 
            setAllAToolStripMenuItem.Name = "setAllAToolStripMenuItem";
            resources.ApplyResources(setAllAToolStripMenuItem, "setAllAToolStripMenuItem");
            setAllAToolStripMenuItem.Click += zeroAllToolStripMenuItem_Click;
            // 
            // numericBoxCs
            // 
            resources.ApplyResources(numericBoxCs, "numericBoxCs");
            numericBoxCs.BackColor = System.Drawing.SystemColors.Control;
            numericBoxCs.DecimalPlaces = 2;
            numericBoxCs.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxCs.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxCs.Maximum = 20D;
            numericBoxCs.Minimum = -20D;
            numericBoxCs.Name = "numericBoxCs";
            numericBoxCs.RadianValue = 0.0087266462599716477D;
            numericBoxCs.RoundErrorAccuracy = -1;
            numericBoxCs.ShowUpDown = true;
            numericBoxCs.SmartIncrement = true;
            numericBoxCs.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxCs.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxCs, resources.GetString("numericBoxCs.ToolTip"));
            numericBoxCs.UpDown_Increment = 0.1D;
            numericBoxCs.Value = 0.5D;
            numericBoxCs.ValueChanged += NumericBoxCs_ValueChanged;
            // 
            // numericBoxCc
            // 
            resources.ApplyResources(numericBoxCc, "numericBoxCc");
            numericBoxCc.BackColor = System.Drawing.SystemColors.Control;
            numericBoxCc.DecimalPlaces = 2;
            numericBoxCc.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxCc.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxCc.Maximum = 10D;
            numericBoxCc.Minimum = 0D;
            numericBoxCc.Name = "numericBoxCc";
            numericBoxCc.RadianValue = 0.024434609527920613D;
            numericBoxCc.RestrictLimitValue = false;
            numericBoxCc.RoundErrorAccuracy = -1;
            numericBoxCc.ShowUpDown = true;
            numericBoxCc.SmartIncrement = true;
            numericBoxCc.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxCc.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxCc, resources.GetString("numericBoxCc.ToolTip"));
            numericBoxCc.UpDown_Increment = 0.1D;
            numericBoxCc.Value = 1.4D;
            numericBoxCc.ValueChanged += NumericBoxTEMproperty_ValueChanged;
            // 
            // numericBoxAccVol
            // 
            resources.ApplyResources(numericBoxAccVol, "numericBoxAccVol");
            numericBoxAccVol.BackColor = System.Drawing.SystemColors.Control;
            numericBoxAccVol.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxAccVol.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxAccVol.Maximum = 1000D;
            numericBoxAccVol.Minimum = 1D;
            numericBoxAccVol.Name = "numericBoxAccVol";
            numericBoxAccVol.RadianValue = 3.4906585039886591D;
            numericBoxAccVol.RoundErrorAccuracy = -1;
            numericBoxAccVol.ShowUpDown = true;
            numericBoxAccVol.SmartIncrement = true;
            numericBoxAccVol.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxAccVol.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxAccVol, resources.GetString("numericBoxAccVol.ToolTip"));
            numericBoxAccVol.Value = 200D;
            numericBoxAccVol.ValueChanged += NumericBoxAccVol_ValueChanged;
            // 
            // numericBoxDeltaV
            // 
            resources.ApplyResources(numericBoxDeltaV, "numericBoxDeltaV");
            numericBoxDeltaV.BackColor = System.Drawing.SystemColors.Control;
            numericBoxDeltaV.DecimalPlaces = 2;
            numericBoxDeltaV.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxDeltaV.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxDeltaV.Maximum = 10D;
            numericBoxDeltaV.Minimum = 0D;
            numericBoxDeltaV.Name = "numericBoxDeltaV";
            numericBoxDeltaV.RadianValue = 0.0017453292519943296D;
            numericBoxDeltaV.RestrictLimitValue = false;
            numericBoxDeltaV.RoundErrorAccuracy = -1;
            numericBoxDeltaV.ShowUpDown = true;
            numericBoxDeltaV.SmartIncrement = true;
            numericBoxDeltaV.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxDeltaV.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxDeltaV, resources.GetString("numericBoxDeltaV.ToolTip"));
            numericBoxDeltaV.UpDown_Increment = 0.1D;
            numericBoxDeltaV.Value = 0.1D;
            numericBoxDeltaV.ValueChanged += NumericBoxTEMproperty_ValueChanged;
            // 
            // numericBoxDefocus
            // 
            resources.ApplyResources(numericBoxDefocus, "numericBoxDefocus");
            numericBoxDefocus.BackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocus.DecimalPlaces = 1;
            numericBoxDefocus.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocus.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxDefocus.Maximum = 1000D;
            numericBoxDefocus.Minimum = -1000D;
            numericBoxDefocus.Name = "numericBoxDefocus";
            numericBoxDefocus.RadianValue = -0.71383966406568078D;
            numericBoxDefocus.RoundErrorAccuracy = -1;
            numericBoxDefocus.ShowUpDown = true;
            numericBoxDefocus.SmartIncrement = true;
            numericBoxDefocus.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxDefocus.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxDefocus, resources.GetString("numericBoxDefocus.ToolTip"));
            numericBoxDefocus.Value = -40.9D;
            numericBoxDefocus.ValueChanged += NumericBoxDefocus_ValueChanged;
            // 
            // numericBoxBetaAgnle
            // 
            resources.ApplyResources(numericBoxBetaAgnle, "numericBoxBetaAgnle");
            numericBoxBetaAgnle.BackColor = System.Drawing.SystemColors.Control;
            numericBoxBetaAgnle.DecimalPlaces = 2;
            numericBoxBetaAgnle.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxBetaAgnle.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxBetaAgnle.Maximum = 100D;
            numericBoxBetaAgnle.Minimum = 0D;
            numericBoxBetaAgnle.Name = "numericBoxBetaAgnle";
            numericBoxBetaAgnle.RadianValue = 0.0017453292519943296D;
            numericBoxBetaAgnle.RoundErrorAccuracy = -1;
            numericBoxBetaAgnle.ShowUpDown = true;
            numericBoxBetaAgnle.SmartIncrement = true;
            numericBoxBetaAgnle.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxBetaAgnle.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxBetaAgnle, resources.GetString("numericBoxBetaAgnle.ToolTip"));
            numericBoxBetaAgnle.UpDown_Increment = 0.05D;
            numericBoxBetaAgnle.Value = 0.1D;
            numericBoxBetaAgnle.ValueChanged += NumericBoxTEMproperty_ValueChanged;
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(flowLayoutPanel3, "flowLayoutPanel3");
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(textBoxScherzer);
            flowLayoutPanel3.Controls.Add(label4);
            flowLayoutPanel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label3.Name = "label3";
            toolTip.SetToolTip(label3, resources.GetString("label3.ToolTip"));
            // 
            // textBoxScherzer
            // 
            textBoxScherzer.BackColor = System.Drawing.SystemColors.InactiveCaption;
            resources.ApplyResources(textBoxScherzer, "textBoxScherzer");
            textBoxScherzer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            textBoxScherzer.Name = "textBoxScherzer";
            toolTip.SetToolTip(textBoxScherzer, resources.GetString("textBoxScherzer.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label4.Name = "label4";
            toolTip.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // label34
            // 
            resources.ApplyResources(label34, "label34");
            label34.ForeColor = System.Drawing.Color.Black;
            label34.Name = "label34";
            // 
            // panel4
            // 
            resources.ApplyResources(panel4, "panel4");
            panel4.Controls.Add(buttonSimulate);
            panel4.Controls.Add(checkBoxRealTimeSimulation);
            panel4.Name = "panel4";
            // 
            // buttonSimulate
            // 
            resources.ApplyResources(buttonSimulate, "buttonSimulate");
            buttonSimulate.BackColor = System.Drawing.Color.SteelBlue;
            buttonSimulate.ForeColor = System.Drawing.Color.White;
            buttonSimulate.Name = "buttonSimulate";
            toolTip.SetToolTip(buttonSimulate, resources.GetString("buttonSimulate.ToolTip"));
            buttonSimulate.UseVisualStyleBackColor = false;
            buttonSimulate.Click += ButtonSimulate_Click;
            // 
            // checkBoxRealTimeSimulation
            // 
            resources.ApplyResources(checkBoxRealTimeSimulation, "checkBoxRealTimeSimulation");
            checkBoxRealTimeSimulation.Name = "checkBoxRealTimeSimulation";
            toolTip.SetToolTip(checkBoxRealTimeSimulation, resources.GetString("checkBoxRealTimeSimulation.ToolTip"));
            checkBoxRealTimeSimulation.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel14
            // 
            resources.ApplyResources(flowLayoutPanel14, "flowLayoutPanel14");
            flowLayoutPanel14.Controls.Add(groupBox6);
            flowLayoutPanel14.Controls.Add(groupBoxSampleProperty);
            flowLayoutPanel14.Name = "flowLayoutPanel14";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(radioButtonProjectedPotential);
            groupBox6.Controls.Add(radioButtonSTEM);
            groupBox6.Controls.Add(radioButtonHRTEM);
            resources.ApplyResources(groupBox6, "groupBox6");
            groupBox6.Name = "groupBox6";
            groupBox6.TabStop = false;
            // 
            // radioButtonProjectedPotential
            // 
            resources.ApplyResources(radioButtonProjectedPotential, "radioButtonProjectedPotential");
            radioButtonProjectedPotential.Name = "radioButtonProjectedPotential";
            toolTip.SetToolTip(radioButtonProjectedPotential, resources.GetString("radioButtonProjectedPotential.ToolTip"));
            radioButtonProjectedPotential.UseVisualStyleBackColor = true;
            radioButtonProjectedPotential.CheckedChanged += RadioButtonHRTEM_CheckedChanged;
            // 
            // radioButtonSTEM
            // 
            resources.ApplyResources(radioButtonSTEM, "radioButtonSTEM");
            radioButtonSTEM.Name = "radioButtonSTEM";
            toolTip.SetToolTip(radioButtonSTEM, resources.GetString("radioButtonSTEM.ToolTip"));
            radioButtonSTEM.UseVisualStyleBackColor = true;
            radioButtonSTEM.CheckedChanged += RadioButtonHRTEM_CheckedChanged;
            // 
            // radioButtonHRTEM
            // 
            resources.ApplyResources(radioButtonHRTEM, "radioButtonHRTEM");
            radioButtonHRTEM.Checked = true;
            radioButtonHRTEM.Name = "radioButtonHRTEM";
            radioButtonHRTEM.TabStop = true;
            radioButtonHRTEM.UseVisualStyleBackColor = true;
            radioButtonHRTEM.CheckedChanged += RadioButtonHRTEM_CheckedChanged;
            // 
            // groupBoxSampleProperty
            // 
            groupBoxSampleProperty.Controls.Add(numericBoxThickness);
            resources.ApplyResources(groupBoxSampleProperty, "groupBoxSampleProperty");
            groupBoxSampleProperty.Name = "groupBoxSampleProperty";
            groupBoxSampleProperty.TabStop = false;
            // 
            // numericBoxThickness
            // 
            resources.ApplyResources(numericBoxThickness, "numericBoxThickness");
            numericBoxThickness.BackColor = System.Drawing.SystemColors.Control;
            numericBoxThickness.DecimalPlaces = 3;
            numericBoxThickness.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxThickness.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxThickness.Maximum = 1000D;
            numericBoxThickness.Minimum = 0.001D;
            numericBoxThickness.Name = "numericBoxThickness";
            numericBoxThickness.RadianValue = 0.3490658503988659D;
            numericBoxThickness.RoundErrorAccuracy = -1;
            numericBoxThickness.ShowUpDown = true;
            numericBoxThickness.SmartIncrement = true;
            numericBoxThickness.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxThickness.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxThickness, resources.GetString("numericBoxThickness.ToolTip"));
            numericBoxThickness.Value = 20D;
            numericBoxThickness.ValueChanged += NumericBoxThickness_ValueChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemSave, copyImageToolStripMenuItem, toolStripMenuItemOverprintSymbols, toolStripSeparator1, readTEMParameterToolStripMenuItem, saveTEMParametersToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // toolStripMenuItemSave
            // 
            toolStripMenuItemSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemSavePNG, toolStripMenuItemSaveTIFF, toolStripMenuItemSaveMetafile, toolStripMenuItemSaveIndividually });
            toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            resources.ApplyResources(toolStripMenuItemSave, "toolStripMenuItemSave");
            // 
            // toolStripMenuItemSavePNG
            // 
            toolStripMenuItemSavePNG.Name = "toolStripMenuItemSavePNG";
            resources.ApplyResources(toolStripMenuItemSavePNG, "toolStripMenuItemSavePNG");
            toolStripMenuItemSavePNG.Click += ToolStripMenuItemSavePNG_Click;
            // 
            // toolStripMenuItemSaveTIFF
            // 
            toolStripMenuItemSaveTIFF.Name = "toolStripMenuItemSaveTIFF";
            resources.ApplyResources(toolStripMenuItemSaveTIFF, "toolStripMenuItemSaveTIFF");
            toolStripMenuItemSaveTIFF.Click += ToolStripMenuItemSaveTIFF_Click;
            // 
            // toolStripMenuItemSaveMetafile
            // 
            toolStripMenuItemSaveMetafile.Name = "toolStripMenuItemSaveMetafile";
            resources.ApplyResources(toolStripMenuItemSaveMetafile, "toolStripMenuItemSaveMetafile");
            toolStripMenuItemSaveMetafile.Click += ToolStripMenuItemSaveMetafile_Click;
            // 
            // toolStripMenuItemSaveIndividually
            // 
            toolStripMenuItemSaveIndividually.Checked = true;
            toolStripMenuItemSaveIndividually.CheckOnClick = true;
            toolStripMenuItemSaveIndividually.CheckState = System.Windows.Forms.CheckState.Checked;
            toolStripMenuItemSaveIndividually.Name = "toolStripMenuItemSaveIndividually";
            resources.ApplyResources(toolStripMenuItemSaveIndividually, "toolStripMenuItemSaveIndividually");
            // 
            // copyImageToolStripMenuItem
            // 
            copyImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemCopyImage, toolStripMenuItemCopyMetafile });
            copyImageToolStripMenuItem.Name = "copyImageToolStripMenuItem";
            resources.ApplyResources(copyImageToolStripMenuItem, "copyImageToolStripMenuItem");
            // 
            // toolStripMenuItemCopyImage
            // 
            toolStripMenuItemCopyImage.Name = "toolStripMenuItemCopyImage";
            resources.ApplyResources(toolStripMenuItemCopyImage, "toolStripMenuItemCopyImage");
            toolStripMenuItemCopyImage.Click += ToolStripMenuItemCopyImage_Click;
            // 
            // toolStripMenuItemCopyMetafile
            // 
            toolStripMenuItemCopyMetafile.Name = "toolStripMenuItemCopyMetafile";
            resources.ApplyResources(toolStripMenuItemCopyMetafile, "toolStripMenuItemCopyMetafile");
            toolStripMenuItemCopyMetafile.Click += ToolStripMenuItemCopyMetafile_Click;
            // 
            // toolStripMenuItemOverprintSymbols
            // 
            toolStripMenuItemOverprintSymbols.Checked = true;
            toolStripMenuItemOverprintSymbols.CheckOnClick = true;
            toolStripMenuItemOverprintSymbols.CheckState = System.Windows.Forms.CheckState.Checked;
            toolStripMenuItemOverprintSymbols.Name = "toolStripMenuItemOverprintSymbols";
            resources.ApplyResources(toolStripMenuItemOverprintSymbols, "toolStripMenuItemOverprintSymbols");
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // readTEMParameterToolStripMenuItem
            // 
            resources.ApplyResources(readTEMParameterToolStripMenuItem, "readTEMParameterToolStripMenuItem");
            readTEMParameterToolStripMenuItem.Name = "readTEMParameterToolStripMenuItem";
            // 
            // saveTEMParametersToolStripMenuItem
            // 
            resources.ApplyResources(saveTEMParametersToolStripMenuItem, "saveTEMParametersToolStripMenuItem");
            saveTEMParametersToolStripMenuItem.Name = "saveTEMParametersToolStripMenuItem";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { detailsOfHRTEMSimulationToolStripMenuItem, toolStripSeparator2, calculationLibraryToolStripMenuItem, toolStripComboBoxCaclulationLibrary });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // detailsOfHRTEMSimulationToolStripMenuItem
            // 
            detailsOfHRTEMSimulationToolStripMenuItem.Name = "detailsOfHRTEMSimulationToolStripMenuItem";
            resources.ApplyResources(detailsOfHRTEMSimulationToolStripMenuItem, "detailsOfHRTEMSimulationToolStripMenuItem");
            detailsOfHRTEMSimulationToolStripMenuItem.Click += DetailsOfHRTEMSimulationToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // calculationLibraryToolStripMenuItem
            // 
            calculationLibraryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            calculationLibraryToolStripMenuItem.Name = "calculationLibraryToolStripMenuItem";
            resources.ApplyResources(calculationLibraryToolStripMenuItem, "calculationLibraryToolStripMenuItem");
            // 
            // toolStripComboBoxCaclulationLibrary
            // 
            toolStripComboBoxCaclulationLibrary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            toolStripComboBoxCaclulationLibrary.Items.AddRange(new object[] { resources.GetString("toolStripComboBoxCaclulationLibrary.Items"), resources.GetString("toolStripComboBoxCaclulationLibrary.Items1") });
            toolStripComboBoxCaclulationLibrary.Margin = new System.Windows.Forms.Padding(20, 2, 2, 2);
            toolStripComboBoxCaclulationLibrary.Name = "toolStripComboBoxCaclulationLibrary";
            resources.ApplyResources(toolStripComboBoxCaclulationLibrary, "toolStripComboBoxCaclulationLibrary");
            // 
            // buttonStop
            // 
            resources.ApplyResources(buttonStop, "buttonStop");
            buttonStop.BackColor = System.Drawing.Color.IndianRed;
            buttonStop.ForeColor = System.Drawing.Color.White;
            buttonStop.Name = "buttonStop";
            toolTip.SetToolTip(buttonStop, resources.GetString("buttonStop.ToolTip"));
            buttonStop.UseVisualStyleBackColor = false;
            buttonStop.Click += buttonStop_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripProgressBar1, toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.Name = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(toolStripStatusLabel2, "toolStripStatusLabel2");
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            resources.ApplyResources(toolStripStatusLabel3, "toolStripStatusLabel3");
            // 
            // FormImageSimulator
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(buttonStop);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            KeyPreview = true;
            Name = "FormImageSimulator";
            FormClosing += FormImageSimulator_FormClosing;
            Load += FormImageSimulator_Load;
            VisibleChanged += FormImageSimulator_VisibleChanged;
            KeyDown += FormImageSimulator_KeyDown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxScaleOfIntensity).EndInit();
            flowLayoutPanelScale.ResumeLayout(false);
            flowLayoutPanelScale.PerformLayout();
            flowLayoutPanelLabel.ResumeLayout(false);
            flowLayoutPanelLabel.PerformLayout();
            flowLayoutPanelGaussianBlur2.ResumeLayout(false);
            flowLayoutPanelGaussianBlur2.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBoxSerialImage.ResumeLayout(false);
            groupBoxSerialImage.PerformLayout();
            panelSerial.ResumeLayout(false);
            panelSerial.PerformLayout();
            panelSerialThickness.ResumeLayout(false);
            panelSerialThickness.PerformLayout();
            panelSerialDefocus.ResumeLayout(false);
            panelSerialDefocus.PerformLayout();
            flowLayoutPanelHorizontalDirection.ResumeLayout(false);
            flowLayoutPanelHorizontalDirection.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            groupBoxPotentialOption.ResumeLayout(false);
            groupBoxPotentialOption.PerformLayout();
            flowLayoutPanel11.ResumeLayout(false);
            flowLayoutPanel11.PerformLayout();
            flowLayoutPanelMagAndPhase.ResumeLayout(false);
            flowLayoutPanelMagAndPhase.PerformLayout();
            panelPhaseScale.ResumeLayout(false);
            panelPhaseScale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhaseScale).EndInit();
            flowLayoutPanelRealAndImaiginary.ResumeLayout(false);
            flowLayoutPanelRealAndImaiginary.PerformLayout();
            groupBoxSTEMoption2.ResumeLayout(false);
            groupBoxSTEMoption2.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            groupBoxHREMoption2.ResumeLayout(false);
            groupBoxHREMoption2.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            groupBoxNormalization.ResumeLayout(false);
            groupBoxNormalization.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBoxOpticalProperty.ResumeLayout(false);
            groupBoxOpticalProperty.PerformLayout();
            groupBoxSTEMoption1.ResumeLayout(false);
            contextMenuStripSTEM.ResumeLayout(false);
            groupBoxHREMoption1.ResumeLayout(false);
            groupBoxHREMoption1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            panelLenz.ResumeLayout(false);
            panelLenz.PerformLayout();
            groupBoxLensFunction.ResumeLayout(false);
            panelGraphOption.ResumeLayout(false);
            panelGraphOption.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            contextMenuStripTEMcondition.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            flowLayoutPanel14.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBoxSampleProperty.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Crystallography.Controls.NumericBox numericBoxNumOfBlochWave;
        private Crystallography.Controls.NumericBox numericBoxObjAperRadius;
        private System.Windows.Forms.Button buttonSimulate;
        private Crystallography.Controls.NumericBox numericBoxAccVol;
        private Crystallography.Controls.NumericBox numericBoxWidth;
        private Crystallography.Controls.NumericBox numericBoxHeight;
        private Crystallography.Controls.NumericBox numericBoxResolution;
        private Crystallography.Controls.NumericBox numericBoxDefocus;
        private Crystallography.Controls.NumericBox numericBoxCs;
        private Crystallography.Controls.NumericBox numericBoxBetaAgnle;
        private Crystallography.Controls.NumericBox numericBoxDeltaV;
        private Crystallography.Controls.NumericBox numericBoxCc;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxOpticalProperty;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSingleMode;
        private System.Windows.Forms.RadioButton radioButtonSerialMode;
        private Crystallography.Controls.NumericBox numericBoxDefocusStart;
        private Crystallography.Controls.NumericBox numericBoxDefocusStep;
        private Crystallography.Controls.NumericBox numericBoxDefocusNum;
        private System.Windows.Forms.TextBox textBoxDefocusList;
        private Crystallography.Controls.NumericBox numericBoxThicknessStart;
        private Crystallography.Controls.NumericBox numericBoxThicknessNum;
        private Crystallography.Controls.NumericBox numericBoxThicknessStep;
        private System.Windows.Forms.CheckBox checkBoxSerialDefocus;
        private System.Windows.Forms.CheckBox checkBoxSerialThickness;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBoxHREMoption2;
        private System.Windows.Forms.RadioButton radioButtonModeTransmissionCrossCoefficient;
        private System.Windows.Forms.RadioButton radioButtonModeQuasiCoherent;
        private System.Windows.Forms.CheckBox checkBoxShowLabel;
        private Crystallography.Controls.GraphControl graphControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Crystallography.Controls.NumericBox numericBoxObjAperY;
        private Crystallography.Controls.NumericBox numericBoxObjAperX;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxScherzer;
        private System.Windows.Forms.Button buttonCopyGraph;
        private Crystallography.Controls.NumericBox numericBoxMaxU1;
        private System.Windows.Forms.GroupBox groupBoxHREMoption1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.TextBox textBoxApertureRadius;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxShowUnitcell;
        private System.Windows.Forms.RadioButton radioButtonHorizontalThickness;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHorizontalDirection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButtonHorizontalDefocus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.CheckBox checkBoxShowScale;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelScale;
        private Crystallography.Controls.NumericBox numericBoxScaleLength;
        private System.Windows.Forms.TextBox textBoxThicknessList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLabel;
        private Crystallography.Controls.NumericBox numericBoxLabelFontSize;
        private Crystallography.Controls.ColorControl colorControlLabel;
        private Crystallography.Controls.ColorControl colorControlScale;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSavePNG;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveTIFF;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveMetafile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveIndividually;
        private System.Windows.Forms.ToolStripMenuItem copyImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyMetafile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOverprintSymbols;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem readTEMParameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTEMParametersToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxGraphAll;
        private System.Windows.Forms.CheckBox checkBoxGraphEc;
        private System.Windows.Forms.CheckBox checkBoxGraphEs;
        private System.Windows.Forms.CheckBox checkBoxGraphPCTF;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxNumOfSpots;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonDetailsOfSpots;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsOfHRTEMSimulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem calculationLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxCaclulationLibrary;
        private System.Windows.Forms.CheckBox checkBoxOpenAperture;
        private System.Windows.Forms.GroupBox groupBoxLensFunction;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.GroupBox groupBoxSerialImage;
        private System.Windows.Forms.Panel panelSerial;
        private System.Windows.Forms.Panel panelSerialDefocus;
        private System.Windows.Forms.Panel panelSerialThickness;
        private System.Windows.Forms.CheckBox checkBoxPotentialUg;
        private System.Windows.Forms.GroupBox groupBoxPotentialOption;
        private System.Windows.Forms.CheckBox checkBoxPotentialUgPrime;
        private System.Windows.Forms.RadioButton radioButtonPotentialModeRealAndImag;
        private System.Windows.Forms.RadioButton radioButtonPotentialModeMagAndPhase;
        private System.Windows.Forms.Panel panelGraphOption;
        private System.Windows.Forms.Button buttonPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBoxPhaseScale;
        private System.Windows.Forms.Panel panelPhaseScale;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private Crystallography.Controls.TrackBarAdvanced trackBarAdvancedMax;
        private Crystallography.Controls.TrackBarAdvanced trackBarAdvancedMin;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.ComboBox comboBoxScaleColorScale;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGaussianBlur2;
        private System.Windows.Forms.CheckBox checkBoxGaussianBlur;
        private Crystallography.Controls.NumericBox numericBoxGaussianBlurRadius;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMagAndPhase;
        private System.Windows.Forms.RadioButton radioButtonPotentialShowMagAndPhase;
        private System.Windows.Forms.RadioButton radioButtonPotentialShowMag;
        private System.Windows.Forms.RadioButton radioButtonPotentialShowPhase;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRealAndImaiginary;
        private System.Windows.Forms.RadioButton radioButtonPotentialShowRealAndImag;
        private System.Windows.Forms.RadioButton radioButtonPotentialShowReal;
        private System.Windows.Forms.RadioButton radioButtonPotentialShowImag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.PictureBox pictureBoxScaleOfIntensity;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label labelMousePositionValue;
        private System.Windows.Forms.Label labelMousePositionY;
        private System.Windows.Forms.Label labelMousePositionX;
        private System.Windows.Forms.CheckBox checkBoxRealTimeSimulation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label2;
        private NumericBox numericBoxIntensityMax;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.CheckBox checkBoxIntensityMin;
        private NumericBox numericBoxIntensityMin;
        private NumericBox numericBoxSTEM_ConvergenceAngle;
        private NumericBox numericBoxSTEM_DetectorOuterAngle;
        private NumericBox numericBoxSTEM_DetectorInnerAngle;
        private NumericBox numericBoxDivisionOfIncidentElectron;
        private System.Windows.Forms.GroupBox groupBoxSTEMoption2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.RadioButton radioButtonSTEM_target_Inel;
        private System.Windows.Forms.RadioButton radioButtonSTEM_target_Both;
        private System.Windows.Forms.RadioButton radioButtonSTEM_target_Elas;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBoxShowLensFunctionGraph;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private NumericBox numericBoxSliceThicknessForInelasticSTEM;
        private System.Windows.Forms.Panel panelLenz;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel14;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButtonProjectedPotential;
        private System.Windows.Forms.RadioButton radioButtonSTEM;
        private System.Windows.Forms.RadioButton radioButtonHRTEM;
        private System.Windows.Forms.GroupBox groupBoxSampleProperty;
        private NumericBox numericBoxThickness;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBoxSTEMoption1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.GroupBox groupBoxNormalization;
        private System.Windows.Forms.CheckBox checkBoxNormarizeIndividually;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTEMcondition;
        private System.Windows.Forms.ToolStripMenuItem setoZeroDefocusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setoScherzerDefocusToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSTEM;
        private System.Windows.Forms.ToolStripMenuItem typicalBF02MradToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typicalABF1224MradToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typicalLAADF2560MradToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typicalHAADF80250MradToolStripMenuItem;
        private NumericBox numericBoxSourceSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem setAllAToolStripMenuItem;
    }
}