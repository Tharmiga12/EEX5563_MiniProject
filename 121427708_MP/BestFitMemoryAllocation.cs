using System;

class BestFitMemoryAllocation
{
    // Best Fit memory allocation method
    static void BestFit(int[] memoryBlocks, int[] processSizes)
    {
        // To store the block index allocated to each process
        int[] allocation = new int[processSizes.Length];
        string[] status = new string[processSizes.Length];

        // Initialize allocation and status
        Array.Fill(allocation, -1); //  "Not Allocated"
        Array.Fill(status, "Fail"); // Default status is "Fail"

        // Pick each process and find the best fit block
        for (int i = 0; i < processSizes.Length; i++)
        {
            // Index of the best fit block
            int bestBlockIndex = -1; 
            for (int j = 0; j < memoryBlocks.Length; j++)
            {
                // Check if the block can accommodate the process
                if (memoryBlocks[j] >= processSizes[i])
                {
                    // Choose the block with the smallest available size that fits
                    if (bestBlockIndex == -1 || memoryBlocks[j] < memoryBlocks[bestBlockIndex])
                    {
                        bestBlockIndex = j;
                    }
                }
            }

            // If a suitable block is found, allocate it to the process
            if (bestBlockIndex != -1)
            {
                allocation[i] = bestBlockIndex;
                memoryBlocks[bestBlockIndex] -= processSizes[i]; // Reduce block size
                status[i] = "Success"; // Mark process as successfully allocated
            }
        }

        // Display results
        Console.WriteLine("\nProcess No.\tProcess Size\tBlock No.\tRemaining Block Size\tStatus");

        for (int i = 0; i < processSizes.Length; i++)
        {
            if (allocation[i] != -1)
            {
                Console.WriteLine($"{i + 1}\t\t{processSizes[i]}\t\t{allocation[i] + 1}\t\t{memoryBlocks[allocation[i]]}\t\t{status[i]}");
            }
            else
            {
                Console.WriteLine($"{i + 1}\t\t{processSizes[i]}\t\tNot Allocated\t-\t\t{status[i]}");
            }
        }




    }

    static void Main(string[] args)
    {
        // Define test cases with different memory block and process sizes
        var testCases = new[]
        {
            new {
                mBlocks = new int[] { 100, 500, 200, 300, 600 },
                pSizes = new int[] { 212, 417, 112, 626 }
            },
            new {
                mBlocks = new int[] { 150, 600, 250, 350 },
                pSizes = new int[] { 130, 250, 150, 400 }
            },
            new {
                mBlocks = new int[] { 400, 800, 200, 300 },
                pSizes = new int[] { 350, 150, 100, 250 }
            },
            new {
                mBlocks = new int[] { 300, 200, 100, 50 },
                pSizes = new int[] { 400, 50, 150, 70 }
            }
        };

        // Run each test case
        for (int idx = 0; idx < testCases.Length; idx++)
        {
            Console.WriteLine($"\n=== Running Test Case {idx + 1} ===");
            var testCase = testCases[idx];
            BestFit(testCase.mBlocks, testCase.pSizes);
        }
    }
}
