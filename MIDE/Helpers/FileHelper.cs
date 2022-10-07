using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Avalonia.Controls;

namespace MIDE.Helpers;

public class FileHelper
{
    public FileHelper()
    {
        NewFile();
    }

    public void NewFile()
    {
        Wikitext = "";
        DidLastLoadSucceed = true;
        Path = "New File";
    }

    public void LoadFile(String filename)
    {
        try
        {
            using FileStream file = File.OpenRead(filename);
            Path = filename;

            using ZipArchive zip = new ZipArchive(file, ZipArchiveMode.Read);
            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                if (entry.Name.StartsWith("."))
                {
                    // Ignore dot files on unix systems
                    continue;
                }
                
                Console.WriteLine(entry.Name);

                using (Stream stream = entry.Open())
                {
                    var reader = new StreamReader(stream);
                    if (entry.Name == "wikitext")
                    {
                        Wikitext = reader.ReadToEnd();
                    }
                    else if (entry.Name == "version")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                    // do whatever we want with stream
                    // ...
                }

                DidLastLoadSucceed = true;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void SaveFile(String path = null)
    {
        if (path != null)
        {
            Path = path;
        }
        
        

    }

    public List<FileDialogFilter> CreateFilters()
    {
        List<FileDialogFilter> filters = new List<FileDialogFilter>();
        FileDialogFilter filter1 = new FileDialogFilter();
        List<String> filter1Extension = new List<string>();
        filter1Extension.Add("mide");
        filter1.Extensions = filter1Extension;
        filter1.Name = "MIDE Files";
        filters.Add(filter1);
        return filters;
    }

    public String Wikitext { get; set; }
    
    public String Path { get; private set; }

    public bool DidLastLoadSucceed { get; private set; }

    public bool IsNewFile { get; private set; }
}