﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoI4_Modding_Supporter
{
    public partial class NationalLeaderSettings : Form
    {
        /// <summary>
        /// エラーメッセージボックスを表示
        /// </summary>
        public void errorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 入力ミスなどを検知する
        /// </summary>
        /// <returns></returns>
        public int check()
        {
            // 名前
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorMessage("[名前]が無効です。");
                return 1;
            }
            // 説明
            else if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                errorMessage("[説明]が無効です。");
                return 1;
            }
            // 画像
            else if (string.IsNullOrWhiteSpace(textBox17.Text))
            {
                errorMessage("[画像]のファイルパスが無効です。");
                return 1;
            }
            // イデオロギー
            else if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                errorMessage("[イデオロギー]が設定されていません。");
                return 1;
            }

            MessageBox.Show("入力ミスのチェックが完了しました。");
            return 0;
        }

        /// <summary>
        /// データの変数化処理
        /// </summary>
        public void dataAssignment()
        {
            Variable variable = new Variable();

            // カスタム国家指導者の有効化
            variable.customLeaderEnabled = checkBox1.Checked;
            // 名前
            variable.leaderName = textBox1.Text;
            // 説明
            variable.leaderDesc = richTextBox1.Text;
            // 画像
            variable.leaderPicturePath = textBox17.Text;
            // 画像ファイル名（指導者名がファイル名になります）
            variable.leaderPictureName = variable.leaderName.Replace(" ", "_") + ".dds";
            // イデオロギー
            if (comboBox1.SelectedIndex == 0)
            {
                // despotism
                if (comboBox2.SelectedIndex == 0)
                {
                    variable.leaderIdeology = "despotism";
                }
                // oligarchism
                else if (comboBox2.SelectedIndex == 1)
                {
                    variable.leaderIdeology = "oligarchism";
                }
                // anarchism
                else if (comboBox2.SelectedIndex == 2)
                {
                    variable.leaderIdeology = "anarchism";
                }
                // moderatism
                else if (comboBox2.SelectedIndex == 3)
                {
                    variable.leaderIdeology = "moderatism";
                }
                // centrism
                else if (comboBox2.SelectedIndex == 4)
                {
                    variable.leaderIdeology = "centrism";
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                // conservatism
                if (comboBox2.SelectedIndex == 0)
                {
                    variable.leaderIdeology = "conservatism";
                }
                // liberalism
                else if (comboBox2.SelectedIndex == 1)
                {
                    variable.leaderIdeology = "liberalism";
                }
                // socialism
                else if (comboBox2.SelectedIndex == 2)
                {
                    variable.leaderIdeology = "socialism";
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                // nazism
                if (comboBox2.SelectedIndex == 0)
                {
                    variable.leaderIdeology = "nazism";
                }
                // fascism_ideology
                else if (comboBox2.SelectedIndex == 1)
                {
                    variable.leaderIdeology = "fascism_ideology";
                }
                // falangism
                else if (comboBox2.SelectedIndex == 2)
                {
                    variable.leaderIdeology = "falangism";
                }
                // rexism
                else if (comboBox2.SelectedIndex == 3)
                {
                    variable.leaderIdeology = "rexism";
                }
                
            }
            else
            {
                //marxism
                if (comboBox2.SelectedIndex == 0)
                {
                    variable.leaderIdeology = "marxism";
                }
                // leninism
                else if (comboBox2.SelectedIndex == 1)
                {
                    variable.leaderIdeology = "leninism";
                }
                // stalinism
                else if (comboBox2.SelectedIndex == 2)
                {
                    variable.leaderIdeology = "stalinism";
                }
                // anti_revisionism
                else if (comboBox2.SelectedIndex == 3)
                {
                    variable.leaderIdeology = "anti_revisionism";
                }
                // anarchist_communism
                else if (comboBox2.SelectedIndex == 4)
                {
                    variable.leaderIdeology = "anarchist_communism";
                }
            }

            // 登場しなくなる年月日 (YYYY/M/D)
            variable.willNotAppear = numericUpDown16.Value.ToString() + "." + numericUpDown15.Value.ToString() + "." + numericUpDown14.Value.ToString();
        }

        public NationalLeaderSettings()
        {
            InitializeComponent();
            checkBox1.Checked = false;
            textBox1.Enabled = false;
            textBox17.Enabled = false;
            richTextBox1.Enabled = false;
            button3.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            numericUpDown16.Enabled = false;
            numericUpDown15.Enabled = false;
            numericUpDown14.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                richTextBox1.Enabled = true;
                textBox17.Enabled = true;
                button3.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                numericUpDown16.Enabled = true;
                numericUpDown15.Enabled = true;
                numericUpDown14.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                richTextBox1.Enabled = false;
                textBox17.Enabled = false;
                button3.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                numericUpDown16.Enabled = false;
                numericUpDown15.Enabled = false;
                numericUpDown14.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                this.Close();
            }
            else
            {
                int cResult = check();
                if (cResult == 1)
                {
                    return;
                }
                else
                {
                    dataAssignment();
                    this.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { FileName = "Picture.dds", Filter = "DDSファイル|*.dds", RestoreDirectory = true, CheckFileExists= true, CheckPathExists = true })
            {
                if (ofd.ShowDialog() ==DialogResult.OK)
                {
                    textBox17.Text = ofd.FileName;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 中道主義
            if (comboBox1.SelectedIndex == 0)
            {
                // despotism, oligarchism, anarchism, moderatism, centrism
                comboBox2.Items.Clear();
                comboBox2.Items.Add("独裁主義者");
                comboBox2.Items.Add("寡頭主義者");
                comboBox2.Items.Add("無政府主義者");
                comboBox2.Items.Add("近代主義者");
                comboBox2.Items.Add("中道主義者");

            }
            // 民主主義
            else if (comboBox1.SelectedIndex == 1)
            {
                // conservatism, liberalism, socialism
                comboBox2.Items.Clear();
                comboBox2.Items.Add("保守主義者");
                comboBox2.Items.Add("自由主義者");
                comboBox2.Items.Add("社会主義者");
            }
            // ファシズム
            else if (comboBox1.SelectedIndex == 2)
            {
                // nazism, fascism_ideology, falangism, rexism
                comboBox2.Items.Clear();
                comboBox2.Items.Add("国家社会主義者");
                comboBox2.Items.Add("ファシスト");
                comboBox2.Items.Add("ファランジスト");
                comboBox2.Items.Add("レクシスト");
            }
            // 共産主義
            else
            {
                // marxism, leninism, stalinism, anti_revisionism, anarchist_communism
                comboBox2.Items.Clear();
                comboBox2.Items.Add("マルクス主義者");
                comboBox2.Items.Add("レーニン主義者");
                comboBox2.Items.Add("スターリン主義者");
                comboBox2.Items.Add("反修正主義者");
                comboBox2.Items.Add("無政府共産主義者");
            }
        }
    }
}
