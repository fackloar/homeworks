using System;
using System.Collections.Generic;
using System.IO;


namespace External_Sort
{
    class ExtSort
    {
        static public void Split(string file)
        {
            int split_num = 1;
            StreamWriter sw = new StreamWriter(
              string.Format("split{0}.txt", split_num));
            using (StreamReader sr = new StreamReader(file))
            {
                int i = 0;
                while (sr.Peek() >= 0)
                {

                    // Copy a line
                    sw.WriteLine(sr.ReadLine());
                    i++;

                    if (i == 10 && sr.Peek() >= 0)
                    // If the file is big, then make a new split,
                    // however if this was the last line then don't bother

                    {
                        sw.Close();
                        split_num++;

                        sw = new StreamWriter(
                          string.Format("split{0}.txt", split_num));
                        i = 0;
                    }
                }
            }
            sw.Close();
        }

        static public void SortTheChunks(string filename)
        {
            foreach (string path in Directory.GetFiles(filename, "split*.txt"))
            {
                // Read all lines into an array
                string[] contents = File.ReadAllLines(path);
                int[] contentsInt = Array.ConvertAll(contents, int.Parse);
                // Sort the in-memory array
                Array.Sort(contentsInt);
                // Create the 'sorted' filename
                string newpath = path.Replace("split", "sorted");
                // Write it
                contents = Array.ConvertAll(contentsInt, x => x.ToString());
                File.WriteAllLines(newpath, contents);
                File.Delete(path);
                // Free the in-memory sorted array
                contents = null;
                GC.Collect();
            }
        }
        static public void MergeTheChunks(string dir, string newFileName)
        {
            string[] paths = Directory.GetFiles(dir, "sorted*.txt");
            int chunks = paths.Length; // Number of chunks
            int recordsize = 10; // estimated record size
            

            // Open the files
            StreamReader[] readers = new StreamReader[chunks];
            for (int i = 0; i < chunks; i++)
                readers[i] = new StreamReader(paths[i]);

            // Make the queues
            Queue<string>[] queues = new Queue<string>[chunks];
            for (int i = 0; i < chunks; i++)
                queues[i] = new Queue<string>(recordsize);

            // Load the queues
            for (int i = 0; i < chunks; i++)
                LoadQueue(queues[i], readers[i], recordsize);

            // Merge!
            StreamWriter sw = new StreamWriter(newFileName);
            bool done = false;
            int lowest_index, j;
            string lowest_value;
            while (!done)
            {


                // Find the chunk with the lowest value
                lowest_index = -1;
                lowest_value = "";
                for (j = 0; j < chunks; j++)
                {
                    if (queues[j] != null)
                    {
                        if (lowest_index < 0 || int.Parse(lowest_value).CompareTo(int.Parse(queues[j].Peek())) > 0)
                        {
                            
                            lowest_index = j;
                            lowest_value = queues[j].Peek();
                        }
                    }
                }

                // Was nothing found in any queue? We must be done then.
                if (lowest_index == -1) { done = true; break; }

                // Output it
                sw.WriteLine(lowest_value);

                // Remove from queue
                queues[lowest_index].Dequeue();
                // Have we emptied the queue? Top it up
                if (queues[lowest_index].Count == 0)
                {
                    LoadQueue(queues[lowest_index],
                      readers[lowest_index], chunks);
                    // Was there nothing left to read?
                    if (queues[lowest_index].Count == 0)
                    {
                        queues[lowest_index] = null;
                    }
                }
            }
            sw.Close();

            // Close and delete the files
            for (int i = 0; i < chunks; i++)
            {
                readers[i].Close();
                File.Delete(paths[i]);
            }
        }

        static void LoadQueue(Queue<string> queue, StreamReader file, int records)
        {
            for (int i = 0; i < records; i++)
            {
                if (file.Peek() < 0) break;
                queue.Enqueue(file.ReadLine());
            }
        }

    }
}
