﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HoI4_Modding_Supporter.Workers;

namespace HoI4_Modding_Supporter.Mediators
{
    class UserController
    {
        InputChecker ic = new InputChecker();

        /// <summary>
        /// Main.csの入力チェック
        /// </summary>
        public int MainGenerateChecker(List<TextBox> textBoxes, List<ComboBox> comboBoxes, List<CheckBox> checkBoxes)
        {
            return ic.MainGenrateChecker(textBoxes, comboBoxes, checkBoxes);
        }

        /// <summary>
        /// FactionSettings.csの入力チェック
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <returns></returns>
        public int FactionSettingsChecker(List<TextBox> textBoxes)
        {
            return ic.FactionSettingsChecker(textBoxes);
        }

        /// <summary>
        /// NationalLeaderSettings.csの入力チェック
        /// </summary>
        /// <param name="textBoxes"></param>
        /// <param name="richTextBoxes"></param>
        /// <param name="comboBoxes"></param>
        /// <returns></returns>
        public int NationalLeaderSettingsChecker(List<TextBox> textBoxes, List<RichTextBox> richTextBoxes, List<ComboBox> comboBoxes)
        {
            return ic.NationalLeaderSettingsChecker(textBoxes, richTextBoxes, comboBoxes);
        }
    }
}
