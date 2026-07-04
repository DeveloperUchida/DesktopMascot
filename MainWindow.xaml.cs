using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

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

            MouseLeftButtonDown += (_,e) =>
            {
                if (e.ClickCount == 1)
                {
                    DragMove();
                }
            };
            //右クリックの動作
            MouseRightButtonDown += (_, _) =>
            {
                MessageText.Text = messages[random.Next(messages.Length)];
            };
            workTimer.Interval = TimeSpan.FromSeconds(1);
            workTimer.Tick += (_, _) =>
            {
                workSeconds++;

                var time = TimeSpan.FromSeconds(workSeconds);
                WorkTimeText.Text = $"作業時間: {time:hh\\:mm\\:ss}";
                //30分毎に休息メッセージ
                if(workSeconds % 1800 == 0)
                {
                    MessageText.Text = "30分作業したよ〜！休憩しよ☕";
                }
            };
            workTimer.Start();
        }
        private int workSeconds = 0;
        private readonly DispatcherTimer workTimer = new();
    }
}