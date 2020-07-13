using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapitaOptimisedFileReadWriteSolution
{
    internal class ReadWriteFile
    {
        /// <summary>
        /// Read text file and return dictinary object with key UDB  number
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private Dictionary<int, string> ReadTextFile(string fileName)
        {
            Dictionary<int, string> textFileData = new Dictionary<int, string>();
            const Int32 BufferSize = 4096;
            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.ASCII, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Int32 key = Convert.ToInt32(line.Split(',')[0]);
                    textFileData.Add(key, line);
                }
            }

            return textFileData;
        }

        /// <summary>
        /// deletes the given features and saves the results into a new file.
        /// </summary>
        public void ManiculateFileData()
        {
            string[] finalFileData;

            // Read Features file
            var FeaturesData = ReadTextFile("Features.txt");

            // Read FeaturesToDelete file
            var FeaturesToDelete = ReadTextFile("FeaturesToDelete.txt");

            // Deletes the given features data
            foreach (var key in FeaturesToDelete)
            {
                FeaturesData.Remove(key.Key);
            }

            // final File Data after Deleteed the given features data
            finalFileData = FeaturesData.Values.ToArray();


            // write final features data to new file
            string path = @"FinalFeatures.txt";

            if (!(File.Exists(path)))
            {
                File.CreateText(path);
            }

            // This features data is added only once to the file.
            File.WriteAllLines(path, finalFileData, Encoding.ASCII);
        }
    }
}