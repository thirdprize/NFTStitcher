using System.CommandLine;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace MyApp // Note: actual namespace depends on the project name.
{

    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            //sort out the command line parameters
            var inputFolderOption = new Option<string>
                ("--inputFile", "The folder with the source image files in.");
            var outputFolderption = new Option<string>
                ("--outputFile", "The folder wo write files to.");
            var layerNamesOption = new Option<string>
                ("--layers", "A comma seperated list of \"layer names\".");

            var fileNamesOption = new Option<string>
                ("--fileName", "A prefix for the output file name.");

            var rootCommand = new RootCommand("File compositer");
            rootCommand.Add(inputFolderOption);
            rootCommand.Add(outputFolderption);
            rootCommand.Add(layerNamesOption);
            rootCommand.Add(fileNamesOption);

            //add the actual main routine
            rootCommand.SetHandler(
                (inputFileValue, outputFileValue, layersValue, fileNamesValue) =>
                {
                    ActualMain(inputFileValue, outputFileValue, layersValue, fileNamesValue);
                },
                inputFolderOption, outputFolderption, layerNamesOption, fileNamesOption);

            //pasrse them
            return await rootCommand.InvokeAsync(args);
        }

        static void ActualMain(string inputFileValue, string outputFileValue, string layersValue, string fileNameValue)
        {
            //print inputs
            Console.WriteLine(inputFileValue);
            Console.WriteLine(outputFileValue);
            Console.WriteLine(layersValue);
            Console.WriteLine(fileNameValue);

            var layerPrefixes = layersValue.Split(",");
            int index = 0;
            int nftCount = 0;
            string fileNamePrefix = (string.IsNullOrEmpty(fileNameValue) ? "NFT " :$"{fileNameValue} ");

            //get all the individul layers
            var allFiles = Directory.GetFiles($"{inputFileValue}");
            Console.WriteLine($"individual layers = {allFiles.Count()}");

            //group them into chunks
            List<string[]> fileChunks = new List<string[]>();
            foreach (var layerName in layerPrefixes)
            {
                //based on the start of the file name
                var files = allFiles.Where(s => new FileInfo(s).Name.StartsWith(layerName));
                fileChunks.Add(files.ToArray());
                Console.WriteLine($"{layerName} - {files.Count()} files");
            }

            //start by looping through the backgrounds
            foreach (var baseFile in fileChunks[0])
            {
                //zap any existing files
                var subdir = Path.Combine(outputFileValue, $"{index}");
                Directory.CreateDirectory(subdir);
                DirectoryInfo di = new DirectoryInfo(subdir);
                foreach (FileInfo file in di.EnumerateFiles())
                {
                    file.Delete();
                }

                //then go through all the layer combinations
                Console.WriteLine(baseFile);

                for (int a = 0; a < fileChunks[1].Length; a++)
                {
                    Console.WriteLine($"a - {a}");
                    for (int b = 0; b < fileChunks[2].Length; b++)
                    {
                        Console.WriteLine($"b - {b}");
                        for (int c = 0; c < fileChunks[3].Length; c++)
                        {
                            Console.WriteLine($"c - {c}");
                            for (int d = 0; d < fileChunks[4].Length; d++)
                            {
                                for (int e = 0; e < fileChunks[5].Length; e++)
                                {
                                    for (int f = 0; f < fileChunks[6].Length; f++)
                                    {
                                        for (int g = 0; g < fileChunks[7].Length; g++)
                                        {
#pragma warning disable CA1416 // Validate platform compatibility
                                            //get the background image
                                            using (Bitmap baseImage = (Bitmap)Image.FromFile(baseFile))
                                            {
                                                //and add other layers
                                                CompositeLayer(fileChunks[1][a], baseImage);
                                                CompositeLayer(fileChunks[2][b], baseImage);
                                                CompositeLayer(fileChunks[3][c], baseImage);
                                                CompositeLayer(fileChunks[4][d], baseImage);
                                                CompositeLayer(fileChunks[5][e], baseImage);
                                                CompositeLayer(fileChunks[6][f], baseImage);
                                                CompositeLayer(fileChunks[7][g], baseImage);
                                                baseImage.Save(Path.Combine(outputFileValue, $"{index}", $"ted #{nftCount++}.png"), ImageFormat.Png);

                                            }

#pragma warning restore CA1416 // Validate platform compatibility
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void CompositeLayer(string layerFileName, Bitmap baseImage)
        {
#pragma warning disable CA1416 // Validate platform compatibility

            using (Bitmap overlayImage = (Bitmap)Image.FromFile(layerFileName))
            {
                using (Graphics graphics = Graphics.FromImage(baseImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceOver;

                    graphics.DrawImage(overlayImage, 0, 0);
                }
            }
#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}