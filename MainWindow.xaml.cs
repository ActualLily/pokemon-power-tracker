using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PPT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int[] EVs = new int[6];
        int itemSelected = 0;
        int EVsLeft = 510;

        void UpdateUI()
        {
            if (EVs[0] % 4 == 0 && EVs[0] != 0) Lbl_HP.FontWeight = FontWeights.Bold;
            else Lbl_HP.FontWeight = FontWeights.Regular;
            Lbl_HP.Content = EVs[0];
            if (EVs[1] % 4 == 0 && EVs[1] != 0) Lbl_ATK.FontWeight = FontWeights.Bold;
            else Lbl_ATK.FontWeight = FontWeights.Regular;
            Lbl_ATK.Content = EVs[1];
            if (EVs[2] % 4 == 0 && EVs[2] != 0) Lbl_DEF.FontWeight = FontWeights.Bold;
            else Lbl_DEF.FontWeight = FontWeights.Regular;
            Lbl_DEF.Content = EVs[2];
            if (EVs[3] % 4 == 0 && EVs[3] != 0) Lbl_SPA.FontWeight = FontWeights.Bold;
            else Lbl_SPA.FontWeight = FontWeights.Regular;
            Lbl_SPA.Content = EVs[3];
            if (EVs[4] % 4 == 0 && EVs[4] != 0) Lbl_SPD.FontWeight = FontWeights.Bold;
            else Lbl_SPD.FontWeight = FontWeights.Regular;
            Lbl_SPD.Content = EVs[4];
            if (EVs[5] % 4 == 0 && EVs[5] != 0) Lbl_SPE.FontWeight = FontWeights.Bold;
            else Lbl_SPE.FontWeight = FontWeights.Regular;
            Lbl_SPE.Content = EVs[5];

            Bar_HP.Value = Convert.ToDouble(EVs[0]) / 2.52;
            Bar_ATK.Value = Convert.ToDouble(EVs[1]) / 2.52;
            Bar_DEF.Value = Convert.ToDouble(EVs[2]) / 2.52;
            Bar_SPA.Value = Convert.ToDouble(EVs[3]) / 2.52;
            Bar_SPD.Value = Convert.ToDouble(EVs[4]) / 2.52;
            Bar_SPE.Value = Convert.ToDouble(EVs[5]) / 2.52;

            double setOpacity = 0.3;

            Btn_HP.Opacity = setOpacity;
            Btn_ATK.Opacity = setOpacity;
            Btn_DEF.Opacity = setOpacity;
            Btn_SPA.Opacity = setOpacity;
            Btn_SPD.Opacity = setOpacity;
            Btn_SPE.Opacity = setOpacity;
            Btn_MCB.Opacity = setOpacity;

            if (itemSelected == 1) Btn_HP.Opacity = 1;
            if (itemSelected == 2) Btn_ATK.Opacity = 1;
            if (itemSelected == 3) Btn_DEF.Opacity = 1;
            if (itemSelected == 4) Btn_SPA.Opacity = 1;
            if (itemSelected == 5) Btn_SPD.Opacity = 1;
            if (itemSelected == 6) Btn_SPE.Opacity = 1;
            if (itemSelected == 7) Btn_MCB.Opacity = 1;

            Lbl_SUM.Content = EVsLeft;
            Bar_SUM.Value = EVsLeft / 5.1;
        }

        public int LeftoverEVCheck(int EVIndex, int EVAmount)
        {
            if (EVAmount > EVsLeft) EVAmount = EVsLeft;

            if (EVAmount > 252 - EVs[EVIndex]) EVAmount = 252 - EVs[EVIndex];

            EVsLeft -= EVAmount;

            return EVAmount;
        }

        void UpdateEVs(int EVIndex, int EVAmount)
        {
            EVs[EVIndex] += LeftoverEVCheck(EVIndex, EVAmount);

            // double on Macho Brace
            if (itemSelected == 7) EVs[EVIndex] += LeftoverEVCheck(EVIndex, EVAmount);

            // add +8 to the Power item held's stat
            if (itemSelected > 0 && itemSelected < 7) EVs[itemSelected - 1] += LeftoverEVCheck(itemSelected - 1, 8);

            UpdateUI();
        }

        void itemSelection(int selectedItem)
        {
            if (selectedItem == itemSelected) itemSelected = 0;
            else itemSelected = selectedItem;

            UpdateUI();
        }

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 6; i++) EVs[i] = 0;

            UpdateUI();
        }
        private void Btn_HP_Click(object sender, RoutedEventArgs e)
        {
            itemSelection(1);
        }
        private void Btn_ATK_Click(object sender, RoutedEventArgs e)
        {
            itemSelection(2);
        }
        private void Btn_DEF_Click(object sender, RoutedEventArgs e)
        {
            itemSelection(3);
        }
        private void Btn_SPA_Click(object sender, RoutedEventArgs e)
        {
            itemSelection(4);
        }
        private void Btn_SPD_Click(object sender, RoutedEventArgs e)
        {
            itemSelection(5);
        }
        private void BTN_SPE_Click(object sender, RoutedEventArgs e)
        {
            itemSelection(6);
        }
        private void Btn_MCB_Click(object sender, RoutedEventArgs e)
        {
            itemSelection(7);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateEVs(0, 1);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateEVs(0, 2);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateEVs(0, 3);
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UpdateEVs(1, 1);
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            UpdateEVs(1, 2);
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            UpdateEVs(1, 3);
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            UpdateEVs(2, 1);
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            UpdateEVs(2, 2);
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            UpdateEVs(2, 3);
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            UpdateEVs(3, 1);
        }
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            UpdateEVs(3, 2);
        }
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            UpdateEVs(3, 3);
        }
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            UpdateEVs(4, 1);
        }
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            UpdateEVs(4, 2);
        }
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            UpdateEVs(4, 3);
        }
        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            UpdateEVs(5, 1);
        }
        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            UpdateEVs(5, 2);
        }
        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            UpdateEVs(5, 3);
        }
        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            itemSelected = 0;
            EVsLeft = 510;
            for (int i = 0; i < 6; i++) EVs[i] = 0;
            UpdateUI();
        }
    }
}
