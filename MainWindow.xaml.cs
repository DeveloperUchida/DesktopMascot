using System;
using System.Windows;
using System.Windows.Input;

namespace DesktopMascot
{
    public partial class MainWindow : Window
    {
        private readonly string[] messages =
        {
              "作業しててえらい〜！✨",
            "水飲んだ？🚰",
            "そろそろ休憩しよ〜☕",
            "今日もちゃんと進んでるよ！",
            "Gitコミット忘れてない？💻"
        };
        private readonly Random random = new();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += (_, _) =>
            {
                Left = SystemParameters.WorkArea.Width - Width - 20;
                Top = SystemParameters.WorkArea.Height - Height - 20;
            };

            MouseLeftButtonDown += (_, _) =>
            {
                MessageText.Text = messages[random.Next(messages.Length)];
            };
        }
    }
}