using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyTitle("Rugby Scoreboard")]
[assembly: AssemblyDescription("Yerel Rugby Scoreboard başlatıcısı")]
[assembly: AssemblyProduct("Rugby Scoreboard")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

public static class Launcher
{
    // Stable directory keeps browser-local match storage across launches.
    public static string ExtractAssets(string directory)
    {
        Directory.CreateDirectory(directory);
        foreach (string name in new[] { "index.html", "style.css", "app.js" })
        {
            string destination = Path.Combine(directory, name);
            using (Stream resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
            {
                if (resource == null) throw new InvalidDataException("Uygulama dosyası eksik: " + name);
                using (var memory = new MemoryStream())
                {
                    resource.CopyTo(memory);
                    byte[] content = memory.ToArray();
                    // Avoid rewriting files on every launch.
                    if (File.Exists(destination) && SameBytes(File.ReadAllBytes(destination), content)) continue;
                    string temporary = destination + "." + Guid.NewGuid().ToString("N") + ".tmp";
                    try
                    {
                        File.WriteAllBytes(temporary, content);
                        if (File.Exists(destination)) File.Replace(temporary, destination, null);
                        else File.Move(temporary, destination);
                    }
                    finally { if (File.Exists(temporary)) File.Delete(temporary); }
                }
            }
        }
        return Path.Combine(directory, "index.html");
    }

    static bool SameBytes(byte[] first, byte[] second)
    {
        if (first.Length != second.Length) return false;
        for (int i = 0; i < first.Length; i++) if (first[i] != second[i]) return false;
        return true;
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        try
        {
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RugbyScoreboard", "LocalApp");
            string page = ExtractAssets(directory);
            Process.Start(new ProcessStartInfo(page) { UseShellExecute = true });
        }
        catch (Exception error)
        {
            MessageBox.Show("Uygulama açılamadı. Varsayılan tarayıcıyı ve klasör izinlerini kontrol edin.\n\n" + error.Message,
                "Rugby Scoreboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
