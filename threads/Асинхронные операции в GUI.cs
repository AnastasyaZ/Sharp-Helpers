public class MyForm : Form
    {
        private readonly Label label;

        public MyForm()
        {
            label = new Label { Size = new Size(ClientSize.Width, 30) };
            var button = new Button
            {
                Location = new Point(0, label.Bottom),
                Size = new Size(label.Width, label.Height),
                Text = "Start"
            };
            Controls.Add(label);
            Controls.Add(button);
            button.Click += MakeWork;
        }

        private void MakeWorkInThread()
        {
            Thread.Sleep(3000);
			//label.Text = "Done"; // Операции с контролами можно совершать только из GUI-потока
            BeginInvoke(new Action(() => label.Text = "Done"));// ← это можно делать так
        }

        private void MakeWork(object sender, EventArgs args)
        {
            new Action(MakeWorkInThread).BeginInvoke(null, null);
		// Не нужно путать BeginInvoke у делегата (асинхронный запуск операции в другом потоке)
		// и у формы (асинхронный запуск операции в GUI-потоке этой формы)
        }

        public static void Main()
        {
            Application.Run(new MyForm());
        }
    }