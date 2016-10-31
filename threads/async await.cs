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

        private Task<string> MakeWorkInThread()
        {
            var task= new Task<string>
                (
                    () => { Thread.Sleep(3000); return "Done"; }
                );
            task.Start();
            return task;
		// Вместо создания задачи, тут мог быть вызов какой-либо полезной асинхронной операции. 
		// Имена методов асинхронных операций обычно заканчиваются словом Async, 
		// например, метод ReadLineAsync у класса StreamReader.
        }

        private async void MakeWork(object sender, EventArgs args)
        {
            var labelText = await MakeWorkInThread();
            label.Text = labelText;
        }

        public static void Main()
        {
            Application.Run(new MyForm());
        }
    }