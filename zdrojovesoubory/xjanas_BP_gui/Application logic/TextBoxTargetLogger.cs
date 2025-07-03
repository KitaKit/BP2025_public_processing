using NLog;
using NLog.Targets;
using System;
using System.Collections.Concurrent;
using System.Text;
using System.Windows.Forms;

namespace GenotypeApp.Application_logic
{
    //[Target("TextBox")]
    //internal class TextBoxTargetLogger : TargetWithLayout
    //{
    //    public TextBox TextBoxControl { get; set; }

    //    protected override void Write(LogEventInfo logEvent)
    //    {
    //        string logMessage = this.Layout.Render(logEvent) + Environment.NewLine;
    //        if (TextBoxControl.InvokeRequired)
    //        {
    //            TextBoxControl.BeginInvoke(new Action(() => {
    //                TextBoxControl.AppendText(logMessage);
    //            }));
    //        }
    //        else
    //        {
    //            TextBoxControl.AppendText(logMessage);
    //        }
    //    }
    //}
    internal class BatchedTextBoxTarget : TargetWithLayout
    {
        private readonly ConcurrentQueue<string> _queue = new();
        private readonly System.Timers.Timer _timer;

        public BatchedTextBoxTarget()
        {
            _timer = new System.Timers.Timer(100);
            _timer.Elapsed += (_, __) => FlushQueue();
            _timer.Start();
        }

        public TextBox TextBoxControl { get; set; }

        protected override void Write(LogEventInfo logEvent)
        {
            _queue.Enqueue(Layout.Render(logEvent) + Environment.NewLine);
        }

        private void FlushQueue()
        {
            if (TextBoxControl == null || TextBoxControl.IsDisposed || !TextBoxControl.IsHandleCreated)
                return;

            if (_queue.IsEmpty) return;
            var sb = new StringBuilder();
            while (_queue.TryDequeue(out var line))
                sb.Append(line);

            try
            {
                void append() => TextBoxControl.AppendText(sb.ToString());

                if (TextBoxControl.InvokeRequired)
                    TextBoxControl.BeginInvoke((Action)append);
                else
                    append();
            }
            catch (Exception)
            {
            }
        }

        protected override void CloseTarget()
        {
            _timer.Stop();
            FlushQueue();
            base.CloseTarget();
        }
    }

}
