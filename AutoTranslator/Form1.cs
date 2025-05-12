using AutoTranslator.Models;
using Gma.System.MouseKeyHook;

namespace AutoTranslator
{
    public partial class Form1 : Form
    {
        private IKeyboardMouseEvents m_GlobalHook;
        private Dictionary<string, string> translationCache = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            Subscribe();
        }

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += M_GlobalHook_KeyDown;
        }

        private void M_GlobalHook_KeyDown(object? sender, KeyEventArgs e)
        {
            if ((e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.X)) && isTranslationEnabled.Checked) TranslateClipboardText();
        }

        private async void TranslateClipboardText()
        {
            await Task.Delay(100);
            IDataObject buffer = Clipboard.GetDataObject();
            if (buffer.GetDataPresent(DataFormats.UnicodeText))
            {
                string original = (string)buffer.GetData(DataFormats.UnicodeText);
                if (!translationCache.ContainsKey(original))
                {
                    var translator = new TranslationHandler(original);
                    var translate = await translator.FetchTranslationAsync();
                    translationCache[original] = translate.TranslatedText;
                    translationCache[translate.TranslatedText] = original;
                }

                Clipboard.SetText(translationCache[original], TextDataFormat.UnicodeText);

            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            m_GlobalHook.KeyDown -= M_GlobalHook_KeyDown;
            m_GlobalHook.Dispose();
            base.OnFormClosed(e);
        }

    }
}
