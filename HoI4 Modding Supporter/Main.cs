﻿using System;
using System.Drawing;
using System.Windows.Forms;
namespace HoI4_Modding_Supporter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // 初期化
            AllClear();

            // 従属国オプション
            if (checkBox2.Checked == false)
            {
                textBox36.Enabled = false;
            }
            else if (checkBox2.Checked == true)
            {
                textBox36.Enabled = true;
            }

            // 配色
            ColorChange();
            // 初期政党支持率の合計
            PartiesSupportTotal();
        }

        /// <summary>
        /// テキストボックスをすべてリセット
        /// </summary>
        public void AllClear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 1;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown9.Value = 0;
            numericUpDown10.Value = 0;
            numericUpDown11.Value = 0;
            numericUpDown12.Value = 0;
            numericUpDown13.Value = 0;
            numericUpDown14.Value = 1;
            numericUpDown15.Value = 1;
            numericUpDown16.Value = 1936;
            numericUpDown17.Value = 1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
        }

        /// <summary>
        /// 配色の出力
        /// </summary>
        public void ColorChange()
        {
            int r = (int)numericUpDown1.Value;
            int g = (int)numericUpDown2.Value;
            int b = (int)numericUpDown3.Value;
            Color color = Color.FromArgb(r, g, b);
            panel2.BackColor = color;
        }

        /// <summary>
        /// 政党支持率合計の出力
        /// </summary>
        public void PartiesSupportTotal()
        {
            int nSupport = (int)numericUpDown12.Value;
            int dSupport = (int)numericUpDown11.Value;
            int fSupport = (int)numericUpDown10.Value;
            int cSupport = (int)numericUpDown9.Value;

            int total = nSupport + dSupport + fSupport + cSupport;

            textBox27.Text = total.ToString();
        }

        /// <summary>
        /// tgaファイル参照
        /// </summary>
        /// <param name="ideology">イデオロギー（n, d, f, c）</param>
        /// <param name="size">サイズ（big, medium, small）</param>
        public void OpenTGAFile(string ideology, string size)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { FileName = "Flag.tga", Filter = "TGAファイル|*.tga", RestoreDirectory = true, CheckFileExists = true, CheckPathExists = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    switch (ideology)
                    {
                        case "n":
                            switch (size)
                            {
                                case "big":
                                    textBox17.Text = ofd.FileName;
                                    break;

                                case "medium":
                                    textBox16.Text = ofd.FileName;
                                    break;

                                case "small":
                                    textBox15.Text = ofd.FileName;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case "d":
                            switch (size)
                            {
                                case "big":
                                    textBox23.Text = ofd.FileName;
                                    break;

                                case "medium":
                                    textBox22.Text = ofd.FileName;
                                    break;

                                case "small":
                                    textBox21.Text = ofd.FileName;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case "f":
                            switch (size)
                            {
                                case "big":
                                    textBox20.Text = ofd.FileName;
                                    break;

                                case "medium":
                                    textBox19.Text = ofd.FileName;
                                    break;

                                case "small":
                                    textBox18.Text = ofd.FileName;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case "c":
                            switch (size)
                            {
                                case "big":
                                    textBox26.Text = ofd.FileName;
                                    break;

                                case "medium":
                                    textBox25.Text = ofd.FileName;
                                    break;

                                case "small":
                                    textBox24.Text = ofd.FileName;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 生成直前に入るチェック
        /// 入力ミスなどを検知する
        /// </summary>
        public int Check()
        {
            // hoi4ディレクトリ・modディレクトリ
            if (Properties.Settings.Default.hoi4dir == "" || Properties.Settings.Default.moddir == "")
            {
                ErrorMessage("HoI4本体のディレクトリ、またはmodディレクトリが設定されていません。\n[ツール] - [設定]からフォルダーパスを設定してください。");
                return 1;
            }

            // 国家タグ
            // テキストボックスが空っぽまたはスペース、大文字ではない
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                ErrorMessage("国家タグが無効です。");
                return 1;
            }

            // 国名
            // 内部処理用
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                ErrorMessage("[国名] - [内部処理用]が無効です。");
                return 1;
            }

            // 中道主義
            // 表示名
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                ErrorMessage("[国名] - [中道主義] - [表示名]が無効です。");
                return 1;
            }
            // イベント表示名
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                ErrorMessage("[国名] - [中道主義] - [イベント表示名]が無効です。");
                return 1;
            }
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                ErrorMessage("[国名] - [中道主義] - [通称名]が無効です。");
                return 1;
            }

            // 民主主義
            // 表示名
            if (string.IsNullOrWhiteSpace(textBox8.Text))
            {
                ErrorMessage("[国名] - [民主主義] - [表示名]が無効です。");
                return 1;
            }
            // イベント表示名
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                ErrorMessage("[国名] - [民主主義] - [イベント表示名]が無効です。");
                return 1;
            }
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                ErrorMessage("[国名] - [民主主義] - [通称名]が無効です。");
                return 1;
            }

            // ファシズム
            // 表示名
            if (string.IsNullOrWhiteSpace(textBox11.Text))
            {
                ErrorMessage("[国名] - [ファシズム] - [表示名]が無効です。");
                return 1;
            }
            // イベント表示名
            if (string.IsNullOrWhiteSpace(textBox10.Text))
            {
                ErrorMessage("[国名] - [ファシズム] - [イベント表示名]が無効です。");
                return 1;
            }
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox9.Text))
            {
                ErrorMessage("[国名] - [ファシズム] - [通称名]が無効です。");
                return 1;
            }

            // 共産主義
            // 表示名
            if (string.IsNullOrWhiteSpace(textBox14.Text))
            {
                ErrorMessage("[国名] - [共産主義] - [表示名]が無効です。");
                return 1;
            }
            // イベント表示名
            if (string.IsNullOrWhiteSpace(textBox13.Text))
            {
                ErrorMessage("[国名] - [共産主義] - [イベント表示名]が無効です。");
                return 1;
            }
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox12.Text))
            {
                ErrorMessage("[国名] - [共産主義] - [通称名]が無効です。");
                return 1;
            }

            // 国旗はファイルパスが指定されてなくてもOK

            // 政党名
            // 中道主義政党
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox30.Text))
            {
                ErrorMessage("[政党名] - [中道主義政党] - [通称名]が無効です。");
                return 1;
            }
            // 正式名
            if (string.IsNullOrWhiteSpace(textBox29.Text))
            {
                ErrorMessage("[政党名] - [中道主義政党] - [正式名]が無効です。");
                return 1;
            }
            // 民主主義政党
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox35.Text))
            {
                ErrorMessage("[政党名] - [民主主義政党] - [通称名]が無効です。");
                return 1;
            }
            // 正式名
            if (string.IsNullOrWhiteSpace(textBox34.Text))
            {
                ErrorMessage("[政党名] - [民主主義政党] - [正式名]が無効です。");
                return 1;
            }
            // ファシズム政党
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox31.Text))
            {
                ErrorMessage("[政党名] - [ファシズム政党] - [通称名]が無効です。");
                return 1;
            }
            // 正式名
            if (string.IsNullOrWhiteSpace(textBox28.Text))
            {
                ErrorMessage("[政党名] - [ファシズム政党] - [正式名]が無効です。");
                return 1;
            }
            // 共産主義政党
            // 通称名
            if (string.IsNullOrWhiteSpace(textBox33.Text))
            {
                ErrorMessage("[政党名] - [共産主義政党] - [通称名]が無効です。");
                return 1;
            }
            // 正式名
            if (string.IsNullOrWhiteSpace(textBox32.Text))
            {
                ErrorMessage("[政党名] - [共産主義政党] - [正式名]が無効です。");
                return 1;
            }

            // 各種設定
            // 汎用顔グラフィックの地域設定
            if (comboBox1.SelectedItem == null)
            {
                ErrorMessage("[各種設定] - [汎用顔グラフィックの地域設定]が設定されていません。");
                return 1;
            }
            // 初期政党支持率（の合計が100%ではない場合）
            PartiesSupportTotal();
            int total = int.Parse(textBox27.Text);
            if (total != 100)
            {
                ErrorMessage("[各種設定] - [初期政党支持率]の合計が100%ではありません。\n[合計]の値を確認してください。");
                return 1;
            }
            // 初期与党
            if (comboBox2.SelectedItem == null)
            {
                ErrorMessage("[各種設定] - [初期与党] - [イデオロギー]が設定されていません。");
                return 1;
            }
            // 従属国である場合
            if (checkBox2.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(textBox36.Text))
                {
                    ErrorMessage("[各種設定] - [宗主国の国家タグ]が無効です。");
                }
            }
            // mod名
            if (string.IsNullOrWhiteSpace(textBox39.Text))
            {
                ErrorMessage("[Mod名]が無効です。");
                return 1;
            }

            MessageBox.Show("入力ミスのチェックが完了しました。");
            return 0;
        }

        /// <summary>
        /// データの変数化処理
        /// </summary>
        public void DataAssignment()
        {
            Variable variable = new Variable();

            // フォルダパス
            variable.Hoi4dir = Properties.Settings.Default.hoi4dir;
            variable.Moddir = Properties.Settings.Default.moddir;

            // データ
            // mod名
            variable.ModName = textBox39.Text;
            // 国家タグ
            variable.CountryTag = textBox1.Text;
            // 内部処理用国名
            variable.CountryName = textBox2.Text;
            // 中道主義
            // 表示名
            variable.N_ViewName = textBox3.Text;
            // イベント表示名
            variable.N_EventViewName = textBox4.Text;
            // 通称名
            variable.N_AliasName = textBox5.Text;
            // 民主主義
            // 表示名
            variable.D_ViewName = textBox8.Text;
            // イベント表示名
            variable.D_EventViewName = textBox7.Text;
            // 通称名
            variable.D_AliasName = textBox6.Text;
            // ファシズム
            // 表示名
            variable.F_ViewName = textBox11.Text;
            // イベント表示名
            variable.F_EventViewName = textBox10.Text;
            // 通称名
            variable.F_AliasName = textBox9.Text;
            // 共産主義
            // 表示名
            variable.C_ViewName = textBox14.Text;
            // イベント表示名
            variable.C_EventViewName = textBox13.Text;
            // 通称名
            variable.C_AliasName = textBox12.Text;
            // 国旗ファイルパス
            // 中道主義
            // 大
            variable.N_FlagBig = textBox17.Text;
            // 中
            variable.N_FlagMed = textBox16.Text;
            // 小
            variable.N_FlagSma = textBox15.Text;
            // 民主主義
            // 大
            variable.D_FlagBig = textBox23.Text;
            // 中
            variable.D_FlagMed = textBox22.Text;
            // 小
            variable.D_FlagSma = textBox21.Text;
            // ファシズム
            // 大
            variable.F_FlagBig = textBox20.Text;
            // 中
            variable.F_FlagMed = textBox19.Text;
            // 小
            variable.F_FlagSma = textBox18.Text;
            // 共産主義
            // 大
            variable.C_FlagBig = textBox26.Text;
            // 中
            variable.C_FlagMed = textBox25.Text;
            // 小
            variable.C_FlagSma = textBox24.Text;
            // 政党名
            // 中道主義
            // 通称名
            variable.N_PartyAliasName = textBox30.Text;
            // 正式名
            variable.N_PartyFullName = textBox29.Text;
            // 民主主義
            // 通称名
            variable.D_PartyAliasName = textBox35.Text;
            // 正式名
            variable.D_PartyFullName = textBox34.Text;
            // ファシズム
            // 通称名
            variable.F_PartyAliasName = textBox31.Text;
            // 正式名
            variable.F_PartyFullName = textBox28.Text;
            // 共産主義
            // 通称名
            variable.C_PartyAliasName = textBox33.Text;
            // 正式名
            variable.C_PartyFullName = textBox32.Text;
            // 配色
            variable.ColorR = (int)numericUpDown1.Value;
            variable.ColorG = (int)numericUpDown2.Value;
            variable.ColorB = (int)numericUpDown3.Value;
            // 汎用顔グラフィック
            if (comboBox1.SelectedIndex == 0)
            {
                // 東ヨーロッパ
                variable.GraphicalCulture = "eastern_european_gfx";
                variable.GraphicalCulture2d = "eastern_european_2d";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                // 西ヨーロッパ
                variable.GraphicalCulture = "western_european_gfx";
                variable.GraphicalCulture2d = "western_european_2d";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                // 中東
                variable.GraphicalCulture = "middle_eastern_gfx";
                variable.GraphicalCulture2d = "middle_eastern_2d";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                // 南アメリカ
                variable.GraphicalCulture = "southamerican_gfx";
                variable.GraphicalCulture2d = "southamerican_2d";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                // アジア
                variable.GraphicalCulture = "asian_gfx";
                variable.GraphicalCulture2d = "asian_2d";
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                // アフリカ
                variable.GraphicalCulture = "african_gfx";
                variable.GraphicalCulture2d = "african_2d";
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                // イギリス連邦
                variable.GraphicalCulture = "commonwealth_gfx";
                variable.GraphicalCulture2d = "commonwealth_2d";
            }

            // 首都を含む州ID
            variable.StateIDWithCapital = (int)numericUpDown4.Value;
            // 研究スロット数
            variable.StudySlot = (int)numericUpDown5.Value;
            // 初期安定度（100分率）
            variable.Stability = (int)numericUpDown6.Value * 0.01;
            // 初期戦争協力度
            variable.WarCoop = (int)numericUpDown7.Value * 0.01;
            // 初期政治力
            variable.PoliticalPower = (int)numericUpDown8.Value;
            // 初期輸送船数
            variable.TransportShip = (int)numericUpDown13.Value;
            // この国が従属国かどうか
            variable.DependentCountry = checkBox2.Checked;
            // 宗主国の国家タグ（存在しない場合はnull）
            variable.SovereignCountryTag = null;

            if (checkBox2.Checked == true)
            {
                variable.SovereignCountryTag = textBox36.Text;
            }

            // 初期政党支持率
            // 中道主義
            variable.N_Popularity = (int)numericUpDown12.Value;
            // 民主主義
            variable.D_Popularity = (int)numericUpDown11.Value;
            // ファシズム
            variable.F_Popularity = (int)numericUpDown10.Value;
            // 共産主義
            variable.C_Popularity = (int)numericUpDown9.Value;

            // 初期与党
            // イデオロギー
            if (comboBox2.SelectedIndex == 0)
            {
                // 中道主義
                variable.StartIdeology = "neutrality";

            }
            else if (comboBox2.SelectedIndex == 1)
            {
                // 民主主義
                variable.StartIdeology = "democratic";

            }
            else if (comboBox2.SelectedIndex == 2)
            {
                // ファシズム
                variable.StartIdeology = "fascism";

            }
            else if (comboBox2.SelectedIndex == 3)
            {
                // 共産主義
                variable.StartIdeology = "communism";

            }

            // 前回の選挙
            // YYYY
            variable.LastElectionYYYY = (int)numericUpDown16.Value;
            // MM
            variable.LastElectionM = (int)numericUpDown15.Value;
            // DD
            variable.LastElectionD = (int)numericUpDown14.Value;
            // YYYY.MM.DD
            variable.LastElection = variable.LastElectionYYYY.ToString() + "." + variable.LastElectionM.ToString() + "." + variable.LastElectionD.ToString();

            // 選挙を行う間隔
            variable.ElectionFrequency = (int)numericUpDown17.Value;

            // 選挙がないかどうか（true -> なし）
            variable.NoElection = checkBox1.Checked;
        }

        /// <summary>
        /// エラーメッセージボックスを表示
        /// </summary>
        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ColorChange();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            ColorChange();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            ColorChange();
        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                textBox36.Enabled = false;
            }
            else if (checkBox2.Checked == true)
            {
                textBox36.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            PartiesSupportTotal();
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            PartiesSupportTotal();
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            PartiesSupportTotal();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            PartiesSupportTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenTGAFile("n", "big");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenTGAFile("n", "medium");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenTGAFile("n", "small");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenTGAFile("d", "big");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenTGAFile("d", "medium");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenTGAFile("d", "small");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenTGAFile("f", "big");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenTGAFile("f", "medium");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenTGAFile("f", "small");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenTGAFile("c", "big");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenTGAFile("c", "medium");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenTGAFile("c", "small");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AllClear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Generate generate = new Generate();

            int cResult = Check();
            if (cResult == 1)
            {
                return;
            }
            DataAssignment();
            int gcResult = generate.GenerateCountry();
            if (gcResult == 1)
            {
                return;
            }
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            NationalLeaderSettings nls = new NationalLeaderSettings();
            nls.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            UnitSettings us = new UnitSettings();
            us.ShowDialog();
        }
    }
}
