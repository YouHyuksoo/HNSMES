using System;
using System.Drawing;
using System.Windows.Forms;

namespace IDAT.Devexpress.ActionDemo;

public class ActiveDemoResults : IDisposable
{
	private class ResultForm : Form
	{
		private TextBox textBox;

		public ResultForm()
		{
			base.TopMost = true;
			Text = "Active demo result";
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.ShowInTaskbar = false;
			base.Width = 200;
			base.Height = 200;
			base.StartPosition = FormStartPosition.Manual;
			textBox = new TextBox();
			textBox.Dock = DockStyle.Fill;
			textBox.Multiline = true;
			textBox.WordWrap = true;
			textBox.Parent = this;
		}

		public void Add(string text)
		{
			TextBox obj = textBox;
			obj.Text = obj.Text + text + Environment.NewLine;
		}

		public void Clear()
		{
			textBox.Clear();
		}
	}

	private Control fparent;

	private ResultForm fform;

	private ResultForm Form
	{
		get
		{
			if (fform == null)
			{
				fform = CreateResultForm();
			}
			return fform;
		}
	}

	public ActiveDemoResults(Control fparent)
	{
		this.fparent = fparent;
	}

	public void Dispose()
	{
		if (fform != null)
		{
			fform.Dispose();
			fform = null;
		}
	}

	void IDisposable.Dispose()
	{
		Dispose();
	}

	public void Show()
	{
		Form.Show();
	}

	public void Hide()
	{
		if (fform != null)
		{
			fform.Hide();
		}
	}

	public void Add(string text)
	{
		if (!Form.Visible)
		{
			Show();
		}
		Form.Add(text);
	}

	public void Clear()
	{
		if (fform != null)
		{
			fform.Clear();
		}
	}

	private ResultForm CreateResultForm()
	{
		ResultForm resultForm = new ResultForm();
		Rectangle rectangle = fparent.RectangleToScreen(fparent.Bounds);
		resultForm.Left = rectangle.Right - resultForm.Width;
		resultForm.Top = rectangle.Bottom - resultForm.Height;
		resultForm.Disposed += ResultFormDisposed;
		return resultForm;
	}

	private void ResultFormDisposed(object sender, EventArgs e)
	{
		fform = null;
	}
}
