public class MyForm : Form
    {
        private readonly Label label;
        private readonly Button button;
        private readonly ProgressBar progressBar;

        public MyForm()
        {
            label = new Label { Size = new Size(ClientSize.Width, 30) };
            button = new Button
            {
                Location = new Point(0, label.Bottom),
                Size = new Size(label.Width, label.Height),
                Text = "Start"
            };
            progressBar = new ProgressBar()
            {
                Location = new Point(0,button.Bottom),
                Size = new Size(label.Width, label.Height)
            };
            Controls.Add(label);
            Controls.Add(button);
            Controls.Add(progressBar);
            button.Click += MakeWork;
        }

        private void MakeWork(object sender, EventArgs args)
        {
            var cancellBtn = new Button
            {
                Location = button.Location,
                Size = button.Size,
                Text = "Cancel"
            };
            Controls.Remove(button);
            Controls.Add(cancellBtn);

            var worker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };

            worker.DoWork+=WorkerOnDoWork;
            worker.RunWorkerCompleted += (s, a) => label.Text = "Done";
            worker.ProgressChanged += (s, progressChangedArgs) => progressBar.Value=progressChangedArgs.ProgressPercentage;

            cancellBtn.Click += (s, a) => worker.CancelAsync();

            worker.RunWorkerAsync();
        }

        private static void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            for (var i = 0; i < 100; i++)
            {
                if(((BackgroundWorker)sender).CancellationPending) break;
                Thread.Sleep(50);
                ((BackgroundWorker)sender).ReportProgress(i);
            }
        }

        public static void Main()
        {
            Application.Run(new MyForm());
        }
    }