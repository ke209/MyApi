using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyApi.Generator.Tasks
{
    public class GeneratorMyApiStubTask : Task
    {
        [Required]
        public string BaseDirectory { get; set; }

        [Required]
        public string MyApiOutputFile { get; set; }

        [Required]
        public ITaskItem[] SourceFiles { get; set; }

        public string InternalNamespace { get; set; }

        public override bool Execute()
        {
            try
            {
               // Debugger.Launch();
                if (string.IsNullOrWhiteSpace(BaseDirectory))
                {
                    Log.LogError($"{nameof(BaseDirectory)} is not set");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(MyApiOutputFile))
                {
                    Log.LogError($"{nameof(MyApiOutputFile)} is not set");
                    return false;
                }

                if (SourceFiles == null)
                    SourceFiles = Array.Empty<ITaskItem>();

                var targetDir = new DirectoryInfo(BaseDirectory);

                var files = SourceFiles.Select(item => item.ItemSpec).Distinct()
                                     .Select(x => new FileInfo(Path.Combine(targetDir.FullName, x)))
                                     .Where(x => x.Name.Contains("SiteStubs") == false && x.Exists && x.Length > 0)
                                     .ToArray();

                var generator = new SiteStubGenerator(InternalNamespace, msg => Log.LogWarning(msg));
                var template = generator.GenerateInterfaceStubs(files.Select(x => x.FullName).ToArray()).Trim();

                string contents = null;

                var target = new FileInfo(MyApiOutputFile);

                if (target.Exists)
                {
                    // Only try writing if the contents are different. Don't cause a rebuild
                    contents = File.ReadAllText(target.FullName, Encoding.UTF8).Trim();
                    if (string.Equals(contents, template, StringComparison.Ordinal))
                    {
                        return true;
                    }
                }

                // If the file is read-only, we might be on a build server. Check the file to see if 
                // the contents match what we expect
                if (target.Exists && target.IsReadOnly)
                {
                    if (!string.Equals(contents, template, StringComparison.Ordinal))
                    {
                        Log.LogError($"File '{target}' is ReadOnly and cannot be written");
                        return false;
                    }
                }
                else
                {
                    var retryCount = 3;

                retry:

                    FileStream file;

                    // NB: Parallel build weirdness means that we might get >1 person 
                    // trying to party on this file at the same time.
                    try
                    {
                        file = File.Open(target.FullName, FileMode.Create, FileAccess.Write, FileShare.None);
                    }
                    catch (Exception)
                    {
                        if (retryCount < 0)
                        {
                            throw;
                        }

                        retryCount--;
                        Thread.Sleep(500);
                        goto retry;
                    }

                    using (var sw = new StreamWriter(file, Encoding.UTF8))
                    {
                        sw.WriteLine(template);
                    }
                }
            }
            catch (Exception e)
            {
                Log.LogErrorFromException(e);
                return false;
            }
            return true;
        }
    }
}
