using System;
using System.Timers;
using System.Windows;

namespace XueKaoInformationBoard;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
	private readonly DateTime ys = new(2022, 7, 7, 9, 0, 0);
	private readonly DateTime ye = new(2022, 7, 7, 10, 0, 0);
	private readonly DateTime ms = new(2022, 7, 7, 10, 30, 0);
	private readonly DateTime me = new(2022, 7, 7, 11, 30, 0);
	private readonly DateTime xs = new(2022, 7, 7, 15, 0, 0);
	private readonly DateTime xe = new(2022, 7, 7, 16, 0, 0);
	private readonly DateTime ts = new(2022, 7, 7, 16, 30, 0);
	private readonly DateTime te = new(2022, 7, 7, 17, 30, 0);

	public MainWindow() {
		Timer timer = new(500) { AutoReset = true, Enabled = true };
		timer.Elapsed += Update;
		InitializeComponent();
	}


	public void Update(object? sender, ElapsedEventArgs? _) {
		var now = DateTime.Now;
		AppWindow.Dispatcher.Invoke(() => {
			Time.Text = now.ToString("H:mm:ss");
			if (now >= te) {
				Info.Text = "所有考试已结束！";
			} else if (now >= ts) {
				var span = te - now;
				Info.Text = $"距离通用技术考试结束还有{span.Minutes}分{span.Seconds}秒！";
			} else if (now >= xe) {
				var span = ts - now;
				Info.Text = $"距离通用技术考试开始还有{span.Minutes}分{span.Seconds}秒！";
			} else if (now >= xs) {
				var span = xe - now;
				Info.Text = $"距离信息技术考试结束还有{span.Minutes}分{span.Seconds}秒！";
			} else if (now >= me) {
				var span = xs - now;
				Info.Text = $"距离信息技术考试开始还有{span.Minutes}分{span.Seconds}秒！";
			} else if (now >= ms) {
				var span = me - now;
				Info.Text = $"距离美术考试结束还有{span.Minutes}分{span.Seconds}秒！";
			} else if (now >= ye) {
				var span = ms - now;
				Info.Text = $"距离美术考试开始还有{span.Minutes}分{span.Seconds}秒！";
			} else if (now >= ys) {
				var span = ye - now;
				Info.Text = $"距离音乐考试结束还有{span.Minutes}分{span.Seconds}秒！";
			} else {
				var span = ys - now;
				Info.Text = $"距离音乐考试开始还有{span.Minutes}分{span.Seconds}秒！";
			}
		});
	}
}